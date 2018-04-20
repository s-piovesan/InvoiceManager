using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class InvoiceDAL
	{
		/// <summary>
		/// Retourne la liste des factures
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<Invoice> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Invoices.ToList();
			}
		}

		/// <summary>
		/// Retourne le facture sélectionnée en fonction de son id
		/// </summary>
		/// <param name="id">Id du facture</param>
		/// <returns>Retourne l'objet Invoice en fonction de son id</returns>
		public Invoice Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Invoices.ToList().Find(c => c.InvoiceId == id);
			}
		}

		/// <summary>
		/// Insertion de la facture
		/// </summary>
		/// <param name="Invoice">facture à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(Invoice Invoice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Invoices.Add(Invoice);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour de la facture
		/// </summary>
		/// <param name="Invoice">facture à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(Invoice Invoice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(Invoice).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression de la facture
		/// </summary>
		/// <param name="Invoice">facture à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(Invoice Invoice)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Invoices.Remove(Invoice);
				return context.SaveChanges() > 0;
			}
		}


	}
}