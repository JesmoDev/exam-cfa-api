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
        public List<ProductResponse> GetAllProducts(int? category, int? type, int? brand, int[] sizes, int[] colors)
        {
            var products = _context.Products.
                Include(x => x.Colors).
                Include(x => x.Sizes).
                Include(x => x.Brand).
                Include(x => x.Category).
                Include(x => x.ProductType).
                Where(x =>
                    (category == null || x.Category.ID == category) &&
                    (brand == null || x.Brand.ID == brand) &&
                    (type == null || x.ProductType.ID == type) &&
                    (colors.Length == 0 || x.Colors.Select(c => c.ID).Any(z => colors.Contains(z))) &&
                    (sizes.Length == 0 || x.Sizes.Select(c => c.ID).Any(z => sizes.Contains(z)))).
                ToList();

            return _mapper.Map<List<Product>, List<ProductResponse>>(products);
        }

        public ProductResponse GetProduct(int id)
        {
            var product = _context.Products.
                Include(p => p.Colors).
                Include(p => p.Sizes).
                Include(p => p.Brand).
                Include(p => p.Category).
                Include(p => p.ProductType).
                FirstOrDefault(x => x.ID == id);

            return _mapper.Map<ProductResponse>(product);
        }

        public Product GetProductDetails(int id)
        {
            var product = _context.Products.
                Include(p => p.Colors).
                Include(p => p.Sizes).
                Include(p => p.Brand).
                Include(p => p.Category).
                Include(p => p.ProductType).
                Include(p => p.Supplier).
                FirstOrDefault(x => x.ID == id);

            return product;
        }
        public int CreateProduct(ProductCreateDTO productDTO)
        {
            var colors = _context.Colors.Where(x => productDTO.Colors.Contains(x.ID)).ToList();
            var sizes = _context.Sizes.Where(x => productDTO.Sizes.Contains(x.ID)).ToList();

            var product = _mapper.Map<Product>(productDTO);
            product.Colors = colors;
            product.Sizes = sizes;

            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ID;
        }

        public void UpdateProduct(int id, ProductUpdateDTO productDTO)
        {
            var product = _context.Products.Find(id);
            _mapper.Map(productDTO, product);

            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();
        }
        #endregion Product

        #region Category
        public List<Category> GetAllCategories() => _context.Categories.ToList();

        public Category GetCategory(int id) => _context.Categories.Find(id);

        public int CreateCategory(CategoryCreateDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.ID;
        }

        public void UpdateCategory(int id, CategoryUpdateDTO categoryDTO)
        {
            var category = _context.Categories.Find(id);
            _mapper.Map(categoryDTO, category);

            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);

            _context.SaveChanges();
        }
        #endregion Category

        #region ProductType
        public List<ProductType> GetAllProductTypes() => _context.ProductTypes.ToList();

        public ProductType GetProductType(int id) => _context.ProductTypes.Find(id);

        public int CreateProductType(ProductTypeCreateDTO productTypeDTO)
        {
            var productType = _mapper.Map<ProductType>(productTypeDTO);
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();
            return productType.ID;
        }

        public void UpdateProductType(int id, ProductTypeUpdateDTO productTypeDTO)
        {
            var productType = _context.ProductTypes.Find(id);
            _mapper.Map(productTypeDTO, productType);

            _context.SaveChanges();
        }

        public void DeleteProductType(int id)
        {
            var productType = _context.ProductTypes.Find(id);
            _context.ProductTypes.Remove(productType);

            _context.SaveChanges();
        }
        #endregion ProductType

        #region Brand
        public List<Brand> GetAllBrands() => _context.Brands.ToList();

        public Brand GetBrand(int id) => _context.Brands.Find(id);

        public int CreateBrand(BrandCreateDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand.ID;
        }

        public void UpdateBrand(int id, BrandUpdateDTO brandDTO)
        {
            var brand = _context.Brands.Find(id);
            _mapper.Map(brandDTO, brand);

            _context.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);

            _context.SaveChanges();
        }
        #endregion Brand

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

        #region Supplier
        public List<Supplier> GetAllSuppliers() => _context.Suppliers.ToList();

        public Supplier GetSupplier(int id, bool includeProducts = false)
        {
            if (includeProducts)
            {
                var supplier = _context.Suppliers.Include(x => x.Products).SingleOrDefault(x => x.ID == id);
                return supplier;
            }
            else
            {
                var supplier = _context.Suppliers.Find(id);
                return supplier;
            }
        }

        public int CreateSupplier(Supplier supplierDTO)
        {
            var supplier = _mapper.Map<Supplier>(supplierDTO);
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier.ID;
        }

        public void UpdateSupplier(int id, SupplierUpdateDTO supplierDTO)
        {
            var supplier = _context.Suppliers.Find(id);
            _mapper.Map(supplierDTO, supplier);

            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            _context.Suppliers.Remove(supplier);

            _context.SaveChanges();
        }
        #endregion Supplier
    }
}
