using System;
using Tailspin.Infrastructure;
namespace Tailspin.Model {
    public interface ICustomerRepository {
        Customer GetCustomer(string userName);
        void Save(Customer c);
        void SaveCart(ShoppingCart cart);
        int SaveAddress(Address address);
    }
}

