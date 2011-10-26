using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SignalR.Demo.Controllers;
using SignalR.Routing;
using NHQS;
using GeoCheckin.DataAccess;
using SignalR.Demo.Connections;

namespace SignalR.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapConnection<EchoConnection>("echo", "echo/{*operation}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new 
                { 
                    controller = "Home", 
                    action = "Index", 
                    id = UrlParameter.Optional 
                }
            );
        }

        protected void Application_Start()
        {
            SessionFactoryContainer.Current.Add(new SQLiteSessionFactoryCreator().Create());

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}