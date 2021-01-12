using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using FooBackBar.Controllers.Base;
using FooBackBar.Controllers.CaseHistoryController;
using FooBackBar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FooBackBar.Controllers.CountryController
{
    public class CountryDto : BaseDto<Country, CountryDto>
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Total { get; set; }
        public int Death { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        
        public List<CaseHistoryDto> History { get; set; }

        public CountryDto FromEntity(Country entity)
        {
            Guid = entity.Guid;
            Name = entity.Name;
            Code = entity.Code;
            Total = entity.CountryStatus.First(x => x.Status.IsConfirmed).Total;
            Death = entity.CountryStatus.First(x => x.Status.IsDeath).Total;
            Recovered = entity.CountryStatus.First(x => x.Status.IsRecovered).Total;
            Active = Total - Death - Recovered;
            
            return this;
        }

        //for performance reasons put extra
        public CountryDto FromEntityWithHistory(Country entity)
        {
            FromEntity(entity);

            History = entity.History
                .Select(x => new CaseHistoryDto().FromEntity(x))
                .OrderBy(x => x.Date)
                .ToList();

            return this;
        }
    }
}
