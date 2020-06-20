using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnicalTask.Models.BLL;
using TechnicalTask.Models.DAL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Controllers
{
    public class StoresController : Controller
    {
        StoreService service = new StoreService();

        // GET: Stores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Getall()
        {
            return Json(new { data = service.Getall() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(service.Get(ID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Save(StoreVM StoreVM)
        {
            if (ModelState.IsValid)
            {
                var check = StoreVM.ID > 0 ? service.Edit(StoreVM) : service.Save(StoreVM);
                return Json(new { status = check }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Delete(int ID)
        {

            return Json(new { status = service.delete(ID) }, JsonRequestBehavior.AllowGet);

        }
        //Check Name Exist or Not
        public JsonResult NameExist(string Name, string ID)
        {
            return Json(service.NameCheck(Name, int.Parse(ID)), JsonRequestBehavior.AllowGet);
        }
    }
}
