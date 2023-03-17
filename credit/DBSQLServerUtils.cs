using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit
{
    class DBSQLServerUtils
    {
        public static SqlConnection
        GetDBConnection(string db)
        {
            string connString = db;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
