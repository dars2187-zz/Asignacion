using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asignacion.Entidades;
using Asignacion.Models;

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
            var dbContextAsignacion = _context.GrupoAulas.Include(g => g.aula).Include(g => g.grupo);
            return View(await dbContextAsignacion.ToListAsync());
        }

        // GET: GrupoAula/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: GrupoAula/Create
        public IActionResult Create()
        {
            ViewData["idaula"] = new SelectList(_context.Aulas, "idaula", "numaula");
            ViewData["idgrupo"] = new SelectList(_context.Grupos, "idgrupo", "descripcion");
            return View();
        }

        // POST: GrupoAula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idgrupo,idaula")] GrupoAula grupoAula)
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

        // GET: GrupoAula/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: GrupoAula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idgrupo,idaula")] GrupoAula grupoAula)
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

        // GET: GrupoAula/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: GrupoAula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoAula = await _context.GrupoAulas.FindAsync(id);
            _context.GrupoAulas.Remove(grupoAula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoAulaExists(int id)
        {
            return _context.GrupoAulas.Any(e => e.idgrupo == id);
        }
    }
}
