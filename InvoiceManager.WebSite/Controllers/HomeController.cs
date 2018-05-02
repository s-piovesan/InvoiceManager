using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacturationWebSite.Models;

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
			int barcodeValue = Int32.Parse(Barcode);
			var barcode =  _context.Barcode.SingleOrDefault(b => b.BarcodeId == barcodeValue);
			var invoiceLine = _context.InvoiceLine.SingleOrDefault(il => (il.DeliveryId == DeliveryId) && (barcode.ProductId == il.ProductId) );
			
		
			return View();
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
