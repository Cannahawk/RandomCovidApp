using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBackBar.Services.BaseService
{
    public class IdResult<T>
    {
        public T Entity { get; }
        public bool Success { get; }

        public IdResult(T entity, bool success)
        {
            Entity = entity;
            Success = success;
        }
    }
}
