using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTask.Models.DAL
{
    public class InvoiceDetails
    {
        public int ID { get; set; }
        public int invoiceID { get; set; }
        public int itemID { get; set; }
        public int UnitID { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double Net { get; set; }
        public virtual Invoice invoice { get; set; }
        public virtual Item Item { get; set; }
        public virtual Unit Unit { get; set; }
    }
}