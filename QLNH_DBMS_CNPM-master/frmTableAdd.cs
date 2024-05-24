using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using QLNH_DBMS;

namespace GUI
{
    public partial class frmTableAdd : Form
    {
        private string maBan;
        private string role;
        private TableBUS tableBus;
        public frmTableAdd(string maBan, string role)
        {
            InitializeComponent();
            this.maBan = maBan;
            txtMaBan.Text = maBan;
            tableBus = new TableBUS(role);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string trangThai = cbTrangThai.Text;
            int tienDatCoc = Int32.Parse(txtTienDatCoc.Text ?? "0");
            string maKH = txtKH.Text;
/*
            bool success = tableBus.UpdateTrangThaiBan(maBan, trangThai);
            if (success)
            {
                MessageBox.Show("Successfully");
            }
            else
                MessageBox.Show(tableBus.err);*/
        }

        private void txtTienDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
