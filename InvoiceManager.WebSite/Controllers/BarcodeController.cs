using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturationWebSite.Models;

namespace InvoiceManager.WebSite.Controllers
{
    public class BarcodeController : Controller
    {
        private readonly MvcAppContext _context;

        public BarcodeController(MvcAppContext context)
        {
            _context = context;
        }

        // GET: Barcode
        public async Task<IActionResult> Index()
        {
            var MvcAppContext = _context.Barcode.Include(b => b.Customer).Include(b => b.Product);
            return View(await MvcAppContext.ToListAsync());
        }

        // GET: Barcode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.Barcode
                .Include(b => b.Customer)
                .Include(b => b.Product)
                .SingleOrDefaultAsync(m => m.BarcodeId == id);
            if (barcode == null)
            {
                return NotFound();
            }

            return View(barcode);
        }

        // GET: Barcode/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId");
            return View();
        }

        // POST: Barcode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BarcodeId,CustomerId,ProductId")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId", barcode.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", barcode.ProductId);
            return View(barcode);
        }

        // GET: Barcode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.Barcode.SingleOrDefaultAsync(m => m.BarcodeId == id);
            if (barcode == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId", barcode.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", barcode.ProductId);
            return View(barcode);
        }

        // POST: Barcode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BarcodeId,CustomerId,ProductId")] Barcode barcode)
        {
            if (id != barcode.BarcodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarcodeExists(barcode.BarcodeId))
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
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "CustomerId", barcode.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", barcode.ProductId);
            return View(barcode);
        }

        // GET: Barcode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.Barcode
                .Include(b => b.Customer)
                .Include(b => b.Product)
                .SingleOrDefaultAsync(m => m.BarcodeId == id);
            if (barcode == null)
            {
                return NotFound();
            }

            return View(barcode);
        }

        // POST: Barcode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barcode = await _context.Barcode.SingleOrDefaultAsync(m => m.BarcodeId == id);
            _context.Barcode.Remove(barcode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarcodeExists(int id)
        {
            return _context.Barcode.Any(e => e.BarcodeId == id);
        }
    }
}
