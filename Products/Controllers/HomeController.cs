using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            return View("Categories");
        }
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct()
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Products");
            }
            return View("Index");
        }
        [HttpGet("Products")]
        public IActionResult Products()
        {
            return View("Products");
        }
    }
}
