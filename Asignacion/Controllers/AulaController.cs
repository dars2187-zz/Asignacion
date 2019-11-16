using Asignacion.Entidades;
using Asignacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Controllers
{
    public class AulaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public AulaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Aula
        public async Task<IActionResult> Index()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View(await _context.Aulas.ToListAsync());

            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Aula/Details/5
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

                var aula = await _context.Aulas
                    .FirstOrDefaultAsync(m => m.idaula == id);
                if (aula == null)
                {
                    return NotFound();
                }

                return View(aula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Aula/Create
        public IActionResult Create()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
                return View();

            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Aula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idaula,numaula,idsede")] Aula aula)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(aula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(aula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Aula/Edit/5
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

                var aula = await _context.Aulas.FindAsync(id);
                if (aula == null)
                {
                    return NotFound();
                }
                return View(aula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Aula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idaula,numaula,idsede")] Aula aula)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id != aula.idaula)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(aula);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AulaExists(aula.idaula))
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
                return View(aula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Aula/Delete/5
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

                var aula = await _context.Aulas
                    .FirstOrDefaultAsync(m => m.idaula == id);
                if (aula == null)
                {
                    return NotFound();
                }

                return View(aula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                var aula = await _context.Aulas.FindAsync(id);
                _context.Aulas.Remove(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.idaula == id);
        }
    }
}
