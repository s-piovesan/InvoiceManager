using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FacturationWebSite.Models
{
	public class InvoiceViewModel
	{
		public Invoice Invoice { get; set; }
		public List<InvoiceLine> InvoiceLines { get; set; }
		public double Total { get; set; }
        public double Subtotal { get; set; }
        public double Discount { get; set; }


		public string Description { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public int InvoiceId { get; set; }
		public int DeliveryId { get; set; }
	}
}