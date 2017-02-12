using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Closed : OrderState {
        public Closed() { }
        public Closed(Order order)
            : base(order) {
            this.ID = 10;
        }
    }
}
