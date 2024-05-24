using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNH_DBMS
{
    public partial class frmHome : Form
    {
        private string role;
        public frmHome(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = global::GUI.Properties.Resources.imgHOme;
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        int cnt = 0;
        int selected = 1;
        void chuyenAnh(ref int selected, object sender, EventArgs e)
        {
            selected += 1;
            switch (selected)
            {
                case 1:
                    img1_Click(sender, e);
                    break;
                case 2:
                    img2_Click(sender, e);
                    break;
                case 3:
                    img3_Click(sender, e);
                    break;
            }
            if (selected == 3) selected = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            cnt += 1;
            if (cnt == 30)
            {
                chuyenAnh(ref selected, sender, e);
                cnt = 0;
            }
            timer1.Start();
        }

        private void img1_Click(object sender, EventArgs e)
        {
            this.panel3.BackgroundImage = global::GUI.Properties.Resources.imgHOme;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img1.Checked = true;
            selected = 1;
            cnt = 0;
        }

        private void img2_Click(object sender, EventArgs e)
        {
            this.panel3.BackgroundImage = global::GUI.Properties.Resources.sign1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img2.Checked = true;
            selected = 2;
            cnt = 0;
        }

        private void img3_Click(object sender, EventArgs e)
        {
            this.panel3.BackgroundImage = global::GUI.Properties.Resources.Restaurant_BG_001;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img3.Checked = true;
            selected = 3;
            cnt = 0;
        }
    }
}
