using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalTask.Models.DAL
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetails>();
        }
        public int ID { get; set; }
        //[RegularExpression("^[0-9]*[1-9][0-9]*$", ErrorMessage = "Not Valid Number")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Invoice No")]

        public string invoice_No { get; set; }
        [DisplayFormat(DataFormatString= "{0:dd/MM/yyyy}", ApplyFormatInEditMode= true)]
        [Display(Name = "Invoice Date")]

        public DateTime Date { get; set; }
        [Display(Name ="Taxes")]
        public double? invoice_Taxes { get; set; }
        [Display(Name = "Total")]

        public double invoice_Total { get; set; }
        [Display(Name = "Net")]

        public double invoice_Net { get; set; }
        [Display(Name = "Store")]

        public int storeId { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual Store Store { get; set; }

    }
}