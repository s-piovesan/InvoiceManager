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
	}
}