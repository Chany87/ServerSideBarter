using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryDAL
    {
        bool AddCategory(Category category);
        bool DeleteCategory(int id);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        bool UpdateCategory(int id, Category category);
    }
}