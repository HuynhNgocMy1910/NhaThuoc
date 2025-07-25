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
    public partial class frmNhomThuoc : Form
    {
        private DataTable NhomThuoc;
        public frmNhomThuoc()
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

        private void frmNhomThuoc_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaNhomThuoc.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaNhomThuoc, TenNhomThuoc FROM NhomThuoc";
            NhomThuoc = Functions.GetData(sql); //Đọc dữ liệu từ bảng
            dgvNhomThuoc.DataSource = NhomThuoc; //Nguồn dữ liệu            
            dgvNhomThuoc.Columns[0].HeaderText = "Mã nhóm thuốc";
            dgvNhomThuoc.Columns[1].HeaderText = "Tên nhóm thuốc";
            dgvNhomThuoc.Columns[0].Width = 300;
            dgvNhomThuoc.Columns[1].Width = 300;
            dgvNhomThuoc.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhomThuoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNhomThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhomThuoc.Focus();
                return;
            }
            if (NhomThuoc.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhomThuoc.Text = dgvNhomThuoc.CurrentRow.Cells["MaNhomThuoc"].Value.ToString();
            txtTenNhomThuoc.Text = dgvNhomThuoc.CurrentRow.Cells["TenNhomThuoc"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            DateTime now = DateTime.Now;
            ResetValue(); //Xoá trắng các textbox
            txtMaNhomThuoc.Focus();
            txtMaNhomThuoc.Text = Functions.CreateKey("NT_"); //Khóa sinh tự động
            LoadDataGridView();
        }
        private void ResetValue()
        {
            txtMaNhomThuoc.Text = "";
            txtTenNhomThuoc.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtTenNhomThuoc.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên nhóm thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhomThuoc.Focus();
                return;
            }

            //Kiểm tra đã tồn tại mã nhóm thuốc chưa
            sql = "Select MaNhomThuoc FROM NhomThuoc where MaNhomThuoc=N'" + txtMaNhomThuoc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhóm thuốc này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhomThuoc.Focus();
                return;
            }

            sql = "INSERT INTO NhomThuoc VALUES(N'" + txtMaNhomThuoc.Text + "',N'" + txtTenNhomThuoc.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhomThuoc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NhomThuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhomThuoc.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhomThuoc.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên nhóm thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NhomThuoc SET TenNhomThuoc=N'" + txtTenNhomThuoc.Text.ToString() + "' WHERE MaNhomThuoc=N'" + txtMaNhomThuoc.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            txtMaNhomThuoc.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhomThuoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhomThuoc.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NhomThuoc WHERE MaNhomThuoc=N'" + txtMaNhomThuoc.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhomThuoc.Enabled = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMaNhomThuoc_KeyUp(object sender, KeyEventArgs e)
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
                for (int i = 0; i < dgvNhomThuoc.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvNhomThuoc.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvNhomThuoc.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvNhomThuoc.Columns.Count; j++)
                    {
                        if (dgvNhomThuoc.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvNhomThuoc.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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
