/*
 * Creato da SharpDevelop.
 * Utente: salvatore
 * Data: 21/05/2013
 * Ora: 02.10
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
namespace ImgTag
{
	partial class InputBox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lText = new System.Windows.Forms.Label();
			this.bOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 52);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(278, 20);
			this.textBox1.TabIndex = 0;
			// 
			// lText
			// 
			this.lText.AutoSize = true;
			this.lText.Location = new System.Drawing.Point(6, 6);
			this.lText.Name = "lText";
			this.lText.Size = new System.Drawing.Size(0, 13);
			this.lText.TabIndex = 1;
			// 
			// bOk
			// 
			this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOk.Location = new System.Drawing.Point(91, 87);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(100, 34);
			this.bOk.TabIndex = 2;
			this.bOk.Text = "&OK";
			this.bOk.UseVisualStyleBackColor = true;
			// 
			// InputBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 124);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.lText);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InputBox";
			this.Load += new System.EventHandler(this.InputBoxLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Label lText;
		private System.Windows.Forms.TextBox textBox1;
	}
}
