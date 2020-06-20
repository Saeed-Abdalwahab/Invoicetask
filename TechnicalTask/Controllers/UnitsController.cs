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
    public class UnitsController : Controller
    {
        UnitService service = new UnitService();

        // GET: Units
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
        public JsonResult Save(UnitVM UnitVM)
        {
            if (ModelState.IsValid)
            {
                var check = UnitVM.ID > 0 ? service.Edit(UnitVM) : service.Save(UnitVM);
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
