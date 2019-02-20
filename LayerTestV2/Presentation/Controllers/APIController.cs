using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Logic;
using Storage.Database.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private ICustomerService _customerService;
        private userGenerator generator = new userGenerator();

        public APIController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        CustomerActions CA = new CustomerActions();

        [HttpGet("[action]")]
        public async Task<IActionResult> Print()
        {
            var getCustomers = _customerService.getAllCustomers();

            return Ok(getCustomers);
        }

        [HttpGet("[action]/{dn}")]
        public async Task<IActionResult> PrintOne(string dn)
        {
            var getCustomer = _customerService.GetCustomer(dn);

            return Ok(getCustomer);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> addCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Customer addedCustomer = _customerService.addCustomer(customer.FirstName, customer.LastName, customer.Password);

            return Ok(addedCustomer);
        }

        [HttpGet("[action]/{dn}")]
        public async Task<IActionResult> removeCustomer(string dn)
        {
            var customer = _customerService.removeCustomer(dn);
            return Ok(customer);
        }

        [HttpGet("[action]")]
        public string getLatestDn()
        {
            return _customerService.getLatestDisplayName();
        }

        [HttpGet("[action]/{value}")]
        public void generateUsers(int value)
        {
            generator.generateUsers(value);
        }
    }
}