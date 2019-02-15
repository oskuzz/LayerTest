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
                var firstName = Request.Form["firstName"];
                var lastName = Request.Form["lastName"];
                var Password = Request.Form["Password"];
                CA.addCustomer(firstName, lastName, Password);
            }
            return View();
        }

        public IActionResult Print()
        {
            if (Request.Method.Equals("POST"))
            {
                return View(CA.GetCustomer(Request.Form["displayName"]));
            }
            else
            {
                return View(CA.getAllCustomers());
            }
        }

        public IActionResult Login()
        {
            if (Request.Method.Equals("POST"))
            {
                if(CA.login(Request.Form["displayName"], Request.Form["password"]))
                {
                    return RedirectToAction("Print", "UI");
                } else
                {
                    return View();
                }
            } else
            {
                return View();
            }
        }
    }
}