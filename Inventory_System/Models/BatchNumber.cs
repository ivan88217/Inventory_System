using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class BatchNumber
    {
        public int ID { get; set; }
        [Display(Name = "批號")]
        public string BatchNum { get; set; }
        [Display(Name = "入庫時間")]
        [DataType(DataType.Date)]
        public DateTime In_Date { get; set; }
        [Display(Name = "到期時間")]
        [DataType(DataType.Date)]
        public DateTime Expired_Date { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
