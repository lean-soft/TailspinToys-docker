using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Tailspin.Infrastructure;
using System.Data;
using System.Diagnostics;

namespace Tailspin.SimpleSqlRepository
{
    
    /// <summary>
    /// Some generic Helper thingers
    /// </summary>
    public static class SqlHelper{
        public static DbCommand ToCommand(this string sql, string connStringName){
            var db=new DbCommon(connStringName);
            var cmd=db.CreateCommand(sql);
            return cmd;
        }
        public static void Execute(this SortedList<int,DbCommand> commands, string connStringName) {
            //using a sorted list here to allow for sequential execution
            var db = new DbCommon(connStringName);
            db.ExecuteTransaction(commands);
        }       
        public static void Execute(this IEnumerable<DbCommand> commands, string connStringName){
            var db=new DbCommon(connStringName);
            db.ExecuteTransaction(commands.ToArray());
        }
        public static bool RecordExists(string connStringName, string tableName,  string column, object value) {
            return RecordExists(connStringName, tableName, new Dictionary<string, object>(){
                    {column, value}
                });
        }

       
        public static bool RecordExists( string connStringName,string tableName, Dictionary<string, object> values) {
            var sb = new StringBuilder();
            SqlStatement sql = new SqlStatement(connStringName);
            sql.Add("SELECT " + values.First().Key);
            sql.Add(" FROM " + tableName);

            object result = null;
            int indexer = 1;
            foreach (string s in values.Keys) {
                if (indexer == 1) {
                    sql.Where(s, values[s]);
                } else {
                    sql.And(s, values[s]);
                }
                indexer++;
            }
            using (var cmd = sql.BuildCommand()) {
                result = cmd.ExecuteScalar();
            }
            return result != null;
        }

        public static DbType GetDbType(object item) {
            DbType result = DbType.String;

            if (item == null) {
                return result;
            } else if (item.GetType() == typeof(Guid)) {
                //Guid
                result = DbType.Guid;
            } else if (item.GetType() == typeof(int)) {
                //int
                result = DbType.Int32;

            } else if (item.GetType() == typeof(bool)) {
                //bool
                result = DbType.Boolean;

            } else if (item.GetType() == typeof(decimal)) {
                //decimal
                result = DbType.Decimal;

            } else if (item.GetType() == typeof(DateTime)) {
                //dates
                result = DbType.DateTime;

            } else if (item.GetType() == typeof(byte[])) {
                //binary
                result = DbType.Binary;
            }

            return result;
        }

    }


    public class Parameter {

        public Parameter(string columnName, Op op, object value) {
            ColumnName = columnName;
            Value=value;
            DbType=SqlHelper.GetDbType(value);
            Operator = op;
        }
        public Op Operator { get; set; }
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public object Value { get; set; }
        public DbType DbType { get; set; }
    }

    public class BatchSql{

        List<SqlStatement> sqlList;
        List<Parameter> DbParams;
        public BatchSql(){
            sqlList=new List<SqlStatement>();
            DbParams = new List<Parameter>();
        }

        public void Append(SqlStatement sql){
            sqlList.Add(sql);
        }

        public DbCommand BuildCommand(string connectionStringName) {
            var db = new DbCommon(connectionStringName);
            var cmd = db.CreateCommand(GetSql());
            foreach (var con in DbParams) {
                cmd.AddParameter(con.Name, con.Value, con.DbType);
            }
            return cmd;
        }

        public string GetSql(){
            StringBuilder sb=new StringBuilder();

            int runningParams = 0;


            foreach (var item in sqlList)
            {


                sb.Append(item.sb.ToString());

                //reset the WHERE's
                string clause = "\r\nWHERE";
                foreach (var con in item.DbParams) {
                    con.Name = "@p" + runningParams;
                    sb.AppendFormat("{0} {1}={2} ", clause, con.ColumnName,con.Name);
                    clause = "\r\nAND";
                    runningParams++;
                    DbParams.Add(con);
                }
                sb.AppendLine(item.sbOrderBys.ToString());
                sb.AppendLine(";");
            }
            return sb.ToString();

        }


    }


    /// <summary>
    /// A simple wrapper class for StringBuilder :)
    /// </summary>
    public class SqlStatement
    {

        internal StringBuilder sb;
        internal StringBuilder sbSets;
        internal StringBuilder sbInserts;
        internal StringBuilder sbConstraints;
        internal StringBuilder sbOrderBys;
        DbCommon db;
        internal Dictionary<string,object> paramQueue;
        internal Dictionary<string, object> settingsQueue;
        internal Dictionary<string, object> insertValues;
        internal List<SqlStatement> appendedStatements;

        internal List<Parameter> DbParams;

        int AppendedParamCount {
            get {
                int result = 0;
                foreach (var item in appendedStatements) {
                    result += item.paramQueue.Count;
                }
                return result;
            }
        }

        int GetParamCount {
            get {
                
                return paramQueue.Count + settingsQueue.Count+insertValues.Count+AppendedParamCount;
            }
        }
        string GetParameter {
            get {
                return "@p" + GetParamCount;
            }
        }
        public SqlStatement(string connectionStringName)
        {
            db = new DbCommon(connectionStringName);
            sb = new StringBuilder();
            sbSets = new StringBuilder();
            sbConstraints = new StringBuilder();
            sbOrderBys = new StringBuilder();
            sbInserts = new StringBuilder();
            this.paramQueue = new Dictionary<string, object>();
            this.settingsQueue = new Dictionary<string, object>();
            this.insertValues = new Dictionary<string, object>();
            appendedStatements = new List<SqlStatement>();
            DbParams = new List<Parameter>();
        }
        public void Clear(){
            sb=new StringBuilder();
        }
        public SqlStatement AddInsertValue(string column, object value) {
            if (sbInserts.Length == 0)
                sbInserts.Append("VALUES (");
            
            sbInserts.AppendFormat("{0},",GetParameter);
            insertValues.Add(GetParameter, value);

            return this;
        }
        public SqlStatement AddSetting(string column, object value) {
            sbSets.AppendFormat("{0}={1},", column, GetParameter);
            sbSets.AppendLine();
            settingsQueue.Add(GetParameter, value);
            return this;
        }

        public SqlStatement Add(string sql)
        {
            
            sb.Append(sql);
            return this;
        }


        public string Sql {
            get {
                if (insertValues.Count > 0) {
                    var insertSql = sbInserts.ToString().Substring(0, sbInserts.Length - 1) + ");";
                    sb.AppendLine(insertSql);


                }

                if (settingsQueue.Count > 0) {
                    var setSQl = sbSets.ToString().Substring(0, sbSets.Length - 3);
                    //add it to main SQL statement
                    sb.AppendLine(setSQl);
                }


                sb.AppendLine(sbConstraints.ToString());
                
                //order bys
                sb.Append(sbOrderBys.ToString());


#if DEBUG
                Debug.WriteLine("Creating SQL: ");
                Debug.WriteLine(sb.ToString());

                Debug.WriteLine("Params: ");
                foreach (var p in paramQueue) {
                    Debug.WriteLine(p.Key + "= " + p.Value);
                }
#endif


                return sb.ToString();
            }
        }
        public DbCommand BuildCommand() {

            //if there are settings, need to peel off the last comma of the SET statement

            var cmd = db.CreateCommand(Sql);

            //settings
            foreach (var par in this.settingsQueue.Keys) {
                cmd.AddParameter(par, settingsQueue[par], SqlHelper.GetDbType(settingsQueue[par]));
            }

            //inserts
            foreach (var par in this.insertValues.Keys) {
                cmd.AddParameter(par, insertValues[par], SqlHelper.GetDbType(insertValues[par]));
            }

            //constraints
            foreach (var par in this.paramQueue.Keys) {
                cmd.AddParameter(par, paramQueue[par],SqlHelper.GetDbType(paramQueue[par]));
            }

            return cmd;
        }

        public SqlStatement OrderBy(params string [] columns) {
            sbOrderBys.Append("\r\nORDER BY ");
            int indexer = 1;
            foreach (string s in columns) {
                sbOrderBys.Append(s);
                if (indexer < columns.Length)
                    sbOrderBys.Append(",");
                indexer++;
            }

            return this;
        }
        public SqlStatement OrderByDesc(params string[] columns) {
            sbOrderBys.Append("\r\nORDER BY ");
            int indexer = 1;
            foreach (string s in columns) {
                sbOrderBys.Append(s + "DESC");
                if (indexer < columns.Length)
                    sbOrderBys.Append(",");
                indexer++;
            }

            return this;
        }
        public SqlStatement Where(string column,  object value){
            return Where(column, Op.Equals, value);
        }
        public SqlStatement Where(string column, Op op, object value)
        {
            CreateConstraint("WHERE",column,op,value);
            return this;
        }

        public SqlStatement InnerJoin(string fromTable, string fromColumn, string toTable, string toColumn) {
            string join = string.Format("\r\n FROM {0} INNER JOIN {1} ON {2} = {3}\r\n", fromTable, toTable, fromColumn, toColumn);
            this.Add(join);
            return this;
        }

        public SqlStatement And(string column, object value) {
            return And(column, Op.Equals, value);
        }
        public SqlStatement And(string column, Op op, object value) {
            CreateConstraint("AND", column, op, value);
            return this;
        }

        public SqlStatement Or(string column, object value) {
            return Or(column, Op.Equals, value);
        }
        public SqlStatement Or(string column, Op op, object value) {
            CreateConstraint("OR", column, op, value);
            return this;
        }

        void CreateConstraint(string constraint, string columnName, Op op,object value) {
            string operation = GetOperator(op);

            sbConstraints.AppendFormat("{0} {1} {2} {3}", constraint, columnName, operation, this.GetParameter);
            sbConstraints.AppendLine();
            //queue the param
            paramQueue.Add(this.GetParameter, value);
            DbParams.Add(new Parameter(columnName, op, value));
            
        }

        string GetOperator(Op op)
        {
            string sOut;
            switch(op)
            {
                case Op.GreaterThan:
                    sOut = " > ";
                    break;
                case Op.GreaterOrEquals:
                    sOut = " >= ";
                    break;
                case Op.LessThan:
                    sOut = " < ";
                    break;
                case Op.LessOrEquals:
                    sOut = " <= ";
                    break;
                case Op.Like:
                    sOut = " LIKE ";
                    break;
                case Op.NotEquals:
                    sOut = " <> ";
                    break;
                case Op.NotLike:
                    sOut = " NOT LIKE ";
                    break;
                default:
                    sOut = " = ";
                    break;
            }
            return sOut;
        }


    }
    public enum Op {
        GreaterThan,
        GreaterOrEquals,
        LessThan,
        LessOrEquals,
        Like,
        NotEquals,
        NotLike,
        Equals
    }
}
