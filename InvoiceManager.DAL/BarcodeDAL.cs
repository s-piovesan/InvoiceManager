using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class BarcodeDAL
	{
		/// <summary>
		/// Retourne la liste des codes barres
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<Barcode> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Barcodes.ToList();
			}
		}

		/// <summary>
		/// Retourne le code barre sélectionnée en fonction de son id
		/// </summary>
		/// <param name="id">Id du code barre</param>
		/// <returns>Retourne l'objet Barcode en fonction de son id</returns>
		public Barcode Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Barcodes.ToList().Find(c => c.BarcodeId == id);
			}
		}

		/// <summary>
		/// Insertion du code barre
		/// </summary>
		/// <param name="Barcode">code barre à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(Barcode Barcode)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Barcodes.Add(Barcode);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour du code barre
		/// </summary>
		/// <param name="Barcode">code barre à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(Barcode Barcode)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(Barcode).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression du code barre
		/// </summary>
		/// <param name="Barcode">code barre à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(Barcode Barcode)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Barcodes.Remove(Barcode);
				return context.SaveChanges() > 0;
			}
		}


	}
}