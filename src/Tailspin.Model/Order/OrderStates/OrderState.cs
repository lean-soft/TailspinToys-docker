using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {

    /// <summary>
    /// State pattern for progressing the order through it's lifecycle
    /// This class can be implemented for every valid transition state
    /// for an Order
    /// </summary>
    [Serializable]
    public abstract class OrderState {
        public OrderState() { }

        /// <summary>
        /// Default .ctor
        /// </summary>
        public OrderState(Order order) {
            this.Order = order;
        }

        /// <summary>
        /// Corresponds to a State identifier
        /// </summary>
        public int ID { get; set; }
        internal Order Order { get; set; }

        /// <summary>
        /// Defines if the order can have discounts applied
        /// </summary>
        public virtual bool CanApplyDiscount {
            get {
                return false;
            }
        }

        /// <summary>
        /// Defines if order can have items changed
        /// </summary>
        public virtual bool CanChangeItems {
            get {
                return false;
            }
        }

        /// <summary>
        /// Transition the order to Submitted
        /// </summary>
        public virtual void Submit() {
            throw new InvalidOperationException(string.Format("Can't Submit a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Cancelled
        /// </summary>
        public virtual void Cancel() {
            throw new InvalidOperationException(string.Format("Can't Cancel a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Refunded
        /// </summary>
        public virtual void Refund() {
            throw new InvalidOperationException(string.Format("Can't Refund a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Shipped
        /// </summary>
        public virtual void Ship() {
            throw new InvalidOperationException(string.Format("Can't Ship a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Charged
        /// </summary>
        public virtual void Charge() {
            throw new InvalidOperationException(string.Format("Can't Charge a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Returned
        /// </summary>
        public virtual void Return() {
            throw new InvalidOperationException(string.Format("Can't Return a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Closed
        /// </summary>
        public virtual void Close() {
            throw new InvalidOperationException(string.Format("Can't Close a {0} Order", this.GetType().Name));
        }

        /// <summary>
        /// Transition the order to Verified
        /// </summary>
        public virtual void Verify() {
            throw new InvalidOperationException(string.Format("Can't Verify a {0} Order", this.GetType().Name));
        }
        //internals
        internal void _Cancel(){
            Order.CurrentState=new Cancelled(Order);
            Order.OnCancelled(EventArgs.Empty);
        }

        internal void _Charge(){
            Order.CurrentState=new Charged(Order);
            Order.OnCharged(EventArgs.Empty);
        }
        internal void _Close(){
            Order.CurrentState=new Closed(Order);
            Order.OnClosed(EventArgs.Empty);
        }
        internal void _Refund(){
            Order.CurrentState=new Refunded(Order);
            Order.OnRefunded(EventArgs.Empty);
        }
        internal void _Return(){
            Order.CurrentState=new Returned(Order);
            Order.OnReturned(EventArgs.Empty);
        }
        internal void _Ship(){
            Order.CurrentState=new Shipped(Order);
            Order.OnShipped(EventArgs.Empty);
        }
        internal void _Submit(){
            Order.CurrentState=new Submitted(Order);
            Order.OnSubmitted(EventArgs.Empty);
        }
        internal void _Verify() {
           
            Order.CurrentState=new Verified(Order);
            Order.OnVerified(EventArgs.Empty);
        }
    }
}
