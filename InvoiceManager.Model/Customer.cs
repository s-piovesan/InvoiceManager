//-----------------------------------------------------------------------
// <copyright file="Customer.cs">
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
		public string Name { get; set; }

		/// <summary>
		/// Adresse du client
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// Complément d'adresse du client
		/// </summary>
		public string address2 { get; set; }

		/// <summary>
		/// Complément d'adresse du client
		/// </summary>
		public string address3 { get; set; }

		/// <summary>
		/// Code postal du client
		/// </summary>
		public string zipcode { get; set; }

		/// <summary>
		/// ville du client
		/// </summary>
		public string city { get; set; }
    }
}
