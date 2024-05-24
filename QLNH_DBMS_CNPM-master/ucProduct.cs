﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;
        public string PId { get; set; }
        public float PPrice { get; set; }
        public string PCategory { get; set; } // Tên Danh mục
        public string PState { get;set; }
        public string PName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }

        }
        public Image PImage
        {
            get { return ptbImage.Image; }
            set { ptbImage.Image = value; }
        }

        private void ptbImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
