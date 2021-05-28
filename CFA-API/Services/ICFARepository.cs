using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFA_API.Entities;

namespace CFA_API.Services
{
    interface ICFARepository
    {
        //Category CreateCategory();
        //List<Category> GetAllCategories();
        //Category GetCategory(int ID);
        //void UpdateCategory(int ID, Category category);
        //void DeleteCategory(int ID);


        bool Save();
    }
}
