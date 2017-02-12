using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tailspin.Admin.App.Model;

namespace Tailspin.Admin.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CatalogDataContext catalog;
        Product currentProduct;
        IList<ProductRelationship> relateds;

        public MainWindow()
        {
            InitializeComponent();
            catalog = new CatalogDataContext();
            var products = from p in catalog.Products select p;
            ProductsGrid.ItemsSource = products;
        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentProduct = (Product) e.AddedItems[0];
            TitleTextBox.DataContext = currentProduct.ProductDescriptors[0];
            TitleTextBox.SetBinding(TextBox.TextProperty, "Title");
            BodyTextBox.DataContext = currentProduct.ProductDescriptors[0];
            BodyTextBox.SetBinding(TextBox.TextProperty, "Body");
            relateds = WrapRelateds(currentProduct, from p in catalog.Products select p);
            RelatedGrid.ItemsSource = relateds;
        }

        private IList<ProductRelationship> WrapRelateds(Product product, IEnumerable<Product> products)
        {
            List<ProductRelationship> relationships = new List<ProductRelationship>();
            foreach (Product p in products)
            {
                ProductRelationship relationship = new ProductRelationship(p);
                relationship.IsRelated = product.Products_Relateds1.
                        Where<Products_Related>(r => r.RelatedSKU == p.SKU).Count() > 0;
                relationships.Add(relationship);
            }
            return relationships;       
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> relatedSKUs = from r in relateds
                                                where r.IsRelated
                                                orderby r.Product.SKU
                                                select r.Product.SKU;
            IEnumerable<string> existingRelatedSKUs = from pr in currentProduct.Products_Relateds1
                                                      orderby pr.RelatedSKU
                                                      select pr.RelatedSKU;
            foreach (string addSKU in relatedSKUs)
            {
                if (!existingRelatedSKUs.Contains<string>(addSKU))
                {
                    Products_Related pr = new Products_Related();
                    pr.SKU = currentProduct.SKU;
                    pr.RelatedSKU = addSKU;
                    currentProduct.Products_Relateds1.Add(pr);
                }
            }
            foreach (string removeSKU in existingRelatedSKUs)
            {
                if (!relatedSKUs.Contains(removeSKU))
                {
                    Products_Related pr = new Products_Related();
                    pr.SKU = currentProduct.SKU;
                    pr.RelatedSKU = removeSKU;
                    currentProduct.Products_Relateds1.Remove(pr);
                }
            }
            catalog.SubmitChanges();
        }

    }
}
