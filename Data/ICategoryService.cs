using System.Collections.Generic;
using System.Threading.Tasks;
using JWTApi.Models;

namespace JWTApi.Data
{
    public interface ICategoryService
    {
        bool SaveChanges();
        Task<IEnumerable<Category>> GetAllCategoty();

        Task<Category> GetCategoryById(int id);

        void CreateCategory(Category cat);
        void UpdateCategory(Category cat);
        void DeleteCategory(Category cat);



    }

}