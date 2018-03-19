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
    public class BatchNumbersController : Controller
    {
        private readonly InventoryContext _context;

        public BatchNumbersController(InventoryContext context)
        {
            _context = context;
        }

        // GET: BatchNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatchNumbers.ToListAsync());
        }

        // GET: BatchNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchNumber = await _context.BatchNumbers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (batchNumber == null)
            {
                return NotFound();
            }

            return View(batchNumber);
        }

        // GET: BatchNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatchNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BatchNum,In_Date,Expired_Date")] BatchNumber batchNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batchNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batchNumber);
        }

        // GET: BatchNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchNumber = await _context.BatchNumbers.SingleOrDefaultAsync(m => m.ID == id);
            if (batchNumber == null)
            {
                return NotFound();
            }
            return View(batchNumber);
        }

        // POST: BatchNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BatchNum,In_Date,Expired_Date")] BatchNumber batchNumber)
        {
            if (id != batchNumber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batchNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchNumberExists(batchNumber.ID))
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
            return View(batchNumber);
        }

        // GET: BatchNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchNumber = await _context.BatchNumbers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (batchNumber == null)
            {
                return NotFound();
            }

            return View(batchNumber);
        }

        // POST: BatchNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batchNumber = await _context.BatchNumbers.SingleOrDefaultAsync(m => m.ID == id);
            _context.BatchNumbers.Remove(batchNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchNumberExists(int id)
        {
            return _context.BatchNumbers.Any(e => e.ID == id);
        }
    }
}
