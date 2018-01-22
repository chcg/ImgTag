/*
 * Creato da SharpDevelop.
 * Utente: salvatore
 * Data: 19/06/2013
 * Ora: 09.55
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
namespace ImgTag
{
	partial class ResizingDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.rbResizeWithHtml = new System.Windows.Forms.RadioButton();
            this.rbActuallyResize = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lImageName = new System.Windows.Forms.Label();
            this.btnCalculateHeight = new System.Windows.Forms.Button();
            this.btnCalculateWidth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // nudWidth
            // 
            this.nudWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWidth.Location = new System.Drawing.Point(56, 113);
            this.nudWidth.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(63, 20);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeight.Location = new System.Drawing.Point(56, 161);
            this.nudHeight.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(61, 20);
            this.nudHeight.TabIndex = 5;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbResizeWithHtml
            // 
            this.rbResizeWithHtml.AutoSize = true;
            this.rbResizeWithHtml.Checked = true;
            this.rbResizeWithHtml.Location = new System.Drawing.Point(5, 39);
            this.rbResizeWithHtml.Name = "rbResizeWithHtml";
            this.rbResizeWithHtml.Size = new System.Drawing.Size(161, 17);
            this.rbResizeWithHtml.TabIndex = 7;
            this.rbResizeWithHtml.TabStop = true;
            this.rbResizeWithHtml.Text = "Resize the image with HTML";
            this.rbResizeWithHtml.UseVisualStyleBackColor = true;
            // 
            // rbActuallyResize
            // 
            this.rbActuallyResize.AutoSize = true;
            this.rbActuallyResize.Location = new System.Drawing.Point(5, 69);
            this.rbActuallyResize.Name = "rbActuallyResize";
            this.rbActuallyResize.Size = new System.Drawing.Size(145, 17);
            this.rbActuallyResize.TabIndex = 8;
            this.rbActuallyResize.Text = "Resize the image actually";
            this.rbActuallyResize.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(31, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 26);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(141, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lImageName
            // 
            this.lImageName.AutoSize = true;
            this.lImageName.Location = new System.Drawing.Point(2, 8);
            this.lImageName.Name = "lImageName";
            this.lImageName.Size = new System.Drawing.Size(0, 13);
            this.lImageName.TabIndex = 11;
            // 
            // btnCalculateHeight
            // 
            this.btnCalculateHeight.Location = new System.Drawing.Point(125, 110);
            this.btnCalculateHeight.Name = "btnCalculateHeight";
            this.btnCalculateHeight.Size = new System.Drawing.Size(118, 23);
            this.btnCalculateHeight.TabIndex = 12;
            this.btnCalculateHeight.Text = "Calculate Height";
            this.btnCalculateHeight.UseVisualStyleBackColor = true;
            this.btnCalculateHeight.Click += new System.EventHandler(this.btnCalculateHeight_Click);
            // 
            // btnCalculateWidth
            // 
            this.btnCalculateWidth.Location = new System.Drawing.Point(125, 161);
            this.btnCalculateWidth.Name = "btnCalculateWidth";
            this.btnCalculateWidth.Size = new System.Drawing.Size(118, 20);
            this.btnCalculateWidth.TabIndex = 13;
            this.btnCalculateWidth.Text = "Calculate Width";
            this.btnCalculateWidth.UseVisualStyleBackColor = true;
            this.btnCalculateWidth.Click += new System.EventHandler(this.btnCalculateWidth_Click);
            // 
            // ResizingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 239);
            this.Controls.Add(this.btnCalculateWidth);
            this.Controls.Add(this.btnCalculateHeight);
            this.Controls.Add(this.lImageName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbActuallyResize);
            this.Controls.Add(this.rbResizeWithHtml);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ResizingDialog";
            this.Text = "Resize";
            this.Load += new System.EventHandler(this.ResizingDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label lImageName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.RadioButton rbActuallyResize;
        private System.Windows.Forms.RadioButton rbResizeWithHtml;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalculateHeight;
        private System.Windows.Forms.Button btnCalculateWidth;
	}
}
