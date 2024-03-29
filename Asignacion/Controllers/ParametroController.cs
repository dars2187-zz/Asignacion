﻿using System;
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
    public class ParametroController : Controller
    {
        private readonly DbContextAsignacion _context;

        public ParametroController(DbContextAsignacion context)
        {
            _context = context;
        }

        // GET: Parametro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametros.ToListAsync());
        }

        // GET: Parametro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametro = await _context.Parametros
                .FirstOrDefaultAsync(m => m.idparametro == id);
            if (parametro == null)
            {
                return NotFound();
            }

            return View(parametro);
        }

        // GET: Parametro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parametro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idparametro,descripcion,valor")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametro);
        }

        // GET: Parametro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametro = await _context.Parametros.FindAsync(id);
            if (parametro == null)
            {
                return NotFound();
            }
            return View(parametro);
        }

        // POST: Parametro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idparametro,descripcion,valor")] Parametro parametro)
        {
            if (id != parametro.idparametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametroExists(parametro.idparametro))
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
            return View(parametro);
        }

        // GET: Parametro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametro = await _context.Parametros
                .FirstOrDefaultAsync(m => m.idparametro == id);
            if (parametro == null)
            {
                return NotFound();
            }

            return View(parametro);
        }

        // POST: Parametro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parametro = await _context.Parametros.FindAsync(id);
            _context.Parametros.Remove(parametro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametroExists(int id)
        {
            return _context.Parametros.Any(e => e.idparametro == id);
        }
    }
}
