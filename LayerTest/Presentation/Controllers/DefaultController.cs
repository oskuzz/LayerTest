using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
    public class DefaultController : Controller
    {

        public string asd = "Asd";

        public IActionResult Index()
        {
            if (Request.Method == "POST")
            {
                var Uname = Request.Form["UserName"];
            }
                     
            return View();
        }
    }
}