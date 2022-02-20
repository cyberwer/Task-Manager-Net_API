using System.Web.Mvc;
using System.Web.Routing;

namespace DentalDDS_Api
{
    public class RouteConfig
    {
        //This is for MVC routes. Not used here.
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
