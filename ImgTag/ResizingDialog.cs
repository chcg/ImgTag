/*
 * Creato da SharpDevelop.
 * Utente: salvatore
 * Data: 19/06/2013
 * Ora: 09.55
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ImgTag
{
	/// <summary>
	/// Description of ResizingDialog.
	/// </summary>
	public partial class ResizingDialog : Form
	{
		[DllImport("User32")]
			private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
			[DllImport("User32")]
			private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
			[DllImport("User32")]
			private static extern int GetMenuItemCount(IntPtr hWnd);
            private double aw=0, ah=0;
		
		public ResizingDialog()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void ResizingDialogLoad(object sender, EventArgs e)
		{
			IntPtr hMenu = GetSystemMenu(this.Handle, false);
			int menuItemCount = GetMenuItemCount(hMenu);
			RemoveMenu(hMenu, menuItemCount - 1, 0X400);
		}

        public void CalculateAspectRatio(int w, int h)
        {
            aw = (double)((double)h / (double)w);
            ah = (double)((double)w / (double)h);
            ImageWidth= w;
            ImageHeight = h;
        }
		
		public bool RealResizing
		{
			get
			{
				return rbActuallyResize.Checked;
			}
		}
		
		public int ImageWidth
		{
			get
			{
				return (int)nudWidth.Value;
			}
			set
			{
                if (value < nudWidth.Minimum) nudWidth.Value = nudWidth.Minimum;
                else if (value > nudWidth.Maximum) nudWidth.Value = nudWidth.Maximum;
                else nudWidth.Value = value;
			}
		}
		
		public int ImageHeight
		{
			get
			{
				return (int)nudHeight.Value;
			}
			set
			{
                if (value < nudHeight.Minimum) nudHeight.Value = nudHeight.Minimum;
                else if (value > nudHeight.Maximum) nudHeight.Value = nudHeight.Maximum;
                else nudHeight.Value = value;
			}
		}
		
		public string ImageName
		{
			get
			{
				return lImageName.Text;
			}
			set
			{
				lImageName.Text=value;
			}
		}

        private void btnCalculateHeight_Click(object sender, EventArgs e)
        {
            ImageHeight= (int)(aw * (double)nudWidth.Value);
        }

        private void btnCalculateWidth_Click(object sender, EventArgs e)
        {
            ImageWidth = (int)(ah * (double)nudHeight.Value);
        }

       
	}
}
