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
    public class JornadaController : Controller
    {
        private readonly DbContextAsignacion _context;

        public JornadaController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Jornada
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jornadas.ToListAsync());
        }

        // GET: Jornada/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Jornada/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jornada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idjornada,descripcion")] Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jornada);
        }

        // GET: Jornada/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Jornada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idjornada,descripcion")] Jornada jornada)
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

        // GET: Jornada/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Jornada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jornada = await _context.Jornadas.FindAsync(id);
            _context.Jornadas.Remove(jornada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornadas.Any(e => e.idjornada == id);
        }
    }
}
