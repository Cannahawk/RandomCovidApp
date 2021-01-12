using FooBackBar.Controllers.Base;
using FooBackBar.Models;

namespace FooBackBar.Controllers.StatusController
{
    public class StatusDto: BaseDto<Status, StatusDto> 
    {
        public bool IsConfirmed {get; set;}
        public bool IsDeath {get; set;}
        public bool IsRecovered {get; set;}
        public int Total {get; set;}

        public StatusDto FromEntity(Status status)
        {
          IsConfirmed = status.IsConfirmed;
          IsDeath = status.IsDeath;
          IsRecovered = status.IsRecovered;
          Total = status.Total;

          return this;
        }
    }
}