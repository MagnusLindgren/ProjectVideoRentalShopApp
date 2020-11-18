using System;
using Microsoft.EntityFrameworkCore;

namespace DataBaseConnection
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server.\SQLExpress;" +
                @"database-SaleDatabase;" +
                @"trusted_connection=true" +
                @"MultipleActiveResultSets=true"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
