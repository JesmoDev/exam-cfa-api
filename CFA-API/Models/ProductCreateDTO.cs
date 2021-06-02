using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Models
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string[] Images { get; set; }

        [Required]
        public int? Supplier { get; set; }
        [Required]
        public int? Category { get; set; }
        [Required]
        public int? Type { get; set; }
        [Required]
        public int? Brand { get; set; }
        [Required]
        public int[] Colors { get; set; }
        [Required]
        public int[] Sizes { get; set; }
    }
}
