namespace QuanLyThuoc
{
    partial class frmNhomThuoc
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMaNhomThuoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvNhomThuoc = new System.Windows.Forms.DataGridView();
            this.txtTenNhomThuoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiemTT = new System.Windows.Forms.Button();
            this.btnNhaCC = new System.Windows.Forms.Button();
            this.btnQLKho = new System.Windows.Forms.Button();
            this.btnHDBan = new System.Windows.Forms.Button();
            this.btnthuoc = new System.Windows.Forms.Button();
            this.btnNhomThuoc = new System.Windows.Forms.Button();
            this.btnkhachhang = new System.Windows.Forms.Button();
            this.btnnhanvien = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBCDT = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomThuoc)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.btnIn);
            this.panel3.Controls.Add(this.btnBoQua);
            this.panel3.Controls.Add(this.btnDong);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.txtMaNhomThuoc);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dgvNhomThuoc);
            this.panel3.Controls.Add(this.txtTenNhomThuoc);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(211, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 871);
            this.panel3.TabIndex = 7;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = global::QuanLyThuoc.Properties.Resources._in;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(685, 205);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(226, 57);
            this.btnIn.TabIndex = 88;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Image = global::QuanLyThuoc.Properties.Resources.boqua;
            this.btnBoQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua.Location = new System.Drawing.Point(627, 299);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(169, 58);
            this.btnBoQua.TabIndex = 34;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = global::QuanLyThuoc.Properties.Resources.close;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(826, 299);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(124, 58);
            this.btnDong.TabIndex = 33;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::QuanLyThuoc.Properties.Resources.luu;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(474, 299);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(124, 58);
            this.btnLuu.TabIndex = 32;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QuanLyThuoc.Properties.Resources.sua;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(315, 299);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 58);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QuanLyThuoc.Properties.Resources.xoa;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(156, 299);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 58);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa\r\n";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QuanLyThuoc.Properties.Resources.add;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(7, 299);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(125, 58);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMaNhomThuoc
            // 
            this.txtMaNhomThuoc.Location = new System.Drawing.Point(333, 106);
            this.txtMaNhomThuoc.Multiline = true;
            this.txtMaNhomThuoc.Name = "txtMaNhomThuoc";
            this.txtMaNhomThuoc.Size = new System.Drawing.Size(216, 30);
            this.txtMaNhomThuoc.TabIndex = 26;
            this.txtMaNhomThuoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaNhomThuoc_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Thông tin nhóm thuốc";
            // 
            // dgvNhomThuoc
            // 
            this.dgvNhomThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhomThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomThuoc.Location = new System.Drawing.Point(20, 420);
            this.dgvNhomThuoc.Name = "dgvNhomThuoc";
            this.dgvNhomThuoc.RowHeadersWidth = 51;
            this.dgvNhomThuoc.RowTemplate.Height = 24;
            this.dgvNhomThuoc.Size = new System.Drawing.Size(910, 448);
            this.dgvNhomThuoc.TabIndex = 22;
            this.dgvNhomThuoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhomThuoc_CellContentClick);
            // 
            // txtTenNhomThuoc
            // 
            this.txtTenNhomThuoc.Location = new System.Drawing.Point(333, 181);
            this.txtTenNhomThuoc.Multiline = true;
            this.txtTenNhomThuoc.Name = "txtTenNhomThuoc";
            this.txtTenNhomThuoc.Size = new System.Drawing.Size(216, 38);
            this.txtTenNhomThuoc.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Thông tin cơ bản";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Mã nhóm thuốc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(217, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 29);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tên nhóm thuốc";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(211, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 49);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhóm thuốc";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnTimKiemTT);
            this.panel1.Controls.Add(this.btnNhaCC);
            this.panel1.Controls.Add(this.btnQLKho);
            this.panel1.Controls.Add(this.btnHDBan);
            this.panel1.Controls.Add(this.btnthuoc);
            this.panel1.Controls.Add(this.btnNhomThuoc);
            this.panel1.Controls.Add(this.btnkhachhang);
            this.panel1.Controls.Add(this.btnnhanvien);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnBCDT);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 920);
            this.panel1.TabIndex = 5;
            // 
            // btnTimKiemTT
            // 
            this.btnTimKiemTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTT.Location = new System.Drawing.Point(12, 781);
            this.btnTimKiemTT.Name = "btnTimKiemTT";
            this.btnTimKiemTT.Size = new System.Drawing.Size(184, 52);
            this.btnTimKiemTT.TabIndex = 88;
            this.btnTimKiemTT.Text = "TÌM KIẾM THÔNG TIN";
            this.btnTimKiemTT.UseVisualStyleBackColor = true;
            this.btnTimKiemTT.Click += new System.EventHandler(this.btnTimKiemTT_Click);
            // 
            // btnNhaCC
            // 
            this.btnNhaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCC.Location = new System.Drawing.Point(12, 458);
            this.btnNhaCC.Name = "btnNhaCC";
            this.btnNhaCC.Size = new System.Drawing.Size(191, 52);
            this.btnNhaCC.TabIndex = 24;
            this.btnNhaCC.Text = "NHÀ CUNG CẤP";
            this.btnNhaCC.UseVisualStyleBackColor = true;
            this.btnNhaCC.Click += new System.EventHandler(this.btnNhaCC_Click);
            // 
            // btnQLKho
            // 
            this.btnQLKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKho.Location = new System.Drawing.Point(12, 539);
            this.btnQLKho.Name = "btnQLKho";
            this.btnQLKho.Size = new System.Drawing.Size(191, 52);
            this.btnQLKho.TabIndex = 22;
            this.btnQLKho.Text = "QUẢN LÝ KHO";
            this.btnQLKho.UseVisualStyleBackColor = true;
            this.btnQLKho.Click += new System.EventHandler(this.btnQLKho_Click);
            // 
            // btnHDBan
            // 
            this.btnHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDBan.Location = new System.Drawing.Point(12, 621);
            this.btnHDBan.Name = "btnHDBan";
            this.btnHDBan.Size = new System.Drawing.Size(191, 52);
            this.btnHDBan.TabIndex = 21;
            this.btnHDBan.Text = "HÓA ĐƠN BÁN";
            this.btnHDBan.UseVisualStyleBackColor = true;
            this.btnHDBan.Click += new System.EventHandler(this.btnHDBan_Click);
            // 
            // btnthuoc
            // 
            this.btnthuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthuoc.Location = new System.Drawing.Point(12, 380);
            this.btnthuoc.Name = "btnthuoc";
            this.btnthuoc.Size = new System.Drawing.Size(191, 52);
            this.btnthuoc.TabIndex = 17;
            this.btnthuoc.Text = "THUỐC";
            this.btnthuoc.UseVisualStyleBackColor = true;
            this.btnthuoc.Click += new System.EventHandler(this.btnthuoc_Click);
            // 
            // btnNhomThuoc
            // 
            this.btnNhomThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhomThuoc.Location = new System.Drawing.Point(12, 296);
            this.btnNhomThuoc.Name = "btnNhomThuoc";
            this.btnNhomThuoc.Size = new System.Drawing.Size(191, 52);
            this.btnNhomThuoc.TabIndex = 18;
            this.btnNhomThuoc.Text = "NHÓM THUỐC";
            this.btnNhomThuoc.UseVisualStyleBackColor = true;
            this.btnNhomThuoc.Click += new System.EventHandler(this.btnNhomThuoc_Click);
            // 
            // btnkhachhang
            // 
            this.btnkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkhachhang.Location = new System.Drawing.Point(12, 214);
            this.btnkhachhang.Name = "btnkhachhang";
            this.btnkhachhang.Size = new System.Drawing.Size(191, 52);
            this.btnkhachhang.TabIndex = 19;
            this.btnkhachhang.Text = "KHÁCH HÀNG";
            this.btnkhachhang.UseVisualStyleBackColor = true;
            this.btnkhachhang.Click += new System.EventHandler(this.btnkhachhang_Click);
            // 
            // btnnhanvien
            // 
            this.btnnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhanvien.Location = new System.Drawing.Point(12, 139);
            this.btnnhanvien.Name = "btnnhanvien";
            this.btnnhanvien.Size = new System.Drawing.Size(191, 52);
            this.btnnhanvien.TabIndex = 16;
            this.btnnhanvien.Text = "NHÂN VIÊN";
            this.btnnhanvien.UseVisualStyleBackColor = true;
            this.btnnhanvien.Click += new System.EventHandler(this.btnnhanvien_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyThuoc.Properties.Resources.c98ce598170b3099562b1e1d3e79ede6;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnBCDT
            // 
            this.btnBCDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCDT.Location = new System.Drawing.Point(12, 704);
            this.btnBCDT.Name = "btnBCDT";
            this.btnBCDT.Size = new System.Drawing.Size(188, 52);
            this.btnBCDT.TabIndex = 12;
            this.btnBCDT.Text = "BÁO CÁO DOANH THU";
            this.btnBCDT.UseVisualStyleBackColor = true;
            this.btnBCDT.Click += new System.EventHandler(this.btnBCDT_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(12, 855);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(188, 52);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmNhomThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 916);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmNhomThuoc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NHÓM THUỐC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhomThuoc_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomThuoc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvNhomThuoc;
        private System.Windows.Forms.TextBox txtTenNhomThuoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMaNhomThuoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnNhaCC;
        private System.Windows.Forms.Button btnQLKho;
        private System.Windows.Forms.Button btnHDBan;
        private System.Windows.Forms.Button btnthuoc;
        private System.Windows.Forms.Button btnNhomThuoc;
        private System.Windows.Forms.Button btnkhachhang;
        private System.Windows.Forms.Button btnnhanvien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnBCDT;
        private System.Windows.Forms.Button btnTimKiemTT;
        private System.Windows.Forms.Button btnIn;
    }
}