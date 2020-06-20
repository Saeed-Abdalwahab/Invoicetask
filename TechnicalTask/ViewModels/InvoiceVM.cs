using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalTask.ViewModels
{
    public class InvoiceVM
    {
        public int ID { get; set; }
        [RegularExpression("^[0-9]*[1-9][0-9]*$", ErrorMessage = "Not Valid Number")]
        [Required(ErrorMessage = "Required")]
        [Remote("CheckinvoiceNo", "Invoice", AdditionalFields = "ID", ErrorMessage ="Number Exist")]
        [Display(Name = "Invoice_No")]
        public string invoice_No { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Invoice_Date")]

        public DateTime Date { get; set; }
        [Display(Name = "Taxes")]

        public double? invoice_Taxes { get; set; }
        [Display(Name = "Total")]

        public double invoice_Total { get; set; }
        [Display(Name = "Net")]

        public double invoice_Net { get; set; }
        [Display(Name = "Store")]

        public int storeId { get; set; }
      


    }
}