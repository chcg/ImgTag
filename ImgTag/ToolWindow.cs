using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace ImgTag
{
    public partial class ToolWindow : Form
    {
        Bitmap bmp;

        public ToolWindow(Bitmap bmp)
        {
            InitializeComponent();
            this.bmp = bmp;

        }

        ~ToolWindow()
        {
            if(bmp!=null)bmp.Dispose();
        }


        private void ToolWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height-30);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(this.bmp, rect);
            g.Dispose();
        }
    }
}
