using BUS;
using DTO;
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
    public partial class frmShiftAdd : Form
    {
        ShiftBUS shiftBUS;
        ShiftDTO shiftDTO;
        List<String> listMaCa;
        public bool add;
        public frmShiftAdd(string role)
        {
            InitializeComponent();
            listMaCa = new List<String>();
            listMaCa.Add("ca1");
            listMaCa.Add("ca2");
            listMaCa.Add("ca3");
            cbbMaCa.DataSource = listMaCa;
            shiftBUS = new ShiftBUS(role);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtMaCa.ReadOnly == true) //Chỉnh sửa ca
            if (add == false)
            {
                    /*string displayValue = cbbCateID.Text;
                    string[] splitValues = displayValue.Split('-');
                    string madm = splitValues[0];
                    string tendm = splitValues[1];*/
                    shiftDTO = new ShiftDTO(cbbMaCa.Text,Convert.ToDateTime(DTPNgay.Value), DTPStartTime.Value.ToShortTimeString(), DTPEndTime.Value.ToShortTimeString());

                    if (shiftBUS.updateShift(shiftDTO))
                    {
                        MessageBox.Show("Cập nhật ca làm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công. Lỗi: '" + shiftBUS.err + "'");
                    }
               
            }

            else //Thêm ca làm
            {

                // shiftDTO = new ShiftDTO(cbbMaCa.Text, Convert.ToDateTime(DTPNgay.Value), DTPStartTime.Value.ToShortTimeString(), DTPEndTime.Value.ToShortTimeString());
                shiftDTO = new ShiftDTO(cbbMaCa.Text, Convert.ToDateTime(DTPNgay.Value), DTPStartTime.Value.ToString("HH:mm:ss"), DTPEndTime.Value.ToString("HH:mm:ss"));
                if (shiftBUS.createShift(shiftDTO))
                    {
                        MessageBox.Show("Đã thêm xong!");
                    }
                 else
                    {
                        MessageBox.Show("Thêm không thành công. Lỗi: '" + shiftBUS.err);
                    }
             
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaCa_SelectedValueChanged(object sender, EventArgs e)
        {
            /*if(cbbMaCa.Text == listMaCa[0])
            {
                DTPStartTime.Value = 
                DTPEndTime.Value = 
            }*/
        }
    }
}
