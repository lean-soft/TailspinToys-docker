using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Tailspin.Model;
using System.Linq.Expressions;
using Tailspin.Infrastructure;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commerce.DomainTests.Products {
    /// <summary>
    /// Summary description for ProductModel
    /// </summary>
    [TestClass]
    public class ProductTests {

        public ProductTests()
        {
        }

        Product GetTestProduct() {
            var result = new Product("SKU", "Name", "Blurb", true, 100, 1, DateTime.Now, true, true);
            result.Price = 10M;
            return result;
        }

        [TestMethod]
        public void ProductModel_ShouldHave_Zero_DiscountPercent() {

            Product p = GetTestProduct();

            Assert.AreEqual(0, p.DiscountPercent);

        }
        [TestMethod]
        public void ProductModel_Should_Return_9_For_DiscountedPrice_With_10_For_DiscountPercent() {

            Product p = GetTestProduct();
            p.DiscountPercent = 10;
            Assert.AreEqual(9, p.DiscountedPrice);

        }

        [TestMethod]
        public void ProductModel_Should_Consider_SKU_Equality() {

            Product p = GetTestProduct();
            Product p2 = GetTestProduct();
            Assert.IsTrue(p.Equals(p2));

        }

        [TestMethod]
        public void ProductModel_Should_Return_Name_For_To_String() {

            Product p = GetTestProduct();
            Assert.AreEqual("Name", p.ToString());

        }
        [TestMethod]
        public void ProductModel_Should_Set_Inventory_State_To_InStock_With_10_OnHand_And_DateAvailable_Now() {

            Product p = new Product("TEST","test","test",true, 10, 1, DateTime.Now.AddDays(-7), true,true);
            Assert.AreEqual(typeof(InStock), p.CurrentInventory.GetType());
        }
        [TestMethod]
        public void ProductModel_Should_Set_Inventory_State_To_PreOrder_With_0_OnHand_DateAvailable_InFuture() {

            Product p = new Product("TEST", "test", "test", true, 10, 0, DateTime.Now.AddDays(7), true, true);
            p.AllowPreOrder = true;
            Assert.AreEqual(typeof(OnPreOrder),p.CurrentInventory.GetType() );
        }

        [TestMethod]
        public void ProductModel_Should_Set_Inventory_State_To_BackOrder_With_0_OnHand_DateAvailable_Now_And_AllowbackOrder() {

            Product p = new Product("TEST", "test", "test", true, 10, 0, DateTime.Now.AddDays(-7), true, true);
            Assert.AreEqual(typeof(OnBackOrder), p.CurrentInventory.GetType());
        }

        [TestMethod]
        public void ProductModel_Should_Set_Inventory_State_To_Unavailable_With_0_OnHand_DateAvailable_And_Not_AllowBackOrder() {

            Product p = new Product("TEST", "test", "test", true, 10, 0, DateTime.Now.AddDays(-7), false, true);
            Assert.AreEqual(typeof(Unavailable), p.CurrentInventory.GetType());
        }

        [TestMethod]
        public void ProductModel_Should_Set_Inventory_State_To_PreOrder_With_10_OnHand_DateAvailable_Future() {

            Product p = new Product("TEST", "test", "test", true, 10, 10, DateTime.Now.AddDays(7), false, true);
            p.AllowPreOrder = true;
            Assert.AreEqual(typeof(OnPreOrder), p.CurrentInventory.GetType());
        }
    }
}
