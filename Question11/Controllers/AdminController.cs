using Microsoft.AspNetCore.Mvc;

namespace Question11.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("AdminIndex");
        }
        public IActionResult adminIndex(string name)
        {
            ViewBag.Name = name;
            return View("AdminIndex");
        }
    }
}
