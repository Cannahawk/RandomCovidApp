using FooBackBar.DatabaseContext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FooBackBar.Models
{
    [Seeded]
    public class Status : Entity, IEntityWithSeed
    {
        public Status()
        {
            CaseHistories = new List<CaseHistory>();
        }

        [NotNull]
        public int Total { get; set; }
        [NotNull]
        public bool IsConfirmed { get; set; }
        [NotNull]
        public bool IsDeath { get; set; }
        [NotNull]
        public bool IsRecovered { get; set; }

        public virtual ICollection<CaseHistory> CaseHistories {get; set;}
        public virtual List<CountryStatus> CountryStatus { get; set; }


        public Entity[] GetSeeds()
        {
          return new Status[] {
            new Status(){IsConfirmed = true, Guid = Guid.NewGuid()},
            new Status(){IsDeath = true, Guid = Guid.NewGuid()},
            new Status(){IsRecovered = true, Guid = Guid.NewGuid()}
          };
        }
    }
}