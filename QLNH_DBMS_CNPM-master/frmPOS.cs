using BUS;
using DTO;
using GUI.Select;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPOS : Form
    {

        public int MainID = 0;
        public string OrderType = "";
        public string TableID = "";
        public DateTime Date;
        public DateTime Time;
        public string CustomerName = "";
        public string CustomerPhone = "";
        public int BillID = 0;
        public int DetailID;
        bool successPaid;
        DataTable dtDM;
        DataTable dtSP;
        DataTable dtTblJoin;
        ProductBUS productBus;
        BillBUS billBUS;
        BillDetailBUS billDetailBUS;
        TableBUS tableBUS;
        TableDTO tableDTO;
        int tiencoc = 0;
        double total;
        string waiterID;
        string cusID;
        public bool Them = true; // CHo khởi tạo ban đầu bằng true 
        bool start = false;
        List<String> listProstate;
        List<String> listTstate;
        List<String> listBillstate;
        List<String> listPaymentMethod;
        CustomerDTO customerDTO;
        BillDTO billDTO;
        BillDetailDTO billDetailDTO;
        string role;
        public frmPOS(string role)
        {
            InitializeComponent();
            productBus = new ProductBUS(role);

            billBUS = new BillBUS();
            billDetailBUS = new BillDetailBUS();
            this.Controls.Add(hScrollBar1);
            customerDTO = new CustomerDTO();
            listProstate = new List<String>();
            listProstate.Add("Còn");
            listProstate.Add("Hết");
            listTstate = new List<string>();
            listTstate.Add("Còn trống");
            listTstate.Add("Đã đặt");
            listTstate.Add("Đang dùng");
            listBillstate = new List<string>();
            listBillstate.Add("Chưa thanh toán");
            listBillstate.Add("Đã thanh toán");
            listPaymentMethod = new List<string>();
            listPaymentMethod.Add("Tiền mặt");
            listPaymentMethod.Add("Thanh toán nhanh");
            this.role = role;


        }
        private void GetCategory()
        {
            try
            {
                dtDM = new DataTable();
                dtDM.Clear();

                dtDM = productBus.getAllCategory();
                pnlCategory.Controls.Clear();
                if (dtDM.Rows.Count > 0)
                {

                    Guna.UI2.WinForms.Guna2Button allButton = new Guna.UI2.WinForms.Guna2Button();
                    allButton.FillColor = Color.FromArgb(50, 55, 89);
                    allButton.Size = new Size(130, 45);
                    allButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    allButton.Text = "Tất cả";
                    allButton.TextAlign = HorizontalAlignment.Left;
                    allButton.Click += new EventHandler(_Click); // Gắn sự kiện click cho nút "Tất cả"
                    pnlCategory.Controls.Add(allButton);
                    foreach (DataRow row in dtDM.Rows)
                    {
                        Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                        b.FillColor = Color.FromArgb(50, 55, 89);
                        b.Size = new Size(145, 55);
                        b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        b.Text = row["LoaiSP"].ToString();
                        b.TextAlign = HorizontalAlignment.Left;

                        //event for click
                        b.Click += new EventHandler(_Click);
                        pnlCategory.Controls.Add(b);
                        
                    }
                }
                else
                {
                    Console.WriteLine("Sai");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được các danh mục trong TABLE DANHMUC. Lỗi: " + ex.Message);
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if (b.Text == "Tất cả")
            {
                foreach (var item in pnlProduct.Controls)
                {
                    var pro = (ucProduct)item;
                    pro.Visible = true; // Hiển thị tất cả các sản phẩm
                    
                }
            }
            else // Lọc lấy các sản phẩm theo tên danh mục vd đồ ăn nhanh , món chính , rượu , bia
            {
                foreach (var item in pnlProduct.Controls)
                {
                    var pro = (ucProduct)item;
                    pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
                }
            }
        }

        private void LoadData()
        {
            LoadProducts();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            this.dgvPOS.BorderStyle = BorderStyle.FixedSingle;
            pnlCategory.Controls.Clear();
            pnlProduct.Controls.Clear();
            GetCategory();

            LoadData();
            Date = DateTime.Now;
            Time = DateTime.Now;
            DTPTime.Value = Time;
            DPTDate.Value = Date;
        }
        //Lấy các sản phẩm có trong database đưa lên pnlProduct
        private void LoadProducts()
        {
            try
            {
                dtSP = new DataTable();
                dtSP.Clear();

                dtSP = productBus.getAllProduct_POS();

                foreach (DataRow item in dtSP.Rows)
                {
                    Byte[] imagearray = (byte[])item["AnhSP"];
                    byte[] imagebytearray = imagearray;
                    
                    AddItems(item["MaSP"].ToString(), item["TenSP"].ToString(), item["LoaiSP"].ToString(), item["TinhTrang"].ToString(), float.Parse(item["DonGia"].ToString()), Image.FromStream(new MemoryStream(imagearray)));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được các SẢN PHẨM trong Table SANPHAM. Lỗi: " + ex.Message);
            }
        }

        private void AddItems(string id, string name, string cat,string state, float price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name, //Tên sản phẩm
                PPrice = price, //Gía
                PCategory = cat, // Tên loại sp ( Tên Danh mục)
                PState = state,
                PImage = pimage,
                PId = id // Mã sp

            };
            if (w.PState.Equals(listProstate[1])) //Hết hàng
            {
                w.Enabled = false;
                w.guna2ShadowPanel1.FillColor = Color.DimGray;
            }
            pnlProduct.Controls.Add(w);

            //Nhấn vào ucProdcut bất kỳ sẽ đưa sản phẩm đó lên dgvPOS
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                int d = dgvPOS.Rows.Count;
                foreach (DataGridViewRow item in dgvPOS.Rows)
                {
                    //Check if product already there then add one to quantity ad update price
                    object obj = item.Cells["dgvMaSP"].Value.ToString();
                    //     Console.WriteLine("*"+obj);
                    //    Console.WriteLine(obj.Equals(wdg.PId));
                    //  Console.WriteLine(obj + "><" + wdg.PId);
                    if (obj.Equals(wdg.PId))
                    {

                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GetTotal();
                        //  total += double.Parse(item.Cells["dgvPrice"].Value.ToString());

                        return;// Thoát khỏi onSelct
                    }
                    //Nếu sản phẩm chưa có trong danh sách, thêm một dòng mới cho sản phẩm đó trong guna2DataGridView1.
                    //Add new Product

                }
                dgvPOS.Rows.Add(new object[] { 0, wdg.PId, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                //Số 0 đầu tiên là DetailID , ta mặc định khi ấn chọn sản phẩm , DetailID đưa lên dgvPOS là 0 nhưng 0 qtrong lắm , vì khi chỉnh sửa là lúc database trong tblDetails đổ xuốngdgvPOS 
                //Gía trị trong cột dgvDetailID của dgvPOS sẽ trở nên khác ( vì trong tblDetails , cột DetailID là Indetity nên tự động sinh giá trị mỗi khi thêm record

                GetTotal();
                //   MessageBox.Show(lblTable.Text);
            };

        }
        private void GetTotal()
        {
            total = 0;
            //  lblTable.Text = "";
            foreach (DataGridViewRow item in dgvPOS.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            total += tiencoc;
            lblTotal.Text = total.ToString("N2");
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDinIn_Click(object sender, EventArgs e)
        {

        }

        private void lblDriverName_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in pnlProduct.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearchProduct.Text.Trim().ToLower());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            start = true;
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            //MainID = 0;
            Them = true;
            lblTotal.Text = "0.00";
            dgvPOS.Rows.Clear();
            frmCustomer frmCus = new frmCustomer(role);
            frmCus.ShowDialog();
            customerDTO = frmCus.customerDTO;
            lblCustomer.Text = customerDTO.Id;
            frmTableSelect frmTableSelect = new frmTableSelect(role);
            DataTable dtTemp = new DataTable();
            dtTemp.Clear();

            try
            {
                tableBUS = new TableBUS(role);
                dtTemp = tableBUS.FindReservedTableByCusID(listTstate[1], customerDTO.Id);

                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
             List<String> listReservedTableID  = new List<String>();
            if (dtTemp.Rows.Count > 0) {  //nếu có khách đặt bàn
                frmTableSelect.endbook = true;
                /*foreach (DataRow dtrow in dtTemp.Rows)
                {
                    listReservedTableID.Add(dtrow["MaBan"].ToString());
                }*/
                frmTableSelect.txtTienDatCoc.Text = dtTemp.Rows[0]["TienDatCoc"].ToString();
                tiencoc = Convert.ToInt32(dtTemp.Rows[0]["TienDatCoc"]);
                // frmTableSelect.dtTable = dtTemp;
            }
            frmTableSelect.txtMaKH.Text = customerDTO.Id;
            
            
            frmTableSelect.customer = customerDTO;
            frmTableSelect.ShowDialog();
            lblTable.Text = frmTableSelect.TableID;
            lblTable.Visible = true;
            TableID = frmTableSelect.TableID;
            frmWaiterSelect frmWaiter = new frmWaiterSelect(role);
            frmWaiter.ShowDialog();
            lblWaiter.Text = frmWaiter.WaiterName;
            lblWaiter.Tag = frmWaiter.WaiterID;
            waiterID = frmWaiter.WaiterID;
            lblWaiter.Visible = true;
        }
        private void btnBillList_Click(object sender, EventArgs e)
        {
            frmPOSBillList frm = new frmPOSBillList();
            frm.ShowDialog();


            //Sau khi frm đóng
            if (frm.MainID > 0 && frm.edit == true)
            {
                // Ra khỏi form Bill List 
                Them = frm.bonus; //  Them  = false lúc này sẽ hiển thị Bill cần sửa lên dgvPOS
                BillID = frm.MainID;
                
                billDTO = frm.billDTO; //Lấy ra billDTO là record đã pick trong dgvBillist
                
               // OrderType = frm.OrderType; //Lấy ordertype để xác định có phải din in ko , nếu là din in thì inner join với BAN để lấy idTable
                LoadEntries();
                //  LoadData();

            }
        }

        //Hieenr thi Bill can sua len dgvPOS
        private void LoadEntries()
        {
            try
            {
                dtTblJoin = new DataTable();
                dtTblJoin.Clear();

                dtTblJoin = billBUS.GetBillJoinDetail(BillID);
                
            
                TableID = dtTblJoin.Rows[0]["MaBan"].ToString();
                //btnDinIn.Checked = true;
                waiterID = dtTblJoin.Rows[0]["MaNV"].ToString();
                cusID = dtTblJoin.Rows[0]["MaKH"].ToString();
                lblWaiter.Visible = true;
                lblTable.Visible = true;
                dgvPOS.Rows.Clear();
                foreach (DataRow item in dtTblJoin.Rows)
                {
                    // lblTable.Text = item["TableName"].ToString();
                    //lblWaiter.Text = item["WaiterName"].ToString();
                    TableID = item["MaBan"].ToString();
                    cusID = item["MaKH"].ToString();
                    string detailIDD = item["MaChiTietHD"].ToString();
                    string proName = item["TenSP"].ToString();
                    string proID = item["MaSP"].ToString();
                    string qty = item["SoLuong"].ToString();
                    string price = item["DonGia"].ToString();
                    string amount = item["TongGT"].ToString();
                    object[] obj = { detailIDD, proID, proName, qty, price, amount };
                    dgvPOS.Rows.Add(obj);
                }

                GetTotal();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể load dữ liệu. Lỗi: " + ex.Message);
            }


        }

        private void btnKOT_Click(object sender, EventArgs e)
        //gửi đến bộ phận nhà bếp dưới dạng một phiếu đặt hàng (KOT).  (giống nút Save)     
        {
            int detailID = 0;
            
            if (Them)
            {
                //Cột MaBill tu dong sinh gia tri
                billDTO = new BillDTO(BillID, customerDTO.Id, "Chưa thanh toán", Convert.ToDouble(lblTotal.Text), waiterID, TableID, null, Convert.ToDateTime(Date), Time.ToShortTimeString());
                //Cap nhat gia tri dong hien tai nho SELECT_SCOPE_INDENTITY
                BillID = billBUS.AddBill(billDTO);
                // Thay vì như mặc định Hàm AddTblMain trả về true , false, ở đây nó trả về giá trị Bill Id của đơn hiện tại vừa thêm vào
                if (BillID > 0)
                    MessageBox.Show("Đã thêm xong!");
                else
                    MessageBox.Show("Không thêm được.Lỗi rồi!" + billBUS.err);

            }
            else
            {
                billDTO = new BillDTO(BillID, customerDTO.Id, "Chưa thanh toán", Convert.ToDouble(lblTotal.Text), waiterID, TableID, null, Convert.ToDateTime(Date), Time.ToShortTimeString());
                if (billBUS.UpdateBill(billDTO))
                {
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + billBUS.err + "'");
                }
            }
            foreach (DataGridViewRow row in dgvPOS.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvDetailID"].Value); //

                if (detailID == 0)
                {
                    billDetailDTO = new BillDetailDTO(BillID, row.Cells["dgvMaSP"].Value.ToString(), row.Cells["dgvTenSP"].Value.ToString(), int.Parse(row.Cells["dgvQty"].Value.ToString()), float.Parse(row.Cells["dgvPrice"].Value.ToString()), float.Parse(row.Cells["dgvAmount"].Value.ToString()),null);
                    if (!billDetailBUS.AddBillDetail(billDetailDTO))
                        MessageBox.Show("Thêm chi tiết hóa đơn không thành công. Lỗi: '" + billDetailBUS.err + "'");


                }
                else // Gía trị trong cột dgvDetailID của dgvPOS đã ko còn là 0 mà là giá trị từ tblDetail đổ xuống ( vì khi này là chỉnh sửa , tức giá trị detailID đó đã có trong database
                {
                    billDetailDTO = new BillDetailDTO(BillID, row.Cells["dgvMaSP"].Value.ToString(), row.Cells["dgvTenSP"].Value.ToString(), int.Parse(row.Cells["dgvQty"].Value.ToString()), float.Parse(row.Cells["dgvPrice"].Value.ToString()), float.Parse(row.Cells["dgvAmount"].Value.ToString()), Convert.ToInt32(row.Cells["dgvDetailID"].Value));
                    //Lấy dữ liệu trong dgvPOS update lên dbTblDetail
                    if (billDetailBUS.UpdateBillDetail(billDetailDTO))
                    {
                        MessageBox.Show("Đã sửa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công. Lỗi: '" + billDetailBUS.err + "'");
                    }
                }
            }
            guna2MessageDialog1.Show("Saved Successfully");
            //    MainID = 0;
            detailID = 0;
            dgvPOS.Rows.Clear();
            lblTable.Text = "";
            BillID = 0;
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00";
        

            //    this.Close();
            Them = true;


            //Need to add field to table to store additional info

        }

        private void btnHold_Click(object sender, EventArgs e)
        {

        }

        private void dgvPOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPOS.CurrentCell.OwningColumn.Name == "dgvDecrease")
                {
                    if (dgvPOS.CurrentRow != null && dgvPOS.CurrentRow.Cells["dgvQty"].Value != null)
                    {
                        if (uint.TryParse(dgvPOS.CurrentRow.Cells["dgvQty"].Value.ToString(), out uint currentQty))
                        {
                            if (currentQty > 1)
                            {
                                dgvPOS.CurrentRow.Cells["dgvQty"].Value = currentQty - 1;
                                dgvPOS.CurrentRow.Cells["dgvAmount"].Value = Convert.ToDouble(dgvPOS.CurrentRow.Cells["dgvQty"].Value) * Convert.ToDouble(dgvPOS.CurrentRow.Cells["dgvPrice"].Value);
                                GetTotal();
                            }
                            else if (currentQty == 1)
                            {
                                dgvPOS.Rows.RemoveAt(dgvPOS.CurrentCell.RowIndex);
                                MessageBox.Show("Xoá thành công!");
                            }
                        }
                        else
                        {
                            // Xử lý khi giá trị không phải số
                            MessageBox.Show("Giá trị không hợp lệ.");
                        }
                    }
                    else
                    {
                        // Xử lý khi hàng hiện tại hoặc giá trị cột là null
                        MessageBox.Show("Không có hàng hoặc giá trị cột.");
                    }

                }
                else if (dgvPOS.CurrentCell.OwningColumn.Name == "dgvDel")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        /*dbSP.XoaSanPham(dgvPOS.CurrentRow.Cells["dgvMaSP"].Value.ToString(), ref err);
                        LoadData();*/
                        dgvPOS.Rows.RemoveAt(dgvPOS.CurrentCell.RowIndex);
                        MessageBox.Show("Xoá thành công!");

                    }
                }
                GetTotal();
            }
            catch (SqlException err)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!" + err.Message);
            }
        }

        private void DPTDate_ValueChanged(object sender, EventArgs e)
        {
            Date = DPTDate.Value;
        }

        private void DTPTime_ValueChanged(object sender, EventArgs e)
        {
            Time = DTPTime.Value;
        }

        private void btnFastCard_Click(object sender, EventArgs e)
        {
            billDTO.Pttt = listPaymentMethod[1];
            billDTO.TrangThai = listBillstate[1];
            if (billBUS.UpdateBill(billDTO))
            {
                //   guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Thanh toán hóa đơn thành công");
                tableBUS = new TableBUS(role);
                tableDTO = new TableDTO(TableID, listTstate[0], null, null);
                if (tableBUS.UpdateTrangThaiBan(tableDTO))
                {
                    MessageBox.Show("Cập nhật trạng thái trống cho bàn thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công. Lỗi: '" + tableBUS.err + "'");

                }

                lblTable.Text = "";
                lblWaiter.Text = "";
                lblCustomer.Text = "";
                /* lblWaiter.Visible = false;
                 lblTable.Visible = false;*/
                lblTotal.Text = "0";
                dgvPOS.Rows.Clear();

                BillID = 0;
                DetailID = 0;
            }
            else
            {
                guna2MessageDialog1.Show("Thanh toán không thành công " + billBUS.err);
            }

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut frm = new frmCheckOut();
            frm.billID = BillID; // Lấy giá trị Bill hiện tại truyền cho frm để có thể update cho dat
            frm.amt = Convert.ToDouble(lblTotal.Text); //truyền vào giá trị để khi ấn checkout hiện lên , giá trị Total hiện lên txtBillAmount
            frm.billDTO = billDTO; //Truyền DTO vừa lấy đc từ việc bấm vào dgvEdit trong dgvBillist
            frm.billDTO.Pttt = listPaymentMethod[0];
            frm.ShowDialog();

            //  guna2MessageDialog1.Show("Saved Success");
            tableBUS = new TableBUS(role);
            tableDTO = new TableDTO(TableID, listTstate[0],null,null);
              if (tableBUS.UpdateTrangThaiBan(tableDTO))
            {
                MessageBox.Show("Cập nhật trạng thái trống cho bàn thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Lỗi: '" + tableBUS.err + "'");
          
            }

            lblTable.Text = "";
            lblWaiter.Text = "";
            lblCustomer.Text = "";
           /* lblWaiter.Visible = false;
            lblTable.Visible = false;*/
            lblTotal.Text = "0";
            dgvPOS.Rows.Clear();

            BillID = 0;
            DetailID = 0;
        }
    }
}
