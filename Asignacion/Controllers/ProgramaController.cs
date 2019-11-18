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
    public class ProgramaController : Controller
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

        public ProgramaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Programa
        public async Task<IActionResult> Index()
        {
            if (usu == 1 && perf == 1)
            {
                var dbContextAsignacion = _context.Programas.Include(a => a.facultad).Include(a => a.jornada);
                return View(await dbContextAsignacion.ToListAsync());
            }

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Programa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var programa = await _context.Programas
                    .FirstOrDefaultAsync(m => m.idprograma == id);
                if (programa == null)
                {
                    return NotFound();
                }

                return View(programa);
            }

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Programa/Create
        public IActionResult Create()
        {
            if (usu == 1 && perf == 1)
            {
                ViewData["idfacultad"] = new SelectList(_context.Facultades, "idfacultad", "descripcion");
                ViewData["idjornada"] = new SelectList(_context.Facultades, "idjornada", "descripcion");
                return View();
            }

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Programa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idprograma,descripcion,idfacultad,idjornada")] Programa programa)
        {
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(programa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["idfacultad"] = new SelectList(_context.Facultades, "idfacultad", "descripcion", programa.idfacultad);
                ViewData["idjornada"] = new SelectList(_context.Facultades, "idjornada", "descripcion", programa.idjornada);
                return View(programa);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Programa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var programa = await _context.Programas.FindAsync(id);
                if (programa == null)
                {
                    return NotFound();
                }
                return View(programa);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Programa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idprograma,descripcion,idfacultad,idjornada")] Programa programa)
        {
            if (usu == 1 && perf == 1)
            {
                if (id != programa.idprograma)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(programa);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProgramaExists(programa.idprograma))
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
                return View(programa);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Programa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var programa = await _context.Programas
                    .FirstOrDefaultAsync(m => m.idprograma == id);
                if (programa == null)
                {
                    return NotFound();
                }

                return View(programa);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (usu == 1 && perf == 1)
            {
                var programa = await _context.Programas.FindAsync(id);
                _context.Programas.Remove(programa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool ProgramaExists(int id)
        {
            return _context.Programas.Any(e => e.idprograma == id);
        }
    }
}
