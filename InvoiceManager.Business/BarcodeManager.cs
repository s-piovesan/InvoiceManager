//-----------------------------------------------------------------------
// <copyright file="BarcodeManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les codebarres
	/// </summary>
	public class BarcodeManager
	{
		/// <summary>
		/// Accès aux données des codebarres
		/// </summary>
		private BarcodeDAL BarcodeDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="BarcodeManager"/>
		/// </summary>
		public BarcodeManager(MainManager mainManager)
		{
			this.BarcodeDAL = new BarcodeDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des codebarres
		/// </summary>
		/// <returns>Liste des codebarres trouvées</returns>
		public IEnumerable<Barcode> List()
		{
			return this.BarcodeDAL.List();
		}

		/// <summary>
		/// Ajout d'un codebarre
		/// </summary>
		/// <param name="barcode">codebarre à ajouter</param>
		/// <returns>Vrai si le codebarre a bien été ajoutée, faux sinon</returns>
		public bool AddBarcode(Barcode barcode)
		{
			return this.BarcodeDAL.Insert(barcode);
		}

		/// <summary>
		/// Mise à jour d'un codebarre
		/// </summary>
		/// <param name="barcode">codebarre à modifier</param>
		/// <returns>Vrai si le codebarre a bien été modifié, faux sinon</returns>
		public bool UpdateBarcode(Barcode barcode)
		{
			return this.BarcodeDAL.Update(barcode);
		}

		/// <summary>
		/// Suppression d'un codebarre
		/// </summary>
		/// <param name="barcode">codebarre à supprimer</param>
		/// <returns>Vrai si  le codebarre a bien été supprimé, faux sinon</returns>
		public bool DeleteBarcode(Barcode barcode)
		{
			return this.BarcodeDAL.Delete(barcode);
		}

	}
}
