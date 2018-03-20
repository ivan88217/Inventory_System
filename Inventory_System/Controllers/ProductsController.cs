using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Data;
using Inventory_System.Models;

namespace Inventory_System.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.Products.Include(p => p.BatchNumber).Include(p => p.ManuFactor).Include(p => p.WareHouse).Include(p=>p.Category);
            return View(await inventoryContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.BatchNumber)
                .Include(p => p.Category)
                .Include(p => p.ManuFactor)
                .Include(p => p.WareHouse)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BatchNumberID"] = new SelectList(_context.BatchNumbers, "ID", "BatchNum");
            ViewData["ManuFactorID"] = new SelectList(_context.ManuFactors, "ID", "Name");
            ViewData["WareHouseID"] = new SelectList(_context.WareHouses, "ID", "Name");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,CategoryID,ManuFactorID,BatchNumberID,PartNumber,WareHouseID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchNumberID"] = new SelectList(_context.BatchNumbers, "ID", "BatchNum", product.BatchNumberID);
            ViewData["ManuFactorID"] = new SelectList(_context.ManuFactors, "ID", "Name", product.ManuFactorID);
            ViewData["WareHouseID"] = new SelectList(_context.WareHouses, "ID", "Name", product.WareHouseID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BatchNumberID"] = new SelectList(_context.BatchNumbers, "ID", "BatchNum", product.BatchNumberID);
            ViewData["ManuFactorID"] = new SelectList(_context.ManuFactors, "ID", "Name", product.ManuFactorID);
            ViewData["WareHouseID"] = new SelectList(_context.WareHouses, "ID", "Name", product.WareHouseID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,CategoryID,ManuFactorID,BatchNumberID,PartNumber,WareHouseID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["BatchNumberID"] = new SelectList(_context.BatchNumbers, "ID", "BatchNum", product.BatchNumberID);
            ViewData["ManuFactorID"] = new SelectList(_context.ManuFactors, "ID", "Name", product.ManuFactorID);
            ViewData["WareHouseID"] = new SelectList(_context.WareHouses, "ID", "Name", product.WareHouseID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.BatchNumber)
                .Include(p => p.ManuFactor)
                .Include(p => p.WareHouse)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
