using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Logic;
using DataAccess.Database.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        CustomerActions CA = new CustomerActions();

        [HttpGet("[action]")]
        public List<Customer> index()
        {
            return CA.getAllCustomers();
        }
    }
}