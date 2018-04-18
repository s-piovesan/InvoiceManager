//-----------------------------------------------------------------------
// <copyright file="InvoiceManager.cs">
//     Sébastien PIOVESAN ©.
// </copyright>
//-----------------------------------------------------------------------
namespace InvoiceManager.Business
{
	/// <summary>
	/// Gestion global des méthodes métier
	/// </summary>
	public class MainManager
	{
		/// <summary>
		/// Initialise une nouvelle instance de la classe <see cref="MainManager" />.
		/// </summary>
		public MainManager()
		{
		}

		/// <summary>
		/// Accès aux méthodes métiers des clients
		/// </summary>
		public CustomerManager CustomerManager
		{
			get
			{
				return new CustomerManager(this);
			}
		}


	}
}
