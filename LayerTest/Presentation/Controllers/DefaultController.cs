using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Business.Logic;
using Persistence.DbContext;
using Database.Database.Tables;

namespace Presentation.Controllers
{
    public class DefaultController : Controller
    {

        private UserActions userActions = new UserActions();
        private ApplicationDbContext context = new ApplicationDbContext();

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

        public IActionResult Register([Bind("UserName, Password, Role")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customer.Add(customer); 
            }
            return View();
        }


    }
}