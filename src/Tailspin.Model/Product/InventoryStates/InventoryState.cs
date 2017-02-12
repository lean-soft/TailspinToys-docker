using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    [DataContract]
    public abstract class InventoryState {

        public bool CanOrder() {
            //reads pretty well eh? Love the state pattern :)
            return this is InStock || this is OnBackOrder || this is OnPreOrder;
        }

        //this method sets the initial state of your inventory
        public static InventoryState SetState(Product item, int amountOnHand, bool allowBackOrder, DateTime dateAvailable) {
            InventoryState result = null;

            if (item.IsOnPreOrder()) {
                result=new OnPreOrder(item);
            } else if (item.IsUnavailable()) {
                result = new Unavailable(item);
            } else if (item.IsOnBackOrder()) {
                result = new OnBackOrder(item);
            } else {
             result = new InStock(item);
            }

            return result;
        }

        protected Product _item;

        public virtual string Description {
            get {
                return "Available";
            }
        }
        public virtual int DeliveryDelayInDays { 
            get{
                return 0;
            }
        }
        public virtual bool CanView {
            get {
                return true;
            }
        }
        public virtual bool ReorderFlag {
            get {
                return false;
            }
        }

        public virtual void SetAsAvalable() {
            _item.CurrentInventory = new InStock(_item);
        }

        public virtual void PutOnBackOrder() {
            _item.CurrentInventory = new OnBackOrder(_item);
        }

        public virtual void PutOnPreOrder() {
            _item.CurrentInventory = new OnPreOrder(_item);
        }

        public virtual void TakeOffline() {
            _item.CurrentInventory = new Unavailable(_item);
        }


    }
}
