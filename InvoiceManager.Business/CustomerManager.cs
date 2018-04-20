//-----------------------------------------------------------------------
// <copyright file="CustomerManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les sociétés
	/// </summary>
	public class CustomerManager
	{
		/// <summary>
		/// Accès aux données des sociétés
		/// </summary>
		private CustomerDAL CustomerDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="CustomerManager"/>
		/// </summary>
		public CustomerManager(MainManager mainManager)
		{
			this.CustomerDAL = new CustomerDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des clients
		/// </summary>
		/// <returns>Liste des clients trouvées</returns>
		public IEnumerable<Customer> List()
		{
			return this.CustomerDAL.List();
		}

		/// <summary>
		/// Ajout d'un client
		/// </summary>
		/// <param name="customer">client à ajouter</param>
		/// <returns>Vrai si le client a bien été ajoutée, faux sinon</returns>
		public bool AddCustomer(Customer customer)
		{
			return this.CustomerDAL.Insert(customer);
		}

		/// <summary>
		/// Mise à jour d'un client
		/// </summary>
		/// <param name="customer">Client à modifier</param>
		/// <returns>Vrai si le client a bien été modifié, faux sinon</returns>
		public bool UpdateCustomer(Customer customer)
		{
			return this.CustomerDAL.Update(customer);
		}

		/// <summary>
		/// Suppression d'un client
		/// </summary>
		/// <param name="customer">Client à supprimer</param>
		/// <returns>Vrai si  le client a bien été supprimé, faux sinon</returns>
		public bool DeleteCustomer(Customer customer)
		{
			return this.CustomerDAL.Delete(customer);
		}

	}
}
