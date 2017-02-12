using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tailspin.Model;

namespace Tailspin.Tests
{
    /*
   Things we know about shopping carts
    * 
    * Carts hold products
    * Carts hold the "meta data" of products such as quantity
    * Carts should have a Total Cost of products
    * Carts should have a Line Item Total (price*quantity)
    * When an item is added to a cart, the quantity is incremented by items added
    * When an item is removed from a cart, all items of same SKU are removed
    * If an item is added to a cart with quantity 0, nothing happens
    * if an item is added to a cart with -quantity, items are removed
    * if an item quantity is adjusted leaving 0 items, the item is completely removed - ONLY when RemoveItem is used
    * A cart should hold Billing/Shipping addresses
    * A cart should hold TaxAmount
    * A cart should hold SelectedShipping
    * It's OK to fail - name it "Monkey"
   */
    [TestClass]
    public class ShoppingCartTests
    {

        public ShoppingCartTests()
        {
        }

        [TestMethod]
        public void Total_Should_Be_1_When_1_Product_Added()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            cart.AddItem(new Product("SKU"));
            Assert.AreEqual(1, cart.TotalItems);
        }

        [TestMethod]
        public void Total_Should_Be_2_When_2_Different_Products_Added()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            cart.AddItem(new Product("SKU1"));
            cart.AddItem(new Product("SKU2"));
            Assert.AreEqual(2, cart.TotalItems);
        }

        //[TestMethod]
        //public void Total_Should_Be_2_When_2_Same_Products_Added() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    cart.AddItem(p);
        //    cart.AddItem(p);
        //    Assert.AreEqual(2, cart.TotalItems);
        //}
        //[TestMethod]
        //public void Total_Should_Be_0_When_1_of_2_Same_Products_Removed() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    cart.AddItem(p);
        //    cart.AddItem(p);
        //    Assert.AreEqual(2, cart.TotalItems);
        //    cart.RemoveItem(p);
        //    Assert.AreEqual(0, cart.TotalItems);
        //}

        [TestMethod]
        public void Items_Count_Should_Be_1_When_2_of_Same_Product_Added()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p);
            cart.AddItem(p);
            Assert.AreEqual(1, cart.Items.Count);
        }

        //[TestMethod]
        //public void Item_Should_Have_LineTotal_Of_10_With_2_Products_With_Price_5() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    p.Price = 5;
        //    cart.AddItem(p);
        //    cart.AddItem(p);
        //    Assert.AreEqual(10, cart.Items[0].LineTotal);
        //}

        [TestMethod]
        public void Cart_Item_Quantity_Should_Adjust_To_10()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p);
            cart.AdjustQuantity(p, 10);
            Assert.AreEqual(10, cart.TotalItems);
        }
        [TestMethod]
        public void Items_Count_Should_Be_0_When_10_Items_Adjusted_To_0()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 10);
            cart.AdjustQuantity(p, 0);
            Assert.AreEqual(0, cart.Items.Count);
        }

        [TestMethod]
        public void Items_Count_Should_Be_0_When_10_Items_Adjusted_To_Negative_10()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 10);
            cart.AdjustQuantity(p, -10);
            Assert.AreEqual(0, cart.Items.Count);
        }
        [TestMethod]
        public void Cart_Can_Return_Item_By_SKU()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 1);
            var item = cart.FindItem("SKU");
            Assert.IsNotNull(item);

        }
        [TestMethod]
        public void Cart_Returns_Null_When_No_Sku_Found()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 1);
            var item = cart.FindItem("SKU1");
            Assert.IsNull(item);

        }
        [TestMethod]
        public void Items_Count_Should_Be_0_When_SKU_Removed()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 1);
            Assert.AreEqual(1, cart.Items.Count);

            cart.RemoveItem("SKU");
            Assert.AreEqual(0, cart.Items.Count);

        }
        [TestMethod]
        public void Items_Count_Should_Be_0_When_2_Items_Cleared()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            Product p2 = new Product("SKU2");
            //Clock-foolery
            cart.AddItem(p, 1);
            cart.AddItem(p2, 1);
            Assert.AreEqual(2, cart.Items.Count);

            cart.ClearItems();
            Assert.AreEqual(0, cart.Items.Count);

        }

        [TestMethod]
        public void ItemLastAdded_Should_Be_Sku2_When_SKu1_Sku2_Added_In_Sequence()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU1");
            Product p2 = new Product("SKU2");
            cart.AddItem(p, 1, DateTime.Now.AddSeconds(-1));
            cart.AddItem(p2, 1, DateTime.Now.AddSeconds(1));

            Assert.AreEqual("SKU2", cart.ItemLastAdded.Product.SKU);

        }

        [TestMethod]
        public void ItemLastAdded_Should_Be_Sku2_When_SKu1_Sku2_Added_In_Sequence_Regardless_Of_Adjustments()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU1");
            Product p2 = new Product("SKU2");
            cart.AddItem(p, 1, DateTime.Now.AddSeconds(-1));
            cart.AddItem(p2, 1, DateTime.Now.AddSeconds(1));

            cart.AdjustQuantity(p, 10);

            Assert.AreEqual("SKU2", cart.ItemLastAdded.Product.SKU);

        }
        [TestMethod]
        public void Nothing_Should_Be_Added_When_0_Passed_as_Quantity_To_AddItem()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            cart.AddItem(p, 0);
            Assert.AreEqual(0, cart.Items.Count);
        }
        //[TestMethod]
        //public void TotalItems_Should_Be_9_When_Negative_1_Passed_As_Quantity_To_Existing_10_Items() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    cart.AddItem(p, 10);
        //    cart.AddItem(p, -1);
        //    Assert.AreEqual(9, cart.TotalItems);

        //}

        //[TestMethod]
        //public void SubTotal_Should_Be_10_When_2_Items_of_Price_5() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    p.Price = 5;
        //    cart.AddItem(p, 1);
        //    cart.AddItem(p, 1);
        //    Assert.AreEqual(10, cart.SubTotal);

        //}

        //[TestMethod]
        //public void SubTotal_Should_Be_100_When_2_Items_of_Price_5_Adjusted_to_20() {
        //    ShoppingCart cart = new ShoppingCart("TEST");
        //    Product p = new Product("SKU");
        //    p.Price = 5;
        //    cart.AddItem(p, 1);
        //    cart.AddItem(p, 1);
        //    Assert.AreEqual(10, cart.SubTotal);

        //    cart.AdjustQuantity(p, 20);
        //    Assert.AreEqual(100, cart.SubTotal);
        //}

        [TestMethod]
        public void Total_Should_Be_100_With_90_Subtotal_10_Tax()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            p.Price = 90;
            cart.AddItem(p, 1);
            Assert.AreEqual(90, cart.SubTotal);

            cart.TaxAmount = 10;

            Assert.AreEqual(100, cart.Total);

        }
        [TestMethod]
        public void Total_Should_Be_110_With_90_Subtotal_10_Tax_and_10_Shipping()
        {
            ShoppingCart cart = new ShoppingCart("TEST");
            Product p = new Product("SKU");
            p.Price = 90;
            cart.AddItem(p, 1);
            Assert.AreEqual(90, cart.SubTotal);

            cart.TaxAmount = 10;
            cart.ShippingAmount = 10;

            Assert.AreEqual(110, cart.Total);

        }
    }
}
