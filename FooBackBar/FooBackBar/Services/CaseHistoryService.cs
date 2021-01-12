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
    public interface ICaseHistoryService : IBaseService<CaseHistory>
    {

    }

    public class CaseHistoryService : BaseService<CaseHistory>, ICaseHistoryService
    {
        public CaseHistoryService(Context context): base(context) { }
    }
}
