using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Returned : OrderState {
        public Returned() { }
        public Returned(Order order)
            : base(order) {
            this.ID = 7;
            order.OnReturned(EventArgs.Empty);
        }

        public override void Cancel() {
            _Cancel();
            _Close();
        }
        public override void Refund() {
            _Refund();
            _Close();
        }
        public override void Close() {
            _Close();
        }
    }
}
