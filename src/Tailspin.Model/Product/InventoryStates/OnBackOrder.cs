using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    [DataContract]
    public class OnBackOrder : InventoryState {
        public OnBackOrder(Product item) {
            _item = item;
        }

        public override bool CanView {
            get {
                return true;
            }
        }
        public override int DeliveryDelayInDays {
            get {
                return 14;
            }
        }
        public override string Description {
            get {
                return "On Backorder";
            }
        }
    }
}
