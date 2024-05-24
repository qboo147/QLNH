using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DBConnect
{
    class getConnection
    {
        private const string sqlconnectstaff = @"Data Source=BLAP;Initial Catalog=QLNH;User ID=NVBH;Password=123456;";
        private const string sqlconnectadmin = @"Data Source=BLAP;Initial Catalog=QLNH;User ID=NVQL;Password=123456;";
        private const string sa = @"Data Source=BLAP;Initial Catalog=QLNH;Integrated Security=True";
        

        public static SqlConnection GetSqlConnection(string role = null)
        {
            SqlConnection conn = new SqlConnection(sa);
            return conn;
        }

        public static SqlConnection GetSqlConnectionStaff(string role = null)
        {
            SqlConnection staff = new SqlConnection(sqlconnectstaff);
            return staff;
        }
    }
}
