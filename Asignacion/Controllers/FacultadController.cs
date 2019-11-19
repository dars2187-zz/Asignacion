using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class FacultadController : Controller
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

        public FacultadController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Facultad
        public async Task<IActionResult> Index()
        {
            if (usu == 1 && perf == 1)
                return View(await _context.Facultades.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Facultad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var facultad = await _context.Facultades
                    .FirstOrDefaultAsync(m => m.idfacultad == id);
                if (facultad == null)
                {
                    return NotFound();
                }

                return View(facultad);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Facultad/Create
        public IActionResult Create()
        {
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Facultad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idfacultad,descripcion")] Facultad facultad)
        {
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(facultad);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(facultad);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Facultad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var facultad = await _context.Facultades.FindAsync(id);
                if (facultad == null)
                {
                    return NotFound();
                }
                return View(facultad);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Facultad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idfacultad,descripcion")] Facultad facultad)
        {
            if (usu == 1 && perf == 1)
            {
                if (id != facultad.idfacultad)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(facultad);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FacultadExists(facultad.idfacultad))
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
                return View(facultad);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Facultad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var facultad = await _context.Facultades
                    .FirstOrDefaultAsync(m => m.idfacultad == id);
                if (facultad == null)
                {
                    return NotFound();
                }

                return View(facultad);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Facultad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (usu == 1 && perf == 1)
            {
                var facultad = await _context.Facultades.FindAsync(id);
                _context.Facultades.Remove(facultad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool FacultadExists(int id)
        {
            return _context.Facultades.Any(e => e.idfacultad == id);
        }
    }
}
