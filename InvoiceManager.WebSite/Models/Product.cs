//-----------------------------------------------------------------------
// <copyright file="Product.cs">
// Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------

namespace FacturationWebSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Prix du produit
        /// </summary>
        [DisplayName("Prix")]
        public double Price { get; set; }
    }
}
