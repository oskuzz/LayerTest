﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storage.Database.AppDbContext;

namespace DataAccess.Migrations
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

            modelBuilder.Entity("Storage.Database.Table.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Displayname");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImgFilePath");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer","Service");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Displayname = "Test Tester",
                            FirstName = "Test",
                            ImgFilePath = "",
                            LastName = "Tester",
                            Password = "1218810217245841120812815456141201909791"
                        },
                        new
                        {
                            CustomerID = 2,
                            Displayname = "Test2 Tester2",
                            FirstName = "Test2",
                            ImgFilePath = "",
                            LastName = "Tester2",
                            Password = "1968485458221393622451008116401355443"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
