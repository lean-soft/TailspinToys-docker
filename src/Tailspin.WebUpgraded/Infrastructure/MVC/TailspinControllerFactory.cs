using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using Tailspin.Model;
using Tailspin.Infrastructure;

namespace Tailspin.Web {
    public class TailspinControllerFactory : DefaultControllerFactory {

        protected override IController GetControllerInstance(RequestContext context, Type controllerType) {
            IController result = null;
            if (controllerType != null) {
                try {
                    TailspinController controller = ObjectFactory.GetInstance(controllerType) as TailspinController;
                    result = controller;

                } catch (StructureMapException) {
                    System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                    throw;
                }
            }
            return result;
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}