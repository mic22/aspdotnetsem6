using Service.Abstract;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Service.Concrete
{
    public class ItemService : IItemService

    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public bool AddItem(Item item)
        {
            try
            {
                context.Item.Add(item);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    public bool DeleteItem(int id)
    {
        try
        {
            context.Item.Remove(context.Item.Find(id));
            context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

        public bool EditItem(Item item)
        {
            try
            {
                var dbEntry = context.Item.Find(item.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Value = item.Value;
                    dbEntry.Quantity = item.Quantity;
                    dbEntry.CategoryId = item.CategoryId;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Item> GetAllItems()
        {
            return context.Item.ToList();
        }

        public List<Item> GetByCategory(int categoryId)
        {
            var data = context.Item.Where(x => x.CategoryId == categoryId).ToList();
            return data;
        }

        public Item SelectById(int id)
        {
            return context.Item.Find(id);
        }
    }
}
