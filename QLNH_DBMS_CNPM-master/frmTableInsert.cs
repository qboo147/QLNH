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
    public partial class frmTableInsert : Form
    {
        TableDTO tableDTO;
        TableBUS tableBUS;
        List<string> listTstate; 
        
        public frmTableInsert(string role)
        {
            InitializeComponent();
            tableBUS = new TableBUS(role);
            listTstate = new List<string>();
            listTstate.Add("Còn trống");
            listTstate.Add("Đã đặt");
            listTstate.Add("Đang dùng");
            this.cbbTstate.DataSource = listTstate;
        }

        private void frmTableInsert_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTableID.Text.Trim() == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            //string tienDatCocText = txtTienDatCoc.Text;
            int? tienDatCoc = string.IsNullOrEmpty(txtTienDatCoc.Text) ? (int?)null : int.TryParse(txtTienDatCoc.Text, out int result) ? result : (int?)null;
            string maKH = string.IsNullOrEmpty(txtKH.Text) ? null : txtKH.Text;
            if (txtTableID.ReadOnly == true) //Cap nhap ban
            {
               
                tableDTO = new TableDTO(txtTableID.Text, cbbTstate.Text, tienDatCoc, maKH);              
                if (tableBUS.UpdateTrangThaiBan(tableDTO))
                {
                    MessageBox.Show("Cập nhật bàn thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + tableBUS.err + "'");
                    Console.WriteLine("A");
                }
            }
            else //Them ban
            {

                tableDTO = new TableDTO(txtTableID.Text, cbbTstate.Text, tienDatCoc, maKH);
                if(tableBUS.AddTable(tableDTO))
                {
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công. Lỗi: '" + tableBUS.err+ "'");
                    Console.WriteLine("A");
                }

            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
