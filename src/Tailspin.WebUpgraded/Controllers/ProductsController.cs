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

    public class ProductsController : TailspinController
    {
        IProductRepository _productRepository;
        ICustomerRepository _customerRepository;
        
        public ProductsController(ICustomerRepository customerRepository,
            IProductRepository productRepository) : base(customerRepository) {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Products Actions

        public ActionResult FeaturedProduct() {
            return View("FeaturedProduct");
        }
       
        public ActionResult NewProducts() {
            return View("NewProducts", new ProductList("New Products", this._productRepository.GetNewProducts()));
        }

        public ActionResult ListProducts(IList<Product> products)
        {
            return View("ProductList", new ProductList("Products in Category", products));
        }

        public ActionResult ProductCategoryMenu()
        {
            return View("Menu", this._productRepository.GetProductCategories());
        }

        #endregion   
    }
}
