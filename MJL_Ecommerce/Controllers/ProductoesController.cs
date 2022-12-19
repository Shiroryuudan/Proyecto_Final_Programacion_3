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
    public class ProductoesController : Controller
    {
        private readonly ECommerceDbContextcs _context;

        public ProductoesController(ECommerceDbContextcs context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var eCommerceDbContextcs = _context.Productos.Include(p => p.Fabricantess).Include(p => p.Origenes).Include(p => p.Ubicaciones);
            return View(await eCommerceDbContextcs.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Fabricantess)
                .Include(p => p.Origenes)
                .Include(p => p.Ubicaciones)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["FabricantesId"] = new SelectList(_context.Fabricantes, "Id", "Fabricante");
            ViewData["OrigenId"] = new SelectList(_context.Origenes, "Id", "Lugar");
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Lugar");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreProducto,Description,Imagen,Precio,OrigenId,UbicacionId,FabricantesId")] Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                
            }
            ViewData["FabricantesId"] = new SelectList(_context.Fabricantes, "Id", "Id", producto.FabricantesId);
            ViewData["OrigenId"] = new SelectList(_context.Origenes, "Id", "Id", producto.OrigenId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Id", producto.UbicacionId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["FabricantesId"] = new SelectList(_context.Fabricantes, "Id", "Fabricante", producto.FabricantesId);
            ViewData["OrigenId"] = new SelectList(_context.Origenes, "Id", "Lugar", producto.OrigenId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Lugar", producto.UbicacionId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreProducto,Description,Imagen,Precio,OrigenId,UbicacionId,FabricantesId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
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
            ViewData["FabricantesId"] = new SelectList(_context.Fabricantes, "Id", "Id", producto.FabricantesId);
            ViewData["OrigenId"] = new SelectList(_context.Origenes, "Id", "Id", producto.OrigenId);
            ViewData["UbicacionId"] = new SelectList(_context.Ubicaciones, "Id", "Id", producto.UbicacionId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Fabricantess)
                .Include(p => p.Origenes)
                .Include(p => p.Ubicaciones)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ECommerceDbContextcs.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return _context.Productos.Any(e => e.Id == id);
        }
    }
}
