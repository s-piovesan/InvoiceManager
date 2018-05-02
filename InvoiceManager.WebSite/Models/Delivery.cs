//-----------------------------------------------------------------------
// <copyright file="Product.cs">
// Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------

namespace FacturationWebSite.Models
{
	using System;
	using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Classe de gestion des campagnes
    /// </summary>
    [Table("Delivery")]
    public class Delivery
	{
		/// <summary>
		/// Identifiant unique de la livraison
		/// </summary>
		[Key]
        public int DeliveryId { get; set; }

        /// <summary>
        /// Description du produit
        /// </summary>
        [DisplayName("Date de livraison")]
        public DateTime Date { get; set; }

		/// <summary>
		/// Status de la livraison
		/// </summary>
		[DisplayName("Etat")]
		public Enum.DeliveryStatus Status { get; set; }
	}
}
