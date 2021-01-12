using FooBackBar.Models;
using System;
using System.Collections.Generic;

namespace FooBackBar.Test.DatabaseContext.TestSeeds
{
    public static class CountrySeeds
    {
        public static List<Country> GetEntities()
        {
          List<Country> Seeds = new List<Country>();

          var lotrId = Guid.NewGuid();

          Seeds.Add(new Country {
            Guid = lotrId,
            Name = "Middlearth",
            Code = "LOTR",
            Total = 0,
            Coordinates = new Coordinates() {
              GuidCountry = lotrId,
              Latitude = 10.10m,
              Longitude = 20.20m,
            }
          });

          return Seeds;
        }
    }
}