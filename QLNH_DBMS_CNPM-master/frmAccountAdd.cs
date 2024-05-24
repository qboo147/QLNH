using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAccountAdd : Form
    {
        LoginBUS loginBUS;
        EmployeeBUS employeeBUS;
        LoginDTO loginDTO;
        public frmAccountAdd(string role)
        {
            InitializeComponent();
            loginBUS = new LoginBUS(role);
            employeeBUS = new EmployeeBUS(role);

            // cbbTenNV.DataSource = employeeBUS.getAllManager();
            /*cbbTenNV.DataSource = employeeBUS.getAllPartTime();
            cbbTenNV.ValueMember = "ID";
            cbbTenNV.DisplayMember = "Display";*/
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Trim() == "" || txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }

            string displayValue = cbbTenNV.Text;
            string[] splitValues = displayValue.Split('-');
            string manv = splitValues[0];
            string honv = splitValues[1];
            string tennv = splitValues[2];
            if (txtTenTK.ReadOnly == true) //Sửa tk
            {
                loginDTO = new LoginDTO(txtTenTK.Text, txtMK.Text, manv);
                if (loginBUS.UpdateAccount(loginDTO))
                {
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + loginBUS.err + "'");
                    Console.WriteLine("A");


                }
            }
            else //tHÊM TK
            {

                loginDTO = new LoginDTO(txtTenTK.Text, txtMK.Text, manv);
                if (loginBUS.AddAccount(loginDTO))
                {
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công. Lỗi: '" + loginBUS.err + "'");
                }

            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
