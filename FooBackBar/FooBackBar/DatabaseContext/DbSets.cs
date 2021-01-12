using Microsoft.EntityFrameworkCore;
using FooBackBar.Models;
using System;

namespace FooBackBar.DatabaseContext
{
    public partial class Context
    {
       public DbSet<CaseHistory> CaseHistories { get; set; }
       public DbSet<Country> Countries { get; set; }
       public DbSet<Status> Status { get; set; }
       public DbSet<Coordinates> Coordinates { get; set; }
       public DbSet<CountryStatus> CountryStatus { get; set; }
    }
}
