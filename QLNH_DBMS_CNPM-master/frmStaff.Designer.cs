namespace GUI
{
    partial class frmStaff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblStaff = new System.Windows.Forms.Label();
            this.cmbSearchType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAdd = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txtSearchStaff = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnWage = new Guna.UI2.WinForms.Guna2Button();
            this.dgvStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvManv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHoNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMaCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayTuyenDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHTCongViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenCongViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(9, 209);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1187, 12);
            this.guna2Separator1.TabIndex = 14;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(413, 41);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(284, 38);
            this.lblStaff.TabIndex = 11;
            this.lblStaff.Text = "Danh sách Nhân Viên";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.AutoRoundedCorners = true;
            this.cmbSearchType.BackColor = System.Drawing.Color.Transparent;
            this.cmbSearchType.BorderRadius = 17;
            this.cmbSearchType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSearchType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSearchType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSearchType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSearchType.ItemHeight = 30;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Mã NV",
            "SĐT",
            "Tên CV",
            "Tên NV"});
            this.cmbSearchType.Location = new System.Drawing.Point(1008, 121);
            this.cmbSearchType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(157, 36);
            this.cmbSearchType.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoRoundedCorners = true;
            this.btnSearch.BorderRadius = 27;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.LightCoral;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(996, 32);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(169, 56);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Image = global::GUI.Properties.Resources.delete;
            this.btnDelete.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.ImageRotate = 0F;
            this.btnDelete.ImageSize = new System.Drawing.Size(50, 50);
            this.btnDelete.IndicateFocus = true;
            this.btnDelete.Location = new System.Drawing.Point(129, 100);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.Size = new System.Drawing.Size(91, 101);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.UseTransparentBackground = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.HoverState.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAdd.Image = global::GUI.Properties.Resources.add_button;
            this.btnAdd.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAdd.ImageRotate = 0F;
            this.btnAdd.ImageSize = new System.Drawing.Size(60, 60);
            this.btnAdd.IndicateFocus = true;
            this.btnAdd.Location = new System.Drawing.Point(12, 100);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.Size = new System.Drawing.Size(91, 101);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearchStaff
            // 
            this.txtSearchStaff.AutoRoundedCorners = true;
            this.txtSearchStaff.BorderRadius = 27;
            this.txtSearchStaff.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchStaff.DefaultText = "";
            this.txtSearchStaff.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchStaff.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchStaff.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchStaff.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchStaff.IconLeft = global::GUI.Properties.Resources.magnifying_glass;
            this.txtSearchStaff.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearchStaff.IconLeftSize = new System.Drawing.Size(25, 25);
            this.txtSearchStaff.Location = new System.Drawing.Point(665, 121);
            this.txtSearchStaff.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearchStaff.MaximumSize = new System.Drawing.Size(322, 56);
            this.txtSearchStaff.Name = "txtSearchStaff";
            this.txtSearchStaff.PasswordChar = '\0';
            this.txtSearchStaff.PlaceholderText = "";
            this.txtSearchStaff.SelectedText = "";
            this.txtSearchStaff.Size = new System.Drawing.Size(322, 56);
            this.txtSearchStaff.TabIndex = 10;
            // 
            // btnWage
            // 
            this.btnWage.AutoRoundedCorners = true;
            this.btnWage.BorderRadius = 27;
            this.btnWage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWage.FillColor = System.Drawing.Color.PeachPuff;
            this.btnWage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnWage.ForeColor = System.Drawing.Color.Black;
            this.btnWage.Location = new System.Drawing.Point(336, 121);
            this.btnWage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWage.Name = "btnWage";
            this.btnWage.Size = new System.Drawing.Size(189, 56);
            this.btnWage.TabIndex = 20;
            this.btnWage.Text = "Bảng lương";
            this.btnWage.Click += new System.EventHandler(this.btnWage_Click);
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AllowUserToResizeColumns = false;
            this.dgvStaff.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaff.ColumnHeadersHeight = 40;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvManv,
            this.dgvHoNV,
            this.dgvTenNV,
            this.dgvNgaySinh,
            this.dgvSDT,
            this.dgvMaCV,
            this.dgvSoCa,
            this.dgvThuong,
            this.dgvNgayTuyenDung,
            this.dgvHTCongViec,
            this.dgvTenCongViec,
            this.dgvEdit,
            this.dgvDel});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaff.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.Location = new System.Drawing.Point(15, 229);
            this.dgvStaff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowHeadersWidth = 51;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.IndianRed;
            this.dgvStaff.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStaff.RowTemplate.Height = 35;
            this.dgvStaff.Size = new System.Drawing.Size(1181, 831);
            this.dgvStaff.TabIndex = 21;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStaff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvStaff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStaff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStaff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStaff.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvStaff.ThemeStyle.ReadOnly = true;
            this.dgvStaff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStaff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStaff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStaff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaff.ThemeStyle.RowsStyle.Height = 35;
            this.dgvStaff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStaff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // dgvManv
            // 
            this.dgvManv.DataPropertyName = "MaNV";
            this.dgvManv.HeaderText = "Mã nhân viên";
            this.dgvManv.MinimumWidth = 6;
            this.dgvManv.Name = "dgvManv";
            this.dgvManv.ReadOnly = true;
            // 
            // dgvHoNV
            // 
            this.dgvHoNV.DataPropertyName = "HoNV";
            this.dgvHoNV.HeaderText = "Họ nhân viên";
            this.dgvHoNV.MinimumWidth = 8;
            this.dgvHoNV.Name = "dgvHoNV";
            this.dgvHoNV.ReadOnly = true;
            // 
            // dgvTenNV
            // 
            this.dgvTenNV.DataPropertyName = "TenNV";
            this.dgvTenNV.HeaderText = "Tên nhân viên";
            this.dgvTenNV.MinimumWidth = 6;
            this.dgvTenNV.Name = "dgvTenNV";
            this.dgvTenNV.ReadOnly = true;
            // 
            // dgvNgaySinh
            // 
            this.dgvNgaySinh.DataPropertyName = "NgaySinh";
            this.dgvNgaySinh.HeaderText = "Ngày Sinh";
            this.dgvNgaySinh.MinimumWidth = 8;
            this.dgvNgaySinh.Name = "dgvNgaySinh";
            this.dgvNgaySinh.ReadOnly = true;
            // 
            // dgvSDT
            // 
            this.dgvSDT.DataPropertyName = "SDT";
            this.dgvSDT.HeaderText = "SĐT";
            this.dgvSDT.MinimumWidth = 6;
            this.dgvSDT.Name = "dgvSDT";
            this.dgvSDT.ReadOnly = true;
            // 
            // dgvMaCV
            // 
            this.dgvMaCV.DataPropertyName = "MaCV";
            this.dgvMaCV.HeaderText = "Mã công việc";
            this.dgvMaCV.MinimumWidth = 8;
            this.dgvMaCV.Name = "dgvMaCV";
            this.dgvMaCV.ReadOnly = true;
            // 
            // dgvSoCa
            // 
            this.dgvSoCa.DataPropertyName = "SoCa";
            this.dgvSoCa.HeaderText = "Số ca";
            this.dgvSoCa.MinimumWidth = 8;
            this.dgvSoCa.Name = "dgvSoCa";
            this.dgvSoCa.ReadOnly = true;
            // 
            // dgvThuong
            // 
            this.dgvThuong.DataPropertyName = "Thuong";
            this.dgvThuong.HeaderText = "Thưởng";
            this.dgvThuong.MinimumWidth = 8;
            this.dgvThuong.Name = "dgvThuong";
            this.dgvThuong.ReadOnly = true;
            // 
            // dgvNgayTuyenDung
            // 
            this.dgvNgayTuyenDung.DataPropertyName = "NgayTuyenDung";
            this.dgvNgayTuyenDung.HeaderText = "Ngày tuyển dụng";
            this.dgvNgayTuyenDung.MinimumWidth = 8;
            this.dgvNgayTuyenDung.Name = "dgvNgayTuyenDung";
            this.dgvNgayTuyenDung.ReadOnly = true;
            // 
            // dgvHTCongViec
            // 
            this.dgvHTCongViec.DataPropertyName = "HTCongViec";
            this.dgvHTCongViec.HeaderText = "Hình thức";
            this.dgvHTCongViec.MinimumWidth = 6;
            this.dgvHTCongViec.Name = "dgvHTCongViec";
            this.dgvHTCongViec.ReadOnly = true;
            // 
            // dgvTenCongViec
            // 
            this.dgvTenCongViec.DataPropertyName = "TenCV";
            this.dgvTenCongViec.HeaderText = "Tên công việc";
            this.dgvTenCongViec.MinimumWidth = 8;
            this.dgvTenCongViec.Name = "dgvTenCongViec";
            this.dgvTenCongViec.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvEdit.FillWeight = 50F;
            this.dgvEdit.HeaderText = "";
            this.dgvEdit.Image = global::GUI.Properties.Resources.edit;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvEdit.MinimumWidth = 50;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Width = 50;
            // 
            // dgvDel
            // 
            this.dgvDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvDel.FillWeight = 50F;
            this.dgvDel.HeaderText = "";
            this.dgvDel.Image = global::GUI.Properties.Resources.delete;
            this.dgvDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDel.MinimumWidth = 50;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.Width = 50;
            // 
            // frmStaff
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1209, 1073);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.btnWage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.txtSearchStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStaff";
            this.Load += new System.EventHandler(this.frmStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2ImageButton btnAdd;
        private System.Windows.Forms.Label lblStaff;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchStaff;
        private Guna.UI2.WinForms.Guna2ImageButton btnDelete;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSearchType;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnWage;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvManv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHoNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSoCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgayTuyenDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHTCongViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenCongViec;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDel;
    }
}