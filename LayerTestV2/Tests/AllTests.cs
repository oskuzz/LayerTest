using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Tests;

namespace Tests
{
    public class AllTests
    {
        CustomerTests CT = new CustomerTests();

        [Fact]
        public async void RunAll()
        {
            await CT.removeLatestTest();
            await CT.getAllTest();
            await CT.getSingleTest();
            await CT.addCustomerTest();
            await CT.removeCustomerTest();
        }
    }
}
