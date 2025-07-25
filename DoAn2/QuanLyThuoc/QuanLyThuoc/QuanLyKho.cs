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
    public partial class frmQLKho : Form
    {
        DataTable QLKho;
        public frmQLKho()
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

        private void frmQLKho_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaKho.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from QLKho";
            QLKho = Functions.GetData(sql); //Lấy dữ liệu từ bảng
            dgvQLKho.DataSource = QLKho; //Hiển thị vào dataGridView
            dgvQLKho.Columns[0].HeaderText = "Mã kho";
            dgvQLKho.Columns[1].HeaderText = "Tên kho";
            dgvQLKho.Columns[2].HeaderText = "Ngày nhập";
            dgvQLKho.Columns[3].HeaderText = "Ngày xuất";
            dgvQLKho.Columns[4].HeaderText = "Ghi chú";
            dgvQLKho.Columns[0].Width = 200;
            dgvQLKho.Columns[1].Width = 200;
            dgvQLKho.Columns[2].Width = 200;
            dgvQLKho.Columns[3].Width = 200;
            dgvQLKho.Columns[4].Width = 200;
            dgvQLKho.AllowUserToAddRows = false;
            dgvQLKho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvQLKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKho.Focus();
                return;
            }
            if (QLKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKho.Text = dgvQLKho.CurrentRow.Cells["MaKho"].Value.ToString();
            txtTenKho.Text = dgvQLKho.CurrentRow.Cells["TenKho"].Value.ToString();
            dtpNgayNhap.Text = dgvQLKho.CurrentRow.Cells["NgayNhap"].Value.ToString();
            dtpNgayXuat.Text = dgvQLKho.CurrentRow.Cells["NgayXuat"].Value.ToString();
            txtGhiChu.Text = dgvQLKho.CurrentRow.Cells["GhiChu_Kho"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();//Xoá trắng các textbox
            DateTime now = DateTime.Now;
            txtMaKho.Focus();
            txtMaKho.Text = Functions.CreateKey("QLK_"); //Khóa sinh tự động
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaKho.Text = "";
            txtTenKho.Text = "";
            dtpNgayNhap.Text = "";
            dtpNgayXuat.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKho.Focus();
                return;
            }
            if (dtpNgayNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                DateTime dateTime = DateTime.Now;
                dtpNgayNhap.Focus();
                return;
            }
            if (dtpNgayXuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DateTime dateTime = DateTime.Now;
                dtpNgayXuat.Focus();
                return;
            }

            //Kiểm tra đã tồn tại mã kho chưa
            sql = "SELECT MaKho FROM QLKho WHERE MaKho=N'" + txtMaKho.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã kho này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKho.Focus();
                return;
            }
            string formattedDate = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            string formattedDate1 = dtpNgayXuat.Value.ToString("yyyy-MM-dd");
            //Chèn thêm
            sql = "INSERT INTO QLKho(MaKho,TenKho,NgayNhap,NgayXuat,GhiChu_Kho) VALUES ('" +
            txtMaKho.Text.Trim() + "', N'" + txtTenKho.Text.Trim() + "'," +
            " '" + formattedDate + "', N'" + formattedDate1 + "', N'" + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKho.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (QLKho.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKho.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKho.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKho.Focus();
                return;
            }

            string formattedDate = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            string formattedDate1 = dtpNgayXuat.Value.ToString("yyyy-MM-dd");
            string MaKho = Functions.CreateKey("QLKho");
            sql = "UPDATE QLKho SET  TenKho=N'" + txtTenKho.Text.Trim().ToString() +
                    "NgayNhap = '" + formattedDate.Trim() + "', " +
                    "NgayXuat = '" + formattedDate1.Trim() + "', " +
                    "',GhiChu_Kho=N'" + txtGhiChu.Text.Trim().ToString() +
                    "' WHERE MaKho=N'" + txtMaKho.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (QLKho.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE QLKho WHERE MaKho=N'" + txtMaKho.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKho.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMaKho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
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
                for (int i = 0; i < dgvQLKho.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvQLKho.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvQLKho.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvQLKho.Columns.Count; j++)
                    {
                        if (dgvQLKho.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvQLKho.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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
