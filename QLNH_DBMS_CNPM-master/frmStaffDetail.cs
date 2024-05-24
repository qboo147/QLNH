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

namespace GUI
{
    public partial class frmStaffDetail : Form
    {
        public EmployeeBUS employeeBUS;
        public EmployeeDTO employeeDTO;
        JobBUS jobBUS;
        List<String> listHinhThuc;
        private string role;
        public frmStaffDetail(string role)
        {
            InitializeComponent();
            employeeBUS = new EmployeeBUS(role);
            jobBUS = new JobBUS();
            cbbMaCV.DataSource = jobBUS.MaTenCongViec();
            cbbMaCV.ValueMember = "ID";
            cbbMaCV.DisplayMember = "Display";
            listHinhThuc = new List<String>();
            listHinhThuc.Add("Bán thời gian");
            listHinhThuc.Add("Toàn thời gian");
            cmbHinhThuc.DataSource = listHinhThuc;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHoNV.Text.Trim() == "" || txtTenNV.Text.Trim() == "" || txtSDT.Text.Trim() == ""  || cmbHinhThuc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtMaNV.ReadOnly == false) //Thêm nv
            {
                string displayValue = cbbMaCV.Text;
                string[] splitValues = displayValue.Split('-');
                string macv = splitValues[0];
                string tencv = splitValues[1];
                employeeDTO = new EmployeeDTO(txtMaNV.Text, txtHoNV.Text, txtTenNV.Text, dtpNgaySinh.Value, txtSDT.Text,macv, 0, 0, 
                    dtpNgayTD.Value, cmbHinhThuc.Text);
                if (employeeBUS.addEmployee(employeeDTO))
                {
                    MessageBox.Show("Đã thêm xong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công" + employeeBUS.err);
                }
            }
            else //Sua nv
            {
                string displayValue = cbbMaCV.Text;
                string[] splitValues = displayValue.Split('-');
                string macv = splitValues[0];
                string tencv = splitValues[1];
                employeeDTO = new EmployeeDTO(txtMaNV.Text, txtHoNV.Text, txtTenNV.Text, dtpNgaySinh.Value, txtSDT.Text, macv, Convert.ToInt32(txtSoCa.Text), Convert.ToInt32(txtThuong.Text),
                   dtpNgayTD.Value, cmbHinhThuc.Text);
                if (employeeBUS.editEmployee(employeeDTO))
                {
                    MessageBox.Show("Đã chỉnh sửa xong!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa không thành công " + employeeBUS.err);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
