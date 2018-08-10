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
    public class InvoiceController : Controller
    {
        private readonly MvcAppContext _context;

        public InvoiceController(MvcAppContext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var MvcAppContext = _context.Invoice.Include(i => i.Customer);
            return View(await MvcAppContext.ToListAsync());
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Customer)
                .SingleOrDefaultAsync(m => m.InvoiceId == id);

			var invoiceLine = _context.InvoiceLine.Include(il => il.Delivery).Where(il => il.InvoiceId == invoice.InvoiceId && il.Quantity > 0).OrderBy(il=>il.Delivery.Date).ToList();

			if (invoice == null)
            {
                return NotFound();
            }

			var invoiceViewModel = new InvoiceViewModel();

			invoiceViewModel.Invoice = invoice;
			invoiceViewModel.InvoiceLines = invoiceLine;
            invoiceViewModel.Subtotal = invoiceLine.Sum(il => (il.Price * il.Quantity));
            invoiceViewModel.Total = invoiceViewModel.Subtotal + invoiceViewModel.Discount;
            invoiceViewModel.Discount = 0;

			ViewData["DateList"] = _context.Deliveries.Where(d => d.Date >= DateTime.Parse(invoice.StartPeriod) && d.Date <= DateTime.Parse(invoice.EndPeriod)).OrderBy(d => d.Date).Select(d => new SelectListItem() { Text = d.Date.ToString("D"), Value = d.DeliveryId.ToString() }).ToList();
			ViewData["NearestDate"] = _context.Deliveries.Where(d => d.Date > DateTime.Now).OrderBy(d => d.Date).Select(d => d.DeliveryId).FirstOrDefault();


			return View(invoiceViewModel);
        }

		

// GET: Invoice/Print
[ViewLayout("_PrintLayout")]
		public async Task<IActionResult> Print(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var invoice = await _context.Invoice
				.Include(i => i.Customer)
				.SingleOrDefaultAsync(m => m.InvoiceId == id);

			var invoiceLine = _context.InvoiceLine.Include(il => il.Delivery).Where(il => il.InvoiceId == invoice.InvoiceId && il.Quantity > 0).OrderBy(il => il.Delivery.Date).ToList();

			if (invoice == null)
			{
				return NotFound();
			}

			var invoiceViewModel = new InvoiceViewModel();

			invoiceViewModel.Invoice = invoice;
			invoiceViewModel.InvoiceLines = invoiceLine;
			invoiceViewModel.Subtotal = invoiceLine.Sum(il => (il.Price * il.Quantity));
			invoiceViewModel.Total = invoiceViewModel.Subtotal + invoiceViewModel.Discount;
			invoiceViewModel.Discount = 0;

			return View(invoiceViewModel);
		}
		

		// GET: Invoice/Create
		public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,CustomerId,Ref,CreationDate,StartPeriod,EndPeriod,Status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.SingleOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,CustomerId,Ref,CreationDate,StartPeriod,EndPeriod,Status")] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceId))
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
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Customer)
                .SingleOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.SingleOrDefaultAsync(m => m.InvoiceId == id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.InvoiceId == id);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewLine(int DeliveryId, string Description, double Price, int Quantity, int InvoiceId)
		{
			InvoiceLine returnVal = new InvoiceLine();

			returnVal.InvoiceId = InvoiceId;
			returnVal.DeliveryId = DeliveryId;
			returnVal.CreationDate = DateTime.Now;
			returnVal.Description = Description;
			returnVal.Quantity = Quantity;
			returnVal.Price = Price;

			_context.InvoiceLine.Add(returnVal);
			_context.SaveChanges();


			return Json(returnVal);
		}

		[HttpPost]
		public async Task<IActionResult> ModifyLine(int InvoiceLineId, int Quantity)
		{
			var InvoiceLine = _context.InvoiceLine.FirstOrDefault(il => il.InvoiceLineId == InvoiceLineId);

			if (InvoiceLine != null)
			{
				InvoiceLine.Quantity = Quantity;

				_context.Update(InvoiceLine);
				await _context.SaveChangesAsync();
			}

			return Json(true);

		}
	}
}
