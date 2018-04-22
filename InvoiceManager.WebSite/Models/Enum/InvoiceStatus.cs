//-----------------------------------------------------------------------
// <copyright file="InvoiceStatus.cs">
//    Sébastien PIOVESAN
// </copyright>
//-----------------------------------------------------------------------
namespace FacturationWebSite.Models.Enum
{
    /// <summary>
    /// Énumérateur des différents états d'une facture
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// Élément actif
        /// </summary>
        Active = 0,

        /// <summary>
        /// Élément archivé
        /// </summary>
        Archived = 1,

        /// <summary>
        /// Élément supprimé
        /// </summary>
        Deleted = 2
    }
}
