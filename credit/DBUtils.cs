using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            return DBSQLServerUtils.GetDBConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        }
    }
}
