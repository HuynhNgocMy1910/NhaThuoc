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
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuoc
{
    public partial class frmNhaCC : Form
    {
        DataTable NhaCungCap;
        public frmNhaCC()
        {
            InitializeComponent();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien NhanVien = new frmNhanVien();
            NhanVien.ShowDialog();
            this.Close();
        }

        private void btnKH_Click(object sender, EventArgs e)
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

        private void btnThuoc_Click(object sender, EventArgs e)
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

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaNCC.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from NhaCungCap";
            NhaCungCap = Functions.GetData(sql); //Lấy dữ liệu từ bảng
            dgvNhaCC.DataSource = NhaCungCap; //Hiển thị vào dataGridView
            dgvNhaCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNhaCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNhaCC.Columns[2].HeaderText = "Số điện thoại";
            dgvNhaCC.Columns[3].HeaderText = "Địa chỉ";
            dgvNhaCC.Columns[4].HeaderText = "Ghi chú";
            dgvNhaCC.Columns[0].Width = 200;
            dgvNhaCC.Columns[1].Width = 200;
            dgvNhaCC.Columns[2].Width = 200;
            dgvNhaCC.Columns[3].Width = 300;
            dgvNhaCC.Columns[4].Width = 200;
            dgvNhaCC.AllowUserToAddRows = false;
            dgvNhaCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNhaCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (NhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNCC.Text = dgvNhaCC.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNhaCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtsdt.Text = dgvNhaCC.CurrentRow.Cells["SDT_NCC"].Value.ToString();
            txtDiaChi.Text = dgvNhaCC.CurrentRow.Cells["DiaChi_NCC"].Value.ToString();
            txtGhiChu.Text = dgvNhaCC.CurrentRow.Cells["GhiChu_NCC"].Value.ToString();
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
            DateTime now = DateTime.Now;
            ResetValues();//Xoá trắng các textbox
            txtMaNCC.Focus();
            txtMaNCC.Text = Functions.CreateKey("NCC_"); //Khóa sinh tự động
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtsdt.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;           
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return;
            }
            if (txtsdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsdt.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }

            //Kiểm tra đã tồn tại mã NCC chưa
            sql = "SELECT MaNCC FROM NhaCungCap WHERE MaNCC=N'" + txtMaNCC.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO NhaCungCap(MaNCC,TenNCC,SDT_NCC,DiaChi_NCC,GhiChu_NCC) VALUES ('" +
            txtMaNCC.Text.Trim() + "', N'" + txtTenNCC.Text.Trim() + "'," +
            " '" + txtsdt.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', N'" + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return;
            }          

            sql = "UPDATE NhaCungCap SET TenNCC=N'" + txtTenNCC.Text.Trim().ToString() +
                    "',SDT_NCC='" + txtsdt.Text.ToString() +
                    "',DiaChi_NCC=N'" + txtDiaChi.Text.Trim().ToString() +
                    "',GhiChu_NCC=N'" + txtGhiChu.Text.Trim().ToString() +
                    "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NhaCungCap WHERE MaNCC=N'" + txtMaNCC.Text + "'";
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
            txtMaNCC.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMaNhaCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }


        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            if (txtsdt.Text.Length > 11)
            {
                // Nếu vượt quá 15 ký tự, cắt chuỗi lại thành 10 ký tự đầu tiên
                txtsdt.Text = txtsdt.Text.Substring(0, 11);
                // Đặt vị trí con trỏ vào cuối TextBox để người dùng có thể tiếp tục nhập
                txtsdt.SelectionStart = txtsdt.Text.Length;
                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Vui lòng nhập số điện thoại không quá 11 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txtsdt.Text.Where(c => !char.IsDigit(c)).Any())
            {
                MessageBox.Show("Vui lòng nhập số điện thoại bằng số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
                for (int i = 0; i < dgvNhaCC.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvNhaCC.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvNhaCC.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvNhaCC.Columns.Count; j++)
                    {
                        if (dgvNhaCC.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvNhaCC.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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
