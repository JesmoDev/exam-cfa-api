using CFA_API.Entities;
using CFA_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Services
{
    public class CFARepository : ICFARepository
    {
        private CFAContext _context;

        public CFARepository(CFAContext context)
        {
            _context = context;
        }

        public void CreateProduct(ProductModel productModel)
        {
            var colors = _context.Colors.Where(x => productModel.Colors.Contains(x.ID)).ToList();
            var sizes = _context.Sizes.Where(x => productModel.Sizes.Contains(x.ID)).ToList();

            var product = new Product()
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Images = productModel.Images,
                CategoryId = productModel.Category,
                ProductTypeId = productModel.Type,
                BrandId = productModel.Brand,
                Colors = colors,
                Sizes = sizes
            };


            _context.Products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.
                Include(x => x.Colors).
                Include(x => x.Sizes).
                Include(x => x.Brand).
                Include(x => x.Category).
                Include(x => x.ProductType).
                ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.
                Include(p => p.Colors).
                Include(p => p.Sizes).
                Include(p => p.Brand).
                Include(p => p.Category).
                Include(p => p.ProductType).
                FirstOrDefault(x => x.ID == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
