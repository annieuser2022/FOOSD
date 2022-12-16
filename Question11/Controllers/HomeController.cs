using Microsoft.AspNetCore.Mvc;
using Question11.Models;
using System.Diagnostics;

namespace Question11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static string adminId = "admin@fitness.com";
        static string customerId = "customer@fitness.com";
        string name = "name";
        static IList<User> userList = new List<User> { };
        string adminPass = "admin";
        string customerPass = "customer";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult LogInPage()
        {
            return View();
        }
        public IActionResult LogOutPage()
        {
            return View();
        }

        public IActionResult SignUpPage()
        {
            return View();
        }
        public IActionResult CheckCredentials(Login details)
        {



            // we will do a call to the db
            if (details.EmailId == adminId && details.Password == adminPass)
            {

                return RedirectToAction("adminIndex", "Admin", new {name = "I am admin"});
            }
            if (details.EmailId == customerId && details.Password == customerPass)
            {
                return RedirectToAction("CustomerIndex", "Customer");
            }
            foreach (var eachUser in userList)
            {
                if (eachUser.EmailId == details.EmailId && eachUser.Password ==
                    details.Password)
                {
                    if (eachUser.Role == "Customer")
                    {
                        return RedirectToAction("CustomerIndex", "Customer", new {name=eachUser.Name});
                    }
                    else if (eachUser.Role == "Admin")
                    {
                        return RedirectToAction("adminIndex", "Admin", new { name = eachUser.Name });
                    }
                }
            }
            ViewBag.prompt = "Invalid email, or password, try again..";
            return View("LogInPage");
        }

        public IActionResult AddUser(User details)
        {
            Random Id = new Random();
            int userId = Id.Next(1, 10000);
            details.Id = userId;

            userList.Add(details);

            details.Role = "Customer";
            
            ViewBag.details = details;
        
            return View("UserCreated");
        }
    }
}