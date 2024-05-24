using DAO.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class JobDAO
    {
        DataTable dtJob;
        SqlConnection con;  
        public JobDAO(string role = null)
        {
            con = getConnection.GetSqlConnection();
        }
        public DataTable MaTenCongViec()
        {
            string query = "SELECT * FROM V_MaTenCV";
            DataTable dtTemp = new DataTable();
            dtTemp.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.Fill(dtTemp);
            con.Close();
            dtJob = new DataTable();
            dtJob.Clear();
            dtJob.Columns.Add("ID");
            dtJob.Columns.Add("Display");
            foreach(DataRow row in dtTemp.Rows)
            {
                object[] ID = { row["MaCV"].ToString(), row["TenCV"].ToString() };
                string Display = row["MaCV"].ToString() + "-" + row["TenCV"].ToString();
                dtJob.Rows.Add(ID, Display);
            }
            return dtJob;
            
        }

    }
}
