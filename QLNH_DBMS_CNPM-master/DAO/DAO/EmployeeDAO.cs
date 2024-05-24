using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO.DBConnect;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DAO
{
    public class EmployeeDAO
    {
         SqlConnection con;

        public EmployeeDAO(string role)
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

        public DataTable getAllEmployee()
        {
            string cmd = "SELECT * FROM V_LoadNhanVien";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
            con.Close();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                Console.WriteLine("Không đọc được thông tin");
            }
            return dt;
        }
        public DataTable getAllWaiter()
        {
            string query = "SELECT * FROM V_PhucVu";
       
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            con.Close();
            DataTable dtcategory = new DataTable();
            sda.Fill(dtcategory);

            return dtcategory;
        }
        public DataTable getAllPartTime()
        {
            string query = "SELECT * FROM V_NVBanThoiGian";

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
           
            DataTable dtTemp = new DataTable();
            dtTemp.Clear();
            sda.Fill(dtTemp);
            
            con.Close();
            DataTable dtEmp = new DataTable();
            dtEmp.Clear();
            dtEmp.Columns.Add("ID");
            dtEmp.Columns.Add("Display");
            foreach (DataRow row in dtTemp.Rows)
            {
                object[] ID = { row["MaNV"].ToString(), row["HoNV"].ToString() , row["TenNV"].ToString() };
                string Display = row["MaNV"].ToString() + "-" + row["HoNV"].ToString() + "-" + row["TenNV"].ToString();
                dtEmp.Rows.Add(ID, Display);
            }
            return dtEmp;
        }
        public DataTable getAllManager()
        {
            string query = "SELECT * FROM V_NV_QLY";

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtTemp = new DataTable();
            dtTemp.Clear();
            sda.Fill(dtTemp);

            con.Close();
            DataTable dtEmp = new DataTable();
            dtEmp.Clear();
            dtEmp.Columns.Add("ID");
            dtEmp.Columns.Add("Display");
            foreach (DataRow row in dtTemp.Rows)
            {
                object[] ID = { row["MaNV"].ToString(), row["HoNV"].ToString(), row["TenNV"].ToString() };
                string Display = row["MaNV"].ToString() + "-" + row["HoNV"].ToString() + "-" + row["TenNV"].ToString();
                dtEmp.Rows.Add(ID, Display);
            }
            return dtEmp;
        }

        public DataTable searchEmployee(EmployeeDTO employee, string type)
        {
            string cmd;

            if(type == "Mã NV")
            {
                cmd = "EXEC proc_SearchByMaNV " + employee.MaNV;
            }
            else if(type == "SĐT")
            {
                cmd = "EXEC proc_SearchBySDT " + employee.SDT;
            }
            else if(type == "Tên CV")
            {
                cmd = "EXEC proc_SearchByTenCV " + employee.MaCV;
            }
            else
            {
                cmd = "EXEC proc_SearchByTenNV " + employee.TenNV;
            }
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd,con);
            con.Close();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable CalWageEmployee()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM func_TinhLuongNV(@thang, @nam)", con);
            cmd.Parameters.AddWithValue("@thang", int.Parse(DateTime.Today.ToString("MM")));
            cmd.Parameters.AddWithValue("@nam", int.Parse(DateTime.Today.ToString("yyyy")));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();
            return dt;
        }

        public bool Add_Employee(EmployeeDTO employee, ref string err)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC proc_AddEmployee @manv, @honv, @tennv, @ngaysinh, " +
                    "@sdt, @macv, @soca, @thuong, @ngaytd, @htcongviec", con);

                cmd.Parameters.Add("@manv", SqlDbType.NVarChar, 10).Value = employee.MaNV;
                cmd.Parameters.Add("@honv", SqlDbType.NVarChar, 10).Value = employee.HoNV;
                cmd.Parameters.Add("@tennv", SqlDbType.NVarChar, 10).Value = employee.TenNV;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = employee.NgaySinh;
                cmd.Parameters.Add("@sdt", SqlDbType.NChar, 11).Value = employee.SDT;
                cmd.Parameters.Add("@macv", SqlDbType.NVarChar, 20).Value = employee.MaCV;
                cmd.Parameters.Add("@soca", SqlDbType.Int).Value = employee.Soca;
                cmd.Parameters.Add("@thuong", SqlDbType.Int).Value = employee.Thuong;
                cmd.Parameters.Add("@ngaytd", SqlDbType.Date).Value = employee.NgayTuyenDung;
                cmd.Parameters.Add("@htcongviec", SqlDbType.NVarChar, 20).Value = employee.HTcongviec;
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(SqlException e)
                {
                    err = e.Message;
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Edit_Employee(EmployeeDTO employee, ref string err)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC proc_EditEmployee @manv, @honv, @tennv, @ngaysinh, " +
                    "@sdt, @macv, @soca, @thuong, @ngaytd, @htcongviec", con);

                cmd.Parameters.Add("@manv", SqlDbType.NVarChar, 10).Value = employee.MaNV;
                cmd.Parameters.Add("@honv", SqlDbType.NVarChar, 10).Value = employee.HoNV;
                cmd.Parameters.Add("@tennv", SqlDbType.NVarChar, 10).Value = employee.TenNV;
                cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = employee.NgaySinh;
                cmd.Parameters.Add("@sdt", SqlDbType.NChar, 11).Value = employee.SDT;
                cmd.Parameters.Add("@macv", SqlDbType.NVarChar, 20).Value = employee.MaCV;
                cmd.Parameters.Add("@soca", SqlDbType.Int).Value = employee.Soca;
                cmd.Parameters.Add("@thuong", SqlDbType.Int).Value = employee.Thuong;
                cmd.Parameters.Add("@ngaytd", SqlDbType.Date).Value = employee.NgayTuyenDung;
                cmd.Parameters.Add("@htcongviec", SqlDbType.NVarChar, 20).Value = employee.HTcongviec;
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch(SqlException e)
                {
                    err = e.Message;
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete_Employee(EmployeeDTO employee, ref string err)
        {
            SqlCommand cmd = new SqlCommand("EXEC proc_DeleteEmployee @MaNV", con);
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 10).Value = employee.MaNV;

            con.Open();
            if(cmd.ExecuteNonQuery() == -1)
            {
                con.Close();
                return true;
            }
            else
            {
                
                con.Close();
                return false;
            }
        }
        public bool Delete_Employee(string id, ref string err)
        {
            string queryDelete = "proc_DeleteEmployee @MaNV";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@MaNV", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (SqlException ex)
            {
                err = ex.Message;
                Console.WriteLine("A");
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}
