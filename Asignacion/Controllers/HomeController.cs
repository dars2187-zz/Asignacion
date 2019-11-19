using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;

namespace Asignacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public int? usu
        {
            get => HttpContext.Session.GetInt32("Usuario") as int?;
            set => HttpContext.Session.SetInt32("Usuario", 0);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (usu == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        public IActionResult Privacy()
        {
            if (usu == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (usu == 1)
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            return View("~/Views/Account/Login.cshtml");
        }
    }
}
