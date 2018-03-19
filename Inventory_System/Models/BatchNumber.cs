using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class BatchNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string BatchNum { get; set; }
        public DateTime In_Date { get; set; }
        public DateTime Expired_Date { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
