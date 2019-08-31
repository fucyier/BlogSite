using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                  "Admin_2",
                  "Admin/",
                  new { action = "Index",controller="Post", id = UrlParameter.Optional },
                   namespaces: new[] { "Blog.WebUI.Areas.Admin.Controllers" }
              );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Blog.WebUI.Areas.Admin.Controllers" }
            );
        }
    }
}