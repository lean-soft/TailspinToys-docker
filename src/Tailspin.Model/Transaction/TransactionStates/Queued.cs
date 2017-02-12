using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Queued : TransactionState {
        public Queued(Order order) : base(order) { }
        public override bool InProcess {
            get {
                return true;
            }
        }
        public override void Process() {
            _Process();
        }
    }
}
