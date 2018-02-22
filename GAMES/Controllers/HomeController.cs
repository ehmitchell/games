using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GAMES.Models;
using Microsoft.AspNetCore.Authorization;

namespace GAMES.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var x = User;
            return View();
        }

        [Authorize(Roles = "GamesAdmin")]
        public IActionResult Admin()
        {
            ViewData["Message"] = "Your administration navigation page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
