using DAO.DBConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class BillDetailDAO
    {
        DataTable dtBill;
        SqlConnection con;
        public BillDetailDAO(string role = null)
        {
            con = getConnection.GetSqlConnection();
        }
        public bool AddBillDetail(BillDetailDTO billdetailDTO, ref string err)
        {
            string queryInsert = "proc_ThemChiTietHoaDon @MaHD, @MaSP,@TenSP, @SoLuong, @DonGia, @TongGT";
            // Chuyển đổi chuỗi thời gian thành TimeSpan
            //SqlConnection con = getConnection.GetSqlConnection();
            //string imageHex = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    //new SqlParameter("@MaHD", billDTO.MaHD),
                    new SqlParameter("@MaHD", billdetailDTO.MaHD),
                    new SqlParameter("@MaSP", billdetailDTO.MaSP),
                    new SqlParameter("@TenSP", billdetailDTO.TenSP),
                     new SqlParameter("@SoLuong", billdetailDTO.SoLuong),
                     new SqlParameter("@DonGia", billdetailDTO.DonGia),
                     new SqlParameter("@TongGT", billdetailDTO.TongGT)
                 
                });
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
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
            return false;
        }
        public bool UpdateBillDetail(BillDetailDTO billdetailDTO, ref string err)
        {
            string query = "proc_suaHoaDon   @MaHD, @MaSP,@TenSP,@MaChiTietHD, @SoLuong, @DonGia, @TongGT";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(new[]
               {
                   new SqlParameter("@MaHD", billdetailDTO.MaHD),
                    new SqlParameter("@MaSP", billdetailDTO.MaSP),
                    new SqlParameter("@TenSP", billdetailDTO.TenSP),
                      new SqlParameter("@MaChiTietHD", billdetailDTO.MaChiTietHD),
                     new SqlParameter("@SoLuong", billdetailDTO.SoLuong),
                     new SqlParameter("@DonGia", billdetailDTO.DonGia),
                     new SqlParameter("@TongGT", billdetailDTO.TongGT)
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
