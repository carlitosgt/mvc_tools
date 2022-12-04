using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CombustiblesGT.Models;

namespace CombustiblesGT.Controllers
{
    public class BombasController : Controller
    {
        private readonly DbCombusiblesGtContext _context;

        public BombasController(DbCombusiblesGtContext context)
        {
            _context = context;
        }

        // GET: Bombas
        public async Task<IActionResult> Index()
        {
              return _context.Bombas != null ? 
                          View(await _context.Bombas.ToListAsync()) :
                          Problem("Entity set 'DbCombusiblesGtContext.Bombas'  is null.");
        }

        // GET: Bombas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bombas == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bombas
                .FirstOrDefaultAsync(m => m.IdBomba == id);
            if (bomba == null)
            {
                return NotFound();
            }

            return View(bomba);
        }

        // GET: Bombas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bombas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBomba,Nombre,Ubicacion,Codigo,Empresa")] Bomba bomba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bomba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bomba);
        }

        // GET: Bombas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bombas == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bombas.FindAsync(id);
            if (bomba == null)
            {
                return NotFound();
            }
            return View(bomba);
        }

        // POST: Bombas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBomba,Nombre,Ubicacion,Codigo,Empresa")] Bomba bomba)
        {
            if (id != bomba.IdBomba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bomba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BombaExists(bomba.IdBomba))
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
            return View(bomba);
        }

        // GET: Bombas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bombas == null)
            {
                return NotFound();
            }

            var bomba = await _context.Bombas
                .FirstOrDefaultAsync(m => m.IdBomba == id);
            if (bomba == null)
            {
                return NotFound();
            }

            return View(bomba);
        }

        // POST: Bombas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bombas == null)
            {
                return Problem("Entity set 'DbCombusiblesGtContext.Bombas'  is null.");
            }
            var bomba = await _context.Bombas.FindAsync(id);
            if (bomba != null)
            {
                _context.Bombas.Remove(bomba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BombaExists(int id)
        {
          return (_context.Bombas?.Any(e => e.IdBomba == id)).GetValueOrDefault();
        }
    }
}
