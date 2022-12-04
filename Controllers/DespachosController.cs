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
    public class DespachosController : Controller
    {
        private readonly DbCombusiblesGtContext _context;

        public DespachosController(DbCombusiblesGtContext context)
        {
            _context = context;
        }

        // GET: Despachos
        public async Task<IActionResult> Index()
        {
            var dbCombusiblesGtContext = _context.Despachos.Include(d => d.IdBombaNavigation).Include(d => d.IdVehiculoNavigation);
            return View(await dbCombusiblesGtContext.ToListAsync());
        }

        // GET: Despachos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Despachos == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos
                .Include(d => d.IdBombaNavigation)
                .Include(d => d.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdDespacho == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // GET: Despachos/Create
        public IActionResult Create()
        {
            ViewData["IdBomba"] = new SelectList(_context.Bombas, "IdBomba", "Nombre");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Descripcion");
            return View();
        }

        // POST: Despachos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDespacho,Fecha,IdVehiculo,IdBomba,TotalDespachado")] Despacho despacho)
        {

            using (DbCombusiblesGtContext db = new DbCombusiblesGtContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        _context.Add(despacho);
                        await _context.SaveChangesAsync();

                        throw new Exception();
                        dbContextTransaction.Commit();

                        return RedirectToAction(nameof(Index));
                    }
                    catch 
                    {
                        dbContextTransaction.Rollback();
                    }

                }
                
            }

            ViewData["IdBomba"] = new SelectList(_context.Bombas, "IdBomba", "Nombre", despacho.IdBomba);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Descripcion", despacho.IdVehiculo);
            return View(despacho);

            //if (ModelState.IsValid)
            //    {
            //        _context.Add(despacho);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
           
        }

        // GET: Despachos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Despachos == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho == null)
            {
                return NotFound();
            }
            ViewData["IdBomba"] = new SelectList(_context.Bombas, "IdBomba", "IdBomba", despacho.IdBomba);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "IdVehiculo", despacho.IdVehiculo);
            return View(despacho);
        }

        // POST: Despachos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDespacho,Fecha,IdVehiculo,IdBomba,TotalDespachado")] Despacho despacho)
        {
            if (id != despacho.IdDespacho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despacho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespachoExists(despacho.IdDespacho))
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
            ViewData["IdBomba"] = new SelectList(_context.Bombas, "IdBomba", "Nombre", despacho.IdBomba);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "Descripcion", despacho.IdVehiculo);
            return View(despacho);
        }

        // GET: Despachos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Despachos == null)
            {
                return NotFound();
            }

            var despacho = await _context.Despachos
                .Include(d => d.IdBombaNavigation)
                .Include(d => d.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdDespacho == id);
            if (despacho == null)
            {
                return NotFound();
            }

            return View(despacho);
        }

        // POST: Despachos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Despachos == null)
            {
                return Problem("Entity set 'DbCombusiblesGtContext.Despachos'  is null.");
            }
            var despacho = await _context.Despachos.FindAsync(id);
            if (despacho != null)
            {
                _context.Despachos.Remove(despacho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespachoExists(int id)
        {
          return (_context.Despachos?.Any(e => e.IdDespacho == id)).GetValueOrDefault();
        }
    }
}
