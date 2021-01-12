using FooBackBar.DatabaseContext.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FooBackBar.Models
{
    public class Country : Entity
    {
        public Country()
        {
            History = new List<CaseHistory>();
        }

        [JsonProperty("country")][NotNull]
        public string Name { get; set; }
        [JsonProperty("country_code")][NotNull]
        public string Code { get; set; }

        [JsonProperty("latest")][NotNull][NotMapped]
        public int Total { get; set; }

        private IDictionary<string, int> _historyDictionary;
        [JsonProperty("history")][NotMapped]
        public IDictionary<string, int> HistoryDictionary
        {
            get
            {
                return _historyDictionary;
            }
            set
            {
                _historyDictionary = value;
                MapHistory();
            }
        }
        public virtual List<CaseHistory> History { get; set; }
        [JsonProperty("coordinates")]
        public virtual Coordinates Coordinates { get; set; }
        public virtual List<CountryStatus> CountryStatus { get; set; }

        private void MapHistory()
        {
            History = HistoryDictionary.Select(x => new CaseHistory()
            {
                Amount = x.Value,
                Date = DateTime.ParseExact(x.Key, "M/d/yy", CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void SetStatus(Status status)
        {
          foreach(var history in History)
          {
            history.GuidStatus = status.Guid;
          }
        }
    }
}