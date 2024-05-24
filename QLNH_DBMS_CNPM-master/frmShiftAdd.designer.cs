namespace GUI
{
    partial class frmShiftAdd
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
            this.DTPNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPStartTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.DTPEndTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbbMaCa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTPNgay
            // 
            this.DTPNgay.AutoRoundedCorners = true;
            this.DTPNgay.BackColor = System.Drawing.Color.Transparent;
            this.DTPNgay.BorderColor = System.Drawing.Color.LightGray;
            this.DTPNgay.BorderRadius = 24;
            this.DTPNgay.Checked = true;
            this.DTPNgay.FillColor = System.Drawing.Color.Gainsboro;
            this.DTPNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPNgay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DTPNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DTPNgay.Location = new System.Drawing.Point(232, 341);
            this.DTPNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DTPNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTPNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTPNgay.Name = "DTPNgay";
            this.DTPNgay.Size = new System.Drawing.Size(334, 51);
            this.DTPNgay.TabIndex = 85;
            this.DTPNgay.Value = new System.DateTime(2023, 11, 2, 19, 26, 59, 815);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 26);
            this.label4.TabIndex = 77;
            this.label4.Text = "Ngày làm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 74;
            this.label1.Text = "Mã ca";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.BackColor = System.Drawing.Color.Transparent;
            this.lblAdd.Font = new System.Drawing.Font("Constantia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAdd.Location = new System.Drawing.Point(506, 65);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(172, 49);
            this.lblAdd.TabIndex = 1;
            this.lblAdd.Text = "CA LÀM";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblAdd);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1257, 176);
            this.guna2Panel1.TabIndex = 72;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.task_png;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(63, 18);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(143, 156);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 41;
            this.btnSave.CustomizableEdges.TopRight = false;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(260, 59);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(243, 84);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 41;
            this.btnClose.CustomizableEdges.TopLeft = false;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(581, 59);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(243, 84);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(625, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 26);
            this.label9.TabIndex = 80;
            this.label9.Text = "Giờ bắt đầu";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnSave);
            this.guna2Panel2.Controls.Add(this.btnClose);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 467);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1257, 163);
            this.guna2Panel2.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(625, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 89;
            this.label2.Text = "Giờ kết thúc";
            // 
            // DTPStartTime
            // 
            this.DTPStartTime.Animated = true;
            this.DTPStartTime.AutoRoundedCorners = true;
            this.DTPStartTime.BackColor = System.Drawing.Color.Transparent;
            this.DTPStartTime.BorderColor = System.Drawing.Color.Transparent;
            this.DTPStartTime.BorderRadius = 24;
            this.DTPStartTime.Checked = true;
            this.DTPStartTime.FillColor = System.Drawing.Color.Crimson;
            this.DTPStartTime.Font = new System.Drawing.Font(".VnVogueH", 10F, System.Drawing.FontStyle.Bold);
            this.DTPStartTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DTPStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPStartTime.HoverState.FillColor = System.Drawing.Color.Red;
            this.DTPStartTime.Location = new System.Drawing.Point(807, 262);
            this.DTPStartTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTPStartTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTPStartTime.Name = "DTPStartTime";
            this.DTPStartTime.ShowUpDown = true;
            this.DTPStartTime.Size = new System.Drawing.Size(187, 51);
            this.DTPStartTime.TabIndex = 91;
            this.DTPStartTime.UseTransparentBackground = true;
            this.DTPStartTime.Value = new System.DateTime(2023, 6, 2, 8, 0, 0, 0);
            // 
            // DTPEndTime
            // 
            this.DTPEndTime.Animated = true;
            this.DTPEndTime.AutoRoundedCorners = true;
            this.DTPEndTime.BackColor = System.Drawing.Color.Transparent;
            this.DTPEndTime.BorderColor = System.Drawing.Color.Transparent;
            this.DTPEndTime.BorderRadius = 24;
            this.DTPEndTime.Checked = true;
            this.DTPEndTime.FillColor = System.Drawing.Color.Crimson;
            this.DTPEndTime.Font = new System.Drawing.Font(".VnVogueH", 10F, System.Drawing.FontStyle.Bold);
            this.DTPEndTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPEndTime.HoverState.FillColor = System.Drawing.Color.Red;
            this.DTPEndTime.Location = new System.Drawing.Point(807, 341);
            this.DTPEndTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTPEndTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTPEndTime.Name = "DTPEndTime";
            this.DTPEndTime.ShowUpDown = true;
            this.DTPEndTime.Size = new System.Drawing.Size(187, 51);
            this.DTPEndTime.TabIndex = 93;
            this.DTPEndTime.UseTransparentBackground = true;
            this.DTPEndTime.Value = new System.DateTime(2023, 6, 2, 12, 0, 0, 0);
            // 
            // cbbMaCa
            // 
            this.cbbMaCa.BackColor = System.Drawing.Color.Transparent;
            this.cbbMaCa.BorderRadius = 10;
            this.cbbMaCa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMaCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaCa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMaCa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMaCa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaCa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbMaCa.ItemHeight = 30;
            this.cbbMaCa.Location = new System.Drawing.Point(232, 268);
            this.cbbMaCa.Name = "cbbMaCa";
            this.cbbMaCa.Size = new System.Drawing.Size(334, 36);
            this.cbbMaCa.TabIndex = 94;
            this.cbbMaCa.SelectedValueChanged += new System.EventHandler(this.cbbMaCa_SelectedValueChanged);
            // 
            // frmShiftAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1257, 630);
            this.Controls.Add(this.cbbMaCa);
            this.Controls.Add(this.DTPEndTime);
            this.Controls.Add(this.DTPStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTPNgay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShiftAdd";
            this.Text = "frmShiftAdd";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2DateTimePicker DTPNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblAdd;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label9;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2DateTimePicker DTPStartTime;
        public Guna.UI2.WinForms.Guna2DateTimePicker DTPEndTime;
        public Guna.UI2.WinForms.Guna2ComboBox cbbMaCa;
    }
}