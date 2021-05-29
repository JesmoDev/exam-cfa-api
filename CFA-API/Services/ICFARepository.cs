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

        // Color
        List<ProductColor> GetAllColors();
        ProductColor GetColor(int id);
        int CreateColor(ProductColor color);
        void UpdateColor(int id, ProductColor color);
        void DeleteColor(int id);

        //Category CreateCategory();
        //List<Category> GetAllCategories();
        //Category GetCategory(int ID);
        //void UpdateCategory(int ID, Category category);
        //void DeleteCategory(int ID);
    }
}
