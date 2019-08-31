using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

public class SeoFriendlyRoute : Route
{
    public SeoFriendlyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
    {
    }

    public override RouteData GetRouteData(HttpContextBase httpContext)
    {
        var routeData = base.GetRouteData(httpContext);

        if (routeData != null)
        {
            if (routeData.Values.ContainsKey("postId"))
                routeData.Values["postId"] = GetIdValue(routeData.Values["postId"]);
            routeData.DataTokens.Add("Namespaces", new string[] { "Blog.WebUI.Controllers" });
        }

        return routeData;
    }

    private object GetIdValue(object id)
    {
        if (id != null)
        {
            string idValue = id.ToString();

            var regex = new Regex(@"^(?<postId>\d+).*$");
            var match = regex.Match(idValue);

            if (match.Success)
            {
                return match.Groups["postId"].Value;
            }
        }

        return id;
    }
}