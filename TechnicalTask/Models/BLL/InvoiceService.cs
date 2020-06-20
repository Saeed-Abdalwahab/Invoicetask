using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnicalTask.Models.DAL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Models.BLL
{
    public class InvoiceService
    {
        Context db = new Context();
        public IEnumerable<Invoice> GetAll()
        {
            return db.Invoices.ToList();
        }
         public CreatInvoiceVM GetINvoice(int id)
        {
            CreatInvoiceVM creatInvoiceVM = new CreatInvoiceVM();
          var invoice=  db.Invoices.Find(id) ;
          var invoiceDetails=  db.InvoiceDetails.Where(x=>x.invoiceID==id) ;
            creatInvoiceVM.InvoiceVM.ID = invoice.ID;
            creatInvoiceVM.InvoiceVM.Date = invoice.Date;
            creatInvoiceVM.InvoiceVM.invoice_Net = invoice.invoice_Net;
            creatInvoiceVM.InvoiceVM.invoice_No = invoice.invoice_No;
            creatInvoiceVM.InvoiceVM.invoice_Taxes = invoice.invoice_Taxes;
            creatInvoiceVM.InvoiceVM.invoice_Total = invoice.invoice_Total;
            creatInvoiceVM.InvoiceVM.storeId = invoice.storeId;
            creatInvoiceVM.InvoiceDetailsVMs = invoiceDetails.Select(x => new InvoiceDetailsVM
            {
                Discount = x.Discount,
                ID=x.ID,
                InvoiceID=x.invoiceID,
                ItemID=x.itemID,
                ItemName=x.Item.Name,
                Net=x.Net,
                Price=x.Price,
                Quantity=x.Quantity,
                Total=x.Total,
                UnitID=x.UnitID,
                UnitName=x.UnitID
            }).ToList();
            return creatInvoiceVM;
        }

        public bool CreatInvoiceVM(CreatInvoiceVM creatInvoiceVM)
        {
            var obj= db.Database.BeginTransaction();
            
            try
            {

                Invoice invoice = new Invoice();
                invoice.Date = creatInvoiceVM.InvoiceVM.Date;
                invoice.invoice_Taxes = creatInvoiceVM.InvoiceVM.invoice_Taxes;
                invoice.invoice_Total =Math.Round(creatInvoiceVM.InvoiceVM.invoice_Total,2);
                invoice.invoice_Net = Math.Round(creatInvoiceVM.InvoiceVM.invoice_Net,2);
                invoice.invoice_No = creatInvoiceVM.InvoiceVM.invoice_No;
                invoice.storeId = creatInvoiceVM.InvoiceVM.storeId;
                db.Invoices.Add(invoice);
                db.SaveChanges();
                var InvoiceDetails = creatInvoiceVM.InvoiceDetailsVMs.Select(x => new InvoiceDetails
                {
                    invoiceID = invoice.ID,
                    Discount = x.Discount,
                    itemID = x.ItemID,
                    Net = Math.Round(x.Net,2),
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Total = Math.Round(x.Total,2),
                    UnitID = x.UnitID
                }).ToList();
                db.InvoiceDetails.AddRange(InvoiceDetails);
                db.SaveChanges();
                obj.Commit();
                return true;
            }
            catch
            {
                obj.Rollback();
                return false;
            }
        }
        public bool DeleteInvice(int id)
        {
            var obj = db.Database.BeginTransaction();

            try
            {

                var RemovedInvoiceDetails = db.InvoiceDetails.Where(x => x.invoiceID == id).ToList();
                if (RemovedInvoiceDetails.Count > 0) { 
                db.InvoiceDetails.RemoveRange(RemovedInvoiceDetails);
                db.SaveChanges();
                }
                var RemovedInvoice = db.Invoices.Find(id);
                if(RemovedInvoice != null) { 
                db.Invoices.Remove(RemovedInvoice);
                db.SaveChanges();
                }
                obj.Commit();
                return true;
            }
            catch
            {
                obj.Rollback();
                return false;
            }
        }

        #region Methods
        public int SetInvoiceNumber()
        {
            var Lastinvoice = db.Invoices.ToList().LastOrDefault();
            return Lastinvoice == null ? 1 : int.Parse(Lastinvoice.invoice_No)+ 1;

        }
        public List<Store> Stores()
        {
            return db.Stores.ToList();
        }
        public List<Item> items()
        {
            return db.Items.ToList();
        }
          public List<Unit> units()
        {
            return db.Units.ToList();
        }
        public bool CheckInvoiceNumber(string InvoiceNo,int iD)
        {
            if (iD == 0)
                return db.Invoices.FirstOrDefault(x => x.invoice_No == InvoiceNo) == null ? true : false ;
                return db.Invoices.FirstOrDefault(x => x.invoice_No == InvoiceNo && x.ID!=iD) == null ? true : false ;

        }
        #endregion

    }
}