using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class Succeeded : TransactionState {
        public Succeeded(Order order) : base(order) { }

        public override bool IsSuccess {
            get {
                return true;
            }
        }
    
    }


}
