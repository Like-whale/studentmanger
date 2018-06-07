using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Test01
{
    class ConnectionSql
    {
        public static string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(SqlStr);
    }
}
