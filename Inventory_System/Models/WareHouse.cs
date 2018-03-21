using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class WareHouse
    {
        public int ID { get; set; }
        [Display(Name = "倉庫名")]
        public string Name { get; set; }
        [Display(Name = "倉庫位置")]
        public string Location { get; set; }

        public ICollection <Product> Products { get; set; }
    }
}
