using Blog.DataAccess.Concrete.EntityFramework;
using Blog.DataAccess.Configurations;
using Blog.WebUI.Infrastructure;
using Haygem.Hdys.WebUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            Database.SetInitializer<BlogContext>(new DatabaseInitializer());
        }
    }
}
