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
            return View(await _context.DiaSemanas.ToListAsync());
        }

        // GET: DiaSemana/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: DiaSemana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaSemana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iddiasemana,descripcion")] DiaSemana diaSemana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaSemana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaSemana);
        }

        // GET: DiaSemana/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: DiaSemana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iddiasemana,descripcion")] DiaSemana diaSemana)
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

        // GET: DiaSemana/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: DiaSemana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaSemana = await _context.DiaSemanas.FindAsync(id);
            _context.DiaSemanas.Remove(diaSemana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaSemanaExists(int id)
        {
            return _context.DiaSemanas.Any(e => e.iddiasemana == id);
        }
    }
}
