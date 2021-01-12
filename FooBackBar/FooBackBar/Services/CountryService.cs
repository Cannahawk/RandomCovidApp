using FooBackBar.DatabaseContext;
using FooBackBar.Models;
using FooBackBar.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FooBackBar.Services
{
    public interface ICountryService: IBaseService<Country>
    {

    }

    public class CountryService: BaseService<Country>, ICountryService
    {
        public CountryService(Context context): base(context) { }
    }
}
