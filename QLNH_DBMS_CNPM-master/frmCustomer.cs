using BUS;
using DTO;
using QLNH_DBMS;
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

namespace GUI
{
    public partial class frmCustomer : Form
    {
        CustomerBUS customerBUS;
        DataTable dtCustomer;
        public CustomerDTO customerDTO;
        bool check_notnull_action;
        string role;
        public frmCustomer(string role)
        {
            InitializeComponent();
            customerBUS = new CustomerBUS(role);
            customerDTO = new CustomerDTO();
            cbbFindType.SelectedIndex = cbbFindType.Items.IndexOf("SĐT");
            this.role = role;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dtCustomer = new DataTable();
                dtCustomer.Clear();
                dtCustomer = customerBUS.getAllCustomer();
                dgvCustomer.DataSource = dtCustomer;

                // Thay đổi độ rộng cột
                dgvCustomer.AutoResizeColumns();

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmCustomerAdd frm = new frmCustomerAdd(role))
            {
                frm.txtCustomerID.ReadOnly = false;
                frm.txtCustomerLoyaltyPoint.Text = "0";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    customerDTO = frm.customerDTO;
                    check_notnull_action = frm.check_not_null_customerDTO;
                }

            }
                /* cần đảm bảo rằng biến customerDTO là một thuộc tính public hoặc có phương thức getter public trong form frmCustomerAdd. 
                 Khi frmCustomerAdd đóng lại sau khi gọi ShowDialog(), bạn có thể truy cập customerDTO từ đối tượng frm miễn là form không bị Dispose. */

                LoadData();
            if (check_notnull_action == true)
            {
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    // Giả sử "dgvMaKH" là tên của cột trong DataGridView và bạn muốn so sánh nó với ID của customer
                    if (row.Cells["dgvMaKH"].Value.ToString() == customerDTO.Id.ToString())
                    {
                        // Set the current cell to the cell in the first column of the row you found
                        dgvCustomer.CurrentCell = row.Cells[0];

                        // Select the row
                        row.Selected = true;

                        // Optionally, scroll to the selected row if it is not visible
                        dgvCustomer.FirstDisplayedScrollingRowIndex = row.Index;

                        break; // Thoát vòng lặp sau khi đã tìm thấy hàng phù hợp
                    }
                }
            }

        }
        

 

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                int row = dgvCustomer.CurrentCell.RowIndex;
                frmCustomerAdd frm = new frmCustomerAdd(role);
                frm.txtCustomerID.Text = dgvCustomer.CurrentRow.Cells["dgvMaKH"].Value.ToString();
                frm.txtCustomerName.Text = dgvCustomer.CurrentRow.Cells["dgvTenKH"].Value.ToString();
                frm.txtCustomerPhone.Text = dgvCustomer.CurrentRow.Cells["dgvSDT"].Value.ToString();
                frm.txtCustomerLoyaltyPoint.Text = dgvCustomer.CurrentRow.Cells["dgvDiem"].Value.ToString();

                frm.txtCustomerID.ReadOnly = true; //Chỉnh sửa

                frm.ShowDialog();

                if (txtSearchCustomer.Text != "")
                {
                    if(cbbFindType.Text == "SĐT")
                        dgvCustomer.DataSource = customerBUS.FindCustomerByPhone(txtSearchCustomer.Text);
                    else
                        dgvCustomer.DataSource = customerBUS.FindCustomerByID(txtSearchCustomer.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvCustomer.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá khách hàng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (customerBUS.removeCustomer(dgvCustomer.CurrentRow.Cells["dgvMaKH"].Value.ToString()))
                    {
                        txtSearchCustomer.Text = "";
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + customerBUS.err + "'");
                    }
                }
            }
            else if(dgvCustomer.CurrentCell.OwningColumn.Name == "dgvChooseCustomer")
            {
                DialogResult result = MessageBox.Show("Chọn khách hàng này?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    customerDTO = new CustomerDTO(
                         dgvCustomer.CurrentRow.Cells["dgvMaKH"].Value.ToString(),
                         dgvCustomer.CurrentRow.Cells["dgvTenKH"].Value.ToString(),
                         dgvCustomer.CurrentRow.Cells["dgvSDT"].Value.ToString(),
                         int.Parse(dgvCustomer.CurrentRow.Cells["dgvDiem"].Value.ToString()));
                    this.Close();
                }
                //LẤY RA customerDTO truyền vào  form POS
            }
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if(cbbFindType.SelectedIndex == cbbFindType.Items.IndexOf("SĐT"))
            {
                try
                {
 
                    dtCustomer = new DataTable();
                    dtCustomer.Clear();
                    
                    dtCustomer = customerBUS.FindCustomerByPhone(txtSearchCustomer.Text);
                    // Đưa dữ liệu lên DataGridView
                    dgvCustomer.DataSource = dtCustomer;
                    // Thay đổi độ rộng cột
                    dgvCustomer.AutoResizeColumns();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Không lấy được nội dung khách hàng. Lỗi: " + error.Message);
                }
            }
            else
            {
                try
                {
                    dtCustomer = new DataTable();
                    dtCustomer.Clear();

                    dtCustomer = customerBUS.FindCustomerByID(txtSearchCustomer.Text);
                    // Đưa dữ liệu lên DataGridView
                    dgvCustomer.DataSource = dtCustomer;
                    // Thay đổi độ rộng cột
                    dgvCustomer.AutoResizeColumns();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Không lấy được nội dung khách hàng Lỗi: " + error.Message);
                }
            }
        }
    }
}
