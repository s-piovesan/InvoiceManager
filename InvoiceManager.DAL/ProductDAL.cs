using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class ProductDAL
	{
		/// <summary>
		/// Retourne la liste des produits
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<Product> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Products.ToList();
			}
		}

		/// <summary>
		/// Retourne le produit sélectionné en fonction de son id
		/// </summary>
		/// <param name="id">Id du client</param>
		/// <returns>Retourne l'objet Product en fonction de son id</returns>
		public Product Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Products.ToList().Find(c => c.ProductId == id);
			}
		}

		/// <summary>
		/// Insertion du produit
		/// </summary>
		/// <param name="Product">produit à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(Product Product)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Products.Add(Product);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour du produit
		/// </summary>
		/// <param name="Product">produit à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(Product Product)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(Product).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression du produit
		/// </summary>
		/// <param name="Product">produit à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(Product Product)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Products.Remove(Product);
				return context.SaveChanges() > 0;
			}
		}


	}
}