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
    public class ManuFactorsController : Controller
    {
        private readonly InventoryContext _context;

        public ManuFactorsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: ManuFactors
        public async Task<IActionResult> Index()
        {
            return View(await _context.ManuFactors.ToListAsync());
        }

        // GET: ManuFactors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manuFactor = await _context.ManuFactors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (manuFactor == null)
            {
                return NotFound();
            }

            return View(manuFactor);
        }

        // GET: ManuFactors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManuFactors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ManuFactor manuFactor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manuFactor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manuFactor);
        }

        // GET: ManuFactors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manuFactor = await _context.ManuFactors.SingleOrDefaultAsync(m => m.ID == id);
            if (manuFactor == null)
            {
                return NotFound();
            }
            return View(manuFactor);
        }

        // POST: ManuFactors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ManuFactor manuFactor)
        {
            if (id != manuFactor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manuFactor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManuFactorExists(manuFactor.ID))
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
            return View(manuFactor);
        }

        // GET: ManuFactors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manuFactor = await _context.ManuFactors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (manuFactor == null)
            {
                return NotFound();
            }

            return View(manuFactor);
        }

        // POST: ManuFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manuFactor = await _context.ManuFactors.SingleOrDefaultAsync(m => m.ID == id);
            _context.ManuFactors.Remove(manuFactor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManuFactorExists(int id)
        {
            return _context.ManuFactors.Any(e => e.ID == id);
        }
    }
}
