using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FooBackBar.Models
{
    public class CaseHistory : Entity
    {
        [NotNull]
        public Guid GuidCountry { get; set; }
        [NotNull] 
        public Guid GuidStatus { get; set; }

        [NotNull] 
        public DateTime Date { get; set; }
        [NotNull] 
        public int Amount { get; set; }

        [ForeignKey("GuidCountry")][NotNull]
        public virtual Country Country { get; set; }
        [ForeignKey("GuidStatus")][NotNull]
        public virtual Status Status { get; set; }
    }
}