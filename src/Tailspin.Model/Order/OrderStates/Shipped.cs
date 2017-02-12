using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Shipped : OrderState {
        public Shipped() { }
        public Shipped(Order order)
            : base(order) {
            ID = 6;
        }

        public override void Return() {
            _Return();
        }
        public override void Close() {
            _Close();
        }
    }
}
