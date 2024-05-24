using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace QLNH_DBMS
{
    public partial class frmProduct : Form
    {
        ProductBUS productBus;
        DataTable dtSP ;
        string role;
        public frmProduct(string role)
        {
            InitializeComponent();
            productBus = new ProductBUS(role);
            this.role = role;
        }

        void LoadData()
        {
            try
            {
                dtSP = new DataTable();
                dtSP.Clear();
                dtSP = productBus.getAllProduct_Product();
                dgvProduct.DataSource = dtSP;
                // Thay đổi độ rộng cột
                dgvProduct.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + e.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd(role);
           /* frm.cbbCateID.DataSource = productBus.LayDanhSachDanhMuc();
            frm.cbbCateID.ValueMember = "ID";
            frm.cbbCateID.DisplayMember = "Display";*/
            frm.txtProductID.ReadOnly = false;
            frm.cbbCategory.DataSource = productBus.getAllCategory();
            frm.cbbCategory.DisplayMember = "LoaiSP";
            frm.cbbState.SelectedIndex = frm.cbbState.Items.IndexOf("Còn");
            frm.ShowDialog();
            LoadData();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtSP = new DataTable();
                dtSP.Clear();
                dtSP = productBus.FindProduct(txtSearchProduct.Text);
                // Đưa dữ liệu lên DataGridView
                dgvProduct.DataSource = dtSP;
                // Thay đổi độ rộng cột
                dgvProduct.AutoResizeColumns();
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + error);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvEdit") //Sửa sp
            {
                int row = dgvProduct.CurrentCell.RowIndex;
                frmProductAdd frm = new frmProductAdd(role);
                frm.cbbCategory.DataSource = productBus.getAllCategory();
                frm.cbbCategory.DisplayMember = "LoaiSP";
                /*frm.cbbCateID.DataSource = dbDM.LayDanhSachDanhMuc();
                frm.cbbCateID.ValueMember = "ID";
                frm.cbbCateID.DisplayMember = "Display";*/


                //int x = dgvProduct.CurrentRow.Index;
                /*frm.txtProductID.Text = dgvProduct.Rows[row].Cells["dgvMaSP"].Value.ToString();
             frm.txtProductName.Text = dgvProduct.Rows[row].Cells["dgvTenSP"].Value.ToString();
             frm.txtCategory.Text = dgvProduct.Rows[row].Cells["dgvCategory"].Value.ToString();
             frm.txtState.Text = dgvProduct.Rows[row].Cells["dgvState"].Value.ToString();
             frm.txtPrice.Text = dgvProduct.Rows[row].Cells["dgvPrice"].Value.ToString();*/
                frm.txtProductID.Text = dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString();
                frm.txtProductName.Text = dgvProduct.CurrentRow.Cells["dgvTenSP"].Value.ToString();
                //frm.cbbCategory.SelectedIndex = frm.cbbState.Items.IndexOf(dgvProduct.CurrentRow.Cells["dgvCategory"].Value.ToString());
                // frm.txtCategory.Text = dgvProduct.CurrentRow.Cells["dgvCategory"].Value.ToString();

                frm.cbbCategory.Text = dgvProduct.CurrentRow.Cells["dgvCategory"].Value.ToString();
                frm.cbbState.Text = dgvProduct.CurrentRow.Cells["dgvState"].Value.ToString();
                frm.txtPrice.Text = dgvProduct.CurrentRow.Cells["dgvPrice"].Value.ToString();
             
                frm.txtProductID.ReadOnly = true; //Chỉnh sửa
                List<byte[]> dsIMG = productBus.getProductImg(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString());
                if (dsIMG.Count > 0)
                {
                    if (!DBNull.Value.Equals(dsIMG[0]))
                    {
                        byte[] imageBytes = dsIMG[0];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            frm.txtImage.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        frm.txtImage.Image = null;
                    }
                }
                else
                {
                    frm.txtImage.Image = null;
                }
                frm.ShowDialog();

                if (txtSearchProduct.Text != "")
                {
                    dgvProduct.DataSource = productBus.FindProduct(txtSearchProduct.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá sản phẩm này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (productBus.removeProduct(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString()))
                    {
                        txtSearchProduct.Text = "";
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + productBus.err + "'");
                    }
                }
            }
        }

    }
}
