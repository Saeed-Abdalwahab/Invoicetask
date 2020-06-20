using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalTask.ViewModels
{
    public class InvoiceDetailsVM
    {
        
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }

        public int UnitID { get; set; }
        public int UnitName { get; set; }
        [Range(.1, double.MaxValue, ErrorMessage = "Invalid Number")]

        public double Price { get; set; }
        [Range(.1, double.MaxValue, ErrorMessage = "Invalid Number")]

        public double Quantity { get; set; }
        public double Total { get; set; }
        [Range(0, 100, ErrorMessage = "Invalid Number")]
        public double Discount { get; set; }
        public double Net { get; set; }
        public int? RowID { get; set; }

    }
}