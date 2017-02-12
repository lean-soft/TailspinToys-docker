using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tailspin.Infrastructure;
using Tailspin.Model;
using System.Data.Linq;
namespace Tailspin.Web.Controllers {

    [HandleError]
    public class HomeController : TailspinController {
        
        IProductRepository _productRepository;
        ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository,
            IProductRepository productRepository) : base(customerRepository)
        {
            
            _productRepository = productRepository;
            _customerRepository = customerRepository;

        }

        public ActionResult Index(string slug) {
            if (!string.IsNullOrEmpty(slug))
            {
                this.Products = this._productRepository.GetProductCategory(slug).Products;
                return View("Listing");
            }
            else
            {
                this.Products = null;
                return View("Home");
            } 
        }

        public ActionResult Show(string sku) {
            this.SelectedProduct = _productRepository.GetProduct(sku);
            return View("Detail");
        }

        public ActionResult About() {
            return View("About");
        }
    }
}
