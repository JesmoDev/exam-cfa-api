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
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProduct(int id);
        int CreateProduct(ProductModel productModel);
        void UpdateProduct(int id, ProductModel productModel);
        void DeleteProduct(int id);

        // Category
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        int CreateCategory(CategoryModel category);
        void UpdateCategory(int id, CategoryModel category);
        void DeleteCategory(int id);

        // Color
        List<ProductColor> GetAllColors();
        ProductColor GetColor(int id);
        int CreateColor(ProductColor color);
        void UpdateColor(int id, ProductColor color);
        void DeleteColor(int id);

        // Size
        List<ProductSize> GetAllSizes();
        ProductSize GetSize(int id);
        int CreateSize(ProductSize color);
        void UpdateSize(int id, ProductSize color);
        void DeleteSize(int id);
    }
}
