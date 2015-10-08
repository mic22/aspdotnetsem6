using Model;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        bool AddItem(Item item);
        bool EditItem(Item item);
        bool DeleteItem(int id);
        List<Item> GetByCategory(int categoryId);
        Item SelectById(int id);
    }
}
