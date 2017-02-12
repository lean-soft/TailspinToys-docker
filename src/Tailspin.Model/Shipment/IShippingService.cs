using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;

namespace Tailspin.Model {
    public interface IShippingService {

        Shipment CalculateShipping(Order order);

    }
}
