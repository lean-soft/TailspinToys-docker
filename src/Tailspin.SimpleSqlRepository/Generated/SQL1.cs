
using System;
using System.Text;
using System.Collections.Generic;
using Tailspin.Infrastructure;
using System.Linq.Expressions;
using System.Data.Common;
using System.Linq;

namespace Tailspin.SimpleSqlRepository {

 

        public static class CategoriesTable{
            public const string TABLE_NAME=@"[dbo].[Categories]";
            public const string COLUMN_LIST=@"[dbo].[Categories].[Code],[dbo].[Categories].[Title]";
 
                public static string ReadCode(DbDataReader rdr){
                string result;
                                result= rdr["Code"].ToString();
                                return result;
            }
                public static string ReadTitle(DbDataReader rdr){
                string result;
                                result= rdr["Title"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string Code="@Code";
                    public static string Title="@Title";
                }    
            
            public struct Columns{
                    public static string Code="Code";
                    public static string Title="Title";
                } 
            public struct ColumnsQualified{
                    public static string Code="[dbo].[Categories].[Code]";
                    public static string Title="[dbo].[Categories].[Title]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("Code","[dbo].[Categories].[Code]");
                            _qualifiedColumns.Add("Title","[dbo].[Categories].[Title]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Categories](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Categories]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Categories]");
                return sql;
            }
        }
         

        public static class Categories_ProductsTable{
            public const string TABLE_NAME=@"[dbo].[Categories_Products]";
            public const string COLUMN_LIST=@"[dbo].[Categories_Products].[CategoryCode],[dbo].[Categories_Products].[SKU]";
 
                public static string ReadCategoryCode(DbDataReader rdr){
                string result;
                                result= rdr["CategoryCode"].ToString();
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string CategoryCode="@CategoryCode";
                    public static string SKU="@SKU";
                }    
            
            public struct Columns{
                    public static string CategoryCode="CategoryCode";
                    public static string SKU="SKU";
                } 
            public struct ColumnsQualified{
                    public static string CategoryCode="[dbo].[Categories_Products].[CategoryCode]";
                    public static string SKU="[dbo].[Categories_Products].[SKU]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("CategoryCode","[dbo].[Categories_Products].[CategoryCode]");
                            _qualifiedColumns.Add("SKU","[dbo].[Categories_Products].[SKU]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Categories_Products](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Categories_Products]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Categories_Products]");
                return sql;
            }
        }
         

        public static class CustomerBehaviorsTable{
            public const string TABLE_NAME=@"[dbo].[CustomerBehaviors]";
            public const string COLUMN_LIST=@"[dbo].[CustomerBehaviors].[UserBehaviorID],[dbo].[CustomerBehaviors].[Description]";
 
                public static int ReadUserBehaviorID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["UserBehaviorID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string UserBehaviorID="@UserBehaviorID";
                    public static string Description="@Description";
                }    
            
            public struct Columns{
                    public static string UserBehaviorID="UserBehaviorID";
                    public static string Description="Description";
                } 
            public struct ColumnsQualified{
                    public static string UserBehaviorID="[dbo].[CustomerBehaviors].[UserBehaviorID]";
                    public static string Description="[dbo].[CustomerBehaviors].[Description]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("UserBehaviorID","[dbo].[CustomerBehaviors].[UserBehaviorID]");
                            _qualifiedColumns.Add("Description","[dbo].[CustomerBehaviors].[Description]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[CustomerBehaviors](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[CustomerBehaviors]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[CustomerBehaviors]");
                return sql;
            }
        }
         

        public static class CustomerEventsTable{
            public const string TABLE_NAME=@"[dbo].[CustomerEvents]";
            public const string COLUMN_LIST=@"[dbo].[CustomerEvents].[EventID],[dbo].[CustomerEvents].[UserBehaviorID],[dbo].[CustomerEvents].[UserName],[dbo].[CustomerEvents].[EventDate],[dbo].[CustomerEvents].[IP],[dbo].[CustomerEvents].[SKU],[dbo].[CustomerEvents].[CategoryID],[dbo].[CustomerEvents].[OrderID]";
 
                public static int ReadEventID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["EventID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static int ReadUserBehaviorID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["UserBehaviorID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadUserName(DbDataReader rdr){
                string result;
                                result= rdr["UserName"].ToString();
                                return result;
            }
                public static DateTime ReadEventDate(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["EventDate"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static string ReadIP(DbDataReader rdr){
                string result;
                                result= rdr["IP"].ToString();
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static int ReadCategoryID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["CategoryID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static Guid ReadOrderID(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["OrderID"];
                                return result;
            }
        
            
            public struct Parameters{
                    public static string EventID="@EventID";
                    public static string UserBehaviorID="@UserBehaviorID";
                    public static string UserName="@UserName";
                    public static string EventDate="@EventDate";
                    public static string IP="@IP";
                    public static string SKU="@SKU";
                    public static string CategoryID="@CategoryID";
                    public static string OrderID="@OrderID";
                }    
            
            public struct Columns{
                    public static string EventID="EventID";
                    public static string UserBehaviorID="UserBehaviorID";
                    public static string UserName="UserName";
                    public static string EventDate="EventDate";
                    public static string IP="IP";
                    public static string SKU="SKU";
                    public static string CategoryID="CategoryID";
                    public static string OrderID="OrderID";
                } 
            public struct ColumnsQualified{
                    public static string EventID="[dbo].[CustomerEvents].[EventID]";
                    public static string UserBehaviorID="[dbo].[CustomerEvents].[UserBehaviorID]";
                    public static string UserName="[dbo].[CustomerEvents].[UserName]";
                    public static string EventDate="[dbo].[CustomerEvents].[EventDate]";
                    public static string IP="[dbo].[CustomerEvents].[IP]";
                    public static string SKU="[dbo].[CustomerEvents].[SKU]";
                    public static string CategoryID="[dbo].[CustomerEvents].[CategoryID]";
                    public static string OrderID="[dbo].[CustomerEvents].[OrderID]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("EventID","[dbo].[CustomerEvents].[EventID]");
                            _qualifiedColumns.Add("UserBehaviorID","[dbo].[CustomerEvents].[UserBehaviorID]");
                            _qualifiedColumns.Add("UserName","[dbo].[CustomerEvents].[UserName]");
                            _qualifiedColumns.Add("EventDate","[dbo].[CustomerEvents].[EventDate]");
                            _qualifiedColumns.Add("IP","[dbo].[CustomerEvents].[IP]");
                            _qualifiedColumns.Add("SKU","[dbo].[CustomerEvents].[SKU]");
                            _qualifiedColumns.Add("CategoryID","[dbo].[CustomerEvents].[CategoryID]");
                            _qualifiedColumns.Add("OrderID","[dbo].[CustomerEvents].[OrderID]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[CustomerEvents](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[CustomerEvents]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[CustomerEvents]");
                return sql;
            }
        }
         

        public static class CustomersTable{
            public const string TABLE_NAME=@"[dbo].[Customers]";
            public const string COLUMN_LIST=@"[dbo].[Customers].[UserName],[dbo].[Customers].[LanguageCode],[dbo].[Customers].[Email],[dbo].[Customers].[First],[dbo].[Customers].[Last]";
 
                public static string ReadUserName(DbDataReader rdr){
                string result;
                                result= rdr["UserName"].ToString();
                                return result;
            }
                public static string ReadLanguageCode(DbDataReader rdr){
                string result;
                                result= rdr["LanguageCode"].ToString();
                                return result;
            }
                public static string ReadEmail(DbDataReader rdr){
                string result;
                                result= rdr["Email"].ToString();
                                return result;
            }
                public static string ReadFirst(DbDataReader rdr){
                string result;
                                result= rdr["First"].ToString();
                                return result;
            }
                public static string ReadLast(DbDataReader rdr){
                string result;
                                result= rdr["Last"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string UserName="@UserName";
                    public static string LanguageCode="@LanguageCode";
                    public static string Email="@Email";
                    public static string First="@First";
                    public static string Last="@Last";
                }    
            
            public struct Columns{
                    public static string UserName="UserName";
                    public static string LanguageCode="LanguageCode";
                    public static string Email="Email";
                    public static string First="First";
                    public static string Last="Last";
                } 
            public struct ColumnsQualified{
                    public static string UserName="[dbo].[Customers].[UserName]";
                    public static string LanguageCode="[dbo].[Customers].[LanguageCode]";
                    public static string Email="[dbo].[Customers].[Email]";
                    public static string First="[dbo].[Customers].[First]";
                    public static string Last="[dbo].[Customers].[Last]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("UserName","[dbo].[Customers].[UserName]");
                            _qualifiedColumns.Add("LanguageCode","[dbo].[Customers].[LanguageCode]");
                            _qualifiedColumns.Add("Email","[dbo].[Customers].[Email]");
                            _qualifiedColumns.Add("First","[dbo].[Customers].[First]");
                            _qualifiedColumns.Add("Last","[dbo].[Customers].[Last]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Customers](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Customers]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Customers]");
                return sql;
            }
        }
         

        public static class DeliveryMethodTable{
            public const string TABLE_NAME=@"[dbo].[DeliveryMethod]";
            public const string COLUMN_LIST=@"[dbo].[DeliveryMethod].[DeliveryMethodID],[dbo].[DeliveryMethod].[Description]";
 
                public static int ReadDeliveryMethodID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["DeliveryMethodID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string DeliveryMethodID="@DeliveryMethodID";
                    public static string Description="@Description";
                }    
            
            public struct Columns{
                    public static string DeliveryMethodID="DeliveryMethodID";
                    public static string Description="Description";
                } 
            public struct ColumnsQualified{
                    public static string DeliveryMethodID="[dbo].[DeliveryMethod].[DeliveryMethodID]";
                    public static string Description="[dbo].[DeliveryMethod].[Description]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("DeliveryMethodID","[dbo].[DeliveryMethod].[DeliveryMethodID]");
                            _qualifiedColumns.Add("Description","[dbo].[DeliveryMethod].[Description]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[DeliveryMethod](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[DeliveryMethod]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[DeliveryMethod]");
                return sql;
            }
        }
         

        public static class InventoryRecordsTable{
            public const string TABLE_NAME=@"[dbo].[InventoryRecords]";
            public const string COLUMN_LIST=@"[dbo].[InventoryRecords].[InventoryRecordID],[dbo].[InventoryRecords].[SKU],[dbo].[InventoryRecords].[Increment],[dbo].[InventoryRecords].[DateEntered],[dbo].[InventoryRecords].[Notes]";
 
                public static int ReadInventoryRecordID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["InventoryRecordID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static int ReadIncrement(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["Increment"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static DateTime ReadDateEntered(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["DateEntered"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static string ReadNotes(DbDataReader rdr){
                string result;
                                result= rdr["Notes"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string InventoryRecordID="@InventoryRecordID";
                    public static string SKU="@SKU";
                    public static string Increment="@Increment";
                    public static string DateEntered="@DateEntered";
                    public static string Notes="@Notes";
                }    
            
            public struct Columns{
                    public static string InventoryRecordID="InventoryRecordID";
                    public static string SKU="SKU";
                    public static string Increment="Increment";
                    public static string DateEntered="DateEntered";
                    public static string Notes="Notes";
                } 
            public struct ColumnsQualified{
                    public static string InventoryRecordID="[dbo].[InventoryRecords].[InventoryRecordID]";
                    public static string SKU="[dbo].[InventoryRecords].[SKU]";
                    public static string Increment="[dbo].[InventoryRecords].[Increment]";
                    public static string DateEntered="[dbo].[InventoryRecords].[DateEntered]";
                    public static string Notes="[dbo].[InventoryRecords].[Notes]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("InventoryRecordID","[dbo].[InventoryRecords].[InventoryRecordID]");
                            _qualifiedColumns.Add("SKU","[dbo].[InventoryRecords].[SKU]");
                            _qualifiedColumns.Add("Increment","[dbo].[InventoryRecords].[Increment]");
                            _qualifiedColumns.Add("DateEntered","[dbo].[InventoryRecords].[DateEntered]");
                            _qualifiedColumns.Add("Notes","[dbo].[InventoryRecords].[Notes]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[InventoryRecords](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[InventoryRecords]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[InventoryRecords]");
                return sql;
            }
        }
         

        public static class InventoryStatusTable{
            public const string TABLE_NAME=@"[dbo].[InventoryStatus]";
            public const string COLUMN_LIST=@"[dbo].[InventoryStatus].[InventoryStatusID],[dbo].[InventoryStatus].[Description]";
 
                public static int ReadInventoryStatusID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["InventoryStatusID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string InventoryStatusID="@InventoryStatusID";
                    public static string Description="@Description";
                }    
            
            public struct Columns{
                    public static string InventoryStatusID="InventoryStatusID";
                    public static string Description="Description";
                } 
            public struct ColumnsQualified{
                    public static string InventoryStatusID="[dbo].[InventoryStatus].[InventoryStatusID]";
                    public static string Description="[dbo].[InventoryStatus].[Description]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("InventoryStatusID","[dbo].[InventoryStatus].[InventoryStatusID]");
                            _qualifiedColumns.Add("Description","[dbo].[InventoryStatus].[Description]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[InventoryStatus](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[InventoryStatus]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[InventoryStatus]");
                return sql;
            }
        }
         

        public static class OrderItemsTable{
            public const string TABLE_NAME=@"[dbo].[OrderItems]";
            public const string COLUMN_LIST=@"[dbo].[OrderItems].[OrderID],[dbo].[OrderItems].[SKU],[dbo].[OrderItems].[Quantity],[dbo].[OrderItems].[DateAdded],[dbo].[OrderItems].[LineItemPrice],[dbo].[OrderItems].[Discount],[dbo].[OrderItems].[Version],[dbo].[OrderItems].[LineItemWeightInPounds],[dbo].[OrderItems].[DiscountReason]";
 
                public static Guid ReadOrderID(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["OrderID"];
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static int ReadQuantity(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["Quantity"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static DateTime ReadDateAdded(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["DateAdded"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static decimal ReadLineItemPrice(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["LineItemPrice"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static decimal ReadDiscount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["Discount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadVersion(DbDataReader rdr){
                string result;
                                result= rdr["Version"].ToString();
                                return result;
            }
                public static decimal ReadLineItemWeightInPounds(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["LineItemWeightInPounds"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadDiscountReason(DbDataReader rdr){
                string result;
                                result= rdr["DiscountReason"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OrderID="@OrderID";
                    public static string SKU="@SKU";
                    public static string Quantity="@Quantity";
                    public static string DateAdded="@DateAdded";
                    public static string LineItemPrice="@LineItemPrice";
                    public static string Discount="@Discount";
                    public static string Version="@Version";
                    public static string LineItemWeightInPounds="@LineItemWeightInPounds";
                    public static string DiscountReason="@DiscountReason";
                }    
            
            public struct Columns{
                    public static string OrderID="OrderID";
                    public static string SKU="SKU";
                    public static string Quantity="Quantity";
                    public static string DateAdded="DateAdded";
                    public static string LineItemPrice="LineItemPrice";
                    public static string Discount="Discount";
                    public static string Version="Version";
                    public static string LineItemWeightInPounds="LineItemWeightInPounds";
                    public static string DiscountReason="DiscountReason";
                } 
            public struct ColumnsQualified{
                    public static string OrderID="[dbo].[OrderItems].[OrderID]";
                    public static string SKU="[dbo].[OrderItems].[SKU]";
                    public static string Quantity="[dbo].[OrderItems].[Quantity]";
                    public static string DateAdded="[dbo].[OrderItems].[DateAdded]";
                    public static string LineItemPrice="[dbo].[OrderItems].[LineItemPrice]";
                    public static string Discount="[dbo].[OrderItems].[Discount]";
                    public static string Version="[dbo].[OrderItems].[Version]";
                    public static string LineItemWeightInPounds="[dbo].[OrderItems].[LineItemWeightInPounds]";
                    public static string DiscountReason="[dbo].[OrderItems].[DiscountReason]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OrderID","[dbo].[OrderItems].[OrderID]");
                            _qualifiedColumns.Add("SKU","[dbo].[OrderItems].[SKU]");
                            _qualifiedColumns.Add("Quantity","[dbo].[OrderItems].[Quantity]");
                            _qualifiedColumns.Add("DateAdded","[dbo].[OrderItems].[DateAdded]");
                            _qualifiedColumns.Add("LineItemPrice","[dbo].[OrderItems].[LineItemPrice]");
                            _qualifiedColumns.Add("Discount","[dbo].[OrderItems].[Discount]");
                            _qualifiedColumns.Add("Version","[dbo].[OrderItems].[Version]");
                            _qualifiedColumns.Add("LineItemWeightInPounds","[dbo].[OrderItems].[LineItemWeightInPounds]");
                            _qualifiedColumns.Add("DiscountReason","[dbo].[OrderItems].[DiscountReason]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[OrderItems](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[OrderItems]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[OrderItems]");
                return sql;
            }
        }
         

        public static class OrdersTable{
            public const string TABLE_NAME=@"[dbo].[Orders]";
            public const string COLUMN_LIST=@"[dbo].[Orders].[ShippingAmount],[dbo].[Orders].[DiscountAmount],[dbo].[Orders].[UserName],[dbo].[Orders].[UserLanguageCode],[dbo].[Orders].[TaxAmount],[dbo].[Orders].[SubTotal],[dbo].[Orders].[OrderStatusID],[dbo].[Orders].[CreatedOn],[dbo].[Orders].[OrderID],[dbo].[Orders].[ModifiedOn],[dbo].[Orders].[Version],[dbo].[Orders].[OrderNumber],[dbo].[Orders].[ExecutedOn],[dbo].[Orders].[ShippingService],[dbo].[Orders].[DiscountReason],[dbo].[Orders].[ShippingAddressID],[dbo].[Orders].[BillingAddressID],[dbo].[Orders].[DateShipped],[dbo].[Orders].[TrackingNumber],[dbo].[Orders].[EstimatedDelivery]";
 
                public static decimal ReadShippingAmount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["ShippingAmount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static decimal ReadDiscountAmount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["DiscountAmount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadUserName(DbDataReader rdr){
                string result;
                                result= rdr["UserName"].ToString();
                                return result;
            }
                public static string ReadUserLanguageCode(DbDataReader rdr){
                string result;
                                result= rdr["UserLanguageCode"].ToString();
                                return result;
            }
                public static decimal ReadTaxAmount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["TaxAmount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static decimal ReadSubTotal(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["SubTotal"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static int ReadOrderStatusID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OrderStatusID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static DateTime ReadCreatedOn(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["CreatedOn"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static Guid ReadOrderID(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["OrderID"];
                                return result;
            }
                public static DateTime ReadModifiedOn(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["ModifiedOn"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static string ReadVersion(DbDataReader rdr){
                string result;
                                result= rdr["Version"].ToString();
                                return result;
            }
                public static string ReadOrderNumber(DbDataReader rdr){
                string result;
                                result= rdr["OrderNumber"].ToString();
                                return result;
            }
                public static DateTime ReadExecutedOn(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["ExecutedOn"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static string ReadShippingService(DbDataReader rdr){
                string result;
                                result= rdr["ShippingService"].ToString();
                                return result;
            }
                public static string ReadDiscountReason(DbDataReader rdr){
                string result;
                                result= rdr["DiscountReason"].ToString();
                                return result;
            }
                public static int ReadShippingAddressID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["ShippingAddressID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static int ReadBillingAddressID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["BillingAddressID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static DateTime ReadDateShipped(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["DateShipped"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static string ReadTrackingNumber(DbDataReader rdr){
                string result;
                                result= rdr["TrackingNumber"].ToString();
                                return result;
            }
                public static DateTime ReadEstimatedDelivery(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["EstimatedDelivery"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
        
            
            public struct Parameters{
                    public static string ShippingAmount="@ShippingAmount";
                    public static string DiscountAmount="@DiscountAmount";
                    public static string UserName="@UserName";
                    public static string UserLanguageCode="@UserLanguageCode";
                    public static string TaxAmount="@TaxAmount";
                    public static string SubTotal="@SubTotal";
                    public static string OrderStatusID="@OrderStatusID";
                    public static string CreatedOn="@CreatedOn";
                    public static string OrderID="@OrderID";
                    public static string ModifiedOn="@ModifiedOn";
                    public static string Version="@Version";
                    public static string OrderNumber="@OrderNumber";
                    public static string ExecutedOn="@ExecutedOn";
                    public static string ShippingService="@ShippingService";
                    public static string DiscountReason="@DiscountReason";
                    public static string ShippingAddressID="@ShippingAddressID";
                    public static string BillingAddressID="@BillingAddressID";
                    public static string DateShipped="@DateShipped";
                    public static string TrackingNumber="@TrackingNumber";
                    public static string EstimatedDelivery="@EstimatedDelivery";
                }    
            
            public struct Columns{
                    public static string ShippingAmount="ShippingAmount";
                    public static string DiscountAmount="DiscountAmount";
                    public static string UserName="UserName";
                    public static string UserLanguageCode="UserLanguageCode";
                    public static string TaxAmount="TaxAmount";
                    public static string SubTotal="SubTotal";
                    public static string OrderStatusID="OrderStatusID";
                    public static string CreatedOn="CreatedOn";
                    public static string OrderID="OrderID";
                    public static string ModifiedOn="ModifiedOn";
                    public static string Version="Version";
                    public static string OrderNumber="OrderNumber";
                    public static string ExecutedOn="ExecutedOn";
                    public static string ShippingService="ShippingService";
                    public static string DiscountReason="DiscountReason";
                    public static string ShippingAddressID="ShippingAddressID";
                    public static string BillingAddressID="BillingAddressID";
                    public static string DateShipped="DateShipped";
                    public static string TrackingNumber="TrackingNumber";
                    public static string EstimatedDelivery="EstimatedDelivery";
                } 
            public struct ColumnsQualified{
                    public static string ShippingAmount="[dbo].[Orders].[ShippingAmount]";
                    public static string DiscountAmount="[dbo].[Orders].[DiscountAmount]";
                    public static string UserName="[dbo].[Orders].[UserName]";
                    public static string UserLanguageCode="[dbo].[Orders].[UserLanguageCode]";
                    public static string TaxAmount="[dbo].[Orders].[TaxAmount]";
                    public static string SubTotal="[dbo].[Orders].[SubTotal]";
                    public static string OrderStatusID="[dbo].[Orders].[OrderStatusID]";
                    public static string CreatedOn="[dbo].[Orders].[CreatedOn]";
                    public static string OrderID="[dbo].[Orders].[OrderID]";
                    public static string ModifiedOn="[dbo].[Orders].[ModifiedOn]";
                    public static string Version="[dbo].[Orders].[Version]";
                    public static string OrderNumber="[dbo].[Orders].[OrderNumber]";
                    public static string ExecutedOn="[dbo].[Orders].[ExecutedOn]";
                    public static string ShippingService="[dbo].[Orders].[ShippingService]";
                    public static string DiscountReason="[dbo].[Orders].[DiscountReason]";
                    public static string ShippingAddressID="[dbo].[Orders].[ShippingAddressID]";
                    public static string BillingAddressID="[dbo].[Orders].[BillingAddressID]";
                    public static string DateShipped="[dbo].[Orders].[DateShipped]";
                    public static string TrackingNumber="[dbo].[Orders].[TrackingNumber]";
                    public static string EstimatedDelivery="[dbo].[Orders].[EstimatedDelivery]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("ShippingAmount","[dbo].[Orders].[ShippingAmount]");
                            _qualifiedColumns.Add("DiscountAmount","[dbo].[Orders].[DiscountAmount]");
                            _qualifiedColumns.Add("UserName","[dbo].[Orders].[UserName]");
                            _qualifiedColumns.Add("UserLanguageCode","[dbo].[Orders].[UserLanguageCode]");
                            _qualifiedColumns.Add("TaxAmount","[dbo].[Orders].[TaxAmount]");
                            _qualifiedColumns.Add("SubTotal","[dbo].[Orders].[SubTotal]");
                            _qualifiedColumns.Add("OrderStatusID","[dbo].[Orders].[OrderStatusID]");
                            _qualifiedColumns.Add("CreatedOn","[dbo].[Orders].[CreatedOn]");
                            _qualifiedColumns.Add("OrderID","[dbo].[Orders].[OrderID]");
                            _qualifiedColumns.Add("ModifiedOn","[dbo].[Orders].[ModifiedOn]");
                            _qualifiedColumns.Add("Version","[dbo].[Orders].[Version]");
                            _qualifiedColumns.Add("OrderNumber","[dbo].[Orders].[OrderNumber]");
                            _qualifiedColumns.Add("ExecutedOn","[dbo].[Orders].[ExecutedOn]");
                            _qualifiedColumns.Add("ShippingService","[dbo].[Orders].[ShippingService]");
                            _qualifiedColumns.Add("DiscountReason","[dbo].[Orders].[DiscountReason]");
                            _qualifiedColumns.Add("ShippingAddressID","[dbo].[Orders].[ShippingAddressID]");
                            _qualifiedColumns.Add("BillingAddressID","[dbo].[Orders].[BillingAddressID]");
                            _qualifiedColumns.Add("DateShipped","[dbo].[Orders].[DateShipped]");
                            _qualifiedColumns.Add("TrackingNumber","[dbo].[Orders].[TrackingNumber]");
                            _qualifiedColumns.Add("EstimatedDelivery","[dbo].[Orders].[EstimatedDelivery]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Orders](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Orders]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Orders]");
                return sql;
            }
        }
         

        public static class OrderStatusTable{
            public const string TABLE_NAME=@"[dbo].[OrderStatus]";
            public const string COLUMN_LIST=@"[dbo].[OrderStatus].[OrderStatusID],[dbo].[OrderStatus].[Description]";
 
                public static int ReadOrderStatusID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OrderStatusID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OrderStatusID="@OrderStatusID";
                    public static string Description="@Description";
                }    
            
            public struct Columns{
                    public static string OrderStatusID="OrderStatusID";
                    public static string Description="Description";
                } 
            public struct ColumnsQualified{
                    public static string OrderStatusID="[dbo].[OrderStatus].[OrderStatusID]";
                    public static string Description="[dbo].[OrderStatus].[Description]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OrderStatusID","[dbo].[OrderStatus].[OrderStatusID]");
                            _qualifiedColumns.Add("Description","[dbo].[OrderStatus].[Description]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[OrderStatus](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[OrderStatus]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[OrderStatus]");
                return sql;
            }
        }
         

        public static class ProductDescriptorsTable{
            public const string TABLE_NAME=@"[dbo].[ProductDescriptors]";
            public const string COLUMN_LIST=@"[dbo].[ProductDescriptors].[DescriptorID],[dbo].[ProductDescriptors].[SKU],[dbo].[ProductDescriptors].[LanguageCode],[dbo].[ProductDescriptors].[Title],[dbo].[ProductDescriptors].[IsDefault],[dbo].[ProductDescriptors].[Body]";
 
                public static int ReadDescriptorID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["DescriptorID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static string ReadLanguageCode(DbDataReader rdr){
                string result;
                                result= rdr["LanguageCode"].ToString();
                                return result;
            }
                public static string ReadTitle(DbDataReader rdr){
                string result;
                                result= rdr["Title"].ToString();
                                return result;
            }
                public static bool ReadIsDefault(DbDataReader rdr){
                bool result;
                                if(!bool.TryParse(rdr["IsDefault"].ToString(), out result))
				{
										result = false;
									}
                                return result;
            }
                public static string ReadBody(DbDataReader rdr){
                string result;
                                result= rdr["Body"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string DescriptorID="@DescriptorID";
                    public static string SKU="@SKU";
                    public static string LanguageCode="@LanguageCode";
                    public static string Title="@Title";
                    public static string IsDefault="@IsDefault";
                    public static string Body="@Body";
                }    
            
            public struct Columns{
                    public static string DescriptorID="DescriptorID";
                    public static string SKU="SKU";
                    public static string LanguageCode="LanguageCode";
                    public static string Title="Title";
                    public static string IsDefault="IsDefault";
                    public static string Body="Body";
                } 
            public struct ColumnsQualified{
                    public static string DescriptorID="[dbo].[ProductDescriptors].[DescriptorID]";
                    public static string SKU="[dbo].[ProductDescriptors].[SKU]";
                    public static string LanguageCode="[dbo].[ProductDescriptors].[LanguageCode]";
                    public static string Title="[dbo].[ProductDescriptors].[Title]";
                    public static string IsDefault="[dbo].[ProductDescriptors].[IsDefault]";
                    public static string Body="[dbo].[ProductDescriptors].[Body]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("DescriptorID","[dbo].[ProductDescriptors].[DescriptorID]");
                            _qualifiedColumns.Add("SKU","[dbo].[ProductDescriptors].[SKU]");
                            _qualifiedColumns.Add("LanguageCode","[dbo].[ProductDescriptors].[LanguageCode]");
                            _qualifiedColumns.Add("Title","[dbo].[ProductDescriptors].[Title]");
                            _qualifiedColumns.Add("IsDefault","[dbo].[ProductDescriptors].[IsDefault]");
                            _qualifiedColumns.Add("Body","[dbo].[ProductDescriptors].[Body]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ProductDescriptors](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ProductDescriptors]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ProductDescriptors]");
                return sql;
            }
        }
         

        public static class ProductImagesTable{
            public const string TABLE_NAME=@"[dbo].[ProductImages]";
            public const string COLUMN_LIST=@"[dbo].[ProductImages].[ProductImageID],[dbo].[ProductImages].[SKU],[dbo].[ProductImages].[ThumbUrl],[dbo].[ProductImages].[FullImageUrl]";
 
                public static int ReadProductImageID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["ProductImageID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static string ReadThumbUrl(DbDataReader rdr){
                string result;
                                result= rdr["ThumbUrl"].ToString();
                                return result;
            }
                public static string ReadFullImageUrl(DbDataReader rdr){
                string result;
                                result= rdr["FullImageUrl"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string ProductImageID="@ProductImageID";
                    public static string SKU="@SKU";
                    public static string ThumbUrl="@ThumbUrl";
                    public static string FullImageUrl="@FullImageUrl";
                }    
            
            public struct Columns{
                    public static string ProductImageID="ProductImageID";
                    public static string SKU="SKU";
                    public static string ThumbUrl="ThumbUrl";
                    public static string FullImageUrl="FullImageUrl";
                } 
            public struct ColumnsQualified{
                    public static string ProductImageID="[dbo].[ProductImages].[ProductImageID]";
                    public static string SKU="[dbo].[ProductImages].[SKU]";
                    public static string ThumbUrl="[dbo].[ProductImages].[ThumbUrl]";
                    public static string FullImageUrl="[dbo].[ProductImages].[FullImageUrl]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("ProductImageID","[dbo].[ProductImages].[ProductImageID]");
                            _qualifiedColumns.Add("SKU","[dbo].[ProductImages].[SKU]");
                            _qualifiedColumns.Add("ThumbUrl","[dbo].[ProductImages].[ThumbUrl]");
                            _qualifiedColumns.Add("FullImageUrl","[dbo].[ProductImages].[FullImageUrl]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ProductImages](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ProductImages]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ProductImages]");
                return sql;
            }
        }
         

        public static class ProductOptionDisplaysTable{
            public const string TABLE_NAME=@"[dbo].[ProductOptionDisplays]";
            public const string COLUMN_LIST=@"[dbo].[ProductOptionDisplays].[OptionDisplayID],[dbo].[ProductOptionDisplays].[HTMLDisplay]";
 
                public static int ReadOptionDisplayID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionDisplayID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadHTMLDisplay(DbDataReader rdr){
                string result;
                                result= rdr["HTMLDisplay"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OptionDisplayID="@OptionDisplayID";
                    public static string HTMLDisplay="@HTMLDisplay";
                }    
            
            public struct Columns{
                    public static string OptionDisplayID="OptionDisplayID";
                    public static string HTMLDisplay="HTMLDisplay";
                } 
            public struct ColumnsQualified{
                    public static string OptionDisplayID="[dbo].[ProductOptionDisplays].[OptionDisplayID]";
                    public static string HTMLDisplay="[dbo].[ProductOptionDisplays].[HTMLDisplay]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OptionDisplayID","[dbo].[ProductOptionDisplays].[OptionDisplayID]");
                            _qualifiedColumns.Add("HTMLDisplay","[dbo].[ProductOptionDisplays].[HTMLDisplay]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ProductOptionDisplays](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ProductOptionDisplays]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ProductOptionDisplays]");
                return sql;
            }
        }
         

        public static class ProductOptionsTable{
            public const string TABLE_NAME=@"[dbo].[ProductOptions]";
            public const string COLUMN_LIST=@"[dbo].[ProductOptions].[OptionID],[dbo].[ProductOptions].[Description],[dbo].[ProductOptions].[LanguageCode],[dbo].[ProductOptions].[DisplayID],[dbo].[ProductOptions].[Prompt]";
 
                public static int ReadOptionID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
                public static string ReadLanguageCode(DbDataReader rdr){
                string result;
                                result= rdr["LanguageCode"].ToString();
                                return result;
            }
                public static int ReadDisplayID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["DisplayID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadPrompt(DbDataReader rdr){
                string result;
                                result= rdr["Prompt"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OptionID="@OptionID";
                    public static string Description="@Description";
                    public static string LanguageCode="@LanguageCode";
                    public static string DisplayID="@DisplayID";
                    public static string Prompt="@Prompt";
                }    
            
            public struct Columns{
                    public static string OptionID="OptionID";
                    public static string Description="Description";
                    public static string LanguageCode="LanguageCode";
                    public static string DisplayID="DisplayID";
                    public static string Prompt="Prompt";
                } 
            public struct ColumnsQualified{
                    public static string OptionID="[dbo].[ProductOptions].[OptionID]";
                    public static string Description="[dbo].[ProductOptions].[Description]";
                    public static string LanguageCode="[dbo].[ProductOptions].[LanguageCode]";
                    public static string DisplayID="[dbo].[ProductOptions].[DisplayID]";
                    public static string Prompt="[dbo].[ProductOptions].[Prompt]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OptionID","[dbo].[ProductOptions].[OptionID]");
                            _qualifiedColumns.Add("Description","[dbo].[ProductOptions].[Description]");
                            _qualifiedColumns.Add("LanguageCode","[dbo].[ProductOptions].[LanguageCode]");
                            _qualifiedColumns.Add("DisplayID","[dbo].[ProductOptions].[DisplayID]");
                            _qualifiedColumns.Add("Prompt","[dbo].[ProductOptions].[Prompt]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ProductOptions](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ProductOptions]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ProductOptions]");
                return sql;
            }
        }
         

        public static class ProductOptionValuesTable{
            public const string TABLE_NAME=@"[dbo].[ProductOptionValues]";
            public const string COLUMN_LIST=@"[dbo].[ProductOptionValues].[OptionValueID],[dbo].[ProductOptionValues].[OptionID],[dbo].[ProductOptionValues].[Description]";
 
                public static int ReadOptionValueID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionValueID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static int ReadOptionID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadDescription(DbDataReader rdr){
                string result;
                                result= rdr["Description"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OptionValueID="@OptionValueID";
                    public static string OptionID="@OptionID";
                    public static string Description="@Description";
                }    
            
            public struct Columns{
                    public static string OptionValueID="OptionValueID";
                    public static string OptionID="OptionID";
                    public static string Description="Description";
                } 
            public struct ColumnsQualified{
                    public static string OptionValueID="[dbo].[ProductOptionValues].[OptionValueID]";
                    public static string OptionID="[dbo].[ProductOptionValues].[OptionID]";
                    public static string Description="[dbo].[ProductOptionValues].[Description]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OptionValueID","[dbo].[ProductOptionValues].[OptionValueID]");
                            _qualifiedColumns.Add("OptionID","[dbo].[ProductOptionValues].[OptionID]");
                            _qualifiedColumns.Add("Description","[dbo].[ProductOptionValues].[Description]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ProductOptionValues](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ProductOptionValues]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ProductOptionValues]");
                return sql;
            }
        }
         

        public static class ProductsTable{
            public const string TABLE_NAME=@"[dbo].[Products]";
            public const string COLUMN_LIST=@"[dbo].[Products].[SKU],[dbo].[Products].[DeliveryMethodID],[dbo].[Products].[ProductName],[dbo].[Products].[Blurb],[dbo].[Products].[BasePrice],[dbo].[Products].[WeightInPounds],[dbo].[Products].[DateAvailable],[dbo].[Products].[InventoryStatusID],[dbo].[Products].[EstimatedDelivery],[dbo].[Products].[AllowBackOrder],[dbo].[Products].[IsTaxable],[dbo].[Products].[Version],[dbo].[Products].[AmountOnHand],[dbo].[Products].[AllowPreOrder],[dbo].[Products].[DefaultImageFile]";
 
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static int ReadDeliveryMethodID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["DeliveryMethodID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadProductName(DbDataReader rdr){
                string result;
                                result= rdr["ProductName"].ToString();
                                return result;
            }
                public static string ReadBlurb(DbDataReader rdr){
                string result;
                                result= rdr["Blurb"].ToString();
                                return result;
            }
                public static decimal ReadBasePrice(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["BasePrice"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static decimal ReadWeightInPounds(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["WeightInPounds"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static DateTime ReadDateAvailable(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["DateAvailable"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static int ReadInventoryStatusID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["InventoryStatusID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadEstimatedDelivery(DbDataReader rdr){
                string result;
                                result= rdr["EstimatedDelivery"].ToString();
                                return result;
            }
                public static bool ReadAllowBackOrder(DbDataReader rdr){
                bool result;
                                if(!bool.TryParse(rdr["AllowBackOrder"].ToString(), out result))
				{
										result = false;
									}
                                return result;
            }
                public static bool ReadIsTaxable(DbDataReader rdr){
                bool result;
                                if(!bool.TryParse(rdr["IsTaxable"].ToString(), out result))
				{
										result = false;
									}
                                return result;
            }
                public static string ReadVersion(DbDataReader rdr){
                string result;
                                result= rdr["Version"].ToString();
                                return result;
            }
                public static int ReadAmountOnHand(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["AmountOnHand"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static bool ReadAllowPreOrder(DbDataReader rdr){
                bool result;
                                if(!bool.TryParse(rdr["AllowPreOrder"].ToString(), out result))
				{
										result = false;
									}
                                return result;
            }
                public static string ReadDefaultImageFile(DbDataReader rdr){
                string result;
                                result= rdr["DefaultImageFile"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string SKU="@SKU";
                    public static string DeliveryMethodID="@DeliveryMethodID";
                    public static string ProductName="@ProductName";
                    public static string Blurb="@Blurb";
                    public static string BasePrice="@BasePrice";
                    public static string WeightInPounds="@WeightInPounds";
                    public static string DateAvailable="@DateAvailable";
                    public static string InventoryStatusID="@InventoryStatusID";
                    public static string EstimatedDelivery="@EstimatedDelivery";
                    public static string AllowBackOrder="@AllowBackOrder";
                    public static string IsTaxable="@IsTaxable";
                    public static string Version="@Version";
                    public static string AmountOnHand="@AmountOnHand";
                    public static string AllowPreOrder="@AllowPreOrder";
                    public static string DefaultImageFile="@DefaultImageFile";
                }    
            
            public struct Columns{
                    public static string SKU="SKU";
                    public static string DeliveryMethodID="DeliveryMethodID";
                    public static string ProductName="ProductName";
                    public static string Blurb="Blurb";
                    public static string BasePrice="BasePrice";
                    public static string WeightInPounds="WeightInPounds";
                    public static string DateAvailable="DateAvailable";
                    public static string InventoryStatusID="InventoryStatusID";
                    public static string EstimatedDelivery="EstimatedDelivery";
                    public static string AllowBackOrder="AllowBackOrder";
                    public static string IsTaxable="IsTaxable";
                    public static string Version="Version";
                    public static string AmountOnHand="AmountOnHand";
                    public static string AllowPreOrder="AllowPreOrder";
                    public static string DefaultImageFile="DefaultImageFile";
                } 
            public struct ColumnsQualified{
                    public static string SKU="[dbo].[Products].[SKU]";
                    public static string DeliveryMethodID="[dbo].[Products].[DeliveryMethodID]";
                    public static string ProductName="[dbo].[Products].[ProductName]";
                    public static string Blurb="[dbo].[Products].[Blurb]";
                    public static string BasePrice="[dbo].[Products].[BasePrice]";
                    public static string WeightInPounds="[dbo].[Products].[WeightInPounds]";
                    public static string DateAvailable="[dbo].[Products].[DateAvailable]";
                    public static string InventoryStatusID="[dbo].[Products].[InventoryStatusID]";
                    public static string EstimatedDelivery="[dbo].[Products].[EstimatedDelivery]";
                    public static string AllowBackOrder="[dbo].[Products].[AllowBackOrder]";
                    public static string IsTaxable="[dbo].[Products].[IsTaxable]";
                    public static string Version="[dbo].[Products].[Version]";
                    public static string AmountOnHand="[dbo].[Products].[AmountOnHand]";
                    public static string AllowPreOrder="[dbo].[Products].[AllowPreOrder]";
                    public static string DefaultImageFile="[dbo].[Products].[DefaultImageFile]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("SKU","[dbo].[Products].[SKU]");
                            _qualifiedColumns.Add("DeliveryMethodID","[dbo].[Products].[DeliveryMethodID]");
                            _qualifiedColumns.Add("ProductName","[dbo].[Products].[ProductName]");
                            _qualifiedColumns.Add("Blurb","[dbo].[Products].[Blurb]");
                            _qualifiedColumns.Add("BasePrice","[dbo].[Products].[BasePrice]");
                            _qualifiedColumns.Add("WeightInPounds","[dbo].[Products].[WeightInPounds]");
                            _qualifiedColumns.Add("DateAvailable","[dbo].[Products].[DateAvailable]");
                            _qualifiedColumns.Add("InventoryStatusID","[dbo].[Products].[InventoryStatusID]");
                            _qualifiedColumns.Add("EstimatedDelivery","[dbo].[Products].[EstimatedDelivery]");
                            _qualifiedColumns.Add("AllowBackOrder","[dbo].[Products].[AllowBackOrder]");
                            _qualifiedColumns.Add("IsTaxable","[dbo].[Products].[IsTaxable]");
                            _qualifiedColumns.Add("Version","[dbo].[Products].[Version]");
                            _qualifiedColumns.Add("AmountOnHand","[dbo].[Products].[AmountOnHand]");
                            _qualifiedColumns.Add("AllowPreOrder","[dbo].[Products].[AllowPreOrder]");
                            _qualifiedColumns.Add("DefaultImageFile","[dbo].[Products].[DefaultImageFile]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Products](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Products]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Products]");
                return sql;
            }
        }
         

        public static class Products_CrossSellTable{
            public const string TABLE_NAME=@"[dbo].[Products_CrossSell]";
            public const string COLUMN_LIST=@"[dbo].[Products_CrossSell].[SKU],[dbo].[Products_CrossSell].[CrossSKU]";
 
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static string ReadCrossSKU(DbDataReader rdr){
                string result;
                                result= rdr["CrossSKU"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string SKU="@SKU";
                    public static string CrossSKU="@CrossSKU";
                }    
            
            public struct Columns{
                    public static string SKU="SKU";
                    public static string CrossSKU="CrossSKU";
                } 
            public struct ColumnsQualified{
                    public static string SKU="[dbo].[Products_CrossSell].[SKU]";
                    public static string CrossSKU="[dbo].[Products_CrossSell].[CrossSKU]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("SKU","[dbo].[Products_CrossSell].[SKU]");
                            _qualifiedColumns.Add("CrossSKU","[dbo].[Products_CrossSell].[CrossSKU]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Products_CrossSell](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Products_CrossSell]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Products_CrossSell]");
                return sql;
            }
        }
         

        public static class Products_OptionsTable{
            public const string TABLE_NAME=@"[dbo].[Products_Options]";
            public const string COLUMN_LIST=@"[dbo].[Products_Options].[SKU],[dbo].[Products_Options].[OptionID],[dbo].[Products_Options].[OptionValueID]";
 
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static int ReadOptionID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static int ReadOptionValueID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["OptionValueID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
        
            
            public struct Parameters{
                    public static string SKU="@SKU";
                    public static string OptionID="@OptionID";
                    public static string OptionValueID="@OptionValueID";
                }    
            
            public struct Columns{
                    public static string SKU="SKU";
                    public static string OptionID="OptionID";
                    public static string OptionValueID="OptionValueID";
                } 
            public struct ColumnsQualified{
                    public static string SKU="[dbo].[Products_Options].[SKU]";
                    public static string OptionID="[dbo].[Products_Options].[OptionID]";
                    public static string OptionValueID="[dbo].[Products_Options].[OptionValueID]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("SKU","[dbo].[Products_Options].[SKU]");
                            _qualifiedColumns.Add("OptionID","[dbo].[Products_Options].[OptionID]");
                            _qualifiedColumns.Add("OptionValueID","[dbo].[Products_Options].[OptionValueID]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Products_Options](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Products_Options]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Products_Options]");
                return sql;
            }
        }
         

        public static class Products_RelatedTable{
            public const string TABLE_NAME=@"[dbo].[Products_Related]";
            public const string COLUMN_LIST=@"[dbo].[Products_Related].[SKU],[dbo].[Products_Related].[RelatedSKU]";
 
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static string ReadRelatedSKU(DbDataReader rdr){
                string result;
                                result= rdr["RelatedSKU"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string SKU="@SKU";
                    public static string RelatedSKU="@RelatedSKU";
                }    
            
            public struct Columns{
                    public static string SKU="SKU";
                    public static string RelatedSKU="RelatedSKU";
                } 
            public struct ColumnsQualified{
                    public static string SKU="[dbo].[Products_Related].[SKU]";
                    public static string RelatedSKU="[dbo].[Products_Related].[RelatedSKU]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("SKU","[dbo].[Products_Related].[SKU]");
                            _qualifiedColumns.Add("RelatedSKU","[dbo].[Products_Related].[RelatedSKU]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Products_Related](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Products_Related]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Products_Related]");
                return sql;
            }
        }
         

        public static class ShippingMethodsTable{
            public const string TABLE_NAME=@"[dbo].[ShippingMethods]";
            public const string COLUMN_LIST=@"[dbo].[ShippingMethods].[ShippingMethodID],[dbo].[ShippingMethods].[Carrier],[dbo].[ShippingMethods].[ServiceName],[dbo].[ShippingMethods].[RatePerPound],[dbo].[ShippingMethods].[BaseRate],[dbo].[ShippingMethods].[DaysToDeliver],[dbo].[ShippingMethods].[EstimatedDelivery]";
 
                public static int ReadShippingMethodID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["ShippingMethodID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadCarrier(DbDataReader rdr){
                string result;
                                result= rdr["Carrier"].ToString();
                                return result;
            }
                public static string ReadServiceName(DbDataReader rdr){
                string result;
                                result= rdr["ServiceName"].ToString();
                                return result;
            }
                public static decimal ReadRatePerPound(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["RatePerPound"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static decimal ReadBaseRate(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["BaseRate"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static int ReadDaysToDeliver(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["DaysToDeliver"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadEstimatedDelivery(DbDataReader rdr){
                string result;
                                result= rdr["EstimatedDelivery"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string ShippingMethodID="@ShippingMethodID";
                    public static string Carrier="@Carrier";
                    public static string ServiceName="@ServiceName";
                    public static string RatePerPound="@RatePerPound";
                    public static string BaseRate="@BaseRate";
                    public static string DaysToDeliver="@DaysToDeliver";
                    public static string EstimatedDelivery="@EstimatedDelivery";
                }    
            
            public struct Columns{
                    public static string ShippingMethodID="ShippingMethodID";
                    public static string Carrier="Carrier";
                    public static string ServiceName="ServiceName";
                    public static string RatePerPound="RatePerPound";
                    public static string BaseRate="BaseRate";
                    public static string DaysToDeliver="DaysToDeliver";
                    public static string EstimatedDelivery="EstimatedDelivery";
                } 
            public struct ColumnsQualified{
                    public static string ShippingMethodID="[dbo].[ShippingMethods].[ShippingMethodID]";
                    public static string Carrier="[dbo].[ShippingMethods].[Carrier]";
                    public static string ServiceName="[dbo].[ShippingMethods].[ServiceName]";
                    public static string RatePerPound="[dbo].[ShippingMethods].[RatePerPound]";
                    public static string BaseRate="[dbo].[ShippingMethods].[BaseRate]";
                    public static string DaysToDeliver="[dbo].[ShippingMethods].[DaysToDeliver]";
                    public static string EstimatedDelivery="[dbo].[ShippingMethods].[EstimatedDelivery]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("ShippingMethodID","[dbo].[ShippingMethods].[ShippingMethodID]");
                            _qualifiedColumns.Add("Carrier","[dbo].[ShippingMethods].[Carrier]");
                            _qualifiedColumns.Add("ServiceName","[dbo].[ShippingMethods].[ServiceName]");
                            _qualifiedColumns.Add("RatePerPound","[dbo].[ShippingMethods].[RatePerPound]");
                            _qualifiedColumns.Add("BaseRate","[dbo].[ShippingMethods].[BaseRate]");
                            _qualifiedColumns.Add("DaysToDeliver","[dbo].[ShippingMethods].[DaysToDeliver]");
                            _qualifiedColumns.Add("EstimatedDelivery","[dbo].[ShippingMethods].[EstimatedDelivery]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[ShippingMethods](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[ShippingMethods]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[ShippingMethods]");
                return sql;
            }
        }
         

        public static class TaxRatesTable{
            public const string TABLE_NAME=@"[dbo].[TaxRates]";
            public const string COLUMN_LIST=@"[dbo].[TaxRates].[TaxRateID],[dbo].[TaxRates].[Rate],[dbo].[TaxRates].[Region],[dbo].[TaxRates].[Country],[dbo].[TaxRates].[PostalCode]";
 
                public static int ReadTaxRateID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["TaxRateID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static decimal ReadRate(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["Rate"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadRegion(DbDataReader rdr){
                string result;
                                result= rdr["Region"].ToString();
                                return result;
            }
                public static string ReadCountry(DbDataReader rdr){
                string result;
                                result= rdr["Country"].ToString();
                                return result;
            }
                public static string ReadPostalCode(DbDataReader rdr){
                string result;
                                result= rdr["PostalCode"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string TaxRateID="@TaxRateID";
                    public static string Rate="@Rate";
                    public static string Region="@Region";
                    public static string Country="@Country";
                    public static string PostalCode="@PostalCode";
                }    
            
            public struct Columns{
                    public static string TaxRateID="TaxRateID";
                    public static string Rate="Rate";
                    public static string Region="Region";
                    public static string Country="Country";
                    public static string PostalCode="PostalCode";
                } 
            public struct ColumnsQualified{
                    public static string TaxRateID="[dbo].[TaxRates].[TaxRateID]";
                    public static string Rate="[dbo].[TaxRates].[Rate]";
                    public static string Region="[dbo].[TaxRates].[Region]";
                    public static string Country="[dbo].[TaxRates].[Country]";
                    public static string PostalCode="[dbo].[TaxRates].[PostalCode]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("TaxRateID","[dbo].[TaxRates].[TaxRateID]");
                            _qualifiedColumns.Add("Rate","[dbo].[TaxRates].[Rate]");
                            _qualifiedColumns.Add("Region","[dbo].[TaxRates].[Region]");
                            _qualifiedColumns.Add("Country","[dbo].[TaxRates].[Country]");
                            _qualifiedColumns.Add("PostalCode","[dbo].[TaxRates].[PostalCode]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[TaxRates](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[TaxRates]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[TaxRates]");
                return sql;
            }
        }
         

        public static class TransactionsTable{
            public const string TABLE_NAME=@"[dbo].[Transactions]";
            public const string COLUMN_LIST=@"[dbo].[Transactions].[TransactionID],[dbo].[Transactions].[OrderID],[dbo].[Transactions].[TransactionDate],[dbo].[Transactions].[Amount],[dbo].[Transactions].[AuthorizationCode],[dbo].[Transactions].[Notes],[dbo].[Transactions].[Processor]";
 
                public static Guid ReadTransactionID(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["TransactionID"];
                                return result;
            }
                public static Guid ReadOrderID(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["OrderID"];
                                return result;
            }
                public static DateTime ReadTransactionDate(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["TransactionDate"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static decimal ReadAmount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["Amount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadAuthorizationCode(DbDataReader rdr){
                string result;
                                result= rdr["AuthorizationCode"].ToString();
                                return result;
            }
                public static string ReadNotes(DbDataReader rdr){
                string result;
                                result= rdr["Notes"].ToString();
                                return result;
            }
                public static string ReadProcessor(DbDataReader rdr){
                string result;
                                result= rdr["Processor"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string TransactionID="@TransactionID";
                    public static string OrderID="@OrderID";
                    public static string TransactionDate="@TransactionDate";
                    public static string Amount="@Amount";
                    public static string AuthorizationCode="@AuthorizationCode";
                    public static string Notes="@Notes";
                    public static string Processor="@Processor";
                }    
            
            public struct Columns{
                    public static string TransactionID="TransactionID";
                    public static string OrderID="OrderID";
                    public static string TransactionDate="TransactionDate";
                    public static string Amount="Amount";
                    public static string AuthorizationCode="AuthorizationCode";
                    public static string Notes="Notes";
                    public static string Processor="Processor";
                } 
            public struct ColumnsQualified{
                    public static string TransactionID="[dbo].[Transactions].[TransactionID]";
                    public static string OrderID="[dbo].[Transactions].[OrderID]";
                    public static string TransactionDate="[dbo].[Transactions].[TransactionDate]";
                    public static string Amount="[dbo].[Transactions].[Amount]";
                    public static string AuthorizationCode="[dbo].[Transactions].[AuthorizationCode]";
                    public static string Notes="[dbo].[Transactions].[Notes]";
                    public static string Processor="[dbo].[Transactions].[Processor]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("TransactionID","[dbo].[Transactions].[TransactionID]");
                            _qualifiedColumns.Add("OrderID","[dbo].[Transactions].[OrderID]");
                            _qualifiedColumns.Add("TransactionDate","[dbo].[Transactions].[TransactionDate]");
                            _qualifiedColumns.Add("Amount","[dbo].[Transactions].[Amount]");
                            _qualifiedColumns.Add("AuthorizationCode","[dbo].[Transactions].[AuthorizationCode]");
                            _qualifiedColumns.Add("Notes","[dbo].[Transactions].[Notes]");
                            _qualifiedColumns.Add("Processor","[dbo].[Transactions].[Processor]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Transactions](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Transactions]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Transactions]");
                return sql;
            }
        }
         

        public static class __RefactorLogTable{
            public const string TABLE_NAME=@"[dbo].[__RefactorLog]";
            public const string COLUMN_LIST=@"[dbo].[__RefactorLog].[OperationKey]";
 
                public static Guid ReadOperationKey(DbDataReader rdr){
                Guid result;
                                result=(Guid)rdr["OperationKey"];
                                return result;
            }
        
            
            public struct Parameters{
                    public static string OperationKey="@OperationKey";
                }    
            
            public struct Columns{
                    public static string OperationKey="OperationKey";
                } 
            public struct ColumnsQualified{
                    public static string OperationKey="[dbo].[__RefactorLog].[OperationKey]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("OperationKey","[dbo].[__RefactorLog].[OperationKey]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[__RefactorLog](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[__RefactorLog]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[__RefactorLog]");
                return sql;
            }
        }
         

        public static class AddressesTable{
            public const string TABLE_NAME=@"[dbo].[Addresses]";
            public const string COLUMN_LIST=@"[dbo].[Addresses].[AddressID],[dbo].[Addresses].[UserName],[dbo].[Addresses].[FirstName],[dbo].[Addresses].[LastName],[dbo].[Addresses].[Email],[dbo].[Addresses].[Street1],[dbo].[Addresses].[City],[dbo].[Addresses].[StateOrProvince],[dbo].[Addresses].[Zip],[dbo].[Addresses].[Country],[dbo].[Addresses].[IsDefault],[dbo].[Addresses].[Latitude],[dbo].[Addresses].[Longitude],[dbo].[Addresses].[Street2]";
 
                public static int ReadAddressID(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["AddressID"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static string ReadUserName(DbDataReader rdr){
                string result;
                                result= rdr["UserName"].ToString();
                                return result;
            }
                public static string ReadFirstName(DbDataReader rdr){
                string result;
                                result= rdr["FirstName"].ToString();
                                return result;
            }
                public static string ReadLastName(DbDataReader rdr){
                string result;
                                result= rdr["LastName"].ToString();
                                return result;
            }
                public static string ReadEmail(DbDataReader rdr){
                string result;
                                result= rdr["Email"].ToString();
                                return result;
            }
                public static string ReadStreet1(DbDataReader rdr){
                string result;
                                result= rdr["Street1"].ToString();
                                return result;
            }
                public static string ReadCity(DbDataReader rdr){
                string result;
                                result= rdr["City"].ToString();
                                return result;
            }
                public static string ReadStateOrProvince(DbDataReader rdr){
                string result;
                                result= rdr["StateOrProvince"].ToString();
                                return result;
            }
                public static string ReadZip(DbDataReader rdr){
                string result;
                                result= rdr["Zip"].ToString();
                                return result;
            }
                public static string ReadCountry(DbDataReader rdr){
                string result;
                                result= rdr["Country"].ToString();
                                return result;
            }
                public static bool ReadIsDefault(DbDataReader rdr){
                bool result;
                                if(!bool.TryParse(rdr["IsDefault"].ToString(), out result))
				{
										result = false;
									}
                                return result;
            }
                public static string ReadLatitude(DbDataReader rdr){
                string result;
                                result= rdr["Latitude"].ToString();
                                return result;
            }
                public static string ReadLongitude(DbDataReader rdr){
                string result;
                                result= rdr["Longitude"].ToString();
                                return result;
            }
                public static string ReadStreet2(DbDataReader rdr){
                string result;
                                result= rdr["Street2"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string AddressID="@AddressID";
                    public static string UserName="@UserName";
                    public static string FirstName="@FirstName";
                    public static string LastName="@LastName";
                    public static string Email="@Email";
                    public static string Street1="@Street1";
                    public static string City="@City";
                    public static string StateOrProvince="@StateOrProvince";
                    public static string Zip="@Zip";
                    public static string Country="@Country";
                    public static string IsDefault="@IsDefault";
                    public static string Latitude="@Latitude";
                    public static string Longitude="@Longitude";
                    public static string Street2="@Street2";
                }    
            
            public struct Columns{
                    public static string AddressID="AddressID";
                    public static string UserName="UserName";
                    public static string FirstName="FirstName";
                    public static string LastName="LastName";
                    public static string Email="Email";
                    public static string Street1="Street1";
                    public static string City="City";
                    public static string StateOrProvince="StateOrProvince";
                    public static string Zip="Zip";
                    public static string Country="Country";
                    public static string IsDefault="IsDefault";
                    public static string Latitude="Latitude";
                    public static string Longitude="Longitude";
                    public static string Street2="Street2";
                } 
            public struct ColumnsQualified{
                    public static string AddressID="[dbo].[Addresses].[AddressID]";
                    public static string UserName="[dbo].[Addresses].[UserName]";
                    public static string FirstName="[dbo].[Addresses].[FirstName]";
                    public static string LastName="[dbo].[Addresses].[LastName]";
                    public static string Email="[dbo].[Addresses].[Email]";
                    public static string Street1="[dbo].[Addresses].[Street1]";
                    public static string City="[dbo].[Addresses].[City]";
                    public static string StateOrProvince="[dbo].[Addresses].[StateOrProvince]";
                    public static string Zip="[dbo].[Addresses].[Zip]";
                    public static string Country="[dbo].[Addresses].[Country]";
                    public static string IsDefault="[dbo].[Addresses].[IsDefault]";
                    public static string Latitude="[dbo].[Addresses].[Latitude]";
                    public static string Longitude="[dbo].[Addresses].[Longitude]";
                    public static string Street2="[dbo].[Addresses].[Street2]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("AddressID","[dbo].[Addresses].[AddressID]");
                            _qualifiedColumns.Add("UserName","[dbo].[Addresses].[UserName]");
                            _qualifiedColumns.Add("FirstName","[dbo].[Addresses].[FirstName]");
                            _qualifiedColumns.Add("LastName","[dbo].[Addresses].[LastName]");
                            _qualifiedColumns.Add("Email","[dbo].[Addresses].[Email]");
                            _qualifiedColumns.Add("Street1","[dbo].[Addresses].[Street1]");
                            _qualifiedColumns.Add("City","[dbo].[Addresses].[City]");
                            _qualifiedColumns.Add("StateOrProvince","[dbo].[Addresses].[StateOrProvince]");
                            _qualifiedColumns.Add("Zip","[dbo].[Addresses].[Zip]");
                            _qualifiedColumns.Add("Country","[dbo].[Addresses].[Country]");
                            _qualifiedColumns.Add("IsDefault","[dbo].[Addresses].[IsDefault]");
                            _qualifiedColumns.Add("Latitude","[dbo].[Addresses].[Latitude]");
                            _qualifiedColumns.Add("Longitude","[dbo].[Addresses].[Longitude]");
                            _qualifiedColumns.Add("Street2","[dbo].[Addresses].[Street2]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[Addresses](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[Addresses]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[Addresses]");
                return sql;
            }
        }
         

        public static class CartItemsTable{
            public const string TABLE_NAME=@"[dbo].[CartItems]";
            public const string COLUMN_LIST=@"[dbo].[CartItems].[SKU],[dbo].[CartItems].[UserName],[dbo].[CartItems].[Quantity],[dbo].[CartItems].[DateAdded],[dbo].[CartItems].[DiscountAmount],[dbo].[CartItems].[DiscountReason]";
 
                public static string ReadSKU(DbDataReader rdr){
                string result;
                                result= rdr["SKU"].ToString();
                                return result;
            }
                public static string ReadUserName(DbDataReader rdr){
                string result;
                                result= rdr["UserName"].ToString();
                                return result;
            }
                public static int ReadQuantity(DbDataReader rdr){
                int result;
                                if(!int.TryParse(rdr["Quantity"].ToString(), out result))
				{
										result = int.MinValue;
									}
                                return result;
            }
                public static DateTime ReadDateAdded(DbDataReader rdr){
                DateTime result;
                                if(!DateTime.TryParse(rdr["DateAdded"].ToString(), out result))
				{
										result = DateTime.MinValue;
									}
                                return result;
            }
                public static decimal ReadDiscountAmount(DbDataReader rdr){
                decimal result;
                                if(!decimal.TryParse(rdr["DiscountAmount"].ToString(), out result))
				{
										result = decimal.MinValue;
									}
                                return result;
            }
                public static string ReadDiscountReason(DbDataReader rdr){
                string result;
                                result= rdr["DiscountReason"].ToString();
                                return result;
            }
        
            
            public struct Parameters{
                    public static string SKU="@SKU";
                    public static string UserName="@UserName";
                    public static string Quantity="@Quantity";
                    public static string DateAdded="@DateAdded";
                    public static string DiscountAmount="@DiscountAmount";
                    public static string DiscountReason="@DiscountReason";
                }    
            
            public struct Columns{
                    public static string SKU="SKU";
                    public static string UserName="UserName";
                    public static string Quantity="Quantity";
                    public static string DateAdded="DateAdded";
                    public static string DiscountAmount="DiscountAmount";
                    public static string DiscountReason="DiscountReason";
                } 
            public struct ColumnsQualified{
                    public static string SKU="[dbo].[CartItems].[SKU]";
                    public static string UserName="[dbo].[CartItems].[UserName]";
                    public static string Quantity="[dbo].[CartItems].[Quantity]";
                    public static string DateAdded="[dbo].[CartItems].[DateAdded]";
                    public static string DiscountAmount="[dbo].[CartItems].[DiscountAmount]";
                    public static string DiscountReason="[dbo].[CartItems].[DiscountReason]";
                }
                 
            static Dictionary<string, string> _qualifiedColumns;
            static Dictionary<string, string> QualifiedColumns{
                get{
                    if(_qualifiedColumns==null){
                        _qualifiedColumns=new Dictionary<string,string>();
                            _qualifiedColumns.Add("SKU","[dbo].[CartItems].[SKU]");
                            _qualifiedColumns.Add("UserName","[dbo].[CartItems].[UserName]");
                            _qualifiedColumns.Add("Quantity","[dbo].[CartItems].[Quantity]");
                            _qualifiedColumns.Add("DateAdded","[dbo].[CartItems].[DateAdded]");
                            _qualifiedColumns.Add("DiscountAmount","[dbo].[CartItems].[DiscountAmount]");
                            _qualifiedColumns.Add("DiscountReason","[dbo].[CartItems].[DiscountReason]");
                        }
                    return _qualifiedColumns;
                }
            }

          
            public static SqlStatement Select(){
                return Select(COLUMN_LIST.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
            }

            public static SqlStatement Select(params string[] columns){
                //for jon galloway
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("SELECT ");
                
                int indexer=1;
                foreach(string s in columns){
                    string qualifiedName=s;
                    if(QualifiedColumns.ContainsKey(s))
                        qualifiedName=QualifiedColumns[s];
                    sb.AppendFormat("{0}",qualifiedName);
                    if(indexer<columns.Length)
                        sb.Append(",");
                    indexer++;
                }
                sb.AppendFormat("\r\nFROM {0} ",TABLE_NAME);
                sb.AppendLine();
                sql.Add(sb.ToString());
                return sql; 

            } 

            public static SqlStatement Insert(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                StringBuilder sb=new StringBuilder();
                sb.Append("INSERT INTO [dbo].[CartItems](");
                int indexer=1;
                foreach(string key in settings.Keys){
                    
                    sb.Append(key);
                    if(indexer<settings.Count)
                        sb.Append(",");

                    sql.AddInsertValue(key,settings[key]);
                    indexer++;
                }
                sb.AppendLine(")");
                sql.Add(sb.ToString());
                return sql;
            }
            
           
            public static SqlStatement Update(Dictionary<string,object> settings){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add(string.Format("UPDATE {0} SET ","[dbo].[CartItems]"));
                foreach(string key in settings.Keys){
                    sql.AddSetting(key,settings[key]);
                }
                return sql;
            }
            

            public static SqlStatement Delete(){
                var sql=new SqlStatement("TailspinConnectionString");
                sql.Add("DELETE FROM [dbo].[CartItems]");
                return sql;
            }
        }
        
}