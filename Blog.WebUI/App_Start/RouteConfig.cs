using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("PostDetails",
                new SeoFriendlyRoute("Post/Detail/{postId}",
                new RouteValueDictionary(new { controller = "Post", action = "Detail" }),
                new MvcRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Nav", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Blog.WebUI.Controllers" }
            );

        }
    }
}
