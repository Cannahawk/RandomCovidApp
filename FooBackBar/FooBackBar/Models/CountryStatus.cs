using FooBackBar.DatabaseContext.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FooBackBar.Models
{
    public class CountryStatus: Entity
    {
        [NotNull]
        public Guid GuidCountry { get; set; }
        [NotNull]
        public Guid GuidStatus { get; set; }
        [NotNull]
        public int Total { get; set; }
        [ForeignKey("GuidCountry")]
        public virtual Country Country { get; set; }
        [ForeignKey("GuidStatus")]
        public virtual Status Status { get; set; }
    }
}
