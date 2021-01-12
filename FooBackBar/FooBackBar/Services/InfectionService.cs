using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Serialization.Json;
using FooBackBar.DatabaseContext;
using FooBackBar.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Storage;

namespace FooBackBar.Services.BaseService
{
    public interface IInfectionService
    {
        public void Infect();
    }

    public class InfectionService: IInfectionService
    {
        private readonly ICountryService _countryService;
        private readonly IStatusService _statusService;
        private readonly IConfiguration _configuration;
        private readonly ICountryStatusService _countryStatusService;
        private readonly Context _context;

        public InfectionService(ICountryService countryService,
            IStatusService statusService,
            IConfiguration configuration,
            ICountryStatusService countryStatusService,
            Context context)
        {
            _countryService = countryService;
            _statusService = statusService;    
            _configuration = configuration;
            _countryStatusService = countryStatusService;
            _context = context;
        }

        public void Infect()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            JsonStatus confirmed = GetJsonStatus(_configuration["CovidDataApi:Confirmed"]);
            JsonStatus death = GetJsonStatus(_configuration["CovidDataApi:Death"]);
            JsonStatus recovered = GetJsonStatus(_configuration["CovidDataApi:Recovered"]);

            var confirmedStatus = _statusService.GetConfirmed();
            confirmedStatus.Total = confirmed.Total;

            var deathStatus =_statusService.GetDeath();
            deathStatus.Total = death.Total;

            var recoveredStatus = _statusService.GetRecovered();
            recoveredStatus.Total = recovered.Total;

            var confirmedCountries = confirmed.ToCountries();
            var deathCountries = death.ToCountries();
            var recoveredCountries = recovered.ToCountries();

            var listForUpdate = new List<Status>();
            listForUpdate.Add(confirmedStatus);
            listForUpdate.Add(deathStatus);
            listForUpdate.Add(recoveredStatus);
            _statusService.UpdateRange(listForUpdate);

            List<Country> combinedCountries = new List<Country>();
            List<CountryStatus> countryStati = new List<CountryStatus>();

            foreach (var confirmedCountry in confirmedCountries)
            {
              var deathCountry = deathCountries.FirstOrDefault(x => x.Code == confirmedCountry.Code);
              var recoveredCountry = recoveredCountries.FirstOrDefault(x => x.Code == confirmedCountry.Code);

              confirmedCountry.SetStatus(confirmedStatus);
              deathCountry.SetStatus(deathStatus);
              recoveredCountry.SetStatus(recoveredStatus);

              Guid countryGuid = Guid.NewGuid();

                countryStati.Add(new CountryStatus()
                {
                    GuidCountry = countryGuid,
                    GuidStatus = deathStatus.Guid,
                    Total = deathCountry.History.Sum(x => x.Amount)
                });

              countryStati.Add(new CountryStatus()
              {
                  GuidCountry = countryGuid,
                  GuidStatus = recoveredStatus.Guid,
                  Total = recoveredCountry.History.Sum(x => x.Amount)
              });

              countryStati.Add(new CountryStatus()
              {
                  GuidCountry = countryGuid,
                  GuidStatus = confirmedStatus.Guid,
                  Total = confirmedCountry.History.Sum(x => x.Amount)
              });

              var   combinedCountry = confirmedCountry;
              combinedCountry.History.AddRange(deathCountry.History);
              combinedCountry.History.AddRange(recoveredCountry.History);
              combinedCountry.Guid = countryGuid;

              combinedCountries.Add(combinedCountry);
            }

            _countryService.AddRange(combinedCountries);
            _countryStatusService.AddRange(countryStati);
        }

        private JsonStatus GetJsonStatus(string uri)
        {
          var client = new RestClient(uri);
          var request = new RestRequest(Method.GET);
          
          var response = client.Execute(request);

          return JsonConvert.DeserializeObject<JsonStatus>(response.Content);
        }
    }
}
