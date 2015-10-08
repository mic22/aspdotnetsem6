using Model;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        bool AddCategory(Category category);
        bool EditCategory(Category category);
        bool DeleteCategory(int id);
        Category SelectById(int id);
    }
}
