using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using UserManagement.Models;
using static System.Collections.Specialized.BitVector32;
using UserManagement.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly DbUserContext db;


        public HomeController(ILogger<HomeController> logger, DbUserContext context)
        {
            _logger = logger;
            db = context;

        }
      

        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString(Session.USERNAME);
            ViewBag.name = s;

            return View();

        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost, ActionName("Login")]

        public async Task<IActionResult> Login(string username, string password)
        {
            {
                var p = db.Users.Include(u => u.Group).ToList();
                var userDetail = p.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

                if (userDetail == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    HttpContext.Session.SetString(Session.USERNAME, username);

                    return RedirectToAction("Index", "Home");
                }

            }
        }
        public IActionResult Group()
        {
            return RedirectToAction("Index", "Group");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}