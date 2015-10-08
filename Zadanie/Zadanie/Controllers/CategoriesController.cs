
using Model;
using Service.Abstract;
using System.Web.Mvc;

namespace Zadanie.Controllers
{
    [RoutePrefix("kategorie")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public ICategoryService SCategory { get; private set; }
        public CategoriesController(ICategoryService CategoryService)
        {
            SCategory = CategoryService;
        }

        // GET: Categories
        [Route]
        public ActionResult Index()
        {
            return View(SCategory.GetAllCategories());
        }
        [Route("nowy")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("nowy")]
        public ActionResult Create(Category category)
        {
            if(SCategory.AddCategory(category))
                return View("Index", SCategory.GetAllCategories());
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
            var item  = SCategory.SelectById(id);
            return View(item);
        }

        
        [HttpPost]
        [Route("edytuj/{id:int}")]
        public ActionResult Edit(Category category)
        {
            if (SCategory.EditCategory(category))
                return View("Index", SCategory.GetAllCategories());
            else
            {
                ModelState.AddModelError("", "Validation Error");
                return View();
            }
        }

        [Route("usun/{id}")]
        public ActionResult Delete(int id)
        {
            if (SCategory.DeleteCategory(id))
                return View("Index", SCategory.GetAllCategories());
            else
            {
                ModelState.AddModelError("", "Delete Error");
                return View();
            }
        }
    }
}