using FooBackBar.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FooBackBar.Test.DatabaseContext
{
    public class TestContext: FooBackBar.DatabaseContext.Context
    {
        public TestContext(DbContextOptions<Context> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Database/test.db");
            SQLitePCL.Batteries.Init();
        }

        public void Seed()
        {
          Database.EnsureDeleted();
          Database.EnsureCreated();
        }
    }
}