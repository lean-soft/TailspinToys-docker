using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    
    [Serializable]
    public abstract class PaymentMethod {
        string Name { get; set; }
        string AccountNumber { get; set; }
        DateTime Expiration { get; set; }
        string VerificationCode { get; set; }


    }
}
