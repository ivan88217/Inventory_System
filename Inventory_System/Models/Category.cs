using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "類別名稱")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
