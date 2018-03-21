using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class ManuFactor
    {
        public int ID { get; set; }
        [Display(Name = "製造商名稱")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
