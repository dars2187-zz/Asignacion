using System.Linq;
using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asignacion.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbContextAsignacion _context;

        public AccountController(DbContextAsignacion context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            HttpContext.Session.SetInt32("Usuario", 0);
            return View();
        }

        public ActionResult Validate(Usuario admin)
        {
            var _admin = _context.Usuarios.Where(s => s.correo == admin.correo);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.estado).Any())
                {
                    if (_admin.Where(s => s.clave == admin.clave).Any())
                    {
                        var usuario = _admin.FirstOrDefault(s => s.clave == admin.clave);
                        HttpContext.Session.SetInt32("Usuario", 1);
                        HttpContext.Session.SetInt32("Perfil", usuario.idrol);
                        return Json(new { status = true, message = "Ingreso Correcto" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "Contraseña Incorrecta" });
                    }
                }
                else
                {
                    return Json(new { status = false, message = "Usuario Inactivo" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Correo Invalido" });
            }
        }

    }
}