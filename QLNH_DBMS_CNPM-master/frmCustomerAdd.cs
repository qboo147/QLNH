using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCustomerAdd : Form
    {

        CustomerBUS customerBUS;
        public CustomerDTO customerDTO { get; set; }
        public bool check_not_null_customerDTO { get;set; } //nẾU ng dùng khởi tạo frmCustomerAdd nhưng ấn vào close không customerDTO null
        public frmCustomerAdd(string role)
        {
            InitializeComponent();
            customerBUS = new CustomerBUS(role);
            customerDTO = new CustomerDTO();
            txtCustomerLoyaltyPoint.Text = "0";
        }

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() == "" || txtCustomerName.Text.Trim() == "" || txtCustomerLoyaltyPoint.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            customerDTO = new CustomerDTO(txtCustomerID.Text, txtCustomerName.Text, txtCustomerPhone.Text, int.Parse(txtCustomerLoyaltyPoint.Text));
            check_not_null_customerDTO = true;
            if (txtCustomerID.ReadOnly == true) //Sửa khách hàng
            {
           //     customerDTO = new CustomerDTO(txtCustomerID.Text, txtCustomerName.Text, txtCustomerPhone.Text,int.Parse(txtCustomerLoyaltyPoint.Text));
                if (customerBUS.updateCustomer(customerDTO))
                {
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + customerBUS.err + "'");
                }
            }
            else //thêm khách hàng
            {
               
                    if (customerBUS.addCustomer(customerDTO))
                    {
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công. Lỗi: '" + customerBUS.err + "'");

                }
            }
            
            this.DialogResult = DialogResult.OK;
            
            this.Close();
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           // them = false;
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
