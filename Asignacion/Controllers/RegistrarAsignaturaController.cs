using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asignacion.Controllers
{
    public class RegistrarAsignaturaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public int? usu
        {
            get => HttpContext.Session.GetInt32("Usuario") as int?;
            set => HttpContext.Session.SetInt32("Usuario", 0);
        }

        public int? perf
        {
            get => HttpContext.Session.GetInt32("Perfil") as int?;
            set => HttpContext.Session.SetInt32("Perfil", 0);
        }

        public RegistrarAsignaturaController(DbContextAsignacion context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (usu == 1 && perf == 2)
            {
                ViewData["idprograma"] = new SelectList(_context.Programas, "idprograma", "descripcion");
                return View();
            }

            return View("~/Views/Account/Login.cshtml");
        }
    }
}