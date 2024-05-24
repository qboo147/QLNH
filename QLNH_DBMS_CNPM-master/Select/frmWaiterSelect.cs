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

namespace GUI.Select
{
    public partial class frmWaiterSelect : Form
    {
        DataTable dtNV = null;
        EmployeeBUS employeeBUS;
        public string WaiterName;
        public string WaiterID;
        string role;
        public frmWaiterSelect(string role)
        {
            InitializeComponent();
            employeeBUS = new EmployeeBUS(role);
        }

        private void frmWaiterSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                dtNV = employeeBUS.getAllWaiter();
                foreach (DataRow row in dtNV.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    WaiterName = row["TenNV"].ToString();
                    b.Text = row["TenNV"].ToString();
                    b.Tag = row["MaNV"].ToString();
                    b.Width = 150;
                    b.Height = 50;
                    b.FillColor = Color.FromArgb(241, 85, 126);
                    b.HoverState.FillColor = Color.FromArgb(50, 55, 89);
                    b.Click += new EventHandler(b_Click);
                    b.Visible = true;
                    flowLayoutPanel1.Controls.Add(b);
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được Waiter . Lỗi rồi!!!" + ex.Message);
            }
        }
        private void b_Click(object sender, EventArgs e)
        {
            WaiterName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            WaiterID = (sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
