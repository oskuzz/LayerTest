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

            var result = await controller.index();

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            var customers = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customers.Count().Should().BeGreaterOrEqualTo(2);
        }

        /*[Fact]
        public async Task getSingle()
        {
            var controller = new APIController(new CustomerActions());
        }*/

    }
}
