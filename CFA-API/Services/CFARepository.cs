using AutoMapper;
using CFA_API.Entities;
using CFA_API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        #region Product
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

        public int CreateProduct(ProductModel productModel)
        {
            var colors = _context.Colors.Where(x => productModel.Colors.Contains(x.ID)).ToList();
            var sizes = _context.Sizes.Where(x => productModel.Sizes.Contains(x.ID)).ToList();

            var product = _mapper.Map<Product>(productModel);
            product.Colors = colors;
            product.Sizes = sizes;

            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ID;
        }

        public void UpdateProduct(int id, ProductModel productModel)
        {
            var product = _context.Products.Find(id);
            _mapper.Map(productModel, product);

            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }
        #endregion Product

        #region Color
        public List<ProductColor> GetAllColors() => _context.Colors.ToList();
        public ProductColor GetColor(int id) => _context.Colors.Find(id);
        public int CreateColor(ProductColor color)
        {
            _context.Colors.Add(color);
            _context.SaveChanges();
            return color.ID;
        }

        public void UpdateColor(int id, ProductColor color)
        {
            _context.Colors.Find(id).Name = color.Name;
            _context.SaveChanges();
        }

        public void DeleteColor(int id)
        {
            var color = _context.Colors.Find(id);
            _context.Colors.Remove(color);
            _context.SaveChanges();
        }
        #endregion Color

        #region Size
        public List<ProductSize> GetAllSizes() => _context.Sizes.ToList();
        public ProductSize GetSize(int id) => _context.Sizes.Find(id);
        public int CreateSize(ProductSize size)
        {
            _context.Sizes.Add(size);
            _context.SaveChanges();
            return size.ID;
        }

        public void UpdateSize(int id, ProductSize size)
        {
            _context.Sizes.Find(id).Name = size.Name;
            _context.SaveChanges();
        }

        public void DeleteSize(int id)
        {
            var size = _context.Sizes.Find(id);
            _context.Sizes.Remove(size);
            _context.SaveChanges();
        }
        #endregion Size
    }
}
