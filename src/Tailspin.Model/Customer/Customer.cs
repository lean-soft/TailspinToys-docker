using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;

namespace Tailspin.Model {
    [Serializable]
    public class Customer:User, IAggregateRoot {
        public Customer() : this(Guid.NewGuid().ToString(), "", "", "") { }
        public Customer(string userName) : this(userName, "", "", "") { }
        public Customer(string userName, string email, string first, string last, ShoppingCart cart)
            : base(userName) {
            FirstName = first;
            LastName = last;
            Email = email;
            LanguageCode = "en";
            Cart = cart ?? new ShoppingCart();
            UserName = userName ?? Guid.NewGuid().ToString();
            
        }
        public Customer(string userName, string email, string first, string last):this(userName,email,first,last,null) {}
        new public string UserName { get; set; }
        new public string Email { get; set; }
        new public string FirstName { get; set; }
        new public string LastName { get; set; }
        new public string LanguageCode { get; set; }
        new public string FullName {
            get {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public ShoppingCart Cart { get; set; }
        
        public override string ToString() {
            return FullName;
        }

    }
}
