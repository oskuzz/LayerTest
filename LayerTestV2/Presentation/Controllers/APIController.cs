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

        public APIController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        CustomerActions CA = new CustomerActions();

        [HttpGet("[action]")]
        public async Task<IActionResult> index()
        {
            var getCustomers = _customerService.getAllCustomers();

            return Ok(getCustomers);
        }

        /*[HttpGet("[action]")]
        public List<Customer> index()
        {
            return CA.getAllCustomers();
        }*/
    }
}