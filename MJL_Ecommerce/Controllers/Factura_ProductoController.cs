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
    [Authorize]
    public class Factura_ProductoController : Controller
    {
        private readonly ECommerceDbContextcs _context;

        public Factura_ProductoController(ECommerceDbContextcs context)
        {
            _context = context;
        }

        // GET: Factura_Producto
        public async Task<IActionResult> Index()
        {
            var eCommerceDbContextcs = _context.Factura_Productos.Include(f => f.IdFacturaNavigation).Include(f => f.IdProductoNavigation);
            return View(await eCommerceDbContextcs.ToListAsync());
        }

        // GET: Factura_Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Factura_Productos == null)
            {
                return NotFound();
            }

            var factura_Producto = await _context.Factura_Productos
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura_Producto == null)
            {
                return NotFound();
            }

            return View(factura_Producto);
        }

        // GET: Factura_Producto/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Codigo");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            return View();
        }

        // POST: Factura_Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductoId,FacturaId")] Factura_Producto factura_Producto)
        {
            _context.Add(factura_Producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            if (ModelState.IsValid)
            {

            }

            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", factura_Producto.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", factura_Producto.ProductoId);

            return View(factura_Producto);
        }

        // GET: Factura_Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Factura_Productos == null)
            {
                return NotFound();
            }

            var factura_Producto = await _context.Factura_Productos.FindAsync(id);
            if (factura_Producto == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Codigo", factura_Producto.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", factura_Producto.ProductoId);
            return View(factura_Producto);
        }

        // POST: Factura_Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductoId,FacturaId")] Factura_Producto factura_Producto)
        {

            if (id != factura_Producto.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(factura_Producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Factura_ProductoExists(factura_Producto.Id))
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
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", factura_Producto.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Id", factura_Producto.ProductoId);
            return View(factura_Producto);
        }

        // GET: Factura_Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Factura_Productos == null)
            {
                return NotFound();
            }

            var factura_Producto = await _context.Factura_Productos
                .Include(f => f.IdFacturaNavigation)
                .Include(f => f.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factura_Producto == null)
            {
                return NotFound();
            }

            return View(factura_Producto);
        }

        // POST: Factura_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Factura_Productos == null)
            {
                return Problem("Entity set 'ECommerceDbContextcs.Factura_Productos'  is null.");
            }
            var factura_Producto = await _context.Factura_Productos.FindAsync(id);
            if (factura_Producto != null)
            {
                _context.Factura_Productos.Remove(factura_Producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Factura_ProductoExists(int id)
        {
          return _context.Factura_Productos.Any(e => e.Id == id);
        }
    }
}
