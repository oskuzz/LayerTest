using Business.Logic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;
using Storage.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task getAllTest()
        {
            var controller = new APIController(new CustomerActions());
            var result = await controller.Print();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customers.Count().Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public async Task getSingle()
        {
            string name = "Test Tester";
            var controller = new APIController(new CustomerActions());
            var result = await controller.PrintOne(name);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customer.Single().Displayname.Should().Be(name);
        }

        [Fact]
        public async Task addCustomer()
        {
            var controller = new APIController(new CustomerActions());
            var newCustomer = new Customer
            {
                FirstName = "Test3",
                LastName = "Tester3",
                Password = "Test3",
            };

            var result = await controller.addCustomer(newCustomer);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<Customer>().Subject;

            customer.Displayname.Should().Be("Test3 Tester3");

        }

        [Fact]
        public async Task removeCustomer()
        {
            string name = "Test3 Tester3";
            var controller = new APIController(new CustomerActions());
            var result = await controller.removeCustomer(name);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<bool>().Subject;

            customer.Should().Be(true); 
        }
    }
}
