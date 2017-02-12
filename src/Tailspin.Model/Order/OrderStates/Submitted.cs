using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Submitted : OrderState {
        public Submitted() { }
        public Submitted(Order order)
            : base(order) {
            this.ID = 2;
        }


        public override void Submit() {
            //ignore
        }

        public override void Cancel() {
            _Cancel();
        }
        public override void Verify() {
            _Verify();
        }
    }
}
