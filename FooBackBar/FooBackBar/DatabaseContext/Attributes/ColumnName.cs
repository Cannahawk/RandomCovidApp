using System;

namespace FooBackBar.DatabaseContext.Attributes
{
    public class ColumnName: Attribute
    {
        public string Name { get; }

        public ColumnName(string name)
        {
            Name = name;
        }
    }
}
