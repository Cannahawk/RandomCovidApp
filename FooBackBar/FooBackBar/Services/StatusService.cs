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
    public interface IStatusService: IBaseService<Status>
    {
      Status GetConfirmed();
      Status GetDeath();
      Status GetRecovered();
    }

    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(Context context): base(context) { }

        public Status GetConfirmed()
        {
          return _context.Set<Status>().FirstOrDefault(x => x.IsConfirmed);
        }

        public Status GetDeath()
        {
          return _context.Set<Status>().FirstOrDefault(x => x.IsDeath);
        }

        public Status GetRecovered()
        {
          return _context.Set<Status>().FirstOrDefault(x => x.IsRecovered);
        }
    }
}
