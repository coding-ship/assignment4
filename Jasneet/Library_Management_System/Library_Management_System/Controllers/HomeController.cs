using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Library_Management_System.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private IConfiguration iconfig;
        private UserManager<IdentityUser> UserManager;
        private SignInManager<IdentityUser> signInManager;

        private MyLibraryContext db = new MyLibraryContext();
        public HomeController(IConfiguration _config)
        {
            iconfig = _config;
        }
        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public IActionResult Details()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
