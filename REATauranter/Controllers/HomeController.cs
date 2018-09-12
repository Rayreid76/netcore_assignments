using Microsoft.AspNetCore.Mvc;

namespace REATauranter
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index(){
            return View();
        }

    }
}