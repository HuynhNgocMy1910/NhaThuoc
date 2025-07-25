namespace QuanLyThuoc
{
    partial class frmBaoCaoDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimKiemTT = new System.Windows.Forms.Button();
            this.btnNhaCC = new System.Windows.Forms.Button();
            this.btnQLKho = new System.Windows.Forms.Button();
            this.btnBCDT = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHDBan = new System.Windows.Forms.Button();
            this.btnThuoc = new System.Windows.Forms.Button();
            this.btnNhomThuoc = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblThuocSapHet = new System.Windows.Forms.Label();
            this.lblThuocBanNhieuNhat = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dgvBCDT = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.btnXemKQ = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCDT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnTimKiemTT);
            this.panel1.Controls.Add(this.btnNhaCC);
            this.panel1.Controls.Add(this.btnQLKho);
            this.panel1.Controls.Add(this.btnBCDT);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnHDBan);
            this.panel1.Controls.Add(this.btnThuoc);
            this.panel1.Controls.Add(this.btnNhomThuoc);
            this.panel1.Controls.Add(this.btnKH);
            this.panel1.Controls.Add(this.btnNV);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 895);
            this.panel1.TabIndex = 14;
            // 
            // btnTimKiemTT
            // 
            this.btnTimKiemTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTT.Location = new System.Drawing.Point(9, 757);
            this.btnTimKiemTT.Name = "btnTimKiemTT";
            this.btnTimKiemTT.Size = new System.Drawing.Size(184, 52);
            this.btnTimKiemTT.TabIndex = 16;
            this.btnTimKiemTT.Text = "TÌM KIẾM THÔNG TIN";
            this.btnTimKiemTT.UseVisualStyleBackColor = true;
            this.btnTimKiemTT.Click += new System.EventHandler(this.btnTimKiemTT_Click);
            // 
            // btnNhaCC
            // 
            this.btnNhaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCC.Location = new System.Drawing.Point(9, 448);
            this.btnNhaCC.Name = "btnNhaCC";
            this.btnNhaCC.Size = new System.Drawing.Size(184, 52);
            this.btnNhaCC.TabIndex = 14;
            this.btnNhaCC.Text = "NHÀ CUNG CẤP";
            this.btnNhaCC.UseVisualStyleBackColor = true;
            this.btnNhaCC.Click += new System.EventHandler(this.btnNhaCC_Click);
            // 
            // btnQLKho
            // 
            this.btnQLKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKho.Location = new System.Drawing.Point(9, 529);
            this.btnQLKho.Name = "btnQLKho";
            this.btnQLKho.Size = new System.Drawing.Size(184, 52);
            this.btnQLKho.TabIndex = 13;
            this.btnQLKho.Text = "QUẢN LÝ KHO";
            this.btnQLKho.UseVisualStyleBackColor = true;
            this.btnQLKho.Click += new System.EventHandler(this.btnQLKho_Click);
            // 
            // btnBCDT
            // 
            this.btnBCDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCDT.Location = new System.Drawing.Point(9, 682);
            this.btnBCDT.Name = "btnBCDT";
            this.btnBCDT.Size = new System.Drawing.Size(184, 52);
            this.btnBCDT.TabIndex = 12;
            this.btnBCDT.Text = "BÁO CÁO DOANH THU";
            this.btnBCDT.UseVisualStyleBackColor = true;
            this.btnBCDT.Click += new System.EventHandler(this.btnBCDT_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(9, 827);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(184, 52);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHDBan
            // 
            this.btnHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDBan.Location = new System.Drawing.Point(9, 606);
            this.btnHDBan.Name = "btnHDBan";
            this.btnHDBan.Size = new System.Drawing.Size(184, 52);
            this.btnHDBan.TabIndex = 6;
            this.btnHDBan.Text = "HÓA ĐƠN BÁN";
            this.btnHDBan.UseVisualStyleBackColor = true;
            this.btnHDBan.Click += new System.EventHandler(this.btnHDBan_Click);
            // 
            // btnThuoc
            // 
            this.btnThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuoc.Location = new System.Drawing.Point(9, 367);
            this.btnThuoc.Name = "btnThuoc";
            this.btnThuoc.Size = new System.Drawing.Size(184, 52);
            this.btnThuoc.TabIndex = 2;
            this.btnThuoc.Text = "THUỐC";
            this.btnThuoc.UseVisualStyleBackColor = true;
            this.btnThuoc.Click += new System.EventHandler(this.btnThuoc_Click);
            // 
            // btnNhomThuoc
            // 
            this.btnNhomThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhomThuoc.Location = new System.Drawing.Point(9, 283);
            this.btnNhomThuoc.Name = "btnNhomThuoc";
            this.btnNhomThuoc.Size = new System.Drawing.Size(184, 52);
            this.btnNhomThuoc.TabIndex = 3;
            this.btnNhomThuoc.Text = "NHÓM THUỐC";
            this.btnNhomThuoc.UseVisualStyleBackColor = true;
            this.btnNhomThuoc.Click += new System.EventHandler(this.btnNhomThuoc_Click);
            // 
            // btnKH
            // 
            this.btnKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.Location = new System.Drawing.Point(9, 210);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(184, 52);
            this.btnKH.TabIndex = 4;
            this.btnKH.Text = "KHÁCH HÀNG";
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnNV
            // 
            this.btnNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.Location = new System.Drawing.Point(9, 138);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(184, 52);
            this.btnNV.TabIndex = 1;
            this.btnNV.Text = "NHÂN VIÊN";
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyThuoc.Properties.Resources.c98ce598170b3099562b1e1d3e79ede6;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Báo cáo doanh thu";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(214, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 49);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.lblThuocSapHet);
            this.panel3.Controls.Add(this.lblThuocBanNhieuNhat);
            this.panel3.Controls.Add(this.btnIn);
            this.panel3.Controls.Add(this.chartDoanhThu);
            this.panel3.Controls.Add(this.lblTongDoanhThu);
            this.panel3.Controls.Add(this.dgvBCDT);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.dtpNgayKetThuc);
            this.panel3.Controls.Add(this.dtpNgayBatDau);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnXemKQ);
            this.panel3.Location = new System.Drawing.Point(214, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 846);
            this.panel3.TabIndex = 16;
            // 
            // lblThuocSapHet
            // 
            this.lblThuocSapHet.AutoSize = true;
            this.lblThuocSapHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuocSapHet.Location = new System.Drawing.Point(7, 243);
            this.lblThuocSapHet.Name = "lblThuocSapHet";
            this.lblThuocSapHet.Size = new System.Drawing.Size(171, 29);
            this.lblThuocSapHet.TabIndex = 60;
            this.lblThuocSapHet.Text = "Thuốc sắp hết:";
            // 
            // lblThuocBanNhieuNhat
            // 
            this.lblThuocBanNhieuNhat.AutoSize = true;
            this.lblThuocBanNhieuNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuocBanNhieuNhat.Location = new System.Drawing.Point(7, 161);
            this.lblThuocBanNhieuNhat.Name = "lblThuocBanNhieuNhat";
            this.lblThuocBanNhieuNhat.Size = new System.Drawing.Size(249, 29);
            this.lblThuocBanNhieuNhat.TabIndex = 59;
            this.lblThuocBanNhieuNhat.Text = "Thuốc bán nhiều nhất:";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = global::QuanLyThuoc.Properties.Resources._in;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(280, 374);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(224, 57);
            this.btnIn.TabIndex = 58;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend3);
            this.chartDoanhThu.Location = new System.Drawing.Point(510, 22);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDoanhThu.Series.Add(series3);
            this.chartDoanhThu.Size = new System.Drawing.Size(436, 409);
            this.chartDoanhThu.TabIndex = 57;
            this.chartDoanhThu.Text = "chart1";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(7, 333);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(187, 29);
            this.lblTongDoanhThu.TabIndex = 56;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // dgvBCDT
            // 
            this.dgvBCDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBCDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCDT.Location = new System.Drawing.Point(7, 456);
            this.dgvBCDT.Name = "dgvBCDT";
            this.dgvBCDT.RowHeadersWidth = 51;
            this.dgvBCDT.RowTemplate.Height = 24;
            this.dgvBCDT.Size = new System.Drawing.Size(930, 383);
            this.dgvBCDT.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 54;
            this.label2.Text = "Đến ngày:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 29);
            this.label10.TabIndex = 53;
            this.label10.Text = "Từ ngày:";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(148, 84);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(318, 34);
            this.dtpNgayKetThuc.TabIndex = 36;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(148, 22);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpNgayBatDau.Size = new System.Drawing.Size(318, 34);
            this.dtpNgayBatDau.TabIndex = 35;
            // 
            // btnXemKQ
            // 
            this.btnXemKQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemKQ.Image = global::QuanLyThuoc.Properties.Resources.xemkq;
            this.btnXemKQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemKQ.Location = new System.Drawing.Point(12, 374);
            this.btnXemKQ.Name = "btnXemKQ";
            this.btnXemKQ.Size = new System.Drawing.Size(225, 57);
            this.btnXemKQ.TabIndex = 19;
            this.btnXemKQ.Text = "Xem kết quả";
            this.btnXemKQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemKQ.UseVisualStyleBackColor = true;
            this.btnXemKQ.Click += new System.EventHandler(this.btnXemKQ_Click);
            // 
            // frmBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 892);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "frmBaoCaoDoanhThu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BÁO CÁO DOANH THU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCDT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBCDT;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHDBan;
        private System.Windows.Forms.Button btnThuoc;
        private System.Windows.Forms.Button btnNhomThuoc;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXemKQ;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnQLKho;
        private System.Windows.Forms.Button btnNhaCC;
        private System.Windows.Forms.DataGridView dgvBCDT;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Button btnTimKiemTT;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lblThuocBanNhieuNhat;
        private System.Windows.Forms.Label lblThuocSapHet;
    }
}