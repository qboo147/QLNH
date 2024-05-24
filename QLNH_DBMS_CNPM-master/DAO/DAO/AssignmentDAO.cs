using DAO.DBConnect;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AssignmentDAO
    {
        DataTable dtShift;
        SqlConnection con;
        public AssignmentDAO(string role)
        {
            if (role == "Staff")
            {
                con = getConnection.GetSqlConnectionStaff();
            }
            else
            {
                con = getConnection.GetSqlConnection();
            }
        }
        public bool createAssigment(AssignmentDTO assignmentDTO, ref string err)
        {
            string queryInsert = "proc_PhanCong @MaCa, @MaNV, @NgayLam";
            SqlConnection con = getConnection.GetSqlConnection();
            try
            {
                MemoryStream ms = new MemoryStream();
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaCa", assignmentDTO.ShiftId),
                    new SqlParameter("@MaNV", assignmentDTO.EmployeeId),
                    new SqlParameter("@NgayLam", assignmentDTO.WorkingDate.ToString("yyyy-MM-dd"))
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
        public DataTable GetAllShiftAssignment() //Lấy tất cả danh mục sản phẩm
        {
          
            string queryView = "SELECT * FROM v_TatCaBangPhanCa";
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
        public bool removeShift(AssignmentDTO assignmentDTO, ref string err)
        {
            string queryDelete = "proc_xoaPhanCong @MaCa , @NgayLam";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaCa", assignmentDTO.ShiftId),
                    new SqlParameter("@NgayLam",assignmentDTO.WorkingDate.ToString("yyyy-MM-dd"))
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
        public bool updateShift(AssignmentDTO assignmentDTO, ref string err)
        {
            string queryDelete = "proc_suaPhanCong @MaNV, @HoNV , @TenNV , @MaCa , @NgayLam";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddRange(new[]
                {
                     new SqlParameter("@MaNV", assignmentDTO.EmployeeId),
                      new SqlParameter("@HoNV", assignmentDTO.HoNV),
                          new SqlParameter("@TenNV", assignmentDTO.TenNV),
                    new SqlParameter("@MaCa", assignmentDTO.ShiftId),
                    new SqlParameter("@NgayLam",assignmentDTO.WorkingDate.ToString("yyyy-MM-dd")),
                  
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
        public bool createShift(AssignmentDTO assignmentDTO, ref string err)
        {
            string queryInsert = "proc_ThemPhanCong @MaNV, @HoNV , @TenNV , @MaCa , @NgayLam";

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaNV", assignmentDTO.EmployeeId),
                      new SqlParameter("@HoNV", assignmentDTO.HoNV),
                          new SqlParameter("@TenNV", assignmentDTO.TenNV),
                    new SqlParameter("@MaCa", assignmentDTO.ShiftId),
                    new SqlParameter("@NgayLam",assignmentDTO.WorkingDate.ToString("yyyy-MM-dd")),
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
