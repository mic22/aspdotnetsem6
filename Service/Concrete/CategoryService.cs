using Service.Abstract;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Service.Concrete
{
    public class CategoryService : ICategoryService

    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public bool AddCategory(Category category)
        {
            try
            {
                context.Category.Add(category);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                context.Category.Remove(context.Category.Find(id));
                foreach (var item in context.Item.Where(x=> x.CategoryId == id))
                {
                    item.CategoryId = 0;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditCategory(Category category)
        {
            try
            {
                var dbEntry = context.Category.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Category> GetAllCategories()
        {
            return context.Category.ToList();
        }

        public Category SelectById(int id)
        {
            return context.Category.FirstOrDefault(x => x.Id == id);
        }
    }
}
