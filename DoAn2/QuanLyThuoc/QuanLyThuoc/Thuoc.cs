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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuoc
{
    public partial class frmThuoc : Form
    {
        private DataTable Thuoc;
        public frmThuoc()
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

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaThuoc.Enabled = false;
            btnLuu.Enabled = false;
            Functions.FillCombo("SELECT MaNCC, TenNCC FROM NhaCungCap", cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhomThuoc, TenNhomThuoc FROM  NhomThuoc", cboMaNhomThuoc, "MaNhomThuoc", "TenNhomThuoc");
            cboMaNhomThuoc.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaKho, TenKho FROM QLKho", cboMaKho, "MaKho", "TenKho");
            cboMaKho.SelectedIndex = -1;
            LoadDataGridView("SELECT MaThuoc,MaNCC,MaNhomThuoc,MaKho,TenThuoc,SoLuong,NuocSX,DVT,DonGiaNhap,DonGiaBan,GhiChu_Thuoc FROM Thuoc");
        }
        private void ResetValues()
        {
            txtMaThuoc.Text = "";
            txtTenThuoc.Text = "";
            cboMaNCC.Text = "";
            txtTenNCC.Text = "";
            cboMaNhomThuoc.Text = "";
            txtTenNhomThuoc.Text = "";
            cboMaKho.Text = "";
            txtTenKho.Text = "";
            txtSoLuong.Text = "0";
            txtDVT.Text = "";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtNuocSX.Enabled = true;
            txtDVT.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = true;
            txtGhiChu.Text = "";
        }
        private void LoadDataGridView(string t)
        {
            string sql = @"SELECT 
                        t.MaThuoc AS 'Mã thuốc', 
                        ncc.TenNCC AS 'Nhà cung cấp', 
                        nht.TenNhomThuoc AS 'Nhóm thuốc', 
                        kho.TenKho AS 'Kho', 
                        t.TenThuoc AS 'Tên thuốc', 
                        t.SoLuong AS 'Số lượng', 
                        t.NuocSX AS 'Nước sản xuất', 
                        t.DVT AS 'Đơn vị tính', 
                        t.DonGiaNhap AS 'Đơn giá nhập', 
                        t.DonGiaBan AS 'Đơn giá bán', 
                        t.GhiChu_Thuoc AS 'Ghi chú'
                   FROM Thuoc t
                   JOIN NhaCungCap ncc ON t.MaNCC = ncc.MaNCC
                   JOIN NhomThuoc nht ON t.MaNhomThuoc = nht.MaNhomThuoc
                   JOIN QLKho kho ON t.MaKho = kho.MaKho";

            DataTable Thuoc = Functions.GetData(sql);

            dgvThuoc.DataSource = Thuoc;

            // Cấu hình tiêu đề và độ rộng cột
            dgvThuoc.Columns[0].Width = 150; // Mã thuốc
            dgvThuoc.Columns[1].Width = 150; // Nhà cung cấp
            dgvThuoc.Columns[2].Width = 150; // Nhóm thuốc
            dgvThuoc.Columns[3].Width = 80; // Kho
            dgvThuoc.Columns[4].Width = 150; // Tên thuốc
            dgvThuoc.Columns[5].Width = 80; // Số lượng
            dgvThuoc.Columns[6].Width = 100; // Nước sản xuất
            dgvThuoc.Columns[7].Width = 100; // Đơn vị tính
            dgvThuoc.Columns[8].Width = 100; // Đơn giá nhập
            dgvThuoc.Columns[9].Width = 100; // Đơn giá bán
            dgvThuoc.Columns[10].Width = 150; // Ghi chú

            // Không cho phép thêm hoặc sửa trực tiếp trên DataGridView
            dgvThuoc.AllowUserToAddRows = false;
            dgvThuoc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThuoc.CurrentRow == null)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy dữ liệu từ DataGridView và hiển thị trên các TextBox/ComboBox
            txtMaThuoc.Text = dgvThuoc.CurrentRow.Cells["Mã thuốc"].Value.ToString();
            txtTenThuoc.Text = dgvThuoc.CurrentRow.Cells["Tên thuốc"].Value.ToString();
            cboMaNCC.Text = dgvThuoc.CurrentRow.Cells["Nhà cung cấp"].Value.ToString();
            cboMaNhomThuoc.Text = dgvThuoc.CurrentRow.Cells["Nhóm thuốc"].Value.ToString();
            cboMaKho.Text = dgvThuoc.CurrentRow.Cells["Kho"].Value.ToString();
            txtSoLuong.Text = dgvThuoc.CurrentRow.Cells["Số lượng"].Value.ToString();
            txtNuocSX.Text = dgvThuoc.CurrentRow.Cells["Nước sản xuất"].Value.ToString();
            txtDVT.Text = dgvThuoc.CurrentRow.Cells["Đơn vị tính"].Value.ToString();
            txtDonGiaNhap.Text = dgvThuoc.CurrentRow.Cells["Đơn giá nhập"].Value.ToString();
            txtDonGiaBan.Text = dgvThuoc.CurrentRow.Cells["Đơn giá bán"].Value.ToString();
            txtGhiChu.Text = dgvThuoc.CurrentRow.Cells["Ghi chú"].Value.ToString();

            // Kích hoạt các nút chức năng
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            DateTime now = DateTime.Now;
            ResetValues();
            txtMaThuoc.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtMaThuoc.Text = Functions.CreateKey("T_"); //Khóa sinh tự động
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenThuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenThuoc.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            if (cboMaNhomThuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhóm thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNhomThuoc.Focus();
                return;
            }
            if (cboMaKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaKho.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã thuốc chưa
            sql = "SELECT MaThuoc FROM Thuoc WHERE MaThuoc=N'" + txtMaThuoc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thuốc này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaThuoc.Focus();
                return;
            }

            sql = "INSERT INTO Thuoc(MaThuoc,TenThuoc,MaNCC,MaNhomThuoc,MaKho,SoLuong,NuocSX,DVT,DonGiaNhap,DonGiaBan,GhiChu_Thuoc) VALUES(N'"
                + txtMaThuoc.Text.Trim() + "',N'" + txtTenThuoc.Text.Trim() +
                "',N'" + cboMaNCC.SelectedValue.ToString() +
                "',N'" + cboMaNhomThuoc.SelectedValue.ToString() +
                "',N'" + cboMaKho.SelectedValue.ToString() +
                "',N'" + txtSoLuong.Text.Trim() + "',N'" + txtNuocSX.Text.Trim() +
                "',N'" + txtDVT.Text.Trim() + "',N'" + txtDonGiaNhap.Text +
                "',N'" + txtDonGiaBan.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView("SELECT MaThuoc,TenThuoc,MaNCC,MaNhomThuoc,MaKho,SoLuong,NuocSX,DVT,DonGiaNhap,DonGiaBan,GhiChu_Thuoc FROM Thuoc");
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaThuoc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (Thuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaThuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaThuoc.Focus();
                return;
            }
            if (txtTenThuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenThuoc.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            if (cboMaNhomThuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhóm thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNhomThuoc.Focus();
                return;
            }
            if (cboMaKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaKho.Focus();
                return;
            }

            // Lấy giá trị từ các control và thực hiện câu lệnh UPDATE
            sql = "UPDATE Thuoc SET TenThuoc=N'" + txtTenThuoc.Text.Trim() +
                "', MaNCC=N'" + cboMaNCC.SelectedValue.ToString() +
                "', MaNhomThuoc=N'" + cboMaNhomThuoc.SelectedValue.ToString() +
                "', MaKho=N'" + cboMaKho.SelectedValue.ToString() +
                "', SoLuong=N'" + txtSoLuong.Text +
                "', NuocSX=N'" + txtNuocSX.Text +
                "', DVT=N'" + txtDVT.Text +
                "', DonGiaBan=N'" + txtDonGiaBan.Text +
                "', DonGiaNhap=N'" + txtDonGiaNhap.Text +
                "', GhiChu_Thuoc=N'" + txtGhiChu.Text + "' WHERE MaThuoc=N'" + txtMaThuoc.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView("SELECT MaThuoc,TenThuoc,MaNCC,MaNhomThuoc,MaKho,SoLuong,NuocSX,DVT,DonGiaNhap,DonGiaBan,GhiChu_Thuoc FROM Thuoc");
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (Thuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaThuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Thuoc WHERE MaThuoc=N'" + txtMaThuoc.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView("SELECT MaThuoc,TenThuoc,MaNCC,MaNhomThuoc,MaKho,SoLuong,NuocSX,DVT,DonGiaNhap,DonGiaBan,GhiChu_Thuoc FROM Thuoc");
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaThuoc.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cboMaNCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
            }
            // Khi chọn mã nhà cung cấp thì các thông tin về nhà cung cấp hiện ra
            str = "Select MaNCC from NhaCungCap where TenNCC = N'" + cboMaNCC.SelectedValue + "'";
            txtTenNCC.Text = Functions.GetFieldValues(str);
        }

        private void cboMaNhomThuoc_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhomThuoc.Text == "")
            {
                txtTenNhomThuoc.Text = "";
            }
            // Khi chọn mã nhóm thuốc thì các thông tin về nhóm thuốc hiện ra
            str = "SELECT TenNhomThuoc FROM NhomThuoc WHERE MaNhomThuoc =N'" + cboMaNhomThuoc.SelectedValue + "'";
            txtTenNhomThuoc.Text = Functions.GetFieldValues(str);
        }

        private void cboMaKho_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKho.Text == "")
            {
                txtTenKho.Text = "";
            }
            // Khi chọn mã kho thì các thông tin về kho hiện ra
            str = "Select MaKho from QLKho where TenKho = N'" + cboMaKho.SelectedValue + "'";
            txtTenKho.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Where(c => !char.IsDigit(c)).Any())
            {
                MessageBox.Show("Vui lòng nhập số lượng bằng số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaThuoc.Text == "") && (txtTenThuoc.Text == "") && (cboMaKho.Text == "") && (cboMaNCC.Text == "") && (cboMaNhomThuoc.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Thuoc WHERE 1=1";
            if (txtMaThuoc.Text != "")
                sql += " AND MaThuoc LIKE N'%" + txtMaThuoc.Text + "%'";
            if (txtTenThuoc.Text != "")
                sql += " AND TenThuoc LIKE N'%" + txtTenThuoc.Text + "%'";
            if (cboMaKho.Text != "")
                sql += " AND MaNhomThuoc LIKE N'%" + cboMaKho.SelectedValue + "%'";
            if (cboMaNCC.Text != "")
                sql += " AND MaNCC LIKE N'%" + cboMaNCC.SelectedValue + "%'";
            if (cboMaNhomThuoc.Text != "")
                sql += " AND MaNhomThuoc LIKE N'%" + cboMaNhomThuoc.SelectedValue + "%'";
            Thuoc = Functions.GetData(sql);
            if (Thuoc.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + Thuoc.Rows.Count + "bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvThuoc.DataSource = Thuoc;
            ResetValues();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM Thuoc";
            Thuoc = Functions.GetData(sql);
            dgvThuoc.DataSource = Thuoc;
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTimKiemTT TimKiemTT = new frmTimKiemTT();
            TimKiemTT.ShowDialog();
            this.Close();
        }

        private void ExportToExcelWithoutSaving()
        {
            Excel.Application application = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Khởi tạo Excel
                application = new Excel.Application();
                workbook = application.Workbooks.Add(Type.Missing);// Tạo workbook mới.
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;// Lấy worksheet đang hoạt động.

                // Ghi tiêu đề cột từ DataGridView
                for (int i = 0; i < dgvThuoc.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvThuoc.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvThuoc.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThuoc.Columns.Count; j++)
                    {
                        if (dgvThuoc.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvThuoc.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
                        }
                    }
                }

                // Tự động căn chỉnh cột
                worksheet.Columns.AutoFit();

                // Hiển thị Excel
                application.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xuất dữ liệu ra Excel.\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Không giải phóng các đối tượng Excel tại đây vì ứng dụng cần chúng để hiển thị
                if (application != null)
                {
                    application.UserControl = true;
                }
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm ExportToExcelWithoutSaving
                ExportToExcelWithoutSaving();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu không thành công
                MessageBox.Show("Không thể xuất dữ liệu ra Excel.\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
