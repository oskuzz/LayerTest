using DataAccess.Database.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Database.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public string ConnectionString = @"Server = LAPTOP-19441AC2; Database = LayerDB2; Trusted_Connection = true";

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, a => a.MigrationsHistoryTable("MigrationHistory", "Internal"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer", schema: "Service");

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);
        }
    }
}
