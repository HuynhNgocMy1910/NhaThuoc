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

    public partial class frmKhachHang : Form
    {
         DataTable KhachHang;
        public frmKhachHang()
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

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaKH.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from KhachHang";
            KhachHang = Functions.GetData(sql); //Lấy dữ liệu từ bảng
            dgvKhachHang.DataSource = KhachHang; //Hiển thị vào dataGridView
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Số Điện thoại";
            dgvKhachHang.Columns[3].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[4].HeaderText = "Giới tính";
            dgvKhachHang.Columns[0].Width = 200;
            dgvKhachHang.Columns[1].Width = 200;
            dgvKhachHang.Columns[2].Width = 200;
            dgvKhachHang.Columns[3].Width = 200;
            dgvKhachHang.Columns[4].Width = 200;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtsdt.Text = dgvKhachHang.CurrentRow.Cells["SDT_KH"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi_KH"].Value.ToString();
            if (dgvKhachHang.CurrentRow.Cells["GioiTinh_KH"].Value.ToString() == "Nam") chkNam.Checked = true;
            else chkNam.Checked = false;
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
            ResetValues();
            txtMaKH.Focus();
            txtMaKH.Text = Functions.CreateKey("KH_"); //Khóa sinh tự động
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            chkNam.Checked = false;
            txtDiaChi.Text = "";
            txtsdt.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
           
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
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
            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtMaKH.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO KhachHang(MaKH,TenKH,SDT_KH,DiaChi_KH,GioiTinh_KH) VALUES ('" +
             txtMaKH.Text.Trim() + "', N'" + txtTenKH.Text.Trim() + "', '" + txtsdt.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', N'" + gt + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKH.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE KhachHang SET  TenKH=N'" + txtTenKH.Text.Trim().ToString() +
                    "',SDT_KH='" + txtsdt.Text.ToString() +
                    "',DiaChi_KH=N'" + txtDiaChi.Text.Trim().ToString() +
                    "',GioiTinh_KH=N'" + gt +
                    "' WHERE MaKH=N'" + txtMaKH.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KhachHang WHERE MaKH=N'" + txtMaKH.Text + "'";
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
            txtMaKH.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMaKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNam.Checked)
            {
                chkNu.Checked = false;
            }
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
            {
                chkNam.Checked = false;
            }
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            if (txtsdt.Text.Length > 11)
            {
                // Nếu vượt quá 11 ký tự, cắt chuỗi lại thành 10 ký tự đầu tiên
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
                for (int i = 0; i < dgvKhachHang.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvKhachHang.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvKhachHang.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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
