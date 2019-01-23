﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LayerTest.UI.Controllers
{
    public class HomeController : Controller
    {
        DbData data = new DbData();
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View(data.test());
        }
    }
}
