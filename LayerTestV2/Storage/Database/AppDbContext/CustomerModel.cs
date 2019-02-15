using Storage.Database.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage.Security;

namespace Storage.Database.AppDbContext
{
    public class CustomerModel : IEntityTypeConfiguration<Customer>
    {
        UserSecurity us = new UserSecurity();

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", schema: "Service");

            builder.HasKey(c => c.CustomerID);

            builder.HasData(new Customer { CustomerID = 1, FirstName = "Test", LastName = "Tester", Displayname = "Test Tester", ImgFilePath = "", Password = us.MD5Hash("Test") });
            builder.HasData(new Customer { CustomerID = 2, FirstName = "Test2", LastName = "Tester2", Displayname = "Test2 Tester2", ImgFilePath = "", Password = us.MD5Hash("Test2") });
            
        }
    }
}
