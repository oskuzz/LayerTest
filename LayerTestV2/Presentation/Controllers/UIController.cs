using Microsoft.AspNetCore.Mvc;
using Business.Logic;

namespace Presentation.Controllers
{
    public class UIController : Controller
    {
        CustomerActions CA = new CustomerActions();

        public IActionResult Index()
        {
            if (Request.Method.Equals("POST"))
            {
                var Username = Request.Form["Username"];
                var Password = Request.Form["Password"];
                CA.addCustomer(Username, Password);
            }
            return View();
        }

        public IActionResult Print()
        {
            if (Request.Method.Equals("POST"))
            {
                return View(CA.GetCustomer(Request.Form["Username"]));
            }
            else
            {
                return View(CA.getAllCustomers());
            }
        }
    }
}