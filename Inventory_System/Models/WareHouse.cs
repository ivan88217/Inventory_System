﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class WareHouse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection <Product> Products { get; set; }
    }
}