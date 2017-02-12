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
    public class OrderController : TailspinController
    {
        IOrderRepository _orderRepository;
        ICustomerRepository _customerRepository;

        public OrderController(ICustomerRepository customerRepository,
            IOrderRepository orderRepository) : base(customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public IOrderRepository OrderRepository
        {
            get
            {

                return _orderRepository;
            }
        }
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout() {
            //they need to have items in their cart
            if (this.CurrentCart.Items.Count == 0)
                return RedirectToAction("Show","Cart");
            else
                return View("Address");

        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Address(int? id) {

            id = id ?? 0;
            if (id > 0) {
                this.CurrentCustomer.DefaultAddress = this.CurrentCustomer.AddressBook.Where(x => x.AddressID == (int)id).SingleOrDefault();
            }
            return View("Shipping");

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Address(Address address) {

            ValidateAddress(address);

            if (ModelState.IsValid) {

                //save the address
                address.AddressID = _customerRepository.SaveAddress(address);
                this.CurrentCart.ShippingAddress = address; 

                //calc the tax
                this.CurrentCart.TaxAmount = this.CalculateTax(this.CurrentCart);
                this.CurrentCart.BillingAddress = address;

                //set the shipping methods
                this.ShippingMethods = this.GetShippingMethods(this.CurrentCart);

                //default to the first
                this.CurrentCart.ShippingService = this.ShippingMethods[0].ServiceName;
                this.CurrentCart.ShippingAmount = this.ShippingMethods[0].Cost;
                this.CurrentCart.ShippingMethodID = this.ShippingMethods[0].ID;
                
                
                //save the cart
                this.SaveCart();

                //send to billing
                return RedirectToAction("Finalize");
            } else {
                //let error handling pick it up
                return View();
            }
        }

        private void ValidateAddress(Address address)
        {
            // Validation logic
            if (String.IsNullOrEmpty(address.FirstName))
                ModelState.AddModelError("FirstName", "First name is required.");
            if (String.IsNullOrEmpty(address.LastName))
                ModelState.AddModelError("LastName", "Last name is required.");
            if (String.IsNullOrEmpty(address.Email))
                ModelState.AddModelError("Email", "E-mail name is required.");
            if (String.IsNullOrEmpty(address.Street1))
                ModelState.AddModelError("Street1", "Street is required.");
            if (String.IsNullOrEmpty(address.City))
                ModelState.AddModelError("City", "City is required.");
            if (String.IsNullOrEmpty(address.StateOrProvince))
                ModelState.AddModelError("StateOrProvince", "State or province is required.");
            if (String.IsNullOrEmpty(address.Zip))
                ModelState.AddModelError("Zip", "Zip code is required.");
            if (String.IsNullOrEmpty(address.Country))
                ModelState.AddModelError("Country", "Country is required.");
        }
      
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Payment(CreditCard card) {
            //set the card
            this.CurrentCart.CreditCard = card;
            
            //create an order
            Order order = new Order(this.CurrentCustomer, DateTime.Now.Ticks.ToString());
            this.TempData["CurrentOrder"] = order;

            //TODO: - check boolean
            this.ValidateOrder(order);

            //execute the payment..
            Transaction trans = this.AuthorizeCreditCard(order);
            
            
            //on success send to Receipt
            if (trans.TransactionErrors.Count == 0) {

                //save it down
                //_orderRepository.Save(order, trans);
                SetCustomer(true);

                return RedirectToAction("Receipt", new { id = order.ID.ToString() });

            } else {

                ViewData["ErrorMessage"] = trans.TransactionErrors[0];

                //let the View know
                return View("Finalize");

            }

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Finalize() {
            this.ShippingMethods = this.GetShippingMethods(this.CurrentCart);

            this.CurrentCart.ShippingService = this.ShippingMethods[0].ServiceName;
            this.CurrentCart.ShippingAmount = this.ShippingMethods[0].Cost;
            this.CurrentCart.ShippingMethodID = this.ShippingMethods[0].ID;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Finalize(int? id) {
            if (id > 0) {
                this.ShippingMethods = this.GetShippingMethods(this.CurrentCart);
                var selectedShipping = this.ShippingMethods.SingleOrDefault(x => x.ID == id);
                this.CurrentCart.ShippingService = selectedShipping.ServiceName;
                this.CurrentCart.ShippingMethodID = selectedShipping.ID;
                this.CurrentCart.ShippingAmount = selectedShipping.Cost;
            }
            return View();
        }
        
        public ActionResult Receipt() {
            return View();
        }
    }
}
