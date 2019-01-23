﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenceLayer.DBContext;

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBLayer.Database.Tables.Books", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName");

                    b.Property<int>("CreatorID");

                    b.Property<string>("Description");

                    b.Property<string>("Price");

                    b.HasKey("BookID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Books","Service");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            BookName = "Venäjä",
                            CreatorID = 1,
                            Description = "Kertoo venäjästä",
                            Price = "3000 rub"
                        });
                });

            modelBuilder.Entity("DBLayer.Database.Tables.Creators", b =>
                {
                    b.Property<int>("CreatorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorName");

                    b.HasKey("CreatorID");

                    b.ToTable("Creators","Service");

                    b.HasData(
                        new
                        {
                            CreatorID = 1,
                            CreatorName = "Putin"
                        });
                });

            modelBuilder.Entity("DBLayer.Database.Tables.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorID");

                    b.Property<string>("Description");

                    b.Property<string>("MovieName");

                    b.Property<string>("Price");

                    b.HasKey("MovieID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Movies","Service");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CreatorID = 1,
                            Description = "Suosittelen",
                            MovieName = "Venäjä the movie",
                            Price = "4000 rub"
                        });
                });

            modelBuilder.Entity("DBLayer.Database.Tables.Books", b =>
                {
                    b.HasOne("DBLayer.Database.Tables.Creators", "creator")
                        .WithMany()
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DBLayer.Database.Tables.Movies", b =>
                {
                    b.HasOne("DBLayer.Database.Tables.Creators", "creator")
                        .WithMany()
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
