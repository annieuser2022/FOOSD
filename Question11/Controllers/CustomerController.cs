using Microsoft.AspNetCore.Mvc;

namespace Question11.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("CustomerIndex");
        }
        public IActionResult CustomerIndex(string name)
        {
            ViewBag.Name = name;
            return View("CustomerIndex");
        }
    }
}
