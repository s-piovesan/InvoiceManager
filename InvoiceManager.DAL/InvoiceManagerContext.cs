//-----------------------------------------------------------------------
// <copyright file="InvoiceManagerContext.cs" >
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------
namespace InvoiceManager.Dal
{
    using InvoiceManager.Model;
	using Microsoft.EntityFrameworkCore;
	using System.Configuration;
	using MySql.Data.EntityFrameworkCore.Extensions;

	/// <summary>
	/// Classe de contexte de HrTraxx
	/// </summary>
	public class InvoiceManagerContext : DbContext
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="InvoiceManagerContext"/>.
        /// </summary>
        public InvoiceManagerContext() : base()
        {
           
        }

        /// <summary>
        /// Accès aux données des clients
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

		/// <summary>
		/// Accès aux données des produits
		/// </summary>
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// Accès aux données des factures
		/// </summary>
		public DbSet<Invoice> Invoices { get; set; }

		/// <summary>
		/// Accès aux données des lignes de facture
		/// </summary>
		public DbSet<InvoiceLine> InvoiceLines { get; set; }

		/// <summary>
		/// Accès aux données des code barres
		/// </summary>
		public DbSet<Barcode> Barcodes { get; set; }

		/// <summary>
		/// Accès aux données des surcharges de prix
		/// </summary>
		public DbSet<CustomerPrice> CustomerPrices { get; set; }
	}
}
