using System;
using System.Collections.Generic;
using System.Linq;
using FooBackBar.Services.BaseService;
using Microsoft.AspNetCore.Mvc;

namespace FooBackBar.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<Entity, Dto, RequestModel> : ControllerBase 
        where Entity : Models.Entity
        where Dto: BaseDto<Entity, Dto>, new()
        where RequestModel: BaseRequestModel<Entity>
    {
        protected readonly IBaseService<Entity> _service;

        public BaseController(IBaseService<Entity> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public List<Dto> GetAll()
        {
            return _service.GetAll()
                .Select(x => new Dto().FromEntity(x))
                .ToList();
        }

        [HttpGet("{id}")]
        public Dto GetSingle(Guid guid)
        {
            return new Dto().FromEntity(
                _service.GetSingle(guid)
            );
        }
    }
}
