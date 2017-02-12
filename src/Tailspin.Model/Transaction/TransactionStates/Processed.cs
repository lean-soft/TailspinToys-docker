using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Processed : TransactionState {

        public Processed(Order order) : base(order) { }
        public override bool InProcess {
            get {
                return true;
            }
        }
        public override void Fail() {
            _Fail();
        }
        public override void Success() {
            _Success();
        }
    }
}
