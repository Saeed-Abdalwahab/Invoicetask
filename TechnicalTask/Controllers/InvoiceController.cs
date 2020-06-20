using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnicalTask.Models.BLL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceService service = new InvoiceService();
        // GET: Invoice
        public ActionResult Index()
        {

            return View(service.GetAll());
        }
        public ActionResult Create()
        {
            ViewBag.Stores = new SelectList(service.Stores(), "ID", "Name");
            ViewBag.Items = new SelectList(service.items(), "ID", "Name");
            ViewBag.Units = new SelectList(service.units(), "ID", "Name");
            CreatInvoiceVM creatInvoiceVM = new CreatInvoiceVM();
            creatInvoiceVM.InvoiceVM.invoice_No = service.SetInvoiceNumber().ToString();
            return View(creatInvoiceVM);
        }  
        public ActionResult Edit(int id)
        {
            CreatInvoiceVM creatInvoiceVM = new CreatInvoiceVM();
            creatInvoiceVM = service.GetINvoice(id);
            ViewBag.Stores = new SelectList(service.Stores(), "ID", "Name",creatInvoiceVM.InvoiceVM.storeId);
            ViewBag.Items = new SelectList(service.items(), "ID", "Name");
            ViewBag.Units = new SelectList(service.units(), "ID", "Name");
            return View(creatInvoiceVM);
        }
        [HttpPost]
        public ActionResult Create(CreatInvoiceVM creatInvoiceVM)
        {
            
            return service.CreatInvoiceVM(creatInvoiceVM) == true?
                Json(new { Status=true},JsonRequestBehavior.AllowGet):
             Json(new { Status = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckinvoiceNo([Bind(Prefix = "InvoiceVM.invoice_No")]string invoice_No, [Bind(Prefix = "InvoiceVM.ID")]string ID)
        {
            return Json(service.CheckInvoiceNumber(invoice_No, int.Parse(ID)), JsonRequestBehavior.AllowGet);
        }
         public JsonResult Delete(int ID)
        {
            var Check=service.DeleteInvice(ID);
            
            return Json(new { status = Check}, JsonRequestBehavior.AllowGet);
        }
        

    }
}