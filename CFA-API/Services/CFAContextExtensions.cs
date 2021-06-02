using CFA_API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CFA_API.Services
{
    public static class CFAContextExtensions
    {
        public static void EnsureSeedDataForContext(this CFAContext contex)
        {

            var sizes = new List<ProductSize>
            {
                new ProductSize { ID=1, Name = "XS" },
                new ProductSize { ID=2, Name = "S" },
                new ProductSize { ID=3, Name = "M" },
                new ProductSize { ID=4, Name = "L" },
                new ProductSize { ID=5, Name = "XL" },
                new ProductSize { ID=6, Name = "XXL" },
            };

            var colors = new List<ProductColor>
            {
                new ProductColor { ID=1, Name = "Hvid" },
                new ProductColor { ID=2, Name = "Sort" },
                new ProductColor { ID=3, Name = "Blå" },
                new ProductColor { ID=4, Name = "Lilla" },
                new ProductColor { ID=5, Name = "Gul" },
                new ProductColor { ID=6, Name = "Grøn" },
                new ProductColor { ID=7, Name = "Orange" },
                new ProductColor { ID=8, Name = "Cyan" },
                new ProductColor { ID=9, Name = "Pink" },
            };

            var categories = new List<Category>
            {
                new Category { ID=1, Name = "Herre", Description = "Tøj til ham" },
                new Category { ID=2, Name = "Dame", Description = "Tøj til hende" },
                new Category { ID=3, Name = "Børn", Description = "Tøj til den lille" }
            };

            var productTypes = new List<ProductType>
            {
                new ProductType { ID=1, Name = "Kjoler", Description = "Beskrivelse af kjoler" },
                new ProductType { ID=2, Name = "T-Shirts", Description = "Beskrivelse af t-shirts" },
                new ProductType { ID=3, Name = "Toppe", Description = "Beskrivelse af toppe" },
                new ProductType { ID=4, Name = "Skjorte", Description = "Beskrivelse af skjorter" },
                new ProductType { ID=5, Name = "Bluser", Description = "Beskrivelse af bluser" },
                new ProductType { ID=6, Name = "Shorts", Description = "Beskrivelse af shorts" },
                new ProductType { ID=7, Name = "Strik", Description = "Beskrivelse af strik" },
                new ProductType { ID=8, Name = "Bukser", Description = "Beskrivelse af bukser" },
                new ProductType { ID=9, Name = "Jakker", Description = "Beskrivelse af jakker" },
            };

            var brands = new List<Brand>
            {
                new Brand { ID=1, Name = "Only", Description = "Beskrivelse af Only" },
                new Brand { ID=2, Name = "Denim", Description = "Beskrivelse af Denim" },
                new Brand { ID=3, Name = "Mango", Description = "Beskrivelse af Mango" },
                new Brand { ID=4, Name = "JDY", Description = "Beskrivelse af JDY" },
                new Brand { ID=5, Name = "Samsøe Samsøe", Description = "Beskrivelse af Samsøe Samsøe" },
                new Brand { ID=6, Name = "Versace", Description = "Beskrivelse af Versace" },
            };

            var suppliers = new List<Supplier>
            {
                new Supplier { ID=1, Name = "NEXT-Line", Address = "47 Broad Street, Lyme Regis, DT7 3QF", Email = "alskdjjnf@mail.asd.com"},
                new Supplier { ID=2, Name = "ClothesForYou", Address = "Flat 15, Clayton House, 50 Trinity Church Road, London", Email = "kgasu@mail.bg.com"},
                new Supplier { ID=3, Name = "Digital Closet", Address = "R & H Electric Basingstoke Ltd, Whitney Road, Basingstoke", Email = "DG-info@ogk.com"}
            };

            if (!contex.Sizes.Any()) { contex.AddRange(sizes); }
            if (!contex.Colors.Any()) { contex.AddRange(colors); }
            if (!contex.Categories.Any()) { contex.AddRange(categories); }
            if (!contex.ProductTypes.Any()) { contex.AddRange(productTypes); }
            if (!contex.Brands.Any()) { contex.AddRange(brands); }
            if (!contex.Suppliers.Any()) { contex.AddRange(suppliers); }

            contex.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Maxikjole i poplin",
                    Description = "Beskrivelse af Maxikjole i poplin",
                    Images = new string[] { "/kjole-1-1", "/kjole-1-2" },
                    Price = 199,
                    Stock = 15,
                    Category = contex.Categories.Find(2),
                    ProductType = contex.ProductTypes.Find(1),
                    Brand = contex.Brands.Find(1),
                    Supplier = contex.Suppliers.Find(1),
                    Colors = contex.Colors.Take(4).ToList(),
                    Sizes = contex.Sizes.Take(3).ToList(),
                },
                new Product
                {
                    Name = "Super t-shirt i ubn",
                    Description = "Beskrivelse af Super t-shirt i ubn",
                    Images = new string[] { "/t-shirt-1-2" },
                    Price = 145,
                    Stock = 5,
                    Category = contex.Categories.Find(1),
                    ProductType = contex.ProductTypes.Find(2),
                    Brand = contex.Brands.Find(3),
                    Supplier = contex.Suppliers.Find(1),
                    Colors = contex.Colors.Take(3).ToList(),
                    Sizes = contex.Sizes.Take(2).ToList(),
                },
                new Product
                {
                    Name = "Cargoshorts",
                    Description = "Beskrivelse af Cargoshorts",
                    Images = new string[] { "/shorts-1", "/shorts-2" },
                    Price = 299,
                    Stock = 54,
                    Category = contex.Categories.Find(1),
                    ProductType = contex.ProductTypes.Find(6),
                    Brand = contex.Brands.Find(1),
                    Supplier = contex.Suppliers.Find(1),
                    Colors = contex.Colors.Take(2).ToList(),
                    Sizes = contex.Sizes.Take(5).ToList(),
                },
                new Product
                {
                    Name = "Blød og varm strikketrøje",
                    Description = "Beskrivelse af Blød og varm strikketrøje",
                    Images = new string[] { "/strik-1", "/strik-2", "strik-3" },
                    Price = 459,
                    Stock = 2,
                    Category = contex.Categories.Find(2),
                    ProductType = contex.ProductTypes.Find(7),
                    Brand = contex.Brands.Find(2),
                    Supplier = contex.Suppliers.Find(2),
                    Colors = contex.Colors.Take(5).ToList(),
                    Sizes = contex.Sizes.Take(1).ToList(),
                },
                new Product
                {
                    Name = "Læderjakke rugskind",
                    Description = "Beskrivelse af Læderjakke rugskind",
                    Images = new string[] { "/jakke-24"},
                    Price = 1299,
                    Stock = 4,
                    Category = contex.Categories.Find(2),
                    ProductType = contex.ProductTypes.Find(9),
                    Brand = contex.Brands.Find(1),
                    Supplier = contex.Suppliers.Find(2),
                    Colors = contex.Colors.Take(1).ToList(),
                    Sizes = contex.Sizes.Take(3).ToList(),
                },
                new Product
                {
                    Name = "Frisk sommerskjorte",
                    Description = "Beskrivelse af Frisk sommerskjorte",
                    Images = new string[] { "/sommerskjorte-1" },
                    Price = 499,
                    Stock = 11,
                    Category = contex.Categories.Find(1),
                    ProductType = contex.ProductTypes.Find(4),
                    Brand = contex.Brands.Find(3),
                    Supplier = contex.Suppliers.Find(3),
                    Colors = contex.Colors.Take(5).ToList(),
                    Sizes = contex.Sizes.Take(2).ToList(),
                },
                new Product
                {
                    Name = "Frisk sommerskjorte",
                    Description = "Beskrivelse af Frisk sommerskjorte",
                    Images = new string[] { "/sommerskjorte-1" },
                    Price = 499,
                    Stock = 11,
                    Category = contex.Categories.Find(1),
                    ProductType = contex.ProductTypes.Find(4),
                    Brand = contex.Brands.Find(3),
                    Supplier = contex.Suppliers.Find(3),
                    Colors = contex.Colors.Take(5).ToList(),
                    Sizes = contex.Sizes.Take(2).ToList(),
                }
            };

            if (!contex.Products.Any()) { contex.AddRange(products); }

            contex.SaveChanges();
        }
    }
}
