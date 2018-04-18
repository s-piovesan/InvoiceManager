using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager.Model;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Dal
{
	public class CustomerDAL
	{
		/// <summary>
		/// Retourne la liste des sociétés
		/// </summary>
		/// <returns>La liste retournée</returns>
		public List<Customer> List()
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Customers.ToList();
			}
		}

		/// <summary>
		/// Retourne le client sélectionnée en fonction de son id
		/// </summary>
		/// <param name="id">Id du client</param>
		/// <returns>Retourne l'objet Customer en fonction de son id</returns>
		public Customer Get(int id)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				return context.Customers.ToList().Find(c => c.CustomerId == id);
			}
		}

		/// <summary>
		/// Insertion de la client
		/// </summary>
		/// <param name="customer">client à insérer</param>
		/// <returns>Succès / échec</returns>
		public bool Insert(Customer customer)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Customers.Add(customer);
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Mise à jour de la société
		/// </summary>
		/// <param name="customer">client à mettre à jour</param>
		/// <returns>Succès / échec</returns>
		public bool Update(Customer customer)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Entry(customer).State = EntityState.Modified;
				return context.SaveChanges() > 0;
			}
		}

		/// <summary>
		/// Suppression de la société
		/// </summary>
		/// <param name="customer">client à supprimer</param>
		/// <returns>Succès / échec</returns>
		public bool Delete(Customer customer)
		{
			using (InvoiceManagerContext context = new InvoiceManagerContext())
			{
				context.Customers.Remove(customer);
				return context.SaveChanges() > 0;
			}
		}


	}
}