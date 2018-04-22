//-----------------------------------------------------------------------
// <copyright file="BarCode.cs">
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
    /// Classe de gestion des codes barres
    /// </summary>
    [Table("Barcode")]
    public class Barcode
	{
        /// <summary>
        /// Identifiant unique du code barre
        /// </summary>
        [Key]
        public int BarcodeId { get; set; }

		/// <summary>
		/// Identifiant du client
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// Detail du client
		/// </summary>
		[ForeignKey("CustomerId")]
        [DisplayName("Client")]
        public Customer Customer { get; set; }

		/// <summary>
		/// Identifiant du produit
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// Detail du produit
		/// </summary>
		[ForeignKey("ProductId")]
        [DisplayName("Produit")]
        public Product Product { get; set; }

    }
}
