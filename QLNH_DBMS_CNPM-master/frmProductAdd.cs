using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace QLNH_DBMS
{
    public partial class frmProductAdd : Form
    {
     
        ProductBUS productbus;
        ProductDTO productDTO;
        List<String> listProstate;

        public frmProductAdd(string role)
        {
            InitializeComponent();
            productbus = new ProductBUS(role);
            productDTO = new ProductDTO();
            listProstate = new List<String>();
            listProstate.Add("Còn");
            listProstate.Add("Hết");
            cbbState.DataSource = listProstate;
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "" || cbbCategory.Text.Trim() == "" || txtPrice.Text.Trim() == "" || txtImage.Image == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtProductID.ReadOnly == true) //Chỉnh sửa món 
            {

                
                    /*string displayValue = cbbCateID.Text;
                    string[] splitValues = displayValue.Split('-');
                    string madm = splitValues[0];
                    string tendm = splitValues[1];*/
                    productDTO = new ProductDTO(txtProductID.Text, txtProductName.Text, cbbCategory.Text, cbbState.Text, float.Parse(txtPrice.Text), txtImage.Image);
                    if (productbus.updateProduct(productDTO))
                    {
                        MessageBox.Show("Đã sửa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công. Lỗi: '" + productbus.err + "'");
                    }
                
                
            }

            else //Thêm món
            {
                
                    productDTO = new ProductDTO(txtProductID.Text, txtProductName.Text, cbbCategory.Text, cbbState.Text, float.Parse(txtPrice.Text), txtImage.Image);
                    if (productbus.addProduct(productDTO))
                    {
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công. Lỗi: '" + productbus.err);
                    }
                
                
            }
            this.Close();

        }

        string filepath;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png) | * .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtImage.Image = new Bitmap(filepath);
            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtImage_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
