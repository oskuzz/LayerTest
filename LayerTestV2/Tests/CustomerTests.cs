using Business.Logic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;
using Storage.Database.Table;
using Business.Logic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CustomerTests
    {
        //[Fact]
        public async void AllTests()
        {
            await removeLatestTest();
            await getAllTest();
            await getSingleTest();
            await addCustomerTest();
            await removeCustomerTest();
        }

        public async Task getAllTest()
        {
            var controller = new APIController(new CustomerActions());
            var result = await controller.Print();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customers.Count().Should().BeGreaterOrEqualTo(2);
        }

        public async Task getSingleTest()
        {
            string name = "Test Tester";
            var controller = new APIController(new CustomerActions());
            var result = await controller.PrintOne(name);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customer.Single().Displayname.Should().Be(name);
        }

        public async Task addCustomerTest()
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

        public async Task removeCustomerTest()
        {
            string name = "Test3 Tester3";
            var controller = new APIController(new CustomerActions());
            var result = await controller.removeCustomer(name);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<bool>().Subject;

            customer.Should().Be(true); 
        }

        WriteLog writeLog = new WriteLog();

        [Fact]
        public async Task removeLatestTest()
        {
            var controller = new APIController(new CustomerActions());
            var dn = await controller.getLatest();
            
            foreach(var i in dn as Customer)
            {

            }
            var result = await controller.removeCustomer(dn);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<bool>().Subject;

            writeLog.writeLog(dn);

            customer.Should().Be(true);
        }
    }
}
