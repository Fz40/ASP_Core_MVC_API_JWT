using System.Collections.Generic;
using JWTApi.Models;

namespace JWTApi.Data
{
    public interface ICategoryService
    {
        bool SaveChanges();
        IEnumerable<Category> GetAllCategoty();

        Category GetCategoryById(int id);

        void CreateCategory(Category cat);
        void UpdateCategory(Category cat);
        void DeleteCategory(Category cat);



    }

}