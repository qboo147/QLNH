using DAO.DBConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DTO;
using System.IO;
using System.Xml.Linq;

namespace DAO
{
     public class ProductDAO
    {
        DataTable dtProduct;
        SqlConnection con;
        public ProductDAO(string role) { 
           // dtProduct = new DataTable();
            if(role == "Staff")
            {
                con = getConnection.GetSqlConnectionStaff();
            }
            else
            {
                con = getConnection.GetSqlConnection();
            }

        }
        public DataTable GetAllCategory() //Lấy tất cả danh mục sản phẩm
        {
            //dtProduct = new DataTable();
            string queryView = "SELECT * FROM V_DanhMucSanPham";

            //con = getConnection.GetSqlConnection();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
            con.Close();
            DataTable dtcategory = new DataTable();
            sda.Fill(dtcategory);
            
            return dtcategory;

        }
        public DataTable getAllProduct_Product() //Lấy tất cả sản phẩm (KO LẤY ẢNH)
        {
            dtProduct = new DataTable();
            string queryView = "SELECT * FROM V_Pro_DanhSachSanPham";
            //SqlConnection con = getConnection.GetSqlConnection();
            //con = getConnection.GetSqlConnection();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
            
            dtProduct.Clear();
            sda.Fill(dtProduct);
            con.Close();
            return dtProduct;
        }
        public DataTable getAllProduct_POS() //L
        {
            dtProduct = new DataTable();
            string queryView = "SELECT * FROM V_POS_DanhSachSanPham";
            //SqlConnection con = getConnection.GetSqlConnection();
            //con = getConnection.GetSqlConnection();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryView, con);
           
            dtProduct.Clear();
            sda.Fill(dtProduct);
            con.Close();
            return dtProduct;
        }

        public DataTable FindProduct(string name)
        {
            dtProduct = new DataTable();
            string func_name = "func_findProductByName";
            string queryView = $"SELECT * FROM {func_name} (@name)";
            //SqlConnection con = getConnection.GetSqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@name", name);
           
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtProduct.Clear();
            sda.Fill(dtProduct);

            con.Close();
            return dtProduct;
       
            //SqlDataAdapter sda = new SqlDataAdapter(queryView, con);

        }
        public bool AddProduct(ProductDTO productDTO, ref string err)
        {
            string queryInsert = "proc_ThemSanPham @MaSP, @TenSP, @LoaiSP, @TinhTrang, @DonGia, @HinhAnh";
            //SqlConnection con = getConnection.GetSqlConnection();
            //string imageHex = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                Image tmp = productDTO.Img;
                tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageByteArray = ms.ToArray();
                //imageHex = BitConverter.ToString(imageByteArray).Replace("-", string.Empty);
                con.Open();
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@MaSP", productDTO.Id),
                    new SqlParameter("@TenSP", productDTO.Name),
                    new SqlParameter("@LoaiSP", productDTO.Category),
                    new SqlParameter("@TinhTrang", productDTO.State),
                     new SqlParameter("@DonGia", productDTO.Price),
                     new SqlParameter("@HinhAnh", imageByteArray)
                }) ;
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
        public bool RemoveProduct(string id, ref string err)
        {
            string queryDelete = "proc_xoaSanPham @MaSP";
            //SqlConnection conn = getConnection.GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@MaSP", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                
            }
            catch(SqlException ex)
            {
                err = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public bool UpdateProduct(ProductDTO productDTO, ref string err)
        {
            string query = "proc_suaSanPham  @MaSP, @TenSP, @LoaiSP, @TinhTrang, @DonGia, @HinhAnh";
            try
            {
                MemoryStream ms = new MemoryStream();
                Image tmp = productDTO.Img;
                tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageByteArray = ms.ToArray();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(new[]
               {
                    new SqlParameter("@MaSP", productDTO.Id),
                    new SqlParameter("@TenSP", productDTO.Name),
                    new SqlParameter("@LoaiSP", productDTO.Category),
                    new SqlParameter("@TinhTrang", productDTO.State),
                     new SqlParameter("@DonGia", productDTO.Price),
                     new SqlParameter("@HinhAnh", imageByteArray)
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

        public List<byte[]> GetProductImg(string MaSP)
        {
            string func_name = "func_findImgProduct";
            string queryView = $"SELECT * FROM {func_name} (@MaSP)";
            con.Open();
            SqlCommand cmd = new SqlCommand(queryView, con);

            cmd.Parameters.AddWithValue("@MaSP", MaSP);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtProduct.Clear();
            sda.Fill(dtProduct);

            con.Close();
            List<byte[]> imageList = new List<byte[]>();
            foreach (DataRow row in dtProduct.Rows)
            {
                if (row != null && row["AnhSP"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["AnhSP"];
                    imageList.Add(imageData);
                }
            }
            return imageList;
        }
    }
 
}
