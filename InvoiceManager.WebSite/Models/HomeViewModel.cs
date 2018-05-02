using System;
using System.ComponentModel;

namespace FacturationWebSite.Models
{
	public class HomeViewModel
	{
		public string Barcode { get; set; }
		public string ProductId { get; set; }
		public string CustomerId { get; set; }
		[DisplayName("Date de livraison")]
		public string DeliveryId { get; set; }
	}
}