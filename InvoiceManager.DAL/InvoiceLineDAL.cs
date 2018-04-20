using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class InvoiceLineDAL
	{
		/// <summary>
		/// Retourne la liste des lignes de factures
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<InvoiceLine> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.InvoiceLines.ToList();
			}
		}

		/// <summary>
		/// Retourne la ligne de facture sélectionnée en fonction de son id
		/// </summary>
		/// <param name="id">Id de la ligne de facture</param>
		/// <returns>Retourne l'objet InvoiceLine en fonction de son id</returns>
		public InvoiceLine Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.InvoiceLines.ToList().Find(c => c.InvoiceLineId == id);
			}
		}

		/// <summary>
		/// Insertion de  la ligne de facture
		/// </summary>
		/// <param name="InvoiceLine"> ligne de facture à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(InvoiceLine InvoiceLine)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.InvoiceLines.Add(InvoiceLine);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour de la ligne de facture
		/// </summary>
		/// <param name="InvoiceLine">ligne de facture à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(InvoiceLine InvoiceLine)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(InvoiceLine).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression de la ligne de facture
		/// </summary>
		/// <param name="InvoiceLine">ligne de facture à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(InvoiceLine InvoiceLine)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.InvoiceLines.Remove(InvoiceLine);
				return context.SaveChanges() > 0;
			}
		}


	}
}