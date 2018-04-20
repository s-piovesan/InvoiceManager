//-----------------------------------------------------------------------
// <copyright file="InvoiceManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les factures
	/// </summary>
	public class InvoiceManager
	{
		/// <summary>
		/// Accès aux données des factures
		/// </summary>
		private InvoiceDAL InvoiceDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="InvoiceManager"/>
		/// </summary>
		public InvoiceManager(MainManager mainManager)
		{
			this.InvoiceDAL = new InvoiceDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des factures
		/// </summary>
		/// <returns>Liste des factures trouvées</returns>
		public IEnumerable<Invoice> List()
		{
			return this.InvoiceDAL.List();
		}

		/// <summary>
		/// Ajout d'un facture
		/// </summary>
		/// <param name="invoice">facture à ajouter</param>
		/// <returns>Vrai si le facture a bien été ajoutée, faux sinon</returns>
		public bool AddInvoice(Invoice invoice)
		{
			return this.InvoiceDAL.Insert(invoice);
		}

		/// <summary>
		/// Mise à jour d'un facture
		/// </summary>
		/// <param name="invoice">facture à modifier</param>
		/// <returns>Vrai si le facture a bien été modifié, faux sinon</returns>
		public bool UpdateInvoice(Invoice invoice)
		{
			return this.InvoiceDAL.Update(invoice);
		}

		/// <summary>
		/// Suppression d'un facture
		/// </summary>
		/// <param name="invoice">facture à supprimer</param>
		/// <returns>Vrai si  le facture a bien été supprimé, faux sinon</returns>
		public bool DeleteInvoice(Invoice invoice)
		{
			return this.InvoiceDAL.Delete(invoice);
		}

	}
}
