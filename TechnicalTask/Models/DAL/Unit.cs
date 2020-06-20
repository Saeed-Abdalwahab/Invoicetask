using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalTask.Models.DAL
{
    public class Unit
    {
        public Unit()
        {
            InvoiceDetails = new List<InvoiceDetails>();
        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

    }
}