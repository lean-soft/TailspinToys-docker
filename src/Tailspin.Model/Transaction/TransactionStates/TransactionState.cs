using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public abstract class TransactionState {
        Order _order;
        public TransactionState(Order order) {
            _order = order;
        }

        public virtual bool IsSuccess {
            get {
                return false;
            }
        }

        public virtual bool InProcess {
            get {
                return false;
            }
        }

        public virtual void Queue() {
            throw new InvalidOperationException(string.Format("Can't Queue a {0} Transaction", this.GetType().Name));
        }
        public virtual void Fail() {
            throw new InvalidOperationException(string.Format("Can't Fail a {0} Transaction", this.GetType().Name));
        }

        public virtual void Success() {
            throw new InvalidOperationException(string.Format("Can't Success a {0} Transaction", this.GetType().Name));
        }

        public virtual void Process() {
            throw new InvalidOperationException(string.Format("Can't Process a {0} Transaction", this.GetType().Name));
        }

        public virtual void Retry() {
            throw new InvalidOperationException(string.Format("Can't Retry a {0} Transaction", this.GetType().Name));
        }

        internal void _Fail(){
            _order.TransactionStatus = new Failed(_order);
        }

        internal void _Queue() {
            _order.TransactionStatus = new Queued(_order);
        }
        internal void _Process() {
            _order.TransactionStatus = new Processed(_order);
        }
        internal void _Success() {
            _order.TransactionStatus = new Succeeded(_order);
        }

    }
}
