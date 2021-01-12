using FooBackBar.Controllers.Base;
using FooBackBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBackBar.Controllers.CaseHistoryController
{
    public class CaseHistoryDto: BaseDto<CaseHistory, CaseHistoryDto>
    {
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public bool IsTotal { get; set; }
        public bool IsDeath { get; set; }
        public bool IsRecovered { get; set; }

        public CaseHistoryDto FromEntity(CaseHistory entity)
        {
            Country = entity.Country.Name;
            Date = entity.Date;
            Amount = entity.Amount;
            IsDeath = entity.Status.IsDeath; ;
            IsRecovered = entity.Status.IsRecovered;
            IsTotal = entity.Status.IsConfirmed;

            return this;
        }
    }
}
