using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Logic;
using System.Web;

namespace Presentation.Controllers
{
    public class UIController : Controller
    {
        CustomerActions CA = new CustomerActions();

        public IActionResult Index()
        {

            var Username = Request.Query["Username"];
            var Password = Request.Query["Password"];

            /*if (asd.Equals("POST")) {

                
            }*/
            CA.addCustomer(Username, Password);
            return View();
        }
    }
}