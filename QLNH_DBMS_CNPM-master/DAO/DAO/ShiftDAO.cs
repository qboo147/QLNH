using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DBConnect;
using DTO;
using System.IO;
using System.Drawing;

namespace DAO
{
    public class ShiftDAO
    {
        DataTable dtShift;
        SqlConnection con;
        
        public ShiftDAO(string role) {
            if (role == "Staff")
            {
                con = getConnection.GetSqlConnectionStaff();
            }
            else
            {
                con = getConnection.GetSqlConnection();
            }
        }
        public DataTable GetShiftsByDate(string dateTime)
        {
            DataTable dtTable = new DataTable();

            string query = $"proc_GetCaLamViecByDate @NgayLam = '{dateTime}'";
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dtTable);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                con.Close();
            }
            return dtTable;    
        }
        public DataTable GetAllShift() //Lấy tất cả danh mục sản phẩm
        {
            /*string queryView = "SELECT * FROM V_caLamViec";
            dtShift = new DataTable();
            dtShift.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
            con.Close();
            sda.Fill(dtShift);
            return dtShift;*/


            string queryView = "SELECT * FROM V_caLamViec";
            dtShift = new DataTable();

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection con = getConnection.GetSqlConnection())
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
                sda.Fill(dtShift);
                con.Close();
            }

            // Thêm cột "NgayTrongTuan" vào DataTable
            dtShift.Columns.Add("NgayTrongTuan", typeof(string));

            // Tính toán giá trị cho cột "NgayTrongTuan" cho từng hàng
            foreach (DataRow row in dtShift.Rows)
            {
                // Lấy giá trị của cột "NgayLam"
                DateTime ngayLam = (DateTime)row["NgayLam"];

                // Sử dụng phương thức ToString("dddd") để lấy ngày trong tuần
                string ngayTrongTuan = ngayLam.ToString("dddd");
                // Gán giá trị cho cột "NgayTrongTuan"
                row["NgayTrongTuan"] = ngayTrongTuan;
            }
            return dtShift;

        }
        public bool removeShift(ShiftDTO shiftDTO, ref string err)
        {
            string queryDelete = "proc_xoaCaLam @MaCa , @NgayLam";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaCa", shiftDTO.Id),
                    new SqlParameter("@NgayLam",shiftDTO.WorkingDate.ToString("yyyy-MM-dd"))
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
        public bool updateShift(ShiftDTO shiftDTO, ref string err)
        {
            string queryDelete = "proc_suaCaLam @MaCa , @NgayLam, @GioBatDau , @GioKetThuc";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaCa", shiftDTO.Id),
                    new SqlParameter("@NgayLam",shiftDTO.WorkingDate.ToString("yyyy-MM-dd")),
                     new SqlParameter("@BatDau", shiftDTO.StartTime),
                    new SqlParameter("@KetThuc", shiftDTO.EndTime)
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
        public bool createShift(ShiftDTO shiftDTO, ref string err)
        {
            string queryInsert = "proc_ThemCaLam @MaCa, @NgayLam, @GioBatDau , @GioKetThuc";
         
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaCa", shiftDTO.Id),
                    new SqlParameter("@NgayLam", shiftDTO.WorkingDate.ToString("yyyy-MM-dd")),
                    new SqlParameter("@GioBatDau", shiftDTO.StartTime),
                    new SqlParameter("@GioKetThuc", shiftDTO.EndTime)
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
