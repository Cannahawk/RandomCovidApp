using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBackBar.DatabaseContext
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=covid.db");
            SQLitePCL.Batteries.Init();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var databaseModelTypes = GetDbSetTypes();
            modelBuilder.BuildEntities(databaseModelTypes);
        }

        private IEnumerable<Type> GetDbSetTypes()
        {
            return GetType()
                .GetProperties()
                .Where(x => x.PropertyType.IsGenericType &&
                    x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(x => x.PropertyType.GenericTypeArguments[0]);
        }
    }
}
