using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class CustomerPriceDAL
	{
		/// <summary>
		/// Retourne la liste des sociétés
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<CustomerPrice> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.CustomerPrices.ToList();
			}
		}

		/// <summary>
		/// Retourne la surcharge de prix sélectionnée en fonction de son id
		/// </summary>
		/// <param name="id">Id du surcharge de prix</param>
		/// <returns>Retourne l'objet CustomerPrice en fonction de son id</returns>
		public CustomerPrice Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.CustomerPrices.ToList().Find(c => c.CustomerPriceId == id);
			}
		}

		/// <summary>
		/// Insertion de la surcharge de prix
		/// </summary>
		/// <param name="CustomerPrice">surcharge de prix à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(CustomerPrice CustomerPrice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.CustomerPrices.Add(CustomerPrice);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour de la société
		/// </summary>
		/// <param name="CustomerPrice">surcharge de prix à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(CustomerPrice CustomerPrice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(CustomerPrice).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression de la société
		/// </summary>
		/// <param name="CustomerPrice">surcharge de prix à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(CustomerPrice CustomerPrice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.CustomerPrices.Remove(CustomerPrice);
				return context.SaveChanges() > 0;
			}
		}


	}
}