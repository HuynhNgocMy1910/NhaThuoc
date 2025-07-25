namespace QuanLyThuoc
{
    partial class frmVietQR
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbonganhang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVietQR = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbotemplate = new System.Windows.Forms.ComboBox();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.txtThongTinThem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nupSoTien = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSoTien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngân hàng:";
            // 
            // cbonganhang
            // 
            this.cbonganhang.FormattingEnabled = true;
            this.cbonganhang.Location = new System.Drawing.Point(134, 70);
            this.cbonganhang.Name = "cbonganhang";
            this.cbonganhang.Size = new System.Drawing.Size(173, 24);
            this.cbonganhang.TabIndex = 2;
            this.cbonganhang.Text = "Sacombank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số tiền:";
            // 
            // btnVietQR
            // 
            this.btnVietQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVietQR.Location = new System.Drawing.Point(170, 314);
            this.btnVietQR.Name = "btnVietQR";
            this.btnVietQR.Size = new System.Drawing.Size(243, 52);
            this.btnVietQR.TabIndex = 4;
            this.btnVietQR.Text = "Create VietQR Payment";
            this.btnVietQR.UseVisualStyleBackColor = true;
            this.btnVietQR.Click += new System.EventHandler(this.btnVietQR_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số tài khoản:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(382, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên tài khoản:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(699, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Thông tin thêm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(699, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 7;
            // 
            // cbotemplate
            // 
            this.cbotemplate.FormattingEnabled = true;
            this.cbotemplate.Items.AddRange(new object[] {
            "compact",
            "compact_2",
            "qr_only",
            "print"});
            this.cbotemplate.Location = new System.Drawing.Point(763, 70);
            this.cbotemplate.Name = "cbotemplate";
            this.cbotemplate.Size = new System.Drawing.Size(206, 24);
            this.cbotemplate.TabIndex = 9;
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(450, 197);
            this.txtTenTaiKhoan.Multiline = true;
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(206, 36);
            this.txtTenTaiKhoan.TabIndex = 10;
            this.txtTenTaiKhoan.Text = "LE KHA VY";
            // 
            // txtSTK
            // 
            this.txtSTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTK.Location = new System.Drawing.Point(450, 70);
            this.txtSTK.Multiline = true;
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(206, 37);
            this.txtSTK.TabIndex = 11;
            this.txtSTK.Text = "070127036282";
            // 
            // txtThongTinThem
            // 
            this.txtThongTinThem.Location = new System.Drawing.Point(752, 196);
            this.txtThongTinThem.Multiline = true;
            this.txtThongTinThem.Name = "txtThongTinThem";
            this.txtThongTinThem.Size = new System.Drawing.Size(231, 37);
            this.txtThongTinThem.TabIndex = 12;
            this.txtThongTinThem.Text = "CHUYEN TIEN NHANH QUA QR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(445, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "VietQR Payment:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(699, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Template:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(614, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 307);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // nupSoTien
            // 
            this.nupSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupSoTien.Location = new System.Drawing.Point(134, 196);
            this.nupSoTien.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nupSoTien.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nupSoTien.Name = "nupSoTien";
            this.nupSoTien.Size = new System.Drawing.Size(173, 27);
            this.nupSoTien.TabIndex = 16;
            this.nupSoTien.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // frmVietQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(995, 591);
            this.Controls.Add(this.nupSoTien);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtThongTinThem);
            this.Controls.Add(this.txtSTK);
            this.Controls.Add(this.txtTenTaiKhoan);
            this.Controls.Add(this.cbotemplate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVietQR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbonganhang);
            this.Controls.Add(this.label1);
            this.Name = "frmVietQR";
            this.Text = "VietQR";
            this.Load += new System.EventHandler(this.frmVietQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSoTien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbonganhang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVietQR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbotemplate;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.TextBox txtSTK;
        private System.Windows.Forms.TextBox txtThongTinThem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nupSoTien;
    }
}