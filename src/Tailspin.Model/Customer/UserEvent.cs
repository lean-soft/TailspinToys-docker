using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public enum UserBehavior {
        LoggingIn = 1,
        LoggingOut = 2,
        AddItemToBasket = 3,
        RemoveItemFromBasket = 4,
        CheckoutBilling = 5,
        CheckoutShipping = 6,
        CheckoutFinal = 7,
        ViewOrder = 8,
        ViewBasket = 9,
        ViewCategory = 10,
        ViewProduct = 11
    }


    [Serializable]
    public class UserEvent {
        public string UserName { get; set; }
        public string IP { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CategoryID { get; set; }
        public string SKU { get; set; }
        public Guid? OrderID { get; set; }
        public UserBehavior Behavior { get; set; }

        public UserEvent() {
            this.DateCreated = DateTime.Now;
        }

        public UserEvent(string userName, string IP, int? categoryID, string sku, Guid orderID,
            UserBehavior behavior) {
            this.DateCreated = DateTime.Now;
            UserName = userName;
            this.IP = IP;
            this.CategoryID = categoryID;
            this.SKU = sku;
            this.OrderID = orderID;
            this.Behavior = behavior;
        }


    }
}
