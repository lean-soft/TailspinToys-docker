using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tailspin.Model;
using Tailspin.Infrastructure;

namespace Tailspin.Web {
    public class TailspinController:Controller {

        const int PAGE_SIZE = 20;
        ICustomerRepository _customerRepository;
        string _thisUserName;
        public TailspinController() { }
        public TailspinController(ICustomerRepository customerRepository) {

            _customerRepository = customerRepository;
            SetCustomer(false);
        }

        public void SetCustomer(bool reset) {
            _thisUserName = this.GetCommerceUserName(reset);

            var customer = _customerRepository.GetCustomer(_thisUserName);
            if (customer == null) {
                customer = new Customer();
                customer.UserName = _thisUserName;
                
                customer.LastName = "";
                customer.Email = "";
                customer.LanguageCode = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                customer.FirstName = "Guest";
                //save em
                //_customerRepository.AddCustomer(customer);
                this.RememberCommerceUser(_thisUserName);
            }
            this.CurrentCustomer = customer;
            this.CurrentCart = customer.Cart;
        }

        public void SaveCart() {
            _customerRepository.SaveCart(this.CurrentCart);
        }


        IList<ShippingMethod> _shippingMethods;
        public IList<ShippingMethod> ShippingMethods {
            get {
                return _shippingMethods;
            }
            set {
                _shippingMethods = value;
                ViewData["ShippingMethods"] = _shippingMethods;
            }
        }

        public ShoppingCart CurrentCart {
            get {

                return (ShoppingCart)ViewData["CurrentCart"];
            }
            set {
                ViewData["CurrentCart"] = value;
            }
        }
        
        public Customer CurrentCustomer {
            get {
                return (Customer)ViewData["CurrentCustomer"];
            }
            set {
                ViewData["CurrentCustomer"] = value;
            }
        }

        public Order NewOrder {
            get
            {
                return (Order)ViewData["NewOrder"];
            }
            set
            {
                ViewData["NewOrder"] = value;
            }
        }

        IList<Product> _products;
        public IList<Product> Products {
            get {
                return _products;
            }
            set {
                _products = value;
                ViewData["Products"] = _products;
            }
        }

        Product _product;
        public Product SelectedProduct {
            get {
                return _product;
            }
            set {
                _product = value;
                ViewData["SelectedProduct"] = _product;
            }
        
        }

    }
}
