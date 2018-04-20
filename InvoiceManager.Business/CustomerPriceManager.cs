//-----------------------------------------------------------------------
// <copyright file="CustomerPriceManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les surcharges de prix
	/// </summary>
	public class CustomerPriceManager
	{
		/// <summary>
		/// Accès aux données des surcharges de prix
		/// </summary>
		private CustomerPriceDAL CustomerPriceDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="CustomerPriceManager"/>
		/// </summary>
		public CustomerPriceManager(MainManager mainManager)
		{
			this.CustomerPriceDAL = new CustomerPriceDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des surcharges de prix
		/// </summary>
		/// <returns>Liste des surcharges de prix trouvées</returns>
		public IEnumerable<CustomerPrice> List()
		{
			return this.CustomerPriceDAL.List();
		}

		/// <summary>
		/// Ajout d'un surcharge de prix
		/// </summary>
		/// <param name="customerPrice">surcharge de prix à ajouter</param>
		/// <returns>Vrai si le surcharge de prix a bien été ajoutée, faux sinon</returns>
		public bool AddCustomerPrice(CustomerPrice customerPrice)
		{
			return this.CustomerPriceDAL.Insert(customerPrice);
		}

		/// <summary>
		/// Mise à jour d'un surcharge de prix
		/// </summary>
		/// <param name="customerPrice">surcharge de prix à modifier</param>
		/// <returns>Vrai si le surcharge de prix a bien été modifié, faux sinon</returns>
		public bool UpdateCustomerPrice(CustomerPrice customerPrice)
		{
			return this.CustomerPriceDAL.Update(customerPrice);
		}

		/// <summary>
		/// Suppression d'un surcharge de prix
		/// </summary>
		/// <param name="customerPrice">surcharge de prix à supprimer</param>
		/// <returns>Vrai si  le surcharge de prix a bien été supprimé, faux sinon</returns>
		public bool DeleteCustomerPrice(CustomerPrice customerPrice)
		{
			return this.CustomerPriceDAL.Delete(customerPrice);
		}

	}
}
