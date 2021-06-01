using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFA_API.Entities;
using CFA_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CFA_API.Services
{
    public interface ICFARepository
    {
        // Product
        List<ProductResponse> GetAllProducts(int? category, int? type, int? brand, int[] sizes, int[] colors);
        ProductResponse GetProduct(int id);
        Product GetProductDetails(int id);
        int CreateProduct(ProductCreateDTO productDTO);
        void UpdateProduct(int id, ProductUpdateDTO productDTO);
        void DeleteProduct(int id);

        // Category
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        int CreateCategory(Category categoryDTO);
        void UpdateCategory(int id, CategoryUpdateDTO categoryModel);
        void DeleteCategory(int id);

        // ProductType
        List<ProductType> GetAllProductTypes();
        ProductType GetProductType(int id);
        int CreateProductType(ProductType productTypeDTO);
        void UpdateProductType(int id, ProductTypeUpdateDTO productTypeModel);
        void DeleteProductType(int id);

        // Brand
        List<Brand> GetAllBrands();
        Brand GetBrand(int id);
        int CreateBrand(Brand brandModel);
        void UpdateBrand(int id, BrandUpdateDTO brandDTO);
        void DeleteBrand(int id);

        // Color
        List<ProductColor> GetAllColors();
        ProductColor GetColor(int id);
        int CreateColor(ProductColor color);
        void UpdateColor(int id, ProductColor color);
        void DeleteColor(int id);

        // Size
        List<ProductSize> GetAllSizes();
        ProductSize GetSize(int id);
        int CreateSize(ProductSize productSize);
        void UpdateSize(int id, ProductSize productSize);
        void DeleteSize(int id);

        // Size
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplier(int id, bool includeProducts = false);
        int CreateSupplier(Supplier supplier);
        void UpdateSupplier(int id, SupplierUpdateDTO supplierDTO);
        void DeleteSupplier(int id);
    }
}
