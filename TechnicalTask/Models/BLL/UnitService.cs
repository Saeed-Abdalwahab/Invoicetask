using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnicalTask.Models.DAL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Models.BLL
{
    public class UnitService
    {
        private Context db;
        public UnitService()
        {
            db = new Context();
        }

        public List<UnitVM> Getall()
        {
            var UnitsVM = db.Units.Select(x => new UnitVM { ID = x.ID, Name = x.Name }).ToList();
            return UnitsVM;
        }
        public UnitVM Get(int ID)
        {
            var Unit = db.Units.Find(ID);
            UnitVM UnitVM = new UnitVM();
            UnitVM.ID = Unit.ID;
            UnitVM.Name = Unit.Name;
            return UnitVM;
        }

        public bool Save(UnitVM UnitVM)
        {
            try
            {
                Unit Unit = new Unit();
                Unit.Name = UnitVM.Name;
                db.Units.Add(Unit);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(UnitVM UnitVM)
        {
            try
            {
                Unit Unit = db.Units.Find(UnitVM.ID);
                Unit.Name = UnitVM.Name;
                db.Entry(Unit).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool delete(int ID)
        {
            try
            {
                var Unit = db.Units.Find(ID);
                db.Units.Remove(Unit);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool NameCheck(string Name, int ID)
        {
            if (ID == 0)
                return db.Units.FirstOrDefault(x => x.Name == Name) == null ? true : false;
            return db.Units.FirstOrDefault(x => x.Name == Name && x.ID != ID) == null ? true : false;
        }
    }
}