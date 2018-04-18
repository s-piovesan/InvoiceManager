//-----------------------------------------------------------------------
// <copyright file="Product.cs">
// Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------

namespace InvoiceManager.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Classe de gestion des campagnes
    /// </summary>
    [Table("Product")]
    public class Product
	{
		/// <summary>
		/// Identifiant unique du produit
		/// </summary>
		[Key]
        public int ProductId { get; set; }

		/// <summary>
		/// Description du produit
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Prix du produit
		/// </summary>
		public double Price { get; set; }
    }
}
