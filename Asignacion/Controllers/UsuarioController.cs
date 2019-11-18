using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class UsuarioController : Controller
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

        public UsuarioController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            if (usu == 1 && perf == 1)
                return View(await _context.Usuarios.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.idusuario == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return View(usuario);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idusuario,numdocumento,nombre,apellido,correo,telefono,clave,estado,idrol,idtipodocumento,idprograma")] Usuario usuario)
        {
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idusuario,numdocumento,nombre,apellido,correo,telefono,clave,estado,idrol,idtipodocumento,idprograma")] Usuario usuario)
        {
            if (usu == 1 && perf == 1)
            {
                if (id != usuario.idusuario)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.idusuario))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.idusuario == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return View(usuario);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (usu == 1 && perf == 1)
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idusuario == id);
        }
    }
}
