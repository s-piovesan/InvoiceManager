//-----------------------------------------------------------------------
// <copyright file="InvoiceLineManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les ligne de facture
	/// </summary>
	public class InvoiceLineManager
	{
		/// <summary>
		/// Accès aux données des ligne de facture
		/// </summary>
		private InvoiceLineDAL InvoiceLineDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="InvoiceLineManager"/>
		/// </summary>
		public InvoiceLineManager(MainManager mainManager)
		{
			this.InvoiceLineDAL = new InvoiceLineDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des ligne de facture
		/// </summary>
		/// <returns>Liste des ligne de facture trouvées</returns>
		public IEnumerable<InvoiceLine> List()
		{
			return this.InvoiceLineDAL.List();
		}

		/// <summary>
		/// Ajout d'un ligne de facture
		/// </summary>
		/// <param name="invoiceLine">ligne de facture à ajouter</param>
		/// <returns>Vrai si le ligne de facture a bien été ajoutée, faux sinon</returns>
		public bool AddInvoiceLine(InvoiceLine invoiceLine)
		{
			return this.InvoiceLineDAL.Insert(invoiceLine);
		}

		/// <summary>
		/// Mise à jour d'un ligne de facture
		/// </summary>
		/// <param name="invoiceLine">ligne de facture à modifier</param>
		/// <returns>Vrai si le ligne de facture a bien été modifié, faux sinon</returns>
		public bool UpdateInvoiceLine(InvoiceLine invoiceLine)
		{
			return this.InvoiceLineDAL.Update(invoiceLine);
		}

		/// <summary>
		/// Suppression d'un ligne de facture
		/// </summary>
		/// <param name="invoiceLine">ligne de facture à supprimer</param>
		/// <returns>Vrai si  le ligne de facture a bien été supprimé, faux sinon</returns>
		public bool DeleteInvoiceLine(InvoiceLine invoiceLine)
		{
			return this.InvoiceLineDAL.Delete(invoiceLine);
		}

	}
}
