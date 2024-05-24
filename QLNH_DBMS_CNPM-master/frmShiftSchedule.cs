using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmShiftSchedule : Form
    {
        AssignmentBUS assignmentBUS;
        DataTable dtTable = null;
        AssignmentDTO assignmentDTO;
        string role;
        public frmShiftSchedule(string role)
        {
            InitializeComponent();
            assignmentBUS = new AssignmentBUS(role);
            this.role = role;
        }
        private void LoadData()
        {
            try
            {
                dtTable = new DataTable();
                dtTable.Clear();
                dtTable = assignmentBUS.getAllAssignmentShift();
                dgvShift.DataSource = dtTable;
                dgvShift.AutoResizeColumns();

            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + e.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShiftScheduleAdd frmShiftAdd = new frmShiftScheduleAdd(role);
            frmShiftAdd.add = true;
            frmShiftAdd.ShowDialog();
            LoadData();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dpDate_ValueChanged(object sender, EventArgs e)
        {
            /*DateTime selectedDateTime = dpDate.Value;
            dtTable = shiftBUS.GetAllShifts(selectedDateTime.ToString("yyyy-MM-dd"));
            dgvShift.DataSource = dtTable;
            dgvShift.AutoResizeColumns();*/
        }

        private void dgvShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShift.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmShiftScheduleAdd frm = new frmShiftScheduleAdd(role);
                frm.cbbMaCa.Text = dgvShift.CurrentRow.Cells["dgvMaCa"].Value.ToString();
                frm.cbbMaNV.Text = dgvShift.CurrentRow.Cells["dgvMaNV"].Value.ToString();
                frm.txtHoNV.Text = dgvShift.CurrentRow.Cells["dgvHoNV"].Value.ToString();
                frm.txtTenNV.Text = dgvShift.CurrentRow.Cells["dgvTenNV"].Value.ToString();
                //frm.txtMaCa.ReadOnly = true;
                frm.DTPNgay.Value = (DateTime)dgvShift.CurrentRow.Cells["dgvNgayLam"].Value;
                
                // frm.DTPNgay.Enabled = false;
                frm.add = false;
             
                frm.ShowDialog();
                LoadData();
            }
            else if (dgvShift.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá phân công này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    assignmentDTO = new AssignmentDTO(dgvShift.CurrentRow.Cells["dgvMaNV"].Value.ToString(),
                        dgvShift.CurrentRow.Cells["dgvMaCa"].Value.ToString(),
                        (DateTime)dgvShift.CurrentRow.Cells["dgvNgayLam"].Value,
                        dgvShift.CurrentRow.Cells["dgvHoNV"].Value.ToString(),
                        dgvShift.CurrentRow.Cells["dgvTenNV"].Value.ToString()
                        );
                    //Chú ý ở đây cần thực hiện thêm việc xóa tài khoản theo Manv
                    if (assignmentBUS.removeShift(assignmentDTO))
                    {
                     
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + assignmentBUS.err + "'");
                    }
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
