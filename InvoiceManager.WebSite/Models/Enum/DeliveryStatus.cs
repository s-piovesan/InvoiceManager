//-----------------------------------------------------------------------
// <copyright file="DeliveryStatus.cs">
//    Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------
namespace FacturationWebSite.Models.Enum
{
    /// <summary>
    /// Énumérateur des différents états d'une livraison
    /// </summary>
    public enum DeliveryStatus
    {
        /// <summary>
        /// Livraison en attente
        /// </summary>
        Pending = 0,

		/// <summary>
		/// Livraison facturée
		/// </summary>
		Archived = 1,

    }
}
