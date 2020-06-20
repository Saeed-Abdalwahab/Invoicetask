using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechnicalTask.Models.DAL
{
    public class Context :DbContext
    {
        public Context():base("AppContext")
        {

        }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

    }
}