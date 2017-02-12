using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tailspin.Infrastructure;
using Tailspin.Model;
using System.Text;
using System.Web.Mvc.Html;

    public static class OrderExtensions {

        public static void RenderAddressDisplay(this ViewPage pg, Address address)
        {
            pg.Html.RenderPartial("AddressDisplay", address);
        }
        
        public static void RenderAddressEntry(this ViewPage pg)
        {
            pg.Html.RenderPartial("AddressEntry");
        }
        
        public static void RenderCreditCard(this ViewPage pg)
        {
            pg.Html.RenderPartial("CreditCard");
        }

        public static Order CurrentOrder(this ViewUserControl pg) {
            return CurrentOrder(pg.Page as ViewPage);
        }
        public static  Order CurrentOrder(this ViewPage pg) {
            Order result = null;
            
            if (pg.TempData["CurrentOrder"] != null)
                result = (Order)pg.TempData["CurrentOrder"];

            return result;
        }

        public static IList<ShippingMethod> ShippingMethods(this IViewDataContainer pg) {
            IList<ShippingMethod> result = null;
            if (pg.ViewData["ShippingMethods"] != null)
                result = (IList<ShippingMethod>)pg.ViewData["ShippingMethods"];

            return result;
        }
        public static ShippingMethod SelectedShipping(this IViewDataContainer pg) {
            ShippingMethod result = null;
            if (pg.ViewData["SelectedShipping"] != null)
                result = (ShippingMethod)pg.ViewData["SelectedShipping"];

            return result;
        }


    }



