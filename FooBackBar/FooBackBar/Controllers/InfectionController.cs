using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooBackBar.Services.BaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FooBackBar.Controllers
{
    [Route("api/infection")]
    [ApiController]
    public class InfectionController : ControllerBase
    {
        private readonly IInfectionService _infectionService;

        public InfectionController(IInfectionService infectionService)
        {
            _infectionService = infectionService;
        }

        [Route("infect")]
        [HttpGet]
        public string Infect()
        {
            _infectionService.Infect();
            return "success";
        }
    }
}
