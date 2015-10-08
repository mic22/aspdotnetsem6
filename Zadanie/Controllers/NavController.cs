using Service.Abstract;
using System.Web.Mvc;

namespace Zadanie.Controllers
{
    [RoutePrefix("nawigacja")]
    public class NavController : Controller
    {
        public NavController(ICategoryService categoryService)
        {
            SCategory = categoryService;
        }

        public ICategoryService SCategory { get; private set; }

        [Route("listaKategorii")]
        public ActionResult CategoryList()
        {
            return PartialView(SCategory.GetAllCategories());
        }
    }
}