using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class DiaSemanaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public DiaSemanaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: DiaSemana
        public async Task<IActionResult> Index()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View(await _context.DiaSemanas.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: DiaSemana/Details/5
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

                var diaSemana = await _context.DiaSemanas
                    .FirstOrDefaultAsync(m => m.iddiasemana == id);
                if (diaSemana == null)
                {
                    return NotFound();
                }

                return View(diaSemana);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: DiaSemana/Create
        public IActionResult Create()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: DiaSemana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iddiasemana,descripcion")] DiaSemana diaSemana)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(diaSemana);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(diaSemana);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: DiaSemana/Edit/5
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

                var diaSemana = await _context.DiaSemanas.FindAsync(id);
                if (diaSemana == null)
                {
                    return NotFound();
                }
                return View(diaSemana);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: DiaSemana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iddiasemana,descripcion")] DiaSemana diaSemana)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id != diaSemana.iddiasemana)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(diaSemana);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DiaSemanaExists(diaSemana.iddiasemana))
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
                return View(diaSemana);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: DiaSemana/Delete/5
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

                var diaSemana = await _context.DiaSemanas
                    .FirstOrDefaultAsync(m => m.iddiasemana == id);
                if (diaSemana == null)
                {
                    return NotFound();
                }

                return View(diaSemana);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: DiaSemana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                var diaSemana = await _context.DiaSemanas.FindAsync(id);
                _context.DiaSemanas.Remove(diaSemana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool DiaSemanaExists(int id)
        {
            return _context.DiaSemanas.Any(e => e.iddiasemana == id);
        }
    }
}
