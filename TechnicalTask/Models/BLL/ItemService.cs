using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnicalTask.Models.DAL;
using TechnicalTask.ViewModels;

namespace TechnicalTask.Models.BLL
{
    public class ItemService
    {
      private  Context db;
        public ItemService()
        {
           db = new Context();
        }

        public List<itemVM> Getall()
        {
            var ItemsVM = db.Items.Select(x => new itemVM { ID = x.ID, Name = x.Name }).ToList();
            return ItemsVM;
        }
        public itemVM Get(int ID)
        {
            var item = db.Items.Find(ID);
            itemVM itemVM = new itemVM();
            itemVM.ID = item.ID;
            itemVM.Name = item.Name;
            return itemVM;
        }

        public bool Save(itemVM itemVM)
        {
            try
            {
                Item item = new Item();
                item.Name = itemVM.Name;
                db.Items.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(itemVM itemVM)
        {
            try { 
            Item item = db.Items.Find(itemVM.ID);
            item.Name = itemVM.Name;
            db.Entry(item).State = EntityState.Modified;
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
                var item = db.Items.Find(ID);
                db.Items.Remove(item);
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
                return db.Items.FirstOrDefault(x => x.Name == Name) == null ? true : false;
            return db.Items.FirstOrDefault(x => x.Name == Name && x.ID != ID) == null ? true : false;
        }
    }
}