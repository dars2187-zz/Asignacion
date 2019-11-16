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
    public class ProgramaAsignaturaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public ProgramaAsignaturaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: ProgramaAsignatura
        public async Task<IActionResult> Index()
        {
            var dbContextAsignacion = _context.ProgramaAsignaturas.Include(p => p.asignatura).Include(p => p.programa);
            return View(await dbContextAsignacion.ToListAsync());
        }

        // GET: ProgramaAsignatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaAsignatura = await _context.ProgramaAsignaturas
                .Include(p => p.asignatura)
                .Include(p => p.programa)
                .FirstOrDefaultAsync(m => m.idprograma == id);
            if (programaAsignatura == null)
            {
                return NotFound();
            }

            return View(programaAsignatura);
        }

        // GET: ProgramaAsignatura/Create
        public IActionResult Create()
        {
            ViewData["idasignatura"] = new SelectList(_context.Asignaturas, "idasignatura", "descripcion");
            ViewData["idprograma"] = new SelectList(_context.Programas, "idprograma", "descripcion");
            return View();
        }

        // POST: ProgramaAsignatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idasignatura,idprograma")] ProgramaAsignatura programaAsignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programaAsignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idasignatura"] = new SelectList(_context.Asignaturas, "idasignatura", "descripcion", programaAsignatura.idasignatura);
            ViewData["idprograma"] = new SelectList(_context.Programas, "idprograma", "descripcion", programaAsignatura.idprograma);
            return View(programaAsignatura);
        }

        // GET: ProgramaAsignatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaAsignatura = await _context.ProgramaAsignaturas.FindAsync(id);
            if (programaAsignatura == null)
            {
                return NotFound();
            }
            ViewData["idasignatura"] = new SelectList(_context.Asignaturas, "idasignatura", "descripcion", programaAsignatura.idasignatura);
            ViewData["idprograma"] = new SelectList(_context.Programas, "idprograma", "descripcion", programaAsignatura.idprograma);
            return View(programaAsignatura);
        }

        // POST: ProgramaAsignatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idasignatura,idprograma")] ProgramaAsignatura programaAsignatura)
        {
            if (id != programaAsignatura.idprograma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaAsignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaAsignaturaExists(programaAsignatura.idprograma))
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
            ViewData["idasignatura"] = new SelectList(_context.Asignaturas, "idasignatura", "descripcion", programaAsignatura.idasignatura);
            ViewData["idprograma"] = new SelectList(_context.Programas, "idprograma", "descripcion", programaAsignatura.idprograma);
            return View(programaAsignatura);
        }

        // GET: ProgramaAsignatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaAsignatura = await _context.ProgramaAsignaturas
                .Include(p => p.asignatura)
                .Include(p => p.programa)
                .FirstOrDefaultAsync(m => m.idprograma == id);
            if (programaAsignatura == null)
            {
                return NotFound();
            }

            return View(programaAsignatura);
        }

        // POST: ProgramaAsignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programaAsignatura = await _context.ProgramaAsignaturas.FindAsync(id);
            _context.ProgramaAsignaturas.Remove(programaAsignatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaAsignaturaExists(int id)
        {
            return _context.ProgramaAsignaturas.Any(e => e.idprograma == id);
        }
    }
}
