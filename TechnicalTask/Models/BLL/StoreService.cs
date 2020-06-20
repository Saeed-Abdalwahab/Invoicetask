using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnicalTask.Models.DAL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Models.BLL
{
    public class StoreService
    {
        private Context db;
        public StoreService()
        {
            db = new Context();
        }

        public List<StoreVM> Getall()
        {
            var StoresVM = db.Stores.Select(x => new StoreVM { ID = x.ID, Name = x.Name }).ToList();
            return StoresVM;
        }
        public StoreVM Get(int ID)
        {
            var Store = db.Stores.Find(ID);
            StoreVM StoreVM = new StoreVM();
            StoreVM.ID = Store.ID;
            StoreVM.Name = Store.Name;
            return StoreVM;
        }

        public bool Save(StoreVM StoreVM)
        {
            try
            {
                Store Store = new Store();
                Store.Name = StoreVM.Name;
                db.Stores.Add(Store);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(StoreVM StoreVM)
        {
            try
            {
                Store Store = db.Stores.Find(StoreVM.ID);
                Store.Name = StoreVM.Name;
                db.Entry(Store).State = EntityState.Modified;
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
                var Store = db.Stores.Find(ID);
                db.Stores.Remove(Store);
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
                return db.Stores.FirstOrDefault(x => x.Name == Name) == null ? true : false;
            return db.Stores.FirstOrDefault(x => x.Name == Name && x.ID != ID) == null ? true : false;
        }
    }
}