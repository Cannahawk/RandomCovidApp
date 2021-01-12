using FooBackBar.DatabaseContext.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FooBackBar.Models
{
    public class Coordinates : Entity
    {
        [NotNull]
        public Guid GuidCountry { get; set; }
        [JsonProperty("latitude")][NotNull]
        public decimal Latitude { get; set; }
        [JsonProperty("longitude")][NotNull]
        public decimal Longitude { get; set; }

        
        [ForeignKey("GuidCountry")]
        public virtual Country Country { get; set; }
    }
}