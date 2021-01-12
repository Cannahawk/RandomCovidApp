using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FooBackBar.Models
{
    public class JsonStatus
    {
        [JsonProperty("latest")]
        public int Total { get; set; }
        [JsonProperty("locations")]
        public List<Country> Countries { get; set; }

        public IEnumerable<Country> ToCountries()
        {
            return Countries.GroupBy(x => x.Code)
                .Select(x => new Country()
                {
                    Name = x.First().Name,
                    Code = x.Key,
                    Coordinates = x.First().Coordinates,
                    History = x.SelectMany(x => x.History).ToList()
                });
        }
    }
}