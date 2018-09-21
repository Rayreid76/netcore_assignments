using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        private object dbContext;
        public HomeController(BankContext _context) => dbContext = _context;

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
            return View("Dashboard");
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return View("Index");
        }
        [HttpGet("registure")]
        public IActionResult Registure()
        {
            return View("Registure");
        }
        [HttpPost("record")]
        public IActionResult Record(Person log)
        {
            if(dbContext.Users.Any(pp => pp.email == log.Email))
            {
                ModelState.AddModelError("Email", "Email Exists");
                return View("Index");
            }
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            log.Password = hasher.HashPassword(User, log.Password);

            dbContext.Users.Add(log);
            dbContext.Save();
            return RedirectToAction("Index");
            
        }
    }
}