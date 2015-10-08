using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Model;
using Service.Abstract;
using Service.Concrete;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Zadanie.Models;

namespace Zadanie
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerRequest();
            builder.RegisterType<ItemService>().As<IItemService>().InstancePerRequest();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            Mapper.CreateMap<Category, SelectListItem>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name) );

            Mapper.CreateMap<ItemViewModel, Item>();

            Mapper.CreateMap<Item, ItemViewModel>();
        }
    }
}
