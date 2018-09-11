using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalkintheWoods.Models;
using WalkintheWoods.Factories;
using System.Linq;

namespace WalkintheWoods
{
    public class HomeController : Controller
    {
        private readonly Trailsfactory trailfactory;
        public HomeController(){
            trailfactory = new Trailsfactory();
        }
        [HttpGet("")]
        public IActionResult Index(){
            ViewBag.Table = trailfactory.GetTrails();
            
            
            return View();
        }
        [HttpGet("Addtrail")]
        public IActionResult AddTrail()
        {
            return View("AddTrail");
        }
        [HttpPost("Create")]
        public IActionResult Create(Trails trail)
        {
            if(ModelState.IsValid){
                trailfactory.Addnewtrail(trail);
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddTrail");
            }
        
        }
        [HttpGet("trail/{id}")]
        public IActionResult viewTrail(Trails trail)
        {
            ViewBag.trail = trailfactory.GetoneTrails();
            return View("Viewtrail");
        }
    }
}