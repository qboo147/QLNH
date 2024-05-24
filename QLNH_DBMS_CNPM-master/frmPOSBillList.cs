using BUS;
using DTO;
using GUI.Reports;
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
using System.Windows.Forms.VisualStyles;

namespace GUI
{
    public partial class frmPOSBillList : Form
    {
        DataTable dtBillList = null;
        BillBUS billBUS;
        public BillDTO billDTO;
        string err;
        public int MainID = 0;
        public bool bonus;
        public bool edit = false;
        public frmPOSBillList()
        {
            InitializeComponent();
            billBUS = new BillBUS();
        }


        private void dgvBillList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Khi ấn vào Edit có thể là sửa lại đơn hàng hoặc thanh toán
                if (dgvBillList.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    //Cap nhat gia tri cho bool Them ben formPos
                    edit = true;
                    bonus = false;
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaHD"].Value);
                    billDTO = new BillDTO(
                        Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaHD"].Value),
                        dgvBillList.CurrentRow.Cells["dgvMaKH"].Value.ToString(),
                        dgvBillList.CurrentRow.Cells["dgvTrangThai"].Value.ToString(),
                        Convert.ToDouble(dgvBillList.CurrentRow.Cells["dgvGiaTriHD"].Value),
                        dgvBillList.CurrentRow.Cells["dgvMaNV"].Value.ToString(),
                        dgvBillList.CurrentRow.Cells["dgvMaBan"].Value.ToString(),
                        dgvBillList.CurrentRow.Cells["dgvPTTT"].Value.ToString(),
                        Convert.ToDateTime(dgvBillList.CurrentRow.Cells["dgvNgay"].Value),
                        dgvBillList.CurrentRow.Cells["dgvGio"].Value.ToString()
                        );
                   // OrderType = dgvBillList.CurrentRow.Cells["dgvOrderType"].Value.ToString();
                    this.Close();
                    // Cập nhật MainID và thót khỏi form BillList, trở lại formPos và hiển thị đơn lên lại dgvPOS để edit
                }
                if (dgvBillList.CurrentCell.OwningColumn.Name == "dgvPrint")
                {
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaHD"].Value);
                    //In hoa don de sau nha
/*                    edit = false;
                    try
                    {
                        dtBillPrint = new DataTable();
                        dtBillPrint.Clear();
                        dtBillPrint = dbTblMain.GetJoin(MainID).Tables[0];
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("Không in được bill này. Lỗi: " + err);
                    }

                    frmPrint frm = new frmPrint();
                    rptBill cr = new rptBill();
                    cr.SetDataSource(dtBillPrint);
                    frm.crystalReportViewer1.ReportSource = cr;
                    frm.crystalReportViewer1.Refresh();
                    frm.Show();*/

                }
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không sửa được. Lỗi: " + error.Message);
            }
        }
        private void LoadData()
        {
            try
            {
                // dgvBillList.Columns.Clear();
                dtBillList = new DataTable();
                dtBillList.Clear();
                dtBillList = billBUS.GetAllBill();
                dgvBillList.DataSource = dtBillList;
                dgvBillList.AutoResizeColumns();
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không lấy được nội dung trong table tblMain. Lỗi: " + error.Message);
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOSBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
