using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTask.ViewModels
{
    public class CreatInvoiceVM
    {
        public CreatInvoiceVM()
        {
            InvoiceDetailsVMs = new List<InvoiceDetailsVM>();
            InvoiceVM = new InvoiceVM();
        }
        public InvoiceVM InvoiceVM { get; set; }
        public List<InvoiceDetailsVM> InvoiceDetailsVMs { get; set; }
        
    }
}