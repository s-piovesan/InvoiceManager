//-----------------------------------------------------------------------
// <copyright file="Invoice.cs">
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
    [Table("Invoice")]
    public class Invoice
	{
        /// <summary>
        /// Identifiant unique de la facture
        /// </summary>
        [Key]
        public int InvoiceId { get; set; }

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
		/// Référence de la facture
		/// </summary>
		public string Ref { get; set; }

        /// <summary>
        /// Date de création de la facture
        /// </summary>
        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Date de début de la période de facturation 
        /// </summary>
        [DisplayName("Début de période")]
        public string StartPeriod { get; set; }

        /// <summary>
        /// Date de fin de la période de facturation 
        /// </summary>
        [DisplayName("Fin de période")]
        public string EndPeriod { get; set; }

        /// <summary>
        /// Statut de la facture
        /// </summary>
        [DisplayName("Etat")]
        public Enum.InvoiceStatus Status { get; set; }

	}
}
