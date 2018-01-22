namespace ImgTag
{
    partial class ImgGalleryDlg
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtThumbnails = new System.Windows.Forms.TextBox();
            this.btnThumbnails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullSizeImages = new System.Windows.Forms.TextBox();
            this.btnFullSizeImages = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRel = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Thumbnails Folder";
            // 
            // txtThumbnails
            // 
            this.txtThumbnails.Location = new System.Drawing.Point(12, 35);
            this.txtThumbnails.Name = "txtThumbnails";
            this.txtThumbnails.Size = new System.Drawing.Size(298, 20);
            this.txtThumbnails.TabIndex = 1;
            // 
            // btnThumbnails
            // 
            this.btnThumbnails.Location = new System.Drawing.Point(316, 35);
            this.btnThumbnails.Name = "btnThumbnails";
            this.btnThumbnails.Size = new System.Drawing.Size(32, 23);
            this.btnThumbnails.TabIndex = 2;
            this.btnThumbnails.Text = "...";
            this.btnThumbnails.UseVisualStyleBackColor = true;
            this.btnThumbnails.Click += new System.EventHandler(this.btnThumbnails_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select full size images folder";
            // 
            // txtFullSizeImages
            // 
            this.txtFullSizeImages.Location = new System.Drawing.Point(12, 99);
            this.txtFullSizeImages.Name = "txtFullSizeImages";
            this.txtFullSizeImages.Size = new System.Drawing.Size(298, 20);
            this.txtFullSizeImages.TabIndex = 4;
            // 
            // btnFullSizeImages
            // 
            this.btnFullSizeImages.Location = new System.Drawing.Point(316, 97);
            this.btnFullSizeImages.Name = "btnFullSizeImages";
            this.btnFullSizeImages.Size = new System.Drawing.Size(32, 23);
            this.btnFullSizeImages.TabIndex = 5;
            this.btnFullSizeImages.Text = "...";
            this.btnFullSizeImages.UseVisualStyleBackColor = true;
            this.btnFullSizeImages.Click += new System.EventHandler(this.btnFullSizeImages_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thumbnails and full size images must have the same name.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Columns";
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(156, 179);
            this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(67, 20);
            this.nudColumns.TabIndex = 8;
            this.nudColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Link class";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Link rel";
            // 
            // txtRel
            // 
            this.txtRel.Location = new System.Drawing.Point(229, 224);
            this.txtRel.Name = "txtRel";
            this.txtRel.Size = new System.Drawing.Size(100, 20);
            this.txtRel.TabIndex = 11;
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(68, 224);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 20);
            this.txtClass.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(134, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ImgGalleryDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 284);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtRel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudColumns);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFullSizeImages);
            this.Controls.Add(this.txtFullSizeImages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThumbnails);
            this.Controls.Add(this.txtThumbnails);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImgGalleryDlg";
            this.Text = "Insert Image Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThumbnails;
        private System.Windows.Forms.Button btnThumbnails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullSizeImages;
        private System.Windows.Forms.Button btnFullSizeImages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRel;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Button btnOk;
    }
}