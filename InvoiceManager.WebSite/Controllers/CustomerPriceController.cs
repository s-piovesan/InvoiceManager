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
    public class CustomerPriceController : Controller
    {
        private readonly MvcAppContext _context;

        public CustomerPriceController(MvcAppContext context)
        {
            _context = context;
        }

        // GET: CustomerPrice
        public async Task<IActionResult> Index()
        {
            var MvcAppContext = _context.CustomerPrice.Include(c => c.Customer).Include(c => c.Product);
            return View(await MvcAppContext.ToListAsync());
        }

        // GET: CustomerPrice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPrice = await _context.CustomerPrice
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(m => m.CustomerPriceId == id);
            if (customerPrice == null)
            {
                return NotFound();
            }

            return View(customerPrice);
        }

        // GET: CustomerPrice/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "Description");
            return View();
        }

        // POST: CustomerPrice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerPriceId,CustomerId,ProductId,Price")] CustomerPrice customerPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", customerPrice.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "Description", customerPrice.ProductId);
            return View(customerPrice);
        }

        // GET: CustomerPrice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPrice = await _context.CustomerPrice.SingleOrDefaultAsync(m => m.CustomerPriceId == id);
            if (customerPrice == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", customerPrice.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "Description", customerPrice.ProductId);
            return View(customerPrice);
        }

        // POST: CustomerPrice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerPriceId,CustomerId,ProductId,Price")] CustomerPrice customerPrice)
        {
            if (id != customerPrice.CustomerPriceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPriceExists(customerPrice.CustomerPriceId))
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
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", customerPrice.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "Description", customerPrice.ProductId);
            return View(customerPrice);
        }

        // GET: CustomerPrice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPrice = await _context.CustomerPrice
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(m => m.CustomerPriceId == id);
            if (customerPrice == null)
            {
                return NotFound();
            }

            return View(customerPrice);
        }

        // POST: CustomerPrice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerPrice = await _context.CustomerPrice.SingleOrDefaultAsync(m => m.CustomerPriceId == id);
            _context.CustomerPrice.Remove(customerPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerPriceExists(int id)
        {
            return _context.CustomerPrice.Any(e => e.CustomerPriceId == id);
        }
    }
}
