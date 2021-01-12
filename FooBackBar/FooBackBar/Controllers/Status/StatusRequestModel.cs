using System;
using FooBackBar.Controllers.Base;
using FooBackBar.Models;

namespace FooBackBar.Controllers.StatusController
{
    public class StatusRequestModel: BaseRequestModel<Status>
    {
        public Status ToEntity()
        {
          throw new NotImplementedException();
        }
    }
}