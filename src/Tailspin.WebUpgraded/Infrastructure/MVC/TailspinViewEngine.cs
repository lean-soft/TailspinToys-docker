
using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;
using Tailspin.Infrastructure;
namespace Tailspin.Web {
    public class TailspinViewEngine : WebFormViewEngine {

        public TailspinViewEngine() {
            ViewLocationFormats = new[] { 
               "~/{0}.aspx",
            };

            PartialViewLocationFormats = new[] {
                 "~/Shared/{0}.ascx",
            };

            MasterLocationFormats = new[] {
                "~/{0}.master",
            };

            ViewLocationCache = new DefaultViewLocationCache();
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache) {
            ViewEngineResult result = null;
            var request = controllerContext.RequestContext;
            if (controllerContext.Controller.GetType().BaseType == typeof(TailspinController)) {
                if (controllerContext.IsChildAction) {
                    result = base.FindPartialView(controllerContext, viewName, useCache);
                } else {
                    string templatedViewName = string.Format(CultureInfo.InvariantCulture, "~/{0}.aspx", viewName);

                    masterName = string.IsNullOrEmpty(masterName) ? "Template.master" : masterName;

                    result = base.FindView(controllerContext, templatedViewName, "~/" + masterName, useCache);
                }
            } else {
                result = base.FindView(controllerContext, viewName, masterName, useCache);
            }

            return result;
        }

    }
}