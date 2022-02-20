using DentalDDS_Api.App_Start;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DentalDDS_Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            
            string origin = ConfigurationManager.AppSettings["AzureUIHost"];  //production
            var cors = new EnableCorsAttribute( origin, "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.           
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new ApplicationExceptionHandler());
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();          

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            
        }
    }
}
