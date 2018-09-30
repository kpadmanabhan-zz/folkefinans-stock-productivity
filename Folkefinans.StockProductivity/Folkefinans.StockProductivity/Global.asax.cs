using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace Folkefinans.StockProductivity
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteTable.Routes.MapHttpRoute(
                name: "CalculateStock",
                routeTemplate: "api/{controller}"
                );

            //RouteTable.Routes.MapHttpRoute(
            //    name: "StockResultsOverview",
            //    routeTemplate: "api/{controller}/{action}"
            //    );

            RouteTable.Routes.MapHttpRoute(
                name: "StockResultsDetails",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}