using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFA_API.Entities;
using CFA_API.Models;

namespace CFA_API.Services
{
    public interface ICFARepository
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void CreateProduct(ProductModel productModel);

        //Category CreateCategory();
        //List<Category> GetAllCategories();
        //Category GetCategory(int ID);
        //void UpdateCategory(int ID, Category category);
        //void DeleteCategory(int ID);


        bool Save();
    }
}
