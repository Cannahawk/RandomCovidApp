using FooBackBar.Controllers.Base;
using FooBackBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBackBar.Controllers.CountryController
{
    public class CountryRequestModel: BaseRequestModel<Country>
    {
        public Country ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
