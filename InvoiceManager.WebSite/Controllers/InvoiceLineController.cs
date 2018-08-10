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
    public class InvoiceLineController : Controller
    {
        private readonly MvcAppContext _context;

        public InvoiceLineController(MvcAppContext context)
        {
            _context = context;
        }

        // GET: InvoiceLine
        public async Task<IActionResult> Index()
        {
            var MvcAppContext = _context.InvoiceLine.Include(i => i.Invoice).Include(i => i.Product);
            return View(await MvcAppContext.ToListAsync());
        }

        // GET: InvoiceLine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLine
                .Include(i => i.Invoice)
                .Include(i => i.Product)
                .SingleOrDefaultAsync(m => m.InvoiceLineId == id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            return View(invoiceLine);
        }

        // GET: InvoiceLine/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Set<Invoice>(), "InvoiceId", "InvoiceId");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId");
            return View();
        }

        // POST: InvoiceLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceLineId,InvoiceId,ProductId,CreationDate,Description,Quantity,Price")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Set<Invoice>(), "InvoiceId", "InvoiceId", invoiceLine.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", invoiceLine.ProductId);
            return View(invoiceLine);
        }

        // GET: InvoiceLine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLine.SingleOrDefaultAsync(m => m.InvoiceLineId == id);
            if (invoiceLine == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Set<Invoice>(), "InvoiceId", "InvoiceId", invoiceLine.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", invoiceLine.ProductId);
            return View(invoiceLine);
        }

        // POST: InvoiceLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceLineId,InvoiceId,ProductId,CreationDate,Description,Quantity,Price")] InvoiceLine invoiceLine)
        {
            if (id != invoiceLine.InvoiceLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceLineExists(invoiceLine.InvoiceLineId))
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
            ViewData["InvoiceId"] = new SelectList(_context.Set<Invoice>(), "InvoiceId", "InvoiceId", invoiceLine.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", invoiceLine.ProductId);
            return View(invoiceLine);
        }

        // GET: InvoiceLine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceLine = await _context.InvoiceLine
                .Include(i => i.Invoice)
                .Include(i => i.Product)
                .SingleOrDefaultAsync(m => m.InvoiceLineId == id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            return View(invoiceLine);
        }

        // POST: InvoiceLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceLine = await _context.InvoiceLine.SingleOrDefaultAsync(m => m.InvoiceLineId == id);
            _context.InvoiceLine.Remove(invoiceLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceLineExists(int id)
        {
            return _context.InvoiceLine.Any(e => e.InvoiceLineId == id);
        }

		
	}
}
