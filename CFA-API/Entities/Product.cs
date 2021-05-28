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
        public string[] Images { get; set; }

        public Category Category { get; set; }
        public ProductType ProductType { get; set; }
        public Color Colors { get; set; }
        public Size Sizes { get; set; }
    }
}
