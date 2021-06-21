using Los_api.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Los_api.Daos
{
    public class MainDao
    {
        private readonly OracleConnection _conn;
        SqlConnection connSql;
        //public ReportDao(SqlConnection conn)
        public MainDao(OracleConnection conn)
        {
            //this.connSql = conn;
            _conn = conn;
        }

        public List<ProductItems> Report01(string custCode, string custName, DateTime dueDate, string contractRef, out string errMsg)
        {
            List<ProductItems> list = new List<ProductItems>();
            errMsg = "";
            DbDataReader reader = null;
            try
            {
                string sqlStmt = "";
                sqlStmt = "  select * from ProductItem Prd left join StockItem Stk ";

                // Create command.
                SqlCommand cmd = new SqlCommand();

                // Set connection for command.
                cmd.Connection = connSql;

                cmd.CommandText = sqlStmt;
                cmd.Prepare();

                int row = 0;
                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        ProductItems obj;

                        while (reader.Read())
                        {
                            obj = new ProductItems();

                            obj.id = ReadDateTime(reader["Id"]);
                            obj.name = ReadInt(reader["Name"]);
                            obj.imageUrl = ReadInt(reader["ImageUrl"]);
                            obj.price = ReadInt(reader["Price"]);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = "DAOErr:: " + ex.Message + " \r\n StackTrace : " + ex.StackTrace + " \r\n Line No : ";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return list;
        }
    }
}
