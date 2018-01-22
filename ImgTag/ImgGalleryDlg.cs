using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImgTag
{
    public partial class ImgGalleryDlg : Form
    {
        string initialDir;
        
        public ImgGalleryDlg(string initialDir)
        {
            InitializeComponent();
            this.initialDir = initialDir;
        }


        public string ThumbnailsFolder
        {
            get { return txtThumbnails.Text; }
        }

        public string FullSizeImagesFolder
        {
            get { return txtFullSizeImages.Text; }
        }

        public int Columns
        {
            get
            {
                return (int)nudColumns.Value;
            }
        }

        public string LinkClass
        {
            get
            {
                return txtClass.Text;
            }
        }

        public string LinkRel
        {
            get
            {
                return txtRel.Text;
            }
        }

        private void btnThumbnails_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath=this.initialDir;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtThumbnails.Text = fbd.SelectedPath;
            }

        }

        private void btnFullSizeImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = this.initialDir;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFullSizeImages.Text = fbd.SelectedPath;
            }
        }
    }
}
