using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Cancelled : OrderState {
        public Cancelled() { }
        public Cancelled(Order order)
            : base(order) {
            this.ID = 8;
        }
        public override void Refund() {
            _Refund();
        }
    }
}
