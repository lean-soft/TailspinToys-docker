using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Admin.App.Model;

namespace Tailspin.Admin.App
{
    class ProductRelationship
    {
         
        public ProductRelationship(Product product)
        {
            Product = product;
        }

        public Product Product
        {
            get;
            private set;
        }

        public bool IsRelated;
    }
}
