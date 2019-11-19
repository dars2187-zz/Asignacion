using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public ActionResult ListaAsignatura(int id)
        {
            if (usu == 1 && perf == 2)
            {
                var asignatura = _context.ProgramaAsignaturas
                    .Include(a => a.asignatura)
                    .Where(a => a.idprograma == id);
                return Json(new { data = asignatura });
            }

            return View("~/Views/Account/Login.cshtml");
        }
    }
}