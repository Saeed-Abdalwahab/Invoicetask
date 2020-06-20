using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTask.Models.DAL
{
    public class Store
    {
        public Store()
        {
            Invoices = new List<Invoice>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Invoice> Invoices { get; set; }

    }
}