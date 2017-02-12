using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Model;
using Tailspin.Infrastructure;
using System.Data;
using System.Data.Common;

namespace Tailspin.SimpleSqlRepository {
    public class SimpleOrderRepository:IOrderRepository {
        string connectionStringName = "TailspinConnectionString";

        public Order GetOrder(Guid orderID) {

            SimpleProductRepository productRepository = new SimpleProductRepository();
            SimpleCustomerRepository customerRepository = new SimpleCustomerRepository();
            Order result = null;

            var batch = new BatchSql();

            batch.Append(OrdersTable.Select().Where("OrderID", orderID));
            
            //items
            
            //products for the items
            var sql = new SqlStatement(connectionStringName);
            sql.Add("SELECT ");
            sql.Add(ProductsTable.COLUMN_LIST);
            sql.Add(OrderItemsTable.COLUMN_LIST);
            sql.Add("FROM Products INNER JOIN OrderItems ON Products.SKU = OrderItems.SKU");
            sql.Add("WHERE SKU IN (SELECT SKU FROM OrderItems WHERE OrderID=@OrderID)");

            //transactions
            batch.Append(TransactionsTable.Select().Where("orderid", orderID));

            int shippingAddressID = 0;
            int billingAddressID = 0;
            int shippingMethodID=0;
            
            //pull it
            var cmd = sql.BuildCommand();

            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                if (rdr.Read()) {
                    result = new Order(OrdersTable.ReadOrderStatusID(rdr))
                    {
                        DateCreated =OrdersTable.ReadCreatedOn(rdr),
                        DateShipped = OrdersTable.ReadDateShipped(rdr),
                        UserName = OrdersTable.ReadUserName(rdr),
                        DiscountAmount = OrdersTable.ReadDiscountAmount(rdr),
                        DiscountReason =OrdersTable.ReadDiscountReason(rdr),
                        EstimatedDelivery = OrdersTable.ReadEstimatedDelivery(rdr),
                        ID = orderID,
                        OrderNumber = OrdersTable.ReadOrderNumber(rdr),
                        ShippingAmount = OrdersTable.ReadShippingAmount(rdr),
                        ShippingService=OrdersTable.ReadShippingService(rdr),
                        TaxAmount = OrdersTable.ReadTaxAmount(rdr),
                        
                        
                    };

                    billingAddressID = OrdersTable.ReadBillingAddressID(rdr);
                    shippingAddressID = OrdersTable.ReadShippingAddressID(rdr);
                    

                }
                
                //load the items
                result.Items = new List<OrderLine>();
                if (rdr.NextResult()) {
                    while (rdr.Read()) {
                        var product = productRepository.LoadProduct(rdr);
                        var item = new OrderLine(OrderItemsTable.ReadDateAdded(rdr),OrderItemsTable.ReadQuantity(rdr),product);
                        result.Items.Add(item);
                    }
                }

                //transactions
                result.Transactions = new List<Transaction>();
                if (rdr.NextResult()) {
                    while (rdr.Read()) {
                        Transaction t = new Transaction(
                            TransactionsTable.ReadTransactionID(rdr),
                            orderID,
                            TransactionsTable.ReadAmount(rdr),
                            TransactionsTable.ReadTransactionDate(rdr),
                            TransactionsTable.ReadAuthorizationCode(rdr),
                            TransactionsTable.ReadNotes(rdr),
                            TransactionsTable.ReadProcessor(rdr));

                        result.Transactions.Add(t);
                            
                    }
                }

            }
            sql = new SqlStatement(connectionStringName);

            //addresses
            batch.Append(AddressesTable.Select().Where("addressid", shippingAddressID));

            batch.Append(AddressesTable.Select().Where("addressid", billingAddressID));
            
            //shipping method
            batch.Append(ShippingMethodsTable.Select().Where("shippingmethodid", shippingMethodID));

            cmd = batch.BuildCommand(connectionStringName);


            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {

                //shipping address
                if (rdr.Read()) {
                    //shipping
                    result.ShippingAddress = customerRepository.LoadAddress(rdr);
                }
                //billing address
                if (rdr.NextResult()) {
                    if (rdr.Read()) {
                        result.BillingAddress = customerRepository.LoadAddress(rdr);
                    }
                }
                //shipping method
                if (rdr.NextResult()) {
                    if (rdr.Read()) {
                        LoadShipping(rdr);
                    }
                }

            }

            return result;

        }
        ShippingMethod LoadShipping(DbDataReader rdr) {
            var result= new ShippingMethod(
                ShippingMethodsTable.ReadShippingMethodID(rdr),
                ShippingMethodsTable.ReadCarrier(rdr),
                ShippingMethodsTable.ReadServiceName(rdr),
                ShippingMethodsTable.ReadRatePerPound(rdr),
                ShippingMethodsTable.ReadDaysToDeliver(rdr),
                ShippingMethodsTable.ReadBaseRate(rdr));
            return result;

        }
        public void Save(Order order, Transaction transaction) {
            throw new NotImplementedException();
        }

        public IList<ShippingMethod> GetShippingMethods() {
            var sql=ShippingMethodsTable.Select();
            var result = new List<ShippingMethod>();
            using (var rdr = sql.BuildCommand().ExecuteReader(CommandBehavior.CloseConnection)) {
                while (rdr.Read()) {
                    result.Add(LoadShipping(rdr));
                }
            }
            return result;
        }


    }
}
