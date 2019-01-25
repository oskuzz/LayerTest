using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Business.Logic;

namespace Presentation.Controllers
{
    public class DefaultController : Controller
    {

        private UserActions userActions = new UserActions();

        public string asd = "Asd";

        public IActionResult Index()
        {
            if (Request.Method == "POST")
            {
                var Uname = Request.Form["UserName"];
                var Password = Request.Form["Password"];

                if(!Uname.Equals("") && !Password.Equals(""))
                {
                    ViewBag.User = userActions.getUser(Uname, Password);
                } 
            }       
            return View();
        }


    }
}