using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Tailspin.Model;
using Tailspin.Infrastructure;

namespace Tailspin.Web.App.Controllers
{

    //TODO - make sure we only accept ValidTokens!
    public class CartController : TailspinController
    {
        IProductRepository _productRepository;
        ICustomerRepository _customerRepository;
       
        public CartController(ICustomerRepository customerRepository,
            IProductRepository productRepository) : base(customerRepository) {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Cart Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddItem(string sku) {

            Product p=_productRepository.GetProduct(sku);
            if(p==null)
                throw new InvalidOperationException("Invalid SKU");
            this.CurrentCart.AddItem(p);
            this.SaveCart();
            return RedirectToAction("Show");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveItem(string id) {

            this.CurrentCart.RemoveItem(id);
            this.SaveCart();
            return RedirectToAction("Show");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateItem(string id) {
            string sQuantity = Request.Form["quantity"];
            
            if (!string.IsNullOrEmpty(sQuantity)) {
                int newQuantity = 0;
                int.TryParse(sQuantity, out newQuantity);
                if (newQuantity > 0) {

                    this.CurrentCart.AdjustQuantity(id, newQuantity);
                    this.SaveCart();
                }
            }
            return RedirectToAction("Show");
        }
        public ActionResult Show() {
            //all the cart info is pulled by the base class
            return View("Cart");
        }

        #endregion
    
    
    
    
    }
}
