using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name = "品名")]
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int ManuFactorID { get; set; }
        public int BatchNumberID { get; set; }
        [Display(Name = "料號")]
        public int PartNumber { get; set; }
        public int WareHouseID { get; set; }
        [Display(Name ="數量")]
        public int TotalNumber { get; set; }

        [Display(Name = "類別")]
        public Category Category { get; set; }
        [Display(Name = "製造商")]
        public ManuFactor ManuFactor { get; set; }
        [Display(Name = "批號")]
        public BatchNumber BatchNumber { get; set; }
        [Display(Name = "存放倉庫")]
        public WareHouse WareHouse { get; set; }
        public ICollection<SNnumber> SNnumber { get; set; }//作為被連結端關聯至SNnumber
    }
}
