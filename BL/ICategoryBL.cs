using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface ICategoryBL
    {
        bool AddCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
        List<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
        bool UpdateCategory(int id, CategoryDTO categoryDTO);
    }
}