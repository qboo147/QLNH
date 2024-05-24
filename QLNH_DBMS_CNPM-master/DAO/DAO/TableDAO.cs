using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAO.DBConnect;
using DTO;

namespace DAO
{
    public class TableDAO
    {
        DataTable dtTable;
        SqlConnection con;
        public TableDAO(string role) {
            if (role == "Staff")
            {
                con = getConnection.GetSqlConnectionStaff();
            }
            else
            {
                con = getConnection.GetSqlConnection();
            }
        }
        public DataTable GetAllTables()
        {
            dtTable = new DataTable();
            dtTable.Clear();
            string query = "SELECT * FROM  V_BAN";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            con.Close();
            sda.Fill(dtTable);
            return dtTable;
        }
        /*public bool UpdateTrangThaiBan(string maBan, string trangThai, ref string err)
        {
            string queryInsert = "proc_UpdateTrangThaiBan @MaBan, @TrangThai";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaBan", maBan),
                    new SqlParameter("@TrangThai", trangThai),
                });
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw(ex);
            }
            finally
            {
                con.Close();
            }
            return false;
        }*/
        public bool UpdateTrangThaiBan(TableDTO tableDTO, ref string err)
        {
            string queryInsert = "proc_UpdateTrangThaiBan @MaBan, @TrangThai,@TienDatCoc,@MaKH";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaBan", tableDTO.Id),
                    new SqlParameter("@TrangThai", tableDTO.Status),
                    new SqlParameter("@TienDatCoc", (object)tableDTO.Deposit ?? DBNull.Value),
                    new SqlParameter("@MaKH", (object)tableDTO.CustomerId ?? DBNull.Value)
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
        public void UpdateTrangThaiBan(string maBan, string trangThai, string tienDatCoc, string maKH)
        {
            string queryInsert = "proc_UpdateTrangThaiBan @MaBan @TrangThai";
            SqlConnection con = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaSP", maBan),
                    new SqlParameter("@TenSP", trangThai),
                });
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddTable(TableDTO tableDTO, ref string err)
        {
            string queryInsert = "proc_ThemBan @MaBan, @TrangThai, @TienDatCoc,@MaKH";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaBan", tableDTO.Id),
                    new SqlParameter("@TrangThai", tableDTO.Status),
                    new SqlParameter("@TienDatCoc", (object)tableDTO.Deposit ?? DBNull.Value),
                    new SqlParameter("@MaKH", (object)tableDTO.CustomerId ?? DBNull.Value)
                });
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                err = ex.Message;
               // throw (ex);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public DataTable FindTableByID(string id)
        {

            dtTable = new DataTable();
            string func_name = "func_findTableByID";
            string queryView = $"SELECT * FROM {func_name} (@string)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@string", id);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtTable.Clear();
            sda.Fill(dtTable);

            con.Close();
            return dtTable;
        }
        public bool RemoveTable(string id, ref string err)
        {

            string queryDelete = "proc_xoaBan @MaBan";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@MaBan", id);
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
        public DataTable FindReservedTableByCusID(string state, string cusID)
        {
            dtTable = new DataTable();
            string func_name = "find_TableReservedByCus";
            string queryView = $"SELECT * FROM {func_name} (@TrangThai, @MaKH)";

            using (SqlConnection con = getConnection.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryView, con);
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = state;
                cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = cusID;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtTable);
            }
            return dtTable;
        }
    }
}
