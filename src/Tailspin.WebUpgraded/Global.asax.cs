using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tailspin.Model;
using Tailspin.Infrastructure;
using StructureMap;
using System.Reflection;
using System.Data.Linq;

namespace Tailspin.Web {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            ); 
        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);
            Bootstrapper.ConfigureStructureMap();

            ControllerBuilder.Current.SetControllerFactory(
                new TailspinControllerFactory()
                );

            ViewEngines.Engines.Add(new TailspinViewEngine());


        }
    }
}