using Storage.Database.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage.Log;

namespace Storage.Database.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public string ConnectionString = @"Server = DESKTOP-CBALK4D\SQLEXPRESS; Database = LayerDB2; Trusted_Connection = true";

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, a => a.MigrationsHistoryTable("MigrationHistory", "Internal"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerModel());
        }
    }
}
