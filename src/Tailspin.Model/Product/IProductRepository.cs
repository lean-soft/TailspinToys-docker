using System;
using System.Collections.Generic;
namespace Tailspin.Model {
    public interface IProductRepository {
        Product GetProduct(string sku);
        IList<Product> GetProducts();
        IList<Product> GetNewProducts();
        ProductCategory GetProductCategory(string code);
        IList<Product> GetProductsForCategory(string categoryCode);
        IList<ProductCategory> GetProductCategories();
    }
}
