using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MJL_Ecommerce.Data;
using MJL_Ecommerce.Models;


namespace MJL_Ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FabricantesController : Controller
    {
        private readonly ECommerceDbContextcs _context;

        public FabricantesController(ECommerceDbContextcs context)
        {
            _context = context;
        }

        // GET: Fabricantes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Fabricantes.ToListAsync());
        }

        // GET: Fabricantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fabricantes == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }

        // GET: Fabricantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabricantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fabricante,Description")] Fabricantes fabricantes)
        {
            _context.Add(fabricantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {

            }
            return View(fabricantes);
        }

        // GET: Fabricantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fabricantes == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes.FindAsync(id);
            if (fabricantes == null)
            {
                return NotFound();
            }
            return View(fabricantes);
        }

        // POST: Fabricantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fabricante,Description")] Fabricantes fabricantes)
        {
            if (id != fabricantes.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(fabricantes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricantesExists(fabricantes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                
            }
            return View(fabricantes);
        }

        // GET: Fabricantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fabricantes == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fabricantes == null)
            {
                return Problem("Entity set 'ECommerceDbContextcs.Fabricantes'  is null.");
            }
            var fabricantes = await _context.Fabricantes.FindAsync(id);
            if (fabricantes != null)
            {
                _context.Fabricantes.Remove(fabricantes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricantesExists(int id)
        {
          return _context.Fabricantes.Any(e => e.Id == id);
        }
    }
}
