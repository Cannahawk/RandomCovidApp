using FooBackBar.Controllers.Base;
using FooBackBar.Models;
using FooBackBar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace FooBackBar.Controllers.StatusController
{
    [Route("api/Status")]
    public class StatusController: BaseController<Status, StatusDto, StatusRequestModel>
    {
        public StatusController(IStatusService statusService): base(statusService) { }
    }
}