using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Failed : TransactionState {

        public Failed(Order order) : base(order) { }
        
        public override void Retry() {
            _Queue();
        }

    }
}
