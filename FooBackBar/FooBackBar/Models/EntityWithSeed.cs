using FooBackBar.DatabaseContext.Attributes;
using System.Collections.Generic;

namespace FooBackBar.Models
{
    [Seeded]
    public interface IEntityWithSeed
    {
        Entity[] GetSeeds();
    }
}