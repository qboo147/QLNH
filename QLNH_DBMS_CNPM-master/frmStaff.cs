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
using System.Data.SqlClient;

namespace GUI
{
    public partial class frmStaff : Form
    {
        public EmployeeBUS employeeBUS;
        public EmployeeDTO employeeDTO;
        public JobBUS jobBUS;
        private string role;
        
        public frmStaff(string role)
        {
            InitializeComponent();
            this.role = role;
            employeeBUS = new EmployeeBUS(role);
            jobBUS = new JobBUS();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffDetail frm = new frmStaffDetail(role);
            frm.txtSoCa.Text = "0";
            frm.txtThuong.Text = "0";
            frm.txtSoCa.ReadOnly= true;
            frm.txtThuong.ReadOnly= true;
            frm.txtMaNV.ReadOnly = false;
            frm.ShowDialog();
           Load_data();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Remove Employee",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                string ID = dgvStaff.CurrentRow.Cells[0].Value.ToString();
                employeeDTO = new EmployeeDTO(ID);
                if(employeeBUS.deleteEmployee(employeeDTO))
                {
                    MessageBox.Show("Xóa thành công");
                   Load_data();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }    
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string type = cmbSearchType.Text;
            employeeDTO = new EmployeeDTO(txtSearchStaff.Text, txtSearchStaff.Text, txtSearchStaff.Text, txtSearchStaff.Text);
            DataTable dt = employeeBUS.searchEmployee(employeeDTO, type);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tìm thành công");
                Load_data();
            }
            else
            {
                MessageBox.Show("Không có nhân viên cần tìm");
            }
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void Load_data()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt = employeeBUS.getAllEmployee();
                dgvStaff.DataSource = dt;
                dgvStaff.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi: " + e.Message);
            }
        }

        private void btnWage_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = employeeBUS.CalWageEmployee();
            FWage fwage = new FWage(dt);
            fwage.Show();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvStaff.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmStaffDetail frm = new frmStaffDetail(role);
                string selectedDisplay = dgvStaff.CurrentRow.Cells["dgvMaCV"].Value.ToString() + "-" + dgvStaff.CurrentRow.Cells["dgvTenCongViec"].Value.ToString();
                frm.cbbMaCV.Text = selectedDisplay;
                frm.txtMaNV.ReadOnly = true;
                frm.txtMaNV.Text = dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString();
                frm.txtHoNV.Text = dgvStaff.CurrentRow.Cells["dgvHoNV"].Value.ToString();
                frm.txtTenNV.Text = dgvStaff.CurrentRow.Cells["dgvTenNV"].Value.ToString();
                frm.dtpNgaySinh.Value = (DateTime)dgvStaff.CurrentRow.Cells["dgvNgaySinh"].Value;
                frm.txtSDT.Text = dgvStaff.CurrentRow.Cells["dgvSDT"].Value.ToString();
                //frm.txtMaCV.Text = dgvStaff.CurrentRow.Cells["dgvMaCV"].Value.ToString();
                frm.txtSoCa.Text = dgvStaff.CurrentRow.Cells["dgvSoCa"].Value.ToString();
                frm.txtThuong.Text = dgvStaff.CurrentRow.Cells["dgvThuong"].Value.ToString();
                frm.dtpNgayTD.Value = (DateTime)dgvStaff.CurrentRow.Cells["dgvNgayTuyenDung"].Value;
                frm.cmbHinhThuc.SelectedIndex = frm.cmbHinhThuc.Items.IndexOf(dgvStaff.CurrentRow.Cells["dgvHTCongViec"].Value.ToString());
                frm.ShowDialog();
                if (txtSearchStaff.Text != "")
                {
                    //dgvStaff.DataSource = employeeBUS.searchEmployee(txtSearchStaff.Text);
                }
                else
                {
                    Load_data();
                }
            }
            else if (dgvStaff.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Chú ý ở đây cần thực hiện thêm việc xóa tài khoản theo Manv
                    if (employeeBUS.deleteEmployee(dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString()))
                    {
                        txtSearchStaff.Text = "";
                        Load_data();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + employeeBUS.err + "'");
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
