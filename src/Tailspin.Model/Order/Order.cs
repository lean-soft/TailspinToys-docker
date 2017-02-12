using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Tailspin.Infrastructure;

namespace Tailspin.Model {

    [Serializable]
    public class Order {

        public Guid ID { get; set; }
        public string OrderNumber { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState CurrentState { get; set; }
        public TransactionState TransactionStatus { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public decimal ShippingAmount { get; set; }
        public string ShippingService { get; set; }
        public decimal TaxAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? DateShipped { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public string TrackingNumber { get; set; }
        
        public IList<OrderLine> Items { get; set; }

        public IList<Transaction> Transactions { get; set; }

        public IList<string> ValidationErrors { get; set; }
        public CreditCard CreditCard { get; set; }


        void SetOrderStatus(int orderStatusID) {
            switch (orderStatusID) {
                case 1:
                    CurrentState = new NewOrder(this);
                    break;
                case 2:
                    CurrentState = new Submitted(this);
                    break;
                case 3:
                    CurrentState = new Verified(this);
                    break;
                case 4:
                case 5:
                    CurrentState = new Charged(this);
                    break;
                case 6:
                    CurrentState = new Shipped(this);
                    break;
                case 7:
                    CurrentState = new Returned(this);
                    break;
                case 8:
                    CurrentState = new Cancelled(this);
                    break;
                case 9:
                    CurrentState = new Refunded(this);
                    break;
                case 10:
                    CurrentState = new Closed(this);
                    break;
            }
        }

        
        public Order(int orderStatusID) {
            SetOrderStatus(orderStatusID);

        }
        
        void ValidateCustomer(Customer customer) {

            //the customer cannot be null
            Validator.CheckNull(customer, Messages.NullCustomer);

            //neither can the their cart
            Validator.CheckNull(customer.Cart, Messages.NullCustomerCart);

            //cart must have 1 or more items
            Validator.CheckGreaterThan(x => x.Cart.Items.Count, customer, 1);

        }

        public Order(Customer customer, string orderNumber) {
            ValidateCustomer(customer);
            this.UserName = customer.UserName;
            this.OrderNumber = orderNumber;
            this.ID = Guid.NewGuid();
            this.DiscountAmount = 0;
            this.DiscountReason = "--";
            this.DateCreated = DateTime.Now;
            this.CurrentState = new NewOrder(this);

            //new up the lists
            Items = new LazyList<OrderLine>();
            Transactions = new LazyList<Transaction>();

            //add the items
            AddCartItemsToOrder(customer.Cart);
            this.ShippingAmount = customer.Cart.ShippingAmount;
            this.ShippingAddress = customer.Cart.ShippingAddress;
            this.ShippingService = customer.Cart.ShippingService;
        }

        void AddCartItemsToOrder(ShoppingCart cart) {
            
            foreach (ShoppingCartItem item in cart.Items) {
                AddLineItem(item);
            }
        }

        public void AddLineItem(ShoppingCartItem cartItem) {
            if (cartItem.Product == null)
                throw new InvalidOperationException(Messages.NullCartItemProduct);
            
            Product item = cartItem.Product;

            if (CurrentState.CanChangeItems) {
                OrderLine lineItem = new OrderLine(cartItem.DateAdded,cartItem.Quantity,item);
                this.Items.Add(lineItem);
            }
        }
        
        public void RemoveItem(string sku) {
             if (CurrentState.CanChangeItems) {
                 for (int i = 0; i < this.Items.Count; i++) {
                     if (this.Items[i].Item.SKU.Equals(sku))
                         this.Items.RemoveAt(i);
                 }
             }
        }

        public List<OrderLine> GetItems() {
            return this.Items.ToList();
        }

        public void ValidateForCheckout() {

            //Must have 1 or more items
            if (this.Items.Count <= 0)
                throw new InvalidOperationException(Messages.OrderZeroItems);

            //every order must have a shipping address - used for tax calcs
            if (this.ShippingAddress == null)
                throw new InvalidOperationException(Messages.NoAddress);


            //make sure there's a payment method
            if (this.PaymentMethod == null)
                throw new InvalidOperationException(Messages.NoPaymentMethod);


            if (this.PaymentMethod is CreditCard) {
                CreditCard cc = this.PaymentMethod as CreditCard;

                if (!cc.IsValid())
                    throw new InvalidOperationException(Messages.InvalidCreditCard);

            }


        }
        public decimal TaxableGoodsSubtotal
        {
            get
            {
                //one of the many reasons to love LINQ :)
                return this.Items.Where(x => x.Item.IsTaxable)
                    .Sum(x => x.LineTotal);
            }
        }
        public decimal TotalWeightInPounds
        {
            get
            {
                return this.Items.Sum(x => x.LineWeightInPounds);
            }
        }

        public string DiscountReason { get; set; }
        public decimal DiscountAmount { get; set; }
             
        public decimal SubTotal
        {
            get
            {

                return this.Items.Sum(x => x.LineTotal)-DiscountAmount;

            }
        }

        public decimal Total
        {
            get
            {
                decimal total= SubTotal + TaxAmount;

                return total;
            }
        }

        public decimal TotalPaid
        {
            get
            {
                decimal paid = 0;
                if (this.Transactions.Count > 0)
                    paid = this.Transactions.Sum(x => x.Amount);
                return paid;

            }
        }

        /// <summary>
        /// Returns the sum of the item quantity in the cart. 
        /// </summary>
        public int TotalItemQuantity
        {
            get
            {
                int numItems = 0;
                if (this.Items.Count > 0)
                {
                    numItems = (from i in this.Items
                                select i.Quantity).Sum();
                }
                return numItems; 
            }
        }

        /// <summary>
        /// Reprices all items in the cart to reflect update item prices. 
        /// </summary>
        /// <returns>
        /// True if the operation resulted in a change in the 
        /// total price of the order.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// Throws an InvalidOperationException if the cart 
        /// has been checked out. 
        /// </exception>
        //public bool RepriceItems()
        //{
        //    if (this.Status != OrderStatus.NotCheckoutOut)
        //    {
        //        throw new InvalidOperationException("Order may not be repriced once checked out."); 
        //    }

        //    decimal startingTotal = this.Total; 
        //    foreach (OrderItem item in this.Items)
        //    {
        //        item.LineItemPrice = item.Product.DiscountedPrice; 
        //    }
        //    return startingTotal != this.Total; 
        //}


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is Order) {
                Order compareTo = (Order)obj;
                return compareTo.ID == this.ID;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return UserName + "'s Cart: " + this.Items.Count.ToString() + " items";
        }
        public override int GetHashCode() {
            return this.ID.GetHashCode();
        }
        #endregion


        #region Eventing
        public event OrderCreatedEventHandler Created;
        internal virtual void OnCreated(EventArgs e) {
            if (Created != null)
                Created(this,e);
        }



        public event SubmittedEventHandler Submitted;
        internal virtual void OnSubmitted(EventArgs e) {
            if (Submitted != null)
                Submitted(this, e);
        }

        
        public event CancelledEventHandler Cancelled;
        internal virtual void OnCancelled(EventArgs e) {
            if (Cancelled != null)
                Cancelled(this, e);
        }
        
        public event RefundedEventHandler Refunded;
        internal virtual void OnRefunded(EventArgs e) {
            if (Refunded != null)
                Refunded(this, e);
        }
        
        public event ReturnedEventHandler Returned;
        internal virtual void OnReturned(EventArgs e) {
            if (Returned != null)
                Returned(this, e);
        }

        public event ClosedEventHandler Closed;
        internal virtual void OnClosed(EventArgs e) {
            if (Closed != null)
                Closed(this, e);
        }
        public event ShippedEventHandler Shipped;
        internal virtual void OnShipped(EventArgs e) {
            if (Shipped != null)
                Shipped(this, e);
        }
        public event VerifiedEventHandler Verified;
        internal virtual void OnVerified(EventArgs e) {
            if (Verified != null)
                Verified(this, e);
        }
        public event ChargedEventHandler Charged;
        internal virtual void OnCharged(EventArgs e) {
            if (Charged != null)
                Charged(this, e);
        }
        #endregion
    }
    public delegate void OrderCreatedEventHandler(object sender, EventArgs e);
    public delegate void SubmittedEventHandler(object sender, EventArgs e);
    public delegate void CancelledEventHandler(object sender, EventArgs e);
    public delegate void ClosedEventHandler(object sender, EventArgs e);
    public delegate void RefundedEventHandler(object sender, EventArgs e);
    public delegate void ReturnedEventHandler(object sender, EventArgs e);
    public delegate void ShippedEventHandler(object sender, EventArgs e);
    public delegate void VerifiedEventHandler(object sender, EventArgs e);
    public delegate void ChargedEventHandler(object sender, EventArgs e);


}
