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
using DTO;

namespace GUI
{
    public partial class frmShiftScheduleAdd : Form
    {
        EmployeeBUS emBUS;
        ShiftBUS shiftBUS;
        AssignmentBUS assignmentBUS;
        public bool add;
        List<String> listMaCa;
        public frmShiftScheduleAdd(string role)
        {
            InitializeComponent();
            listMaCa = new List<String>();
            listMaCa.Add("ca1");
            listMaCa.Add("ca2");
            listMaCa.Add("ca3");
            emBUS = new EmployeeBUS(role);
             shiftBUS = new ShiftBUS(role);
            assignmentBUS = new AssignmentBUS(role);
            // Lấy DataTable chứa danh sách nhân viên bán thời gian
            DataTable dtPartTimeEmployees = emBUS.getAllPartTime();

            // Đặt DataSource cho cbbMaNV
            cbbMaNV.DataSource = dtPartTimeEmployees;

            // Đặt DisplayMember và ValueMember cho cbbMaNV
            cbbMaNV.DisplayMember = "Display"; // Cột "MaNV" sẽ được hiển thị trong ComboBox
            cbbMaNV.ValueMember = "ID"; // Giá trị của "MaNV" sẽ được sử dụng khi một item được chọn
            cbbMaCa.DataSource = listMaCa;
        }

       /* private void btnCreateShift_Click(object sender, EventArgs e)
        {
            string shiftId = txtShiftId.Text;
            DateTime date = dpDate.Value;
            string startTime = txtStartTime.Text;
            string endTime = txtEndTime.Text;
            ShiftDTO shiftDTO = new ShiftDTO(shiftId, date, startTime, endTime);
            bool success = shiftBUS.createShift(shiftDTO);
            if (success)
                MessageBox.Show("Create shift Successfully");
            else
                MessageBox.Show("Create shift Failed");
        }*/

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            string displayValue = cbbMaNV.Text;
            string[] splitValues = displayValue.Split('-');
            string manv = splitValues[0];
            string honv = splitValues[1];
            string tennv = splitValues[2];
            if (add == true)
            {

                AssignmentDTO assignmentDTO = new AssignmentDTO(manv, cbbMaCa.Text, Convert.ToDateTime(DTPNgay.Value), honv, tennv);
                bool success = assignmentBUS.createShift(assignmentDTO);
                if (success)
                {
                    MessageBox.Show("Tạo phân công thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Gặp lỗi khi tạo phân công " + assignmentBUS.err);
            }
            else {
                AssignmentDTO assignmentDTO = new AssignmentDTO(manv, cbbMaCa.Text, Convert.ToDateTime(DTPNgay.Value), honv, tennv);
                bool success = assignmentBUS.updateShift(assignmentDTO);
                if (success)
                {
                    MessageBox.Show("Cập nhật phân công thành công");
                    this.Close();
                }
                    
                else
                    MessageBox.Show("Gặp lỗi khi cập nhật phân công " + assignmentBUS.err);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
