using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLNH_DBMS
{
    public partial class frmLogin : Form
    {
        LoginBUS loginBUS;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearForm()
        {
            this.txtUser.Text = string.Empty;
            this.txtPass.Text = string.Empty;
            this.txtUser.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            LoginDTO login = new LoginDTO(username, password,null);
            var result = loginBUS.CheckLogin(login);

            if (result.Item1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                string role = "";
                if (result.Item2 == "Staff")
                {
                    role = result.Item2;
                }
                // Open the main form with appropriate permissions based on the role
                frmMain mainForm = new frmMain(role);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            loginBUS = new LoginBUS(null); //Vào loginBUS admin
        }
        bool hide = true;
        private void txtPass_IconRightClick(object sender, EventArgs e)
        {
            if (hide)
            {
                txtPass.PasswordChar = default;
                hide = false;
                txtPass.IconRight = global::GUI.Properties.Resources.view;
            }
            else
            {
                txtPass.PasswordChar = '*';
                hide = true;
                txtPass.IconRight = global::GUI.Properties.Resources.hidden;
            }
        }
    }
}
