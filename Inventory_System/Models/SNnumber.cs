using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models
{
    public class SNnumber
    {
        public int ID { get; set; }
        [Display(Name ="S/N碼")]
        public string SNnum { get; set; }
        public int ProductID { get; set; }//關聯product外部鍵
        
        [Display(Name ="產品名稱")]
        public Product Product { get; set; }//產生product關聯
    }
}
