using AutoMapper;
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
        private readonly CFAContext _context;
        private readonly IMapper _mapper;

        public CFARepository(CFAContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateProduct(ProductModel productModel)
        {
            var colors = _context.Colors.Where(x => productModel.Colors.Contains(x.ID)).ToList();
            var sizes = _context.Sizes.Where(x => productModel.Sizes.Contains(x.ID)).ToList();

            var product = _mapper.Map<Product>(productModel);
            product.Colors = colors;
            product.Sizes = sizes;

            _context.Products.Add(product);
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _context.Products.
                Include(x => x.Colors).
                Include(x => x.Sizes).
                Include(x => x.Brand).
                Include(x => x.Category).
                Include(x => x.ProductType).
                ToList();

            return _mapper.Map<List<Product>, List<ProductDTO>>(products);
        }

        public ProductDTO GetProduct(int id)
        {
            var product = _context.Products.
                Include(p => p.Colors).
                Include(p => p.Sizes).
                Include(p => p.Brand).
                Include(p => p.Category).
                Include(p => p.ProductType).
                FirstOrDefault(x => x.ID == id);

            return _mapper.Map<ProductDTO>(product);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
