using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {

    public class OrderLine {

        public OrderLine(DateTime dateAdded, int quantity, Product product) {
            _dateAdded = dateAdded;
            _quantity = quantity;
            _item = product;
        }

        DateTime _dateAdded;
        public DateTime DateAdded {
            get {
                return _dateAdded;
            }
        }
        int _quantity;
        public int Quantity {
            get {
                return _quantity;
            }
        }
        Product _item;
        public Product Item {
            get {
                return _item;
            }
        }
        public decimal LineTotal{
            get {
                return Item.Price * Quantity;
            }
        }
        public decimal LineWeightInPounds {
            get {
                return Item.WeightInPounds * Quantity;
            }
        }

        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is OrderLine) {
                OrderLine compareTo = (OrderLine)obj;
                return compareTo.Item.SKU == this.Item.SKU;
            }
            else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return this.Item.Name;
        }
        public override int GetHashCode() {
            return this.Item.SKU.GetHashCode();
        }
        #endregion


    }
}
