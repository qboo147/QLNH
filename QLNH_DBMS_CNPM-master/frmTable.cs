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
using BUS;
using DTO;
using GUI.Select;
namespace GUI
{
    public partial class frmTable : Form
    {
        TableBUS tableBus;
        DataTable dtTable = null;
        CustomerDTO customerDTO = null;
        string role;
        bool book = false;
        public frmTable(string role)
        {
            InitializeComponent();
            tableBus = new TableBUS(role);
            this.role = role;
            /*dgvTable.Columns["dgvTienDatCoc"].ValueType = typeof(int);
            dgvTable.Columns["dgvMaKH"].ValueType = typeof(string);
            dgvTable.Columns["dgvTienDatCoc"].DefaultCellStyle.NullValue = DBNull.Value;
            dgvTable.Columns["dgvMaKH"].DefaultCellStyle.NullValue = DBNull.Value;*/
        }

        public void LoadData()
        {
            try
            {
                dtTable = new DataTable();
                dtTable.Clear();
                dtTable = tableBus.GetAllTables();
                dgvTable.DataSource = dtTable;
                // Thay đổi độ rộng cột
                dgvTable.AutoResizeColumns();

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + e.Message);
            }
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /*string selectedMaBan = dgvTable.CurrentRow.Cells[0].Value.ToString();
            if (string.IsNullOrWhiteSpace(selectedMaBan))
            {
                MessageBox.Show("Bàn không hợp lệ");
            }
            else
            {
                frmTableAdd frmTableAdd = new frmTableAdd(selectedMaBan);
              //  frmTableAdd.cbTrangThai.SelectedIndex = frmTableAdd.cbTrangThai.Items.IndexOf()
                frmTableAdd.ShowDialog();
            }*/
            frmCustomer frmCus = new frmCustomer(role);
            frmCus.ShowDialog();
            customerDTO = frmCus.customerDTO;
            frmTableSelect frmTableSelect = new frmTableSelect(role);
            book = true;
            frmTableSelect.startbook =book; //Đặt bàn
            frmTableSelect.txtMaKH.Text = customerDTO.Id;
            frmTableSelect.ShowDialog();

        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTable.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmTableInsert frm = new frmTableInsert(role);
                frm.txtTableID.ReadOnly = true;
                /*List<string> listTstate = new List<string>();
                listTstate.Add("Còn trống");
                listTstate.Add("Đã đặt");
                listTstate.Add("Đang dùng");
                frm.cbbTstate.DataSource = listTstate;*/
                frm.txtTableID.Text = dgvTable.CurrentRow.Cells["dgvMaBan"].Value.ToString();
                frm.txtTienDatCoc.Text = dgvTable.CurrentRow.Cells["dgvTienDatCoc"].Value.ToString();
                frm.cbbTstate.Text = dgvTable.CurrentRow.Cells["dgvTrangThai"].Value.ToString();
                frm.txtKH.Text = dgvTable.CurrentRow.Cells["dgvMaKH"].Value.ToString();
                frm.ShowDialog();
                if (txtSearchTable.Text != "")
                {
                    dgvTable.DataSource = tableBus.FindTableByID(txtSearchTable.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvTable.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (tableBus.DeleteTableByID(dgvTable.CurrentRow.Cells["dgvTid"].Value.ToString()))
                    {

                        txtSearchTable.Text = "";
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + tableBus.err + "'");
                    }
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTableInsert frm = new frmTableInsert(role);
            frm.txtTableID.ReadOnly = false;
            //frm.txtTableName.ReadOnly = false;
           /* List<string> listTstate = new List<string>();
            listTstate.Add("Bàn trống");
            listTstate.Add("Đã đặt");
            frm.cbbTstate.DataSource = listTstate;*/
            frm.ShowDialog();
            LoadData();
        }
    }
}
