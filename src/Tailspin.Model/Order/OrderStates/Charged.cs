using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Charged : OrderState {
        public Charged() { }
        public Charged(Order order)
            : base(order) {
            ID = 4;
        }

        public override void Ship() {
            _Ship();
        }
        public override void Refund() {
            _Refund();
            _Close();
        }
    }
}
