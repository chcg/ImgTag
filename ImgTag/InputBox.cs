/*
 * Creato da SharpDevelop.
 * Utente: salvatore
 * Data: 21/05/2013
 * Ora: 02.10
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
	/// Description of InputBox.
	/// </summary>
	public partial class InputBox : Form
	{
			[DllImport("User32")]
			private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
			[DllImport("User32")]
			private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
			[DllImport("User32")]
			private static extern int GetMenuItemCount(IntPtr hWnd);
		
		public InputBox(string text)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			this.lText.Text=text;
		}
		
		public string Input
		{
 			get { return this.textBox1.Text;}
		}
		
		
		
		void InputBoxLoad(object sender, EventArgs e)
		{
			IntPtr hMenu = GetSystemMenu(this.Handle, false);
			int menuItemCount = GetMenuItemCount(hMenu);
			RemoveMenu(hMenu, menuItemCount - 1, 0X400);
		}
	}
}
