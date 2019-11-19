using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class AsignaturaController : Controller
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

        public AsignaturaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Asignatura
        public async Task<IActionResult> Index()
        {
            if (usu == 1 && perf == 1)
            {
                var dbContextAsignacion = _context.Asignaturas.Include(a => a.modalidad);
                return View(await dbContextAsignacion.ToListAsync());
            }

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Asignatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var asignatura = await _context.Asignaturas
                    .Include(a => a.modalidad)
                    .FirstOrDefaultAsync(m => m.idasignatura == id);
                if (asignatura == null)
                {
                    return NotFound();
                }

                return View(asignatura);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Asignatura/Create
        public IActionResult Create()
        {
            if (usu == 1 && perf == 1)
            {
                ViewData["idmodalidad"] = new SelectList(_context.Modalidades, "idmodalidad", "descripcion");
                return View();
            }                

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Asignatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idasignatura,descripcion,credito,idmodalidad")] Asignatura asignatura)
        {
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(asignatura);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["idmodalidad"] = new SelectList(_context.Modalidades, "idmodalidad", "descripcion", asignatura.idmodalidad);
                return View(asignatura);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Asignatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var asignatura = await _context.Asignaturas.FindAsync(id);
                if (asignatura == null)
                {
                    return NotFound();
                }
                ViewData["idmodalidad"] = new SelectList(_context.Modalidades, "idmodalidad", "descripcion");
                return View(asignatura);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Asignatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idasignatura,descripcion,credito,idmodalidad")] Asignatura asignatura)
        {
            if (usu == 1 && perf == 1)
            {
                if (id != asignatura.idasignatura)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(asignatura);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AsignaturaExists(asignatura.idasignatura))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    ViewData["idmodalidad"] = new SelectList(_context.Modalidades, "idmodalidad", "descripcion", asignatura.idmodalidad);
                    return RedirectToAction(nameof(Index));
                }
                return View(asignatura);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Asignatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var asignatura = await _context.Asignaturas
                    .Include(a => a.modalidad)
                    .FirstOrDefaultAsync(m => m.idasignatura == id);
                if (asignatura == null)
                {
                    return NotFound();
                }

                return View(asignatura);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (usu == 1 && perf == 1)
            {
                var asignatura = await _context.Asignaturas.FindAsync(id);
                _context.Asignaturas.Remove(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool AsignaturaExists(int id)
        {
            return _context.Asignaturas.Any(e => e.idasignatura == id);
        }
    }
}
