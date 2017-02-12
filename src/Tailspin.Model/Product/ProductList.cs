using System;
using System.Collections.Generic;

namespace Tailspin.Model {

    public class ProductList {

        public ProductList(string title, IList<Product> products) {

            Title = title;
            Products = products;
        }  
        
        public string Title { get; set; }
        public IList<Product> Products { get; set; }

        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is ProductList) {
                ProductList compareTo = (ProductList)obj;
                if (compareTo.Title == this.Title)
                {
                    return compareTo.Products == this.Products;
                }
            }
            return base.Equals(obj);
        }

        public override string ToString() {
            return this.Title;
        }
        public override int GetHashCode() {
            return this.Title.GetHashCode() ^ this.Products.GetHashCode();
        }
        #endregion
    }
}
