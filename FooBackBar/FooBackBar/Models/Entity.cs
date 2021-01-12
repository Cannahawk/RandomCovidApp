using FooBackBar.DatabaseContext.Attributes;
using System;

namespace FooBackBar.Models
{
    public class Entity
    {
        [PrimaryKey][Identity][NotNull]
        public Guid Guid { get; set; }
    }
}
