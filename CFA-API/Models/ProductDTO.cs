﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Models
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string[] Images { get; set; }

        public string Category { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public string[] Colors { get; set; }
        public string[] Sizes { get; set; }
    }
}