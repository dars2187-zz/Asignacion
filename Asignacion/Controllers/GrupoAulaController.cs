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
    public class GrupoAulaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public GrupoAulaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: GrupoAula
        public async Task<IActionResult> Index()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                var dbContextAsignacion = _context.GrupoAulas.Include(g => g.aula).Include(g => g.grupo);
                return View(await dbContextAsignacion.ToListAsync());
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: GrupoAula/Details/5
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

                var grupoAula = await _context.GrupoAulas
                    .Include(g => g.aula)
                    .Include(g => g.grupo)
                    .FirstOrDefaultAsync(m => m.idgrupo == id);
                if (grupoAula == null)
                {
                    return NotFound();
                }

                return View(grupoAula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: GrupoAula/Create
        public IActionResult Create()
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                ViewData["idaula"] = new SelectList(_context.Aulas, "idaula", "numaula");
                ViewData["idgrupo"] = new SelectList(_context.Grupos, "idgrupo", "descripcion");
                return View();
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: GrupoAula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idgrupo,idaula")] GrupoAula grupoAula)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(grupoAula);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["idaula"] = new SelectList(_context.Aulas, "idaula", "numaula", grupoAula.idaula);
                ViewData["idgrupo"] = new SelectList(_context.Grupos, "idgrupo", "descripcion", grupoAula.idgrupo);
                return View(grupoAula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: GrupoAula/Edit/5
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

                var grupoAula = await _context.GrupoAulas.FindAsync(id);
                if (grupoAula == null)
                {
                    return NotFound();
                }
                ViewData["idaula"] = new SelectList(_context.Aulas, "idaula", "numaula", grupoAula.idaula);
                ViewData["idgrupo"] = new SelectList(_context.Grupos, "idgrupo", "descripcion", grupoAula.idgrupo);
                return View(grupoAula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: GrupoAula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idgrupo,idaula")] GrupoAula grupoAula)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                if (id != grupoAula.idgrupo)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(grupoAula);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GrupoAulaExists(grupoAula.idgrupo))
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
                ViewData["idaula"] = new SelectList(_context.Aulas, "idaula", "numaula", grupoAula.idaula);
                ViewData["idgrupo"] = new SelectList(_context.Grupos, "idgrupo", "descripcion", grupoAula.idgrupo);
                return View(grupoAula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: GrupoAula/Delete/5
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

                var grupoAula = await _context.GrupoAulas
                    .Include(g => g.aula)
                    .Include(g => g.grupo)
                    .FirstOrDefaultAsync(m => m.idgrupo == id);
                if (grupoAula == null)
                {
                    return NotFound();
                }

                return View(grupoAula);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: GrupoAula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usu = HttpContext.Session.GetInt32("Usuario");
            var perf = HttpContext.Session.GetInt32("Perfil");
            if (usu == 1 && perf == 1)
            {
                var grupoAula = await _context.GrupoAulas.FindAsync(id);
                _context.GrupoAulas.Remove(grupoAula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Account/Login.cshtml");
        }

        private bool GrupoAulaExists(int id)
        {
            return _context.GrupoAulas.Any(e => e.idgrupo == id);
        }
    }
}
