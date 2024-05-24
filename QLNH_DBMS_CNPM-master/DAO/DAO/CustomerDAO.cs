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
    public class CustomerDAO
    {
        DataTable dtCustomer;
        SqlConnection con;

        public CustomerDAO(string role)
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

        public DataTable getAllCustomer()
        {
            string queryView = "SELECT * FROM V_KhachHang";
            dtCustomer = new DataTable();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);

            dtCustomer.Clear();
            sda.Fill(dtCustomer);
            con.Close();
            return dtCustomer;
        }
        public bool UpdateCustomer(CustomerDTO customerDTO, ref string err) {
            string query = "proc_SuaKH  @MaKH, @TenKH, @SDT, @DiemThuong";
            try
            {
               
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(new[]
               {
                    new SqlParameter("@MaKH", customerDTO.Id),
                    new SqlParameter("@TenKH", customerDTO.Name),
                    new SqlParameter("@SDT", customerDTO.Phone),
                    new SqlParameter("@DiemThuong",customerDTO.Loyalreward),
              
                   
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
        public bool AddCustomer(CustomerDTO customerDTO, ref string err)
        {
            string query = "proc_ThemKH @MaKH, @TenKH, @SDT , @DiemThuong";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(new[]
               {
                    new SqlParameter("@MaKH", customerDTO.Id),
                    new SqlParameter("@TenKH", customerDTO.Name),
                    new SqlParameter("@SDT", customerDTO.Phone),
                    new SqlParameter("@DiemThuong",customerDTO.Loyalreward),


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
        public bool RemoveCustomer(string id, ref string err)
        {
            string query = "proc_XoaKH @MaKH";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaKH", id);
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
        public DataTable FindCustomerByPhone(string phone)
        {
            dtCustomer = new DataTable();
            string func_name = "func_findCustomerByPhone";
            string queryView = $"SELECT * FROM {func_name} (@phone)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@phone", phone);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtCustomer.Clear();
            sda.Fill(dtCustomer);
            con.Close();

            return dtCustomer;
            
            //SqlDataAdapter sda = new SqlDataAdapter(queryView, con);

        }
        public DataTable FindCustomerByID(string ID)
        {
            dtCustomer = new DataTable();
            string func_name = "func_findCustomerByID";
            string queryView = $"SELECT * FROM {func_name} (@ID)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@ID", ID);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtCustomer.Clear();
            sda.Fill(dtCustomer);
            con.Close();

            return dtCustomer;

            //SqlDataAdapter sda = new SqlDataAdapter(queryView, con);

        }
    }
}
