using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyThuoc.CLass;
using System.Globalization;
using COMExcel = Microsoft.Office.Interop.Excel; //thư viện để xuất sang Excel

namespace QuanLyThuoc
{
    public partial class frmHoaDonBan : Form
    {
        private DataTable HoaDonBan;
        public static string MaHD;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien NhanVien = new frmNhanVien();
            NhanVien.ShowDialog();
            this.Close();
        }

        private void btnkhachhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachHang KhachHang = new frmKhachHang();
            KhachHang.ShowDialog();
            this.Close();
        }

        private void btnNhomThuoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhomThuoc NhomThuoc = new frmNhomThuoc();
            NhomThuoc.ShowDialog();
            this.Close();
        }

        private void btnthuoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThuoc Thuoc = new frmThuoc();
            Thuoc.ShowDialog();
            this.Close();
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhaCC NhaCC = new frmNhaCC();
            NhaCC.ShowDialog();
            this.Close();
        }

        private void btnHDBan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDonBan HoaDonBan = new frmHoaDonBan();
            HoaDonBan.ShowDialog();
            this.Close();
        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLKho QLKho = new frmQLKho();
            QLKho.ShowDialog();
            this.Close();
        }


        private void btnBCDT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmBaoCaoDoanhThu BaoCaoDoanhThu = new frmBaoCaoDoanhThu();
            BaoCaoDoanhThu.ShowDialog();
            this.Close();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult Thoat = MessageBox.Show
                ("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Thoat == DialogResult.OK)
                Application.Exit();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtMaNV.ReadOnly = true;
            txtMaHD.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtTenThuoc.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            txtMaHD.Enabled = false;
            Functions.FillCombo("SELECT MaKH, TenKH FROM KhachHang", cboMaKH, "MaKH", "TenKH");
            cboMaKH.SelectedIndex = -1;
            Functions.FillCombo("SELECT  MaNV, TenNV FROM NhanVien", cboMaNV, "MaNV", "TenNV");
            cboMaNV.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaThuoc, TenThuoc FROM Thuoc", cboMaThuoc, "MaThuoc", "TenThuoc");
            cboMaThuoc.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHD.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadInfoHoaDon()
        {
            try
            {
                string sql = "SELECT NgayBan, MaNV, MaKH, TongTien FROM HoaDonBan WHERE MaHD = N'" + txtMaHD.Text + "'";
                DataTable data = Functions.GetData(sql);

                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    dtpNgayBan.Value = DateTime.Parse(row["NgayBan"].ToString());
                    cboMaNV.Text = row["MaNV"].ToString();
                    cboMaKH.Text = row["MaKH"].ToString();
                    txtTongTien.Text = row["TongTien"].ToString();

                    // Chuyển tổng tiền sang chữ
                    lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text));
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaThuoc, b.TenThuoc, a.SoLuong, b.DonGiaBan, a.GiamGia,a.ThanhTien FROM ChiTietHoaDon AS a, Thuoc AS b WHERE a.MaHD = N'" + txtMaHD.Text + "' AND a.MaThuoc=b.MaThuoc";
            HoaDonBan = Functions.GetData(sql);
            dgvHDBanHang.DataSource = HoaDonBan;
            dgvHDBanHang.Columns[0].HeaderText = "Mã thuốc";
            dgvHDBanHang.Columns[1].HeaderText = "Tên thuốc";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 200;
            dgvHDBanHang.Columns[1].Width = 200;
            dgvHDBanHang.Columns[2].Width = 200;
            dgvHDBanHang.Columns[3].Width = 200;
            dgvHDBanHang.Columns[4].Width = 200;
            dgvHDBanHang.Columns[5].Width = 200;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnBoQua.Enabled = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            DateTime now = DateTime.Now;
            ResetValues();
            txtMaHD.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHD.Text = "";
            dtpNgayBan.Text = "";
            cboMaNV.Text = "";
            cboMaKH.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaThuoc.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHD FROM HoaDonBan WHERE MaHD=N'" + txtMaHD.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNV.Focus();
                    return;
                }
                if (cboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKH.Focus();
                    return;
                }
                string formattedDate = dtpNgayBan.Value.ToString("yyyy-MM-dd");
                sql = "INSERT INTO HoaDonBan(MaHD, NgayBan, MaNV, MaKH, TongTien) VALUES " +
                    "(N'" + txtMaHD.Text.Trim() + "','" +
                        formattedDate+ "',N'" + cboMaNV.SelectedValue + "',N'" +
                        cboMaKH.SelectedValue + "'," + txtTongTien.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMaThuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaThuoc.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã thuốc chưa
            sql = "SELECT MaThuoc FROM ChiTietHoaDon WHERE MaThuoc=N'" + cboMaThuoc.SelectedValue + "' AND MaHD = N'" + txtMaHD.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thuốc này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaThuoc.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM Thuoc WHERE MaThuoc = N'" + cboMaThuoc.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietHoaDon(MaHD,MaThuoc,SoLuong,DonGia, GiamGia,ThanhTien) VALUES" +
                "(N'" + txtMaHD.Text.Trim() + "',N'" + cboMaThuoc.SelectedValue + "'," + txtSoLuong.Text + "," +
                "" + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng THUOC
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE Thuoc SET SoLuong =" + SLcon + " WHERE MaThuoc= N'" + cboMaThuoc.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHD = N'" + txtMaHD.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHD = N'" + txtMaHD.Text + "'";
            Functions.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));
            ResetValuesHang();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
            btnLuu.Enabled = true;
            txtMaHD.Enabled = false;
        }
        private void ResetValuesHang()
        {
            cboMaThuoc.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (HoaDonBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHDBanHang.CurrentRow.Cells["MaThuoc"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE ChiTietHoaDon WHERE MaHD=N'" + txtMaHD.Text + "' AND MaThuoc = N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM Thuoc WHERE MaThuoc = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE Thuoc SET SoLuong =" + slcon + " WHERE MaThuoc= N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHD = N'" + txtMaHD.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HoaDonBan SET TongTien =" + tongmoi + " WHERE MaHD = N'" + txtMaHD.Text + "'";
                Functions.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tongmoi.ToString()));
                LoadDataGridView();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaThuoc,SoLuong FROM ChiTietHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
                DataTable Thuoc = Functions.GetData(sql);
                for (int hang = 0; hang <= Thuoc.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM Thuoc WHERE MaThuoc = N'" + Thuoc.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(Thuoc.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE Thuoc SET SoLuong =" + slcon + " WHERE MaThuoc= N'" + Thuoc.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE ChiTietHoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE HoaDonBan WHERE MaHD=N'" + txtMaHD.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
                txtMaNV.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenNV from NhanVien where MaNV =N'" + cboMaNV.SelectedValue + "'";
            txtMaNV.Text = Functions.GetFieldValues(str);
        }
     
        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtMaKH.Text = "";
                txtDiaChi.Text = "";
                txtsdt.Text = "";
            }
            // Khi chọn mã khach hang thì các thông tin về khachs hang hiện ra
            str = "SELECT TenKH FROM KhachHang WHERE MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtMaKH.Text = Functions.GetFieldValues(str);
            str = "SELECT DiaChi_KH FROM KhachHang WHERE MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            str = "SELECT SDT_KH FROM KhachHang WHERE MaKH =N'" + cboMaKH.SelectedValue + "'";
            txtsdt.Text = Functions.GetFieldValues(str);
        }

        private void cboMaThuoc_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaThuoc.Text == "")
            {
                txtTenThuoc.Text = "";
                txtDonGia.Text = "";
            }
            // Khi chọn mã thuốc thì các thông tin về thuốc hiện ra
            str = "SELECT TenThuoc FROM Thuoc WHERE MaThuoc =N'" + cboMaThuoc.SelectedValue + "'";
            txtTenThuoc.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGiaBan FROM Thuoc WHERE MaThuoc =N'" + cboMaThuoc.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Lấy mã hóa đơn từ giao diện
            Functions.MaHD = txtMaHD.Text;
            MaHD = txtMaHD.Text;

            // Hiển thị hộp thoại để chọn loại xuất
            var result = MessageBox.Show(
                "Bạn muốn in hóa đơn dạng nào?\nYes: Excel\nNo: Report",
                "Chọn loại in",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // Chọn xuất Excel
            {
                ExportToExcel(MaHD);
            }
            else if (result == DialogResult.No) // Chọn in Report
            {
                Form f = new frmReport();
                f.Show();
                f.Focus();
            }
            else
            {
                // Người dùng hủy hành động
                MessageBox.Show("Bạn đã hủy thao tác in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToExcel(string maHD)
        {
            // Khởi tạo đối tượng COM Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];
            COMExcel.Range exRange;

            string sql;
            int hang = 0;

            // Lấy thông tin chung của hóa đơn
            sql = "SELECT a.MaHD, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi_KH, b.SDT_KH, c.TenNV " +
                  "FROM HoaDonBan AS a " +
                  "JOIN KhachHang AS b ON a.MaKH = b.MaKH " +
                  "JOIN NhanVien AS c ON a.MaNV = c.MaNV " +
                  "WHERE a.MaHD = N'" + maHD + "'";
            DataTable tblThongTinHD = Functions.GetData(sql);

            // Lấy thông tin chi tiết hóa đơn
            sql = "SELECT b.TenThuoc, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien " +
                  "FROM ChiTietHoaDon AS a " +
                  "JOIN Thuoc AS b ON a.MaThuoc = b.MaThuoc " +
                  "WHERE a.MaHD = N'" + maHD + "'";
            DataTable tblThongTinHang = Functions.GetData(sql);

            // Tiêu đề hóa đơn
            exRange = exSheet.Range["A1:F1"];
            exRange.MergeCells = true;
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "HÓA ĐƠN BÁN THUỐC";

            // Thông tin chung của hóa đơn
            exSheet.Range["A3"].Value = "Mã Hóa Đơn:";
            exSheet.Range["B3"].Value = tblThongTinHD.Rows[0][0].ToString();

            exSheet.Range["A4"].Value = "Khách Hàng:";
            exSheet.Range["B4"].Value = tblThongTinHD.Rows[0][3].ToString();

            exSheet.Range["A5"].Value = "Địa Chỉ:";
            exSheet.Range["B5"].Value = tblThongTinHD.Rows[0][4].ToString();

            exSheet.Range["A6"].Value = "Số Điện Thoại:";
            exSheet.Range["B6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft; // Align B6
            exSheet.Range["B6"].Value = tblThongTinHD.Rows[0][5].ToString();

            exSheet.Range["A7"].Value = "Nhân Viên Bán Hàng:";
            exSheet.Range["B7"].Value = tblThongTinHD.Rows[0][6].ToString();

            // Tiêu đề chi tiết hóa đơn
            exSheet.Range["A10"].Value = "STT";
            exSheet.Range["B10"].Value = "Tên Thuốc";
            exSheet.Range["C10"].Value = "Số Lượng";
            exSheet.Range["D10"].Value = "Đơn Giá";
            exSheet.Range["E10"].Value = "Giảm Giá";
            exSheet.Range["F10"].Value = "Thành Tiền";

            exSheet.Range["A10:F10"].Font.Bold = true;
            exSheet.Range["A10:F10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // Tự động điều chỉnh độ rộng cột A và B
            exSheet.Columns["A"].AutoFit();
            exSheet.Columns["B"].AutoFit();
            exSheet.Columns["C"].AutoFit();
            exSheet.Columns["D"].AutoFit();
            exSheet.Columns["E"].AutoFit();
            exSheet.Columns["F"].AutoFit();
            // Điền dữ liệu chi tiết hóa đơn
            for (hang = 0; hang < tblThongTinHang.Rows.Count; hang++)
            {
                int currentRow = 11 + hang; // Bắt đầu từ dòng 11

                exSheet.Cells[currentRow, 1] = hang + 1; // STT
                exSheet.Cells[currentRow, 2] = tblThongTinHang.Rows[hang][0].ToString(); // Tên Thuốc
                exSheet.Cells[currentRow, 3] = tblThongTinHang.Rows[hang][1].ToString(); // Số Lượng
                exSheet.Cells[currentRow, 4] = tblThongTinHang.Rows[hang][2].ToString(); // Đơn Giá
                exSheet.Cells[currentRow, 5] = tblThongTinHang.Rows[hang][3].ToString(); // Giảm Giá
                exSheet.Cells[currentRow, 6] = tblThongTinHang.Rows[hang][4].ToString(); // Thành Tiền
            }
            // Căn giữa tất cả các dòng dữ liệu từ 11 đến dòng cuối cùng
            int lastRow = 11 + tblThongTinHang.Rows.Count;
            exSheet.Range["A11:F" + lastRow].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Range["A11:F" + lastRow].VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;

            // Thêm dòng "Bằng chữ"
            int rowBangChu = 11 + tblThongTinHang.Rows.Count + 1; // Dòng ngay sau chi tiết hóa đơn
            exSheet.Range["E" + rowBangChu].MergeCells = true;
            exSheet.Range["E" + rowBangChu].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongTinHD.Rows[0][2].ToString());

            // Tổng tiền
            int rowTongTien = rowBangChu + 1;
            exSheet.Range["E" + rowTongTien].Font.Bold = true;
            exSheet.Range["E" + rowTongTien].Value = "Tổng Tiền:";
            exSheet.Range["F" + rowTongTien].Font.Bold = true;
            exSheet.Range["F" + rowTongTien].Value = tblThongTinHD.Rows[0][2].ToString();

            // Hiển thị Excel
            exSheet.Name = "HoaDonBan";
            exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHD.Focus();
                return;
            }
            txtMaHD.Text = cboMaHD.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMaHD.SelectedIndex = -1;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHD FROM HoaDonBan", cboMaHD, "MaHD", "MaHD");
            cboMaHD.SelectedIndex = -1;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHD.Enabled = false;
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTimKiemTT TimKiemTT = new frmTimKiemTT();
            TimKiemTT.ShowDialog();
            this.Close();
        }
    }
}