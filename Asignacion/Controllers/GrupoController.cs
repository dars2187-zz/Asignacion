using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class GrupoController : Controller
    {
        private readonly DbContextAsignacion _context;

        public GrupoController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Grupo
        public async Task<IActionResult> Index()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View(await _context.Grupos.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Grupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var grupo = await _context.Grupos
                    .FirstOrDefaultAsync(m => m.idgrupo == id);
                if (grupo == null)
                {
                    return NotFound();
                }

                return View(grupo);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Grupo/Create
        public IActionResult Create()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Grupo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idgrupo,descripcion,idhorario,idasignatura")] Grupo grupo)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(grupo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(grupo);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Grupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var grupo = await _context.Grupos.FindAsync(id);
                if (grupo == null)
                {
                    return NotFound();
                }
                return View(grupo);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idgrupo,descripcion,idhorario,idasignatura")] Grupo grupo)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id != grupo.idgrupo)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(grupo);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GrupoExists(grupo.idgrupo))
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
                return View(grupo);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Grupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var grupo = await _context.Grupos
                    .FirstOrDefaultAsync(m => m.idgrupo == id);
                if (grupo == null)
                {
                    return NotFound();
                }

                return View(grupo);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                var grupo = await _context.Grupos.FindAsync(id);
                _context.Grupos.Remove(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool GrupoExists(int id)
        {
            return _context.Grupos.Any(e => e.idgrupo == id);
        }
    }
}
