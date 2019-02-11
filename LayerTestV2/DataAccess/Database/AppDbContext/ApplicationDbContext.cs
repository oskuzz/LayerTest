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
        public string ConnectionString = @"Server = LAPTOP-JHHCFN8D; Database = LayerDB2; Trusted_Connection = true";

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

            modelBuilder.Entity<Customer>()
                .HasData(new Customer { CustomerID = 1, FirstName = "Test", LastName = "Tester", Displayname = "Test Tester", ImgFilePath = "", Password = "Test" });

        }
    }
}
