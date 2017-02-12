using System;
using System.Collections.Generic;
using Tailspin.Infrastructure;
namespace Tailspin.Model {
    public interface IOrderRepository {
        Order GetOrder(Guid orderID);
        void Save(Order order, Transaction transaction);
        IList<ShippingMethod> GetShippingMethods();

    }
}

