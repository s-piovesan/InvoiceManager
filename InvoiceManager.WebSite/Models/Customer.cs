//-----------------------------------------------------------------------
// <copyright file="Customer.cs">
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
    [Table("Customer")]
    public class Customer
	{
        /// <summary>
        /// Identifiant unique du client
        /// </summary>
        [Key]
        public int CustomerId { get; set; }

		/// <summary>
		/// Nom du client
		/// </summary>
        [DisplayName("Raison sociale")]
		public string Name { get; set; }

        /// <summary>
        /// Adresse du client
        /// </summary>
        [DisplayName("Adresse")]
        public string address { get; set; }

        /// <summary>
        /// Complément d'adresse du client
        /// </summary>
        [DisplayName("Complément d'adresse")]
        public string address2 { get; set; }

        /// <summary>
        /// Complément d'adresse du client
        /// </summary>
        [DisplayName("Complément d'adresse 2")]
        public string address3 { get; set; }

        /// <summary>
        /// Code postal du client
        /// </summary>
        [DisplayName("Code postal")]
        public string zipcode { get; set; }

        /// <summary>
        /// ville du client
        /// </summary>
        [DisplayName("Ville")]
        public string city { get; set; }
    }
}
