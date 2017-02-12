using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Model;
using Tailspin.Infrastructure;
using System.Data;
using System.Data.Common;

namespace Tailspin.SimpleSqlRepository {
    
    public class SimpleCustomerRepository:ICustomerRepository {

        string connectionStringName = "TailspinConnectionString";

        internal Address LoadAddress(DbDataReader rdr) {
            var result=new Address(
                AddressesTable.ReadUserName(rdr),
                AddressesTable.ReadFirstName(rdr),
                AddressesTable.ReadLastName(rdr),
                AddressesTable.ReadEmail(rdr),
                AddressesTable.ReadStreet1(rdr),
                AddressesTable.ReadStreet2(rdr),
                AddressesTable.ReadCity(rdr),
                AddressesTable.ReadStateOrProvince(rdr),
                AddressesTable.ReadZip(rdr),
                AddressesTable.ReadCountry(rdr));

            result.AddressID = AddressesTable.ReadAddressID(rdr);
            return result;
        }

        public Customer GetCustomer(string userName) {
            var productRepo = new SimpleProductRepository();
            Customer result = null;
            var batch = new BatchSql();

          
            //see if there's a customer - if not create one
            object user = CustomersTable.Select(CustomersTable.Columns.UserName)
                .Where(CustomersTable.Columns.UserName, userName)
                .BuildCommand()
                .ExecuteScalar();
            
            if (user == null) {
                CustomersTable.Insert(
                    new Dictionary<string, object>() {
                    {CustomersTable.Columns.UserName,userName},
                    {CustomersTable.Columns.LanguageCode,System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName}
                })
                .BuildCommand()
                .ExecuteNonQuery();
            }


            //customer
            batch.Append(CustomersTable.Select()
                .Where(CustomersTable.Columns.UserName, userName));
            

            //addresses
            batch.Append(AddressesTable.Select()
                .Where(AddressesTable.Columns.UserName, userName));

            //shopping cart
            Guid orderID = GetCartID(userName);
            batch.Append(OrdersTable.Select()
                .Where(OrdersTable.Columns.OrderID, orderID));
            
            //items
            //avert your eyes if this bothers you
            var itemSql = new SqlStatement(connectionStringName);
            itemSql.Add(string.Format("SELECT {0}, {1} ", OrderItemsTable.COLUMN_LIST, ProductsTable.COLUMN_LIST));
            itemSql.InnerJoin(
                OrderItemsTable.TABLE_NAME,
                OrderItemsTable.ColumnsQualified.SKU,
                ProductsTable.TABLE_NAME,
                ProductsTable.ColumnsQualified.SKU)
                .Where(OrderItemsTable.Columns.OrderID, orderID);


            batch.Append(itemSql);

            var cmd = batch.BuildCommand(connectionStringName);

            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                //customer
                if (rdr.Read()) {
                    result = new Customer(userName,
                        CustomersTable.ReadEmail(rdr),
                        CustomersTable.ReadFirst(rdr),
                        CustomersTable.ReadLast(rdr));
                } else {
                    result = new Customer();
                }
                //address
                result.AddressBook = new List<Address>();
                if (rdr.NextResult()) {
                    while (rdr.Read()) {
                        result.AddressBook.Add(LoadAddress(rdr));
                           
                    }
                }
                //cart
                result.Cart = new ShoppingCart(userName);
                if (rdr.NextResult()) {
                    if (rdr.Read()) {
                        result.Cart.ShippingAddress = result.AddressBook.SingleOrDefault(x => x.AddressID == OrdersTable.ReadShippingAddressID(rdr));
                        result.Cart.BillingAddress = result.AddressBook.SingleOrDefault(x => x.AddressID == OrdersTable.ReadBillingAddressID(rdr));
                        result.Cart.ShippingService = OrdersTable.ReadShippingService(rdr) ?? "";
                        result.Cart.ShippingAmount = OrdersTable.ReadShippingAmount(rdr);
                        result.Cart.TaxAmount = OrdersTable.ReadTaxAmount(rdr);
                    }
                }

                //items
                if (rdr.NextResult()) {
                    while (rdr.Read()) {
                        var product = productRepo.LoadProduct(rdr);
                        result.Cart.Items.Add(new ShoppingCartItem(product, CartItemsTable.ReadQuantity(rdr), CartItemsTable.ReadDateAdded(rdr)));
                    }
                }
            }

            return result;
        }


        DbCommand GetAddressCommand(Address address){
            var sql = new SqlStatement(connectionStringName);

            var settings = new Dictionary<string, object>()
                {
                    {AddressesTable.Columns.UserName, address.UserName},
                    {AddressesTable.Columns.FirstName, address.FirstName},
                    {AddressesTable.Columns.LastName, address.LastName},
                    {AddressesTable.Columns.Email, address.Email},
                    {AddressesTable.Columns.Street1, address.Street1},
                    {AddressesTable.Columns.Street2, address.Street2 != null ? address.Street2 : ""},
                    {AddressesTable.Columns.City, address.City},
                    {AddressesTable.Columns.StateOrProvince, address.StateOrProvince},
                    {AddressesTable.Columns.Zip, address.Zip},
                    {AddressesTable.Columns.Country, address.Country},
                    {AddressesTable.Columns.IsDefault, address.IsDefault}
               };

            if (SqlHelper.RecordExists(connectionStringName,AddressesTable.TABLE_NAME, new Dictionary<string, object>()
                {
                    {AddressesTable.Columns.UserName,address.UserName},
                    {AddressesTable.Columns.Street1,address.Street1},
                    {AddressesTable.Columns.City,address.City},
                    {AddressesTable.Columns.StateOrProvince,address.StateOrProvince},
                })) 
            {
                //update
                sql = AddressesTable.Update(settings)
                    .Where(AddressesTable.Columns.UserName, address.UserName)
                    .And(AddressesTable.Columns.Street1, address.Street1)
                    .And(AddressesTable.Columns.City, address.City)
                    .And(AddressesTable.Columns.StateOrProvince, address.StateOrProvince);

            } else {
                //insert
                sql = AddressesTable.Insert(settings);


            }
            var cmd = sql.BuildCommand();

            //add the params
            return cmd;
        }

        Guid GetCartID(string userName) {
            Guid result = Guid.NewGuid();

            var existsSql = OrdersTable.Select(OrdersTable.Columns.OrderID)
                .Where(OrdersTable.Columns.UserName, userName)
                .And(OrdersTable.Columns.OrderStatusID, 99);

            object existingID = existsSql.BuildCommand().ExecuteScalar();

            if (existingID == null) {
                //create one!
                var sql = OrdersTable.Insert(new Dictionary<string, object>()
                {
                    {OrdersTable.Columns.OrderID,result},
                    {OrdersTable.Columns.UserName,userName},
                    {OrdersTable.Columns.OrderStatusID,99},
                    {OrdersTable.Columns.UserLanguageCode,System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName},
                    {OrdersTable.Columns.CreatedOn,DateTime.Now}
                   
                });

                //save it
                sql.BuildCommand().ExecuteNonQuery();

            } else {

                result = (Guid)existingID;

            }
            return result;
        }

        public void Save(Customer c) {
            
            //save the customer
            List<DbCommand> commands = new List<DbCommand>();

            SqlStatement sql = null;
            var settings=new Dictionary<string,object>(){
                    {CustomersTable.Columns.Email, c.Email},
                    {CustomersTable.Columns.First, c.Email},
                    {CustomersTable.Columns.Last, c.Email},
                    {CustomersTable.Columns.LanguageCode, c.Email}
               };

            if (SqlHelper.RecordExists(connectionStringName,CustomersTable.TABLE_NAME,CustomersTable.Columns.UserName,c.UserName)) {
                //update
                sql=CustomersTable.Update(settings)
                    .Where(CustomersTable.Columns.UserName,c.UserName);

            } else {

                //insert
                settings.Add(CustomersTable.Columns.UserName, c.UserName);
                sql = CustomersTable.Insert(settings);
            }

            sql.BuildCommand().ExecuteNonQuery();
        }


        public void SaveCart(ShoppingCart cart) {


            //using the Orders/OrderItems tables to persist the car
            //with the idea that a cart is an order that hasn't checked out
            //yet. This is a DB-centric decision, our model separates this
            //concept. StatusID 99 marks an order as "Not Checked Out"
            List<DbCommand> commands = new List<DbCommand>();
            Guid orderID = Guid.NewGuid();

            orderID = GetCartID(cart.UserName);

            var settings = new Dictionary<string, object>();

            if (cart.BillingAddress != null)
                settings.Add(OrdersTable.Columns.BillingAddressID, cart.BillingAddress.AddressID);
            
            if (cart.ShippingAddress != null)
                settings.Add(OrdersTable.Columns.ShippingAddressID, cart.ShippingAddress.AddressID);

            settings.Add(OrdersTable.Columns.ShippingService, cart.ShippingService);
            settings.Add(OrdersTable.Columns.ShippingAmount, cart.ShippingAmount);
            settings.Add(OrdersTable.Columns.TaxAmount, cart.TaxAmount);


            //save down any address (billing/shipping), selected shipping, and tax info
            var sql = OrdersTable.Update(settings)
                .Where(OrdersTable.Columns.OrderID, orderID);

            commands.Add(sql.BuildCommand());

            //remove the existing items
            commands.Add(OrderItemsTable.Delete().Where(OrderItemsTable.Columns.OrderID, orderID).BuildCommand());

            //save each item in the cart
            foreach (var item in cart.Items) {
                var itemSql = OrderItemsTable.Insert(new Dictionary<string, object>()
                {
                    {OrderItemsTable.Columns.SKU,item.Product.SKU},
                    {OrderItemsTable.Columns.OrderID,orderID},
                    {OrderItemsTable.Columns.Quantity,item.Quantity},
                    {OrderItemsTable.Columns.DateAdded,item.DateAdded},
                    {OrderItemsTable.Columns.Discount,item.Discount},
                    {OrderItemsTable.Columns.DiscountReason,item.DiscountReason}

                });
                commands.Add(itemSql.BuildCommand());
            }

            //all in one, nice transaction BOOYAH!
            SqlHelper.Execute(commands, connectionStringName);

        }

        public int SaveAddress(Address address) {
            GetAddressCommand(address).ExecuteNonQuery();

            var sql = string.Format("SELECT MAX({0}) FROM {1} WHERE {2} = @p0", 
                AddressesTable.ColumnsQualified.AddressID, 
                AddressesTable.TABLE_NAME, 
                AddressesTable.ColumnsQualified.UserName);
            var cmd = new SqlStatement(connectionStringName).Add(sql).BuildCommand();
            cmd.AddParameter("@p0", address.UserName);
            object id = cmd.ExecuteScalar();
            return (int)id;
        }

    }
}
