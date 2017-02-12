using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {

    
    /// <summary>
    /// This is a loose version of the Specification pattern
    /// In this case we're using Extension methods instead of a defined class
    /// Works nicely for discoverability
    /// </summary>
    public static class InventorySpecifications {
        public static bool IsAvailable(this Product item) {
            return item.AmountOnHand > 0 && item.DateAvailable < DateTime.Now;
        }
        public static bool IsOnPreOrder(this Product item) {
            return item.DateAvailable > DateTime.Now && item.AllowPreOrder;
        }

        public static bool IsOnBackOrder(this Product item) {
            return item.AmountOnHand <= 0 &&
                item.DateAvailable < DateTime.Now 
                && item.AllowBackOrder;
        }

        public static bool IsUnavailable(this Product item) {

            return item.AmountOnHand <= 0 && 
                item.DateAvailable < DateTime.Now &! 
                item.AllowBackOrder;
        }
    }
}
