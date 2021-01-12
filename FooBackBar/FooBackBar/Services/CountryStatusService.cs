
using FooBackBar.DatabaseContext;
using FooBackBar.Models;
using FooBackBar.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBackBar.Services
{
    public interface ICountryStatusService: IBaseService<CountryStatus>
    {

    }
    public class CountryStatusService: BaseService<CountryStatus>, ICountryStatusService
    {
        public CountryStatusService(Context databaseContext) : base(databaseContext) { }
    }
}
