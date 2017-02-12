using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    [DataContract]
    public class Unavailable : InventoryState {

        public Unavailable(Product item) {
            _item = item;
        }

        public override bool CanView {
            get {
                return false;
            }
        }
        public override int DeliveryDelayInDays {
            get {
                return -1;
            }
        }
        public override string Description {
            get {
                return "This item is unavailable";
            }
        }
        

    }
}
