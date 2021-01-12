using System;
using FooBackBar.Controllers.Base;
using FooBackBar.Models;
using FooBackBar.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FooBackBar.Controllers.CountryController
{
    [Route("api/Country")]
    public class CountryController: BaseController<Country, CountryDto, CountryRequestModel>
    {
        public CountryController(ICountryService countryService): base(countryService) { }

        [HttpGet("complete/{id}")]
        public CountryDto GetCountryComplete(Guid id)
        {
            return new CountryDto().FromEntityWithHistory(_service.GetSingle(id));
        }

        [HttpGet("complete/all")]
        public List<CountryDto> GetCountryListComplete(Guid id)
        {
          return _service.GetAll()
            .Select(x => new CountryDto().FromEntityWithHistory(x))
            .ToList();
        }
    }
}
