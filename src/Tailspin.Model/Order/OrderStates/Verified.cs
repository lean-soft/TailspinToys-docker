using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Verified : OrderState {
        public Verified() { }
        public Verified(Order order)
            : base(order) {
            ID = 3;
        }

        public override void Charge() {
            _Charge();
        }

        public override void Cancel() {
            _Cancel();
        }
    }
}
