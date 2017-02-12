using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Refunded : OrderState {
        public Refunded() { }
        public Refunded(Order order):base(order) {
            this.ID = 9;

        }
        public override void Close() {
            _Close();
        }
    }
}
