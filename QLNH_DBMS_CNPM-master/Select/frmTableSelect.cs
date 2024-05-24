using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI.Select
{
    public partial class frmTableSelect : Form
    {
         DataTable dtTable = null;
        
        TableBUS tableBUS;
        TableDTO tabelDTO;
        List<string> listTstate;
        public string maKH;
        public string TableState = "";
        public string TableID = "";
        public int? tiencoc;
        public string err;
        public CustomerDTO customer = null;
        public bool endbook = false;
        public bool startbook = false;  
        
        string role;
        public frmTableSelect(string role)
        {
            InitializeComponent();
            listTstate = new List<string>();
            listTstate.Add("Còn trống");
            listTstate.Add("Đã đặt");
            listTstate.Add("Đang dùng");
            tableBUS = new TableBUS(role);
            this.role = role;

        }
       
        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //lẤY TÊN các bàn đưa vào các button
        private void LoadData()
        {
            dtTable = new DataTable();
            dtTable.Clear();
     
            dtTable = tableBUS.GetAllTables();
            if(startbook == true) { //Lúc này startbook = false tức là hoặc dùng liền hoặc khách đặt trước đến ăn

                foreach (DataRow row in dtTable.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.Text = row["MaBan"].ToString();
                    b.Tag = row["TrangThai"].ToString();
                    b.Width = 150;
                    b.Height = 50;
                    b.FillColor = Color.FromArgb(241, 85, 126);
                    b.HoverState.FillColor = Color.FromArgb(50, 55, 89);
                    //b.Tag = row["Tid"].ToString();
                    b.Click += new EventHandler(b_Click);

                    if (row["TrangThai"].ToString().Equals(listTstate[0]))
                        b.Enabled = true;
                    else
                        b.Enabled = false;
                   /* if (row["TrangThai"].ToString().Equals(listTstate[1]) && row["MaKH"].ToString().Equals(customer.Id))
                        b.Enabled = true;*/

                    flowLayoutPanel1.Controls.Add(b);
                }
            }
            if(endbook == true) 
            {
                
                foreach (DataRow row in dtTable.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.Text = row["MaBan"].ToString();
                    b.Tag = row["TrangThai"].ToString();
                    b.Width = 150;
                    b.Height = 50;
                    b.FillColor = Color.FromArgb(241, 85, 126);
                    b.HoverState.FillColor = Color.FromArgb(50, 55, 89);
                    //b.Tag = row["Tid"].ToString();
                    b.Click += new EventHandler(b_Click);

                    /* if (row["TrangThai"].ToString().Equals(listTstate[0]))
                         b.Enabled = true;
                     if (row["TrangThai"].ToString().Equals(listTstate[1]) && row["MaKH"].ToString().Equals(customer.Id))
                         b.Enabled = true;
                     else 
                         b.Enabled = false;*/
                    if (row["TrangThai"].ToString().Equals(listTstate[1]) && row["MaKH"].ToString().Equals(customer.Id))
                        b.Enabled = true;
                    else
                        b.Enabled = false;

                    flowLayoutPanel1.Controls.Add(b);
                }
               
            }

        }
        //Cập nhật State của bàn 
        private void b_Click(object sender, EventArgs e)
        {
            /* TableInfo tableInfo = (sender as Guna.UI2.WinForms.Guna2Button).Tag as TableInfo;
             TableName = tableInfo.TableName;
             TableID = tableInfo.TableID;*/
           // TableName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            TableID = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            TableState = (sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString();
            tiencoc = string.IsNullOrEmpty(txtTienDatCoc.Text) ? (int?)null : int.TryParse(txtTienDatCoc.Text, out int result) ? result : (int?)null;
            maKH = string.IsNullOrEmpty(txtMaKH.Text) ? null : txtMaKH.Text;
            
            //KHỎI CẦN CHECK LÀ ĐẶT BÀN HAY DÙNG LUÔN VÌ ĐÃ CÓ trigger check tiendatcoc đói với TrangThai = N'Đã đặt'
            if(startbook == true)
            {
                tabelDTO = new TableDTO(TableID, listTstate[1], tiencoc, maKH);
            }
            else //Lúc này có 2 thop là khách dùng liền và khách đặt đến gọi món , chuyển tt từ đã ddaxt -> đang dùng
            {
                tabelDTO = new TableDTO(TableID, listTstate[2], tiencoc, maKH);
            }
           
                if (tableBUS.UpdateTrangThaiBan(tabelDTO))
                {
                guna2MessageDialog1.Show($"Đặt {TableID} thành công");
                this.Close();// Đóng form
                 }
                else
                    guna2MessageDialog1.Show(tableBUS.err);
               
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTienDatCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
