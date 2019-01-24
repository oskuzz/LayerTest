using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Data;
using Microsoft.AspNetCore.Routing;

namespace LayerTest.UI.Controllers
{
    public class DefaultController : Controller
    {
        DbData data = new DbData();

        public IActionResult Index()
        {
            return View();
        }
    }
}