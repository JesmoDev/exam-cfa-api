using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CFA_API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string[] Images { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }

        public virtual ICollection<ProductColor> Colors { get; set; }
        public virtual ICollection<ProductSize> Sizes { get; set; }
    }
}
