using AutoMapper;
using Model;
using Service.Abstract;
using System.Collections.Generic;
using System.Web.Mvc;
using Zadanie.Models;

namespace Zadanie.Controllers
{
    [RoutePrefix("przedmioty")]
    public class ItemController : Controller
    {
        public ICategoryService SCategory { get; private set; }
        public IItemService SItem { get; private set; }

        public ItemController(ICategoryService CategoryService, IItemService ItemService)
        {
            SItem = ItemService;
            SCategory = CategoryService;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var list = new List<ItemsListViewModel>();
            foreach (var item in SItem.GetAllItems())
            {
                var category = SCategory.SelectById(item.CategoryId);
                list.Add(new ItemsListViewModel()
                {
                    CategoryName = category == null ? string.Empty : category.Name,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Value = item.Value,
                    Id = item.Id
                });
            }

            return View(list);
        }
        [Route("nowy")]
        public ActionResult Create()
        {
            var viewModel = new ItemViewModel
            {
                Items = Mapper.Map<IEnumerable<Category>, IEnumerable<SelectListItem>>(SCategory.GetAllCategories())
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("nowy")]
        public ActionResult Create(ItemViewModel viewModel)
        {
            if (SItem.AddItem(Mapper.Map<ItemViewModel, Item>(viewModel)))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Validation Error");
                return View();
            }     
        }

        [HttpGet]
        [Route("edytuj/{id:int}")]
        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<Item, ItemViewModel>(SItem.SelectById(id));
            viewModel.Items =
                 Mapper.Map<IEnumerable<Category>, IEnumerable<SelectListItem>>(SCategory.GetAllCategories());

            return View(viewModel);
        }

        [HttpPost]
        [Route("edytuj/{id:int}")]
        public ActionResult Edit(ItemViewModel viewModel)
        {
            if (!SItem.EditItem(Mapper.Map<ItemViewModel, Item>(viewModel)))
                ModelState.AddModelError("", "Validation Error");

            return RedirectToAction("Index");
        }

        [Route("usun/{id:int}")]
        public ActionResult Delete(int id)
        {
            if (SItem.DeleteItem(id))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Delete Error");
                return View();
            }
        }

        [HttpGet]
        [Route("kategoria/{categoryId:int}")]
        public ActionResult GetByCategory(int categoryId)
        {
            var list = new List<ItemsListViewModel>();
            foreach (var item in SItem.GetByCategory(categoryId))
            {
                list.Add(new ItemsListViewModel()
                {
                    CategoryName = SCategory.SelectById(item.CategoryId).Name,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Value = item.Value,
                    Id = item.Id
                });
            }

            return View(list);
        }
    }
}