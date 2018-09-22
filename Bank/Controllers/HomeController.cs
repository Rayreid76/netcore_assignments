using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        private BankContext dbContext;
        public HomeController(BankContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                Person userEmail = dbContext.Users.FirstOrDefault(pp => pp.Email == user.Email);

                if(userEmail == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, userEmail.Password, user.Password);
                if(result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("iduser", userEmail.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? validate = HttpContext.Session.GetInt32("iduser");
            if(validate == null)
            {
                return RedirectToAction("Registure");
            }
            Person Banker = dbContext.Users.FirstOrDefault(pp => pp.UserId == validate);

            ViewBag.banker = Banker;
            return View("Dashboard");
        }
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return View("Index");
        }
        [HttpGet("registure")]
        public IActionResult Registure()
        {
            return View("Registure");
        }
        [HttpPost("Record")]
        public IActionResult Record(Person log)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(pp => pp.Email == log.Email))
                {
                    return View("Registure");
                }
                PasswordHasher<Person> hasher = new PasswordHasher<Person>();
                log.Password = hasher.HashPassword(log, log.Password);

                dbContext.Users.Add(log);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Registure");
            }
            
        }
        [HttpPost("Deposit")]
        public IActionResult Deposit(Accounts money)
        {
            if(ModelState.IsValid)
            {
                List<Person> red = dbContext.Users.Include(p => p.UserId).Include(p => p.Accounts).ToList();
                ViewBag.deposit = red;
                dbContext.Accounts.Add(money);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Dashboard");
        }
    }
}