﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public string Category { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
