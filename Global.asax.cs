using DentalDDS_Api.Common;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DentalDDS_Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            

            //Global Controller Validation 
            GlobalConfiguration.Configuration.Filters.Add(new CheckModelForNullAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelStateAttribute());

        }

        protected void Application_BeginRequest()
        {
            //string allowedOrigin = ConfigurationManager.AppSettings["HostingUI_IP"];
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", allowedOrigin);
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "*");
        }
    }
}
