﻿using CFA_API.Entities;
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
                new ProductSize { Name = "XS" },
                new ProductSize { Name = "S" },
                new ProductSize { Name = "M" },
                new ProductSize { Name = "L" },
                new ProductSize { Name = "XL" },
                new ProductSize { Name = "XXL" },
            };

            var colors = new List<ProductColor>
            {
                new ProductColor { Name = "Hvid" },
                new ProductColor { Name = "Sort" },
                new ProductColor { Name = "Blå" },
                new ProductColor { Name = "Lilla" },
                new ProductColor { Name = "Gul" },
                new ProductColor { Name = "Grøn" },
                new ProductColor { Name = "Orange" },
                new ProductColor { Name = "Cyan" },
                new ProductColor { Name = "Pink" },
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

            var suppliers = new List<Supplier>
            {
                new Supplier {Name = "NEXT-Line", Address = "47 Broad Street, Lyme Regis, DT7 3QF", Email = "alskdjjnf@mail.asd.com"},
                new Supplier {Name = "ClothesForYou", Address = "Flat 15, Clayton House, 50 Trinity Church Road, London", Email = "kgasu@mail.bg.com"},
                new Supplier {Name = "Digital Closet", Address = "R & H Electric Basingstoke Ltd, Whitney Road, Basingstoke", Email = "DG-info@ogk.com"}
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
                    Brand = contex.Brands.FirstOrDefault(),
                    Category = contex.Categories.FirstOrDefault(),
                    ProductType = contex.ProductTypes.FirstOrDefault(),
                    Colors = contex.Colors.Take(3).ToList(),
                    Sizes = contex.Sizes.Take(2).ToList(),
                    Supplier = contex.Suppliers.Find(1)
                },
                new Product
                {
                    Name = "ORIGINAL TEE REGULAR FIT - T-shirts basic",
                    Description = "Beskrivelse af ORIGINAL TEE REGULAR FIT - T-shirts basic",
                    Images = new string[] { "/t-shirt-1-1", "/tshirt-1-2", "/tshirt-1-3" },
                    Price = 189,
                    Stock = 53,
                    Brand = contex.Brands.FirstOrDefault(),
                    Category = contex.Categories.FirstOrDefault(),
                    ProductType = contex.ProductTypes.FirstOrDefault(),
                    Colors = contex.Colors.ToList(),
                    Sizes = contex.Sizes.ToList(),
                    Supplier = contex.Suppliers.Find(2)
                },
                new Product
                {
                    Name = "JJIGORDON JJSHARK - Træningsbukser",
                    Description = "Beskrivelse af JJIGORDON JJSHARK - Træningsbukser",
                    Images = new string[] { "/bukser-1-1" },
                    Price = 249,
                    Stock = 2,
                    Brand = contex.Brands.FirstOrDefault(),
                    Category = contex.Categories.FirstOrDefault(),
                    ProductType = contex.ProductTypes.FirstOrDefault(),
                    Colors = contex.Colors.Take(2).ToList(),
                    Sizes = contex.Sizes.Take(4).ToList(),
                    Supplier = contex.Suppliers.Find(3)
                }
            };

            if (!contex.Products.Any()) { contex.AddRange(products); }

            contex.SaveChanges();
        }
    }
}
