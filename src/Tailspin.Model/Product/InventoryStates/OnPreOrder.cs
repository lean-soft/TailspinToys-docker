using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    [DataContract]
    public class OnPreOrder : InventoryState {

        public OnPreOrder(Product item) {
            _item = item;
        }

        public override int DeliveryDelayInDays {
            get {
                return 30;
            }
        }
        public override string Description {
            get {
                return "On Pre-order";
            }
        }
    }
}
