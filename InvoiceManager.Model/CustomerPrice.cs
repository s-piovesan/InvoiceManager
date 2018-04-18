﻿//-----------------------------------------------------------------------
// <copyright file="CustomerPrice.cs">
// Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------

namespace InvoiceManager.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Classe de gestion des surcharges de prix
    /// </summary>
    [Table("CustomerPrice")]
    public class CustomerPrice
	{
		/// <summary>
		/// Identifiant unique de la surcharge de prix
		/// </summary>
		[Key]
        public int CustomerPriceId { get; set; }

		/// <summary>
		/// Identifiant du client
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// Detail du client
		/// </summary>
		[ForeignKey("CustomerId")]
		public Customer Customer { get; set; }

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
		/// Prix de la surcharge
		/// </summary>
		public double Price { get; set; }
	}
}
