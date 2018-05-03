using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacturationWebSite.Models;
using InvoiceManager.WebSite.Models;

namespace FacturationWebSite.Controllers
{
    public class HomeController : Controller
    {
		private readonly MvcAppContext _context;

		public HomeController(MvcAppContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
			ViewData["DateList"] = _context.Deliveries.OrderBy(d => d.Date).Select(d => new SelectListItem() { Text = d.Date.ToString("D"), Value = d.DeliveryId.ToString() }).ToList();
			ViewData["NearestDate"] = _context.Deliveries.Where(d => d.Date > DateTime.Now).OrderBy(d => d.Date).Select(d => d.DeliveryId).FirstOrDefault();
			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult NewLine(string Barcode, int DeliveryId)
		{
			ReturnObject returnVal = new ReturnObject();

			int barcodeValue = Int32.Parse(Barcode);
			var barcode =  _context.Barcode.SingleOrDefault(b => b.BarcodeId == barcodeValue);
			if (barcode != null) {

				var startMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				var endMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

				var invoice = _context.Invoice.SingleOrDefault(i => i.CustomerId == barcode.CustomerId && i.StartPeriod == startMonth.ToString("dd/MM/yyyy") && i.EndPeriod == endMonth.ToString("dd/MM/yyyy"));
				var product = _context.Product.SingleOrDefault(p => p.ProductId == barcode.ProductId);

				double? price;
				var customer_price = _context.CustomerPrice.SingleOrDefault(cp => cp.CustomerId == barcode.CustomerId && cp.ProductId == barcode.ProductId);
				if (customer_price == null)
				{
					price = product.Price;

				}
				else
				{
					price = customer_price.Price;
				}


				if (invoice != null)
				{
					var invoiceLine = _context.InvoiceLine.SingleOrDefault(il => (il.DeliveryId == DeliveryId) && (barcode.ProductId == il.ProductId) && il.InvoiceId == invoice.InvoiceId);
					if (invoiceLine == null)
					{



						invoiceLine = new InvoiceLine();
						invoiceLine.InvoiceId = invoice.InvoiceId;
						invoiceLine.Price = price.Value;
						invoiceLine.ProductId = barcode.ProductId;
						invoiceLine.Quantity = 1;
						invoiceLine.Description = product.Description;
						invoiceLine.DeliveryId = DeliveryId;
						invoiceLine.CreationDate = DateTime.Now;

						_context.InvoiceLine.Add(invoiceLine);
						_context.SaveChanges();

						returnVal.successMessage = String.Format("Ligne ajoutée dans la facture ref {0} pour le produit {1} quantité : {2} ", invoice.Ref, product.Description, invoiceLine.Quantity );
						returnVal.errorCode = 0;
						returnVal.errorMessage = "";
					}
					else
					{
						invoiceLine.Quantity = invoiceLine.Quantity + 1;

						_context.Update(invoiceLine);
						_context.SaveChanges();

						returnVal.successMessage = String.Format("Ligne mise à jour dans la facture ref {0} pour le produit {1} - nouvelle quantité : {2} ", invoice.Ref, product.Description, invoiceLine.Quantity);
						returnVal.errorCode = 0;
						returnVal.errorMessage = "";
					}
				}
				else
				{
					invoice = new Invoice();

					invoice = new Invoice();
					invoice.Ref = "test";
					invoice.StartPeriod = startMonth.ToString("dd/MM/yyyy");
					invoice.EndPeriod = endMonth.ToString("dd/MM/yyyy");
					invoice.CustomerId = barcode.CustomerId;
					invoice.CreationDate = DateTime.Now;

					_context.Invoice.Add(invoice);
					_context.SaveChanges();

					var invoiceLine = new InvoiceLine();

					invoiceLine = new InvoiceLine();
					invoiceLine.InvoiceId = invoice.InvoiceId;
					invoiceLine.Price = price.Value;
					invoiceLine.ProductId = barcode.ProductId;
					invoiceLine.Quantity = 1;
					invoiceLine.Description = product.Description;
					invoiceLine.DeliveryId = DeliveryId;
					invoiceLine.CreationDate = DateTime.Now;

					_context.InvoiceLine.Add(invoiceLine);
					_context.SaveChanges();

					returnVal.successMessage = String.Format("Ligne ajoutée dans la facture créée ref {0} pour le produit {1} quantité : {2} ", invoice.Ref, product.Description, invoiceLine.Quantity);
					returnVal.errorCode = 0;
					returnVal.errorMessage = "";
				}


			} else {
				returnVal.successMessage = "";
				returnVal.errorCode = 1;
				returnVal.errorMessage = "Code barre non reconnu ";
			}
			
			
			
		
			return Json(returnVal);
		}

		public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
