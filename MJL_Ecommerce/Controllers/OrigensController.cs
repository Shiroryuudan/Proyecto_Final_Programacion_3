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
    public class OrigensController : Controller
    {
        private readonly ECommerceDbContextcs _context;

        public OrigensController(ECommerceDbContextcs context)
        {
            _context = context;
        }

        // GET: Origens
        public async Task<IActionResult> Index()
        {
              return View(await _context.Origenes.ToListAsync());
        }

        // GET: Origens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Origenes == null)
            {
                return NotFound();
            }

            var origen = await _context.Origenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origen == null)
            {
                return NotFound();
            }

            return View(origen);
        }

        // GET: Origens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lugar")] Origen origen)
        {
            _context.Add(origen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {

            }
            return View(origen);
        }

        // GET: Origens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Origenes == null)
            {
                return NotFound();
            }

            var origen = await _context.Origenes.FindAsync(id);
            if (origen == null)
            {
                return NotFound();
            }
            return View(origen);
        }

        // POST: Origens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lugar")] Origen origen)
        {
            if (id != origen.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(origen);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigenExists(origen.Id))
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
            return View(origen);
        }

        // GET: Origens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Origenes == null)
            {
                return NotFound();
            }

            var origen = await _context.Origenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origen == null)
            {
                return NotFound();
            }

            return View(origen);
        }

        // POST: Origens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Origenes == null)
            {
                return Problem("Entity set 'ECommerceDbContextcs.Origenes'  is null.");
            }
            var origen = await _context.Origenes.FindAsync(id);
            if (origen != null)
            {
                _context.Origenes.Remove(origen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrigenExists(int id)
        {
          return _context.Origenes.Any(e => e.Id == id);
        }
    }
}
