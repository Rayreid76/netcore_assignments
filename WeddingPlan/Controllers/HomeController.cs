using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlan.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;
        public HomeController(WeddingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(WeddingGoer user)
        {
            if(ModelState.IsValid)
            {
                
                if(_context.users.Any(e => e.Email == user.Email))
                {
                    
                    return View("Index");
                }
                
                PasswordHasher<WeddingGoer> hasher = new PasswordHasher<WeddingGoer>();
                user.Password = hasher.HashPassword(user, user.Password);

                _context.users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("Index");
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid){
                WeddingGoer check = _context.users.FirstOrDefault(e => e.Email == user.Email);

                if(check == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginView");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, check.Password, user.Password);
                if(result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");
                    return View("LoginView");
                }

                // store user_id in session!
                HttpContext.Session.SetInt32("userid", check.Id);
                return RedirectToAction("Plans");
            }
            else{
                return View("Index");
            }
        }
        [HttpGet("Plans")]
        public IActionResult Plans()
        {
            return View("Plans");
        }
        [HttpPost("Planner")]
        public IActionResult Planner(Planner plan)
        {
            if(ModelState.IsValid)
            {
                _context.planner.Add(plan);
                _context.SaveChanges();
                return RedirectToAction("Result");
            }
            else
            {
                return View("Plans");
            }
        }
        [HttpGet("Result")]
        public IActionResult Result()
        {
            var goers = _context.planner
                .Include(b => b.Response)
                .OrderByDescending(b => b.Date);
            ViewBag.theLucky = HttpContext.Session.GetInt32("userid");
            return View("Result");
        }
    }
}
