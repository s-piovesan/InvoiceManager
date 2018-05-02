using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class MvcAppContext : DbContext
    {
        public MvcAppContext (DbContextOptions<MvcAppContext> options)
            : base(options)
        {
        }

        public DbSet<FacturationWebSite.Models.Customer> Customer { get; set; }
        public DbSet<FacturationWebSite.Models.CustomerPrice> CustomerPrice { get; set; }
        public DbSet<FacturationWebSite.Models.Invoice> Invoice { get; set; }
        public DbSet<FacturationWebSite.Models.InvoiceLine> InvoiceLine { get; set; }
        public DbSet<FacturationWebSite.Models.Barcode> Barcode { get; set; }
        public DbSet<FacturationWebSite.Models.Product> Product { get; set; }
		public DbSet<FacturationWebSite.Models.Delivery> Deliveries { get; set; }

}
