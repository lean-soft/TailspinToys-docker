using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class NewOrder : OrderState {
        public NewOrder(){}
        public NewOrder(Order order):base(order) {
            this.ID = 1;
        }
        public override bool CanApplyDiscount {
            get {
                return true;
            }
        }
        public override bool CanChangeItems {
            get {
                return true;
            }
        }
        public override void Submit() {
            _Submit();
        }
    }
}
