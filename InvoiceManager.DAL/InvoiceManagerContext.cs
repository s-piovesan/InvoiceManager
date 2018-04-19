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


    }
}
