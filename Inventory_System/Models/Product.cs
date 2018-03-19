using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int ManuFactorID { get; set; }
        public int BatchNumberID { get; set; }
        public int PartNumber { get; set; }
        public int WareHouseID { get; set; }

        public Category Category { get; set; }
        public ManuFactor ManuFactor { get; set; }
        public BatchNumber BatchNumber { get; set; }
        public WareHouse WareHouse { get; set; }
        
    }
}
