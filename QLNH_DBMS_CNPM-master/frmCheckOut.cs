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
    public partial class frmCheckOut : Form
    {
        BillBUS billBUS;
        public BillDTO billDTO = null;
        List<String> listBillstate;

        public frmCheckOut()
        {
            InitializeComponent();
            listBillstate = new List<string>();
            listBillstate.Add("Chưa thanh toán");
            listBillstate.Add("Đã thanh toán");
            btnSave.Enabled = false;
            billBUS = new BillBUS();

            //billDTO = new BillDTO();
        }
        public double amt = 0;
        public double received = 0;
        public double change = 0;
        public int billID = 0;
        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            billDTO.TrangThai = listBillstate[1];
            if (billBUS.UpdateBill(billDTO))
            {
                //   guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Thanh toán hóa đơn thành công");
                this.Close();
            }
            else
            {
                guna2MessageDialog1.Show("Thanh toán không thành công " + billBUS.err);
            }
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out received);
            change = Math.Abs(amt - received);
            txtChange.Text = change.ToString();
            if(change == 0)
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
