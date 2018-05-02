//-----------------------------------------------------------------------
// <copyright file="InvoiceLine.cs">
// Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------

namespace FacturationWebSite.Models
{
	using System;
	using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Classe de gestion des lignes de facture
    /// </summary>
    [Table("InvoiceLine")]
    public class InvoiceLine
	{
        /// <summary>
        /// Identifiant unique du client
        /// </summary>
        [Key]
        public int InvoiceLineId { get; set; }

		/// <summary>
		/// Identifiant de la facture
		/// </summary>
		public int InvoiceId { get; set; }

		/// <summary>
		/// Detail de la facture
		/// </summary>
		[ForeignKey("InvoiceId")]
		public Invoice Invoice { get; set; }

		/// <summary>
		/// Identifiant de la livraison
		/// </summary>
		public int DeliveryId { get; set; }

		/// <summary>
		/// Detail de la livraison
		/// </summary>
		[ForeignKey("DeliveryId")]
		public Delivery Delivery { get; set; }

		/// <summary>
		/// Identifiant du produit
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// Detail du produit
		/// </summary>
		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		/// <summary>
		/// Date de création de la ligne de facture
		/// </summary>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Surcharge de la description de la ligne
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Quantité de la ligne
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// prix affiché sur la ligne
		/// </summary>
		public double Price { get; set; }
    }
}
