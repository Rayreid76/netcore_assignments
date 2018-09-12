using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewRest.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ReviewRest.Controllers
{
    public class HomeController : Controller
    {
        private PostContext _context;
        public HomeController(PostContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> AllUser = _context.Users.ToList();
            
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
        [HttpPost("Create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                // Adding to database
                _context.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Post");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("Index");
            }
        }
        [HttpGet("Post")]
        public IActionResult Post()
        {
            List<User> AllUser = _context.Users.OrderByDescending(a => a.UserId).ToList();
            ViewBag.post = AllUser;
            return View("Post");
        }
    }
}