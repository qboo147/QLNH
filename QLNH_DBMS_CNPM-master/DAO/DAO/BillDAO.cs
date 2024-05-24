using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DBConnect;
using DTO;
namespace DAO
{
    public class BillDAO
    {
        DataTable dtBill;
        SqlConnection con;
        public BillDAO(string role=null) {
           con = getConnection.GetSqlConnection();

        }
        public DataTable GetAllBill() //Lấy tất cả danh mục sản phẩm
        {
            dtBill = new DataTable();
            dtBill.Clear();
            string queryView = "SELECT * FROM V_XemTatCaHoaDon";

            //con = getConnection.GetSqlConnection();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
            con.Close();
            sda.Fill(dtBill);

            return dtBill;

        }
        public DataTable GetBillJoinDetail(int maHD) //Lấy tất cả danh mục sản phẩm
        {
            dtBill = new DataTable();
            dtBill.Clear();
            string queryView = "proc_get_single_BilljoinDetail";

            // Create a SqlCommand
            SqlCommand cmd = new SqlCommand(queryView, con);
            cmd.CommandType = CommandType.StoredProcedure; // Set command type as stored procedure

            // Add parameter to SqlCommand
            cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));

            // Open the connection and execute the command
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd); // Use the SqlCommand instead of the string
            sda.Fill(dtBill);
            con.Close();

            return dtBill;
        }
        public DataTable FindBill(int maHD)
        {
            dtBill = new DataTable();
            string func_name = "func_findBillByID";
            string queryView = $"SELECT * FROM {func_name} (@maHD)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);
            cmd.Parameters.AddWithValue("@maHD", maHD);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtBill.Clear();
            sda.Fill(dtBill);
            con.Close();
            return dtBill;

        }
        public int AddBill(BillDTO billDTO, ref string err)
        {
            string queryInsert = "proc_ThemHoaDon @MaKH, @TrangThai, @GiaTriHD, @MaNV, @MaBan, @PTTT, @Ngay, @Gio";
            // Chuyển đổi chuỗi thời gian thành TimeSpan
            //TimeSpan gioTimeSpan = TimeSpan.Parse(billDTO.Gio);
            //SqlConnection con = getConnection.GetSqlConnection();
            //string imageHex = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    //new SqlParameter("@MaHD", billDTO.MaHD),
                    new SqlParameter("@MaKH", billDTO.MaKH),
                    new SqlParameter("@TrangThai", billDTO.TrangThai),
                    new SqlParameter("@GiaTriHD", billDTO.GiatriHD),
                     new SqlParameter("@MaNV", billDTO.MaNVPV),
                     new SqlParameter("@MaBan", billDTO.MaBan),
                     new SqlParameter("@PTTT", (object)billDTO.Pttt ?? DBNull.Value),
                     new SqlParameter("@Ngay", billDTO.Ngay.ToString("yyyy-MM-dd")),
                     new SqlParameter("@Gio", billDTO.Gio)
                });
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (SqlException ex)
            {
                err = ex.Message;

            }
            finally
            {
                con.Close();
            }
            return -1;
        }
        public bool RemoveBill(int id, ref string err)
        {
            string queryDelete = "proc_xoaHoaDon @MaHD";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@MaHD", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (SqlException ex)
            {
                err = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public bool UpdateBill(BillDTO billDTO, ref string err)
        {
            string query = "proc_suaHoaDon @MaHD, @MaKH, @TrangThai, @GiaTriHD, @MaNV, @MaBan, @PTTT, @Ngay, @Gio";
            //TimeSpan gioTimeSpan = TimeSpan.Parse(billDTO.Gio);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(new[]
               {
                    new SqlParameter("@MaHD", billDTO.MaHD),
                    new SqlParameter("@MaKH", billDTO.MaKH),
                    new SqlParameter("@TrangThai", billDTO.TrangThai),
                    new SqlParameter("@GiaTriHD", billDTO.GiatriHD),
                     new SqlParameter("@MaNV", billDTO.MaNVPV),
                     new SqlParameter("@MaBan", billDTO.MaBan),
                     new SqlParameter("@PTTT", billDTO.Pttt),
                     new SqlParameter("@Ngay", billDTO.Ngay.ToString("yyyy-MM-dd")),
                     new SqlParameter("@Gio", billDTO.Gio)
                });
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                err = ex.Message;
        
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        

    }
}
