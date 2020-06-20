using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalTask.ViewModels
{
    public class StoreVM
    {
        public int ID { get; set; }
        [Required]
        [Remote("NameExist", "Stores", AdditionalFields = "ID", ErrorMessage = "NameAlreadyExist")]

        public string Name { get; set; }
    }
}