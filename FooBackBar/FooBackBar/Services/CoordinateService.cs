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
    public interface ICoordinatesService: IBaseService<Coordinates>
    {

    }

    public class CoordinatesService : BaseService<Coordinates>, ICoordinatesService
    {
        public CoordinatesService(Context context): base(context) { }
    }
}
