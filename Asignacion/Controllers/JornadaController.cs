using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class JornadaController : Controller
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

        public JornadaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Jornada
        public async Task<IActionResult> Index()
        {
            if (usu == 1 && perf == 1)
                return View(await _context.Jornadas.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Jornada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var jornada = await _context.Jornadas
                    .FirstOrDefaultAsync(m => m.idjornada == id);
                if (jornada == null)
                {
                    return NotFound();
                }

                return View(jornada);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Jornada/Create
        public IActionResult Create()
        {
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Jornada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idjornada,descripcion")] Jornada jornada)
        {
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(jornada);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(jornada);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Jornada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var jornada = await _context.Jornadas.FindAsync(id);
                if (jornada == null)
                {
                    return NotFound();
                }
                return View(jornada);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Jornada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idjornada,descripcion")] Jornada jornada)
        {
            if (usu == 1 && perf == 1)
            {
                if (id != jornada.idjornada)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(jornada);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!JornadaExists(jornada.idjornada))
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
                return View(jornada);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Jornada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (usu == 1 && perf == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var jornada = await _context.Jornadas
                    .FirstOrDefaultAsync(m => m.idjornada == id);
                if (jornada == null)
                {
                    return NotFound();
                }

                return View(jornada);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Jornada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (usu == 1 && perf == 1)
            {
                var jornada = await _context.Jornadas.FindAsync(id);
                _context.Jornadas.Remove(jornada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornadas.Any(e => e.idjornada == id);
        }
    }
}
