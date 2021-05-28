using CFA_API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CFA_API.Services
{
    public static class CFAContextExtensions
    {
        public static void EnsureSeedDataForContext(this CFAContext contex)
        {

            var sizes = new List<Size>
            {
                new Size { Name = "XS" },
                new Size { Name = "S" },
                new Size { Name = "M" },
                new Size { Name = "L" },
                new Size { Name = "XL" },
                new Size { Name = "XXL" },
            };

            var colors = new List<Color>
            {
                new Color { Name = "Hvid" },
                new Color { Name = "Sort" },
                new Color { Name = "Blå" },
                new Color { Name = "Lilla" },
                new Color { Name = "Gul" },
                new Color { Name = "Grøn" },
                new Color { Name = "Orange" },
                new Color { Name = "Cyan" },
                new Color { Name = "Pink" },
            };

            var categories = new List<Category>
            {
                new Category { Name = "Herre", Description = "Tøj til ham" },
                new Category { Name = "Dame", Description = "Tøj til hende" },
                new Category { Name = "Børn", Description = "Tøj til den lille" }
            };

            var productTypes = new List<ProductType>
            {
                new ProductType { Name = "Kjoler", Description = "Beskrivelse af kjoler" },
                new ProductType { Name = "T-Shirts", Description = "Beskrivelse af t-shirts" },
                new ProductType { Name = "Toppe", Description = "Beskrivelse af toppe" },
                new ProductType { Name = "Skjorte", Description = "Beskrivelse af skjorter" },
                new ProductType { Name = "Bluser", Description = "Beskrivelse af bluser" },
                new ProductType { Name = "Shorts", Description = "Beskrivelse af shorts" },
                new ProductType { Name = "Strik", Description = "Beskrivelse af strik" },
                new ProductType { Name = "Bukser", Description = "Beskrivelse af bukser" },
                new ProductType { Name = "Sko", Description = "Beskrivelse af sko" },
                new ProductType { Name = "Jakker", Description = "Beskrivelse af jakker" },
            };

            var brands = new List<Brand>
            {
                new Brand { Name = "Only", Description = "Beskrivelse af Only" },
                new Brand { Name = "Denim", Description = "Beskrivelse af Denim" },
                new Brand { Name = "Mango", Description = "Beskrivelse af Mango" },
                new Brand { Name = "JDY", Description = "Beskrivelse af JDY" },
                new Brand { Name = "Samsøe Samsøe", Description = "Beskrivelse af Samsøe Samsøe" },
                new Brand { Name = "Versace", Description = "Beskrivelse af Versace" },
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Maxikjole i poplin",
                    Description = "Beskrivelse af Maxikjole i poplin",
                    Images = new string[] { "/kjole-1-1", "/kjole-1-2" },
                    Price = 199,
                    Category = categories[1],
                    ProductType = productTypes[0],
                    Colors = colors.Take(3).ToList(),
                    Sizes = sizes.Take(5).ToList()
                },
                new Product
                {
                    Name = "Maxikjole i poplin 2",
                    Description = "Beskrivelse af Maxikjole i poplin 2",
                    Images = new string[] { "/kjole-1-1" },
                    Price = 199,
                    Category = categories[1],
                    ProductType = productTypes[0],
                    Colors = colors.Take(3).ToList(),
                    Sizes = sizes.Take(5).ToList()
                },
            };

            contex.AddRange(sizes);
            contex.AddRange(colors);
            contex.AddRange(categories);
            contex.AddRange(productTypes);
            contex.AddRange(brands);
            contex.AddRange(products);

            contex.SaveChanges();
        }
    }
}
