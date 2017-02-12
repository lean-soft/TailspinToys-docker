using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;

namespace Tailspin.Model {
    public class Shipment {
        public Shipment(Order order) {
            Destination = order.ShippingAddress;
        }
        public Guid OrderID { get; set; }
        public Address Destination { get; set; }
        public Address Pickup { get; set; }
        public IList<Package> Items { get; set; }
        public IList<ShippingMethod> ShippingOptions { get; set; }
        public ShippingMethod SelectedShipping { get; set; }

    }
}
