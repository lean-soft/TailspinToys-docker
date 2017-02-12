using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Tailspin.Infrastructure{
    public class StructureMapControllerFactory: DefaultControllerFactory {

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            IController result = null;
            if (controllerType != null)
            {
                try
                {
                    result = ObjectFactory.GetInstance(controllerType) as Controller;

                }
                catch (StructureMapException)
                {
                    System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                    throw;
                }
            }
            return result;
        }
    }
}