using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Models
{
    public class ProductModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; } = null;
        public string[]? Images { get; set; }

        public int? Category { get; set; }
        public int? Type { get; set; }
        public int? Brand { get; set; }
        public int[]? Colors { get; set; }
        public int[]? Sizes { get; set; }
    }
}
