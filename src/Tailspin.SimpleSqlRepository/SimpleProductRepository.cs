using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Model;
using Tailspin.Infrastructure;
using System.Data;
using System.Data.Common;

namespace Tailspin.SimpleSqlRepository {
    
    public class SimpleProductRepository:IProductRepository {

        string connectionStringName = "TailspinConnectionString";
        internal Product LoadProduct(DbDataReader rdr) {
            return new Product(
                ProductsTable.ReadSKU(rdr),
                ProductsTable.ReadProductName(rdr),
                ProductsTable.ReadBlurb(rdr),
                ProductsTable.ReadIsTaxable(rdr),
                ProductsTable.ReadWeightInPounds(rdr),
                ProductsTable.ReadAmountOnHand(rdr),
                ProductsTable.ReadDateAvailable(rdr),
                ProductsTable.ReadAllowBackOrder(rdr),
                ProductsTable.ReadAllowPreOrder(rdr))
            {

                DefaultImage = new Image(
                    ProductsTable.ReadDefaultImageFile(rdr),
                    ProductsTable.ReadDefaultImageFile(rdr)),
                EstimatedDelivery = ProductsTable.ReadEstimatedDelivery(rdr),
                Price = ProductsTable.ReadBasePrice(rdr)
            };
        }

        internal ProductCategory LoadProductCategory(DbDataReader rdr)
        {
            return new ProductCategory(CategoriesTable.ReadCode(rdr), CategoriesTable.ReadTitle(rdr));
        }

        public Product GetProduct(string sku) {
            Product result=null;
            var batch = new BatchSql();
            batch.Append(ProductsTable.Select().Where(ProductsTable.ColumnsQualified.SKU, sku));
            
            //desciptors
            batch.Append(ProductDescriptorsTable.Select()
                .Where(ProductDescriptorsTable.ColumnsQualified.SKU, sku)
                .And(ProductDescriptorsTable.ColumnsQualified.LanguageCode,System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName));
            
            //images
            batch.Append(ProductImagesTable.Select().Where(ProductImagesTable.ColumnsQualified.SKU, sku));
            
            //cross sells
            batch.Append(ProductsTable.Select().Add("\r\nWHERE sku in (SELECT CrossSku FROM Products_CrossSell WHERE Products_CrossSell.SKU=@p0)"));
            //TODO: Fix this
            
            
            //related
            batch.Append(ProductsTable.Select().Add("\r\nWHERE sku in (SELECT RelatedSKu FROM Products_Related WHERE Products_Related.SKU=@p0)"));

            var cmd = batch.BuildCommand(connectionStringName);
            
            using(var rdr=cmd.ExecuteReader(CommandBehavior.CloseConnection)){
                
                if(rdr.Read()){
                    result = LoadProduct(rdr);
                }
                if (result != null) {
                    //desciptors
                    result.Descriptors = new List<ProductDescriptor>();
                    if (rdr.NextResult()) {
                        while (rdr.Read()) {
                            result.Descriptors.Add(new ProductDescriptor(
                                ProductDescriptorsTable.ReadTitle(rdr),
                                ProductDescriptorsTable.ReadBody(rdr)
                                ));
                        }
                    }

                    //images
                    result.Images = new List<Image>();
                    if (rdr.NextResult()) {
                        while (rdr.Read()) {
                            result.Images.Add(new Image(
                                ProductImagesTable.ReadThumbUrl(rdr),
                                ProductImagesTable.ReadFullImageUrl(rdr)));
                        }
                    }

                    //cross sells
                    result.CrossSells = new List<Product>();
                    if (rdr.NextResult()) {
                        while (rdr.Read()) {
                            result.CrossSells.Add(LoadProduct(rdr));
                        }
                    }
                    //related
                    result.RelatedProducts = new List<Product>();
                    if (rdr.NextResult()) {
                        while (rdr.Read()) {
                            result.RelatedProducts.Add(LoadProduct(rdr));
                        }
                    }
                }
            }

            return result;

        }

        public IList<Product> GetProducts() {
            var sql = ProductsTable.Select();
            var cmd = sql.BuildCommand();
            List<Product> result = new List<Product>();


            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {

                while (rdr.Read()) {
                    result.Add(LoadProduct(rdr));
                }
            }
            return result;

        }

        public IList<Product> GetNewProducts()
        {
            var sql = ProductsTable.Select().Where(ProductsTable.ColumnsQualified.DateAvailable, Op.GreaterThan, DateTime.Now.AddDays(-7));
            var cmd = sql.BuildCommand();
            List<Product> result = new List<Product>();


            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {

                while (rdr.Read())
                {
                    result.Add(LoadProduct(rdr));
                }
            }
            return result;

        }

        public IList<Product> GetProductsForCategory(string categoryCode)
        {
            var sql = ProductsTable.Select().Where(ProductsTable.ColumnsQualified.DateAvailable, Op.GreaterThan, DateTime.Now.AddDays(-7));
            var cmd = sql.BuildCommand();
            List<Product> result = new List<Product>();


            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {

                while (rdr.Read())
                {
                    result.Add(LoadProduct(rdr));
                }
            }
            return result;
        }

        public ProductCategory GetProductCategory(string code)
        {
            ProductCategory result = null;
            var batch = new BatchSql();
            batch.Append(CategoriesTable.Select().Where(CategoriesTable.ColumnsQualified.Code, code));
            batch.Append(ProductsTable.Select().Add("\r\nWHERE SKU in (SELECT SKU FROM Categories_Products WHERE Categories_Products.CategoryCode=@p0)"));


            var cmd = batch.BuildCommand(connectionStringName);

            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                if (rdr.Read())
                {
                    result = LoadProductCategory(rdr);

                    if (result != null)
                    {
                        result.Products = new List<Product>();
                        if (rdr.NextResult())
                        {
                            while (rdr.Read())
                            {
                                result.Products.Add(LoadProduct(rdr));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public IList<ProductCategory> GetProductCategories()
        {
            var sql = CategoriesTable.Select();
            var cmd = sql.BuildCommand();
            List<ProductCategory> result = new List<ProductCategory>();

            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (rdr.Read())
                {
                    result.Add(LoadProductCategory(rdr));
                }
            }
            return result;
        }
    }
}
