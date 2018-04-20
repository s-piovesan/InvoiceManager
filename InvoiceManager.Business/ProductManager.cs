//-----------------------------------------------------------------------
// <copyright file="ProductManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using InvoiceManager.Dal;
using InvoiceManager.Model;

namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion des méthodes métiers sur les produits
	/// </summary>
	public class ProductManager
	{
		/// <summary>
		/// Accès aux données des produits
		/// </summary>
		private ProductDAL ProductDAL;


		/// <summary>
		/// Accès aux méthodes métiers globales
		/// </summary>
		private MainManager mainManager;

		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="ProductManager"/>
		/// </summary>
		public ProductManager(MainManager mainManager)
		{
			this.ProductDAL = new ProductDAL();
			this.mainManager = mainManager;
		}

		/// <summary>
		/// Récupération de la liste des produits
		/// </summary>
		/// <returns>Liste des produits trouvées</returns>
		public IEnumerable<Product> List()
		{
			return this.ProductDAL.List();
		}

		/// <summary>
		/// Ajout d'un produit
		/// </summary>
		/// <param name="product">produit à ajouter</param>
		/// <returns>Vrai si le produit a bien été ajoutée, faux sinon</returns>
		public bool AddProduct(Product product)
		{
			return this.ProductDAL.Insert(product);
		}

		/// <summary>
		/// Mise à jour d'un produit
		/// </summary>
		/// <param name="product">Produit à modifier</param>
		/// <returns>Vrai si le produit a bien été modifié, faux sinon</returns>
		public bool UpdateProduct(Product Product)
		{
			return this.ProductDAL.Update(Product);
		}

		/// <summary>
		/// Suppression d'un produit
		/// </summary>
		/// <param name="product">Produit à supprimer</param>
		/// <returns>Vrai si  le produit a bien été supprimé, faux sinon</returns>
		public bool DeleteProduct(Product product)
		{
			return this.ProductDAL.Delete(product);
		}

	}
}
