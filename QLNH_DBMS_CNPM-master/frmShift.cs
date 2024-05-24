using BUS;
using DTO;
using QLNH_DBMS;
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

namespace GUI
{
    public partial class frmShift : Form
    {
        ShiftBUS ShiftBUS;
        //ShiftDTO ShiftDTO;
        DataTable dtShift;
        ShiftDTO ShiftDTO;
        string role;
        public frmShift(string role)
        {
            InitializeComponent();
            ShiftBUS = new ShiftBUS(role);
            this.role = role;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShift.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmShiftAdd frm  = new frmShiftAdd(role);
                frm.cbbMaCa.Text = dgvShift.CurrentRow.Cells["dgvMaCa"].Value.ToString();
               
                //frm.txtMaCa.ReadOnly = true;
                frm.DTPNgay.Value = (DateTime)dgvShift.CurrentRow.Cells["dgvNgayLam"].Value;
                // frm.DTPNgay.Enabled = false;
                frm.add = false;
                // Lấy giá trị ngày từ DataGridView và chuyển đổi sang DateTime
                DateTime ngayLam = Convert.ToDateTime(dgvShift.CurrentRow.Cells["dgvNgayLam"].Value);

                // Lấy giá trị thời gian từ DataGridView và chuyển đổi sang DateTime
                /*DateTime gioBatDau = Convert.ToDateTime(dgvShift.CurrentRow.Cells["dgvGioBatDau"].Value);
                DateTime gioKetThuc = Convert.ToDateTime(dgvShift.CurrentRow.Cells["dgvGioKetThuc"].Value);*/
                TimeSpan gioBatDau = (TimeSpan)dgvShift.CurrentRow.Cells["dgvGioBatDau"].Value;
                TimeSpan gioKetThuc = (TimeSpan)dgvShift.CurrentRow.Cells["dgvGioKetThuc"].Value;
                // Kết hợp ngày và thời gian, bỏ qua phần giây
                //DateTime combinedStDateTime = new DateTime(ngayLam.Year, ngayLam.Month, ngayLam.Day,gioBatDau.Hour, gioBatDau.Minute, 0);

                // Định dạng kết quả thành chuỗi
                //string formattedStartDateTime = combinedDateTime.ToString("M/d/yyyy h:mm tt");
                // Kết hợp ngày và thời gian, bỏ qua phần giây
                /*DateTime combinedStartDateTime = new DateTime(ngayLam.Year, ngayLam.Month, ngayLam.Day,gioBatDau.Hour, gioBatDau.Minute, 0);
                DateTime combinedEndDateTime = new DateTime(ngayLam.Year, ngayLam.Month, ngayLam.Day, gioKetThuc.Hour, gioKetThuc.Minute, 0);*/
                DateTime combinedStartDateTime = ngayLam.Date + gioBatDau;
                DateTime combinedEndDateTime = ngayLam.Date + gioKetThuc;
                frm.DTPStartTime.Value = combinedStartDateTime;

                frm.DTPEndTime.Value = combinedEndDateTime;
                frm.ShowDialog();
                if (txtSearchShift.Text != "")
                {
                    //dgvStaff.DataSource = employeeBUS.searchEmployee(txtSearchStaff.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvShift.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá ca này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ShiftDTO = new ShiftDTO(dgvShift.CurrentRow.Cells["dgvMaCa"].Value.ToString(),
                        (DateTime)dgvShift.CurrentRow.Cells["dgvNgayLam"].Value,
                        dgvShift.CurrentRow.Cells["dgvGioBatDau"].Value.ToString(),
                        dgvShift.CurrentRow.Cells["dgvGioKetThuc"].Value.ToString()
                        );
                    //Chú ý ở đây cần thực hiện thêm việc xóa tài khoản theo Manv
                    if (ShiftBUS.deleteShift(ShiftDTO))
                    {
                        txtSearchShift.Text = "";
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + ShiftBUS.err + "'");
                    }
                }
            }
            else if(dgvShift.CurrentCell.OwningColumn.Name == "dgvCreateAssignment")
            {
                frmShiftScheduleAdd frm = new frmShiftScheduleAdd(role);
                frm.cbbMaCa.Text = dgvShift.CurrentRow.Cells["dgvMaCa"].Value.ToString();
                frm.DTPNgay.Value = Convert.ToDateTime(dgvShift.CurrentRow.Cells["dgvNgayLam"].Value);
                frm.ShowDialog();
            }
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            try
            {
                dtShift = new DataTable();
                dtShift.Clear();
                dtShift = ShiftBUS.GetAllShift();
                dgvShift.DataSource = dtShift;
                // Thay đổi độ rộng cột
                dgvShift.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được ca làm trong table ca làm. Lỗi: " + e.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShiftAdd frm = new frmShiftAdd(role);
            /* frm.cbbCateID.DataSource = productBus.LayDanhSachDanhMuc();
             frm.cbbCateID.ValueMember = "ID";
             frm.cbbCateID.DisplayMember = "Display";*/
            // frm.txtMaCa.ReadOnly = false;
            frm.add = true;
            
            frm.ShowDialog();
            LoadData();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBangPhanCong_Click(object sender, EventArgs e)
        {
            frmShiftSchedule frm = new frmShiftSchedule(role);
            frm.ShowDialog(this);
        }
    }
}
