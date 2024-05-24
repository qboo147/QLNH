using DAO.DBConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DAO
{
    public class LoginDAO
    {
        SqlConnection con;
        DataTable dt;
        string role;
        public LoginDAO(string role)
        {
            this.role = role;
            if (role == "Staff")
            {
                con = getConnection.GetSqlConnectionStaff();
            }
            else
            {
                con = getConnection.GetSqlConnection();
            }
        }
        public Tuple<bool, string> Check_login(LoginDTO loginDTO)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.proc_CheckLogin", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", loginDTO.Username);
                cmd.Parameters.AddWithValue("@password", loginDTO.Password);

                SqlParameter outputParamResult = new SqlParameter("@result", SqlDbType.Bit);
                outputParamResult.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParamResult);

                SqlParameter outputParamRole = new SqlParameter("@role", SqlDbType.NVarChar, 50);
                outputParamRole.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParamRole);

                cmd.ExecuteNonQuery();

                bool result = (bool)outputParamResult.Value;
                string role = outputParamRole.Value.ToString();
                con.Close();

                return Tuple.Create(result, role);

            }
        }
        public DataTable LayTaiKhoan()
        {
            con = getConnection.GetSqlConnection();

            dt = new DataTable();
                dt.Clear();
                string query = "SELECT * FROM  V_LayTaiKhoan";
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                con.Close();
                sda.Fill(dt);
                return dt;
                
        }
       public DataTable FindAccountByEmployeeID(string manv)
        {
           dt= new DataTable();
            dt.Clear();
            string func_name = "func_TimTKTheoMaNV";
            string queryView = $"SELECT * FROM {func_name} (@MaNV)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@MaNV", manv);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();

            return dt;

            //SqlDataAdapter sda = new SqlDataAdapter(queryView, con);

        }
        public bool UpdateAccount(LoginDTO loginDTO, ref string err)
        {
            string queryUpdate = "proc_SuaTaiKhoan @Username, @Password,@MaNV";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryUpdate, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@Username", loginDTO.Username),
                    new SqlParameter("@Password", loginDTO.Password),
                    new SqlParameter("@MaNV", loginDTO.Manv)
                });
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                //  throw (ex);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public bool AddAccount(LoginDTO loginDTO, ref string err)
        {
            string queryInsert = "proc_ThemTaiKhoan @Username, @Password,@MaNV";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@Username", loginDTO.Username),
                    new SqlParameter("@Password", loginDTO.Password),
                    new SqlParameter("@MaNV", loginDTO.Manv)
                
                });
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                err = ex.Message;
                //  throw (ex);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public bool DeleteAccount(string manv, ref string err)
        {
            string query = "proc_DeleteAccount @MaNV";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaNV", manv);
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
