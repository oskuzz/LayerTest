using Database.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersistenceLayer.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public string ConnectionString = @"Server = ODE10-2015; Database = LayerDB; Trusted_Connection = true";

        public DbSet<Books> Books { get; set; }
        public DbSet<Creators> Creators { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, a => a.MigrationsHistoryTable("MigrationHistory", "Internal"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>()
                .ToTable("Books", schema: "Service");

            modelBuilder.Entity<Creators>()
                .ToTable("Creators", schema: "Service");

            modelBuilder.Entity<Movies>()
                .ToTable("Movies", schema: "Service");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer", schema: "Service");

            modelBuilder.Entity<Books>()
                .HasKey(b => b.BookID);

            modelBuilder.Entity<Creators>()
                .HasKey(c => c.CreatorID);

            modelBuilder.Entity<Movies>()
                .HasKey(m => m.MovieID);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Creators>().HasData(
                new Creators { CreatorID = 1, CreatorName = "Putin" });

            modelBuilder.Entity<Books>().HasData(
                new Books { BookID = 1, BookName = "Venäjä", Description = "Kertoo venäjästä", Price = "3000 rub", CreatorID = 1 });

            modelBuilder.Entity<Books>().HasData(
                new Books { BookID = 2, BookName = "Russia", Description = "Mother Russia", Price = "6000 rub", CreatorID = 1 });

            modelBuilder.Entity<Movies>().HasData(
                new Movies { MovieID = 1, MovieName = "Venäjä the movie", Description = "Suosittelen", Price = "4000 rub", CreatorID = 1 });

            modelBuilder.Entity<Movies>().HasData(
                new Movies { MovieID = 2, MovieName = "The Indian TechSubbord", Description = "Hyi", Price = "1000 €", CreatorID = 1 });
        }

    }
}
