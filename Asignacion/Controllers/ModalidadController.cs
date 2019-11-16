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
    public class ModalidadController : Controller
    {
        private readonly DbContextAsignacion _context;

        public ModalidadController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Modalidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modalidades.ToListAsync());
        }

        // GET: Modalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades
                .FirstOrDefaultAsync(m => m.idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // GET: Modalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modalidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idmodalidad,descripcion")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidad);
        }

        // GET: Modalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades.FindAsync(id);
            if (modalidad == null)
            {
                return NotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idmodalidad,descripcion")] Modalidad modalidad)
        {
            if (id != modalidad.idmodalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadExists(modalidad.idmodalidad))
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
            return View(modalidad);
        }

        // GET: Modalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades
                .FirstOrDefaultAsync(m => m.idmodalidad == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // POST: Modalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidad = await _context.Modalidades.FindAsync(id);
            _context.Modalidades.Remove(modalidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadExists(int id)
        {
            return _context.Modalidades.Any(e => e.idmodalidad == id);
        }
    }
}
