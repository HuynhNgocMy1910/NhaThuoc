using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyThuoc.CLass;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyThuoc
{
    public partial class frmNhanVien : Form
    {
        private DataTable NhanVien;
        public frmNhanVien()
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
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Functions.Connection();
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaNV,TenNV,NgaySinh,DiaChi_NV,SDT_NV,ChucVu,NgayVaoLam,GioiTinh,HinhAnh_NV FROM NhanVien";
            NhanVien = Functions.GetData(sql); //lấy dữ liệu
            dgvNhanVien.DataSource = NhanVien;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[3].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[6].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns[7].HeaderText = "Giới tính";
            dgvNhanVien.Columns[8].HeaderText = "Hình ảnh";
            dgvNhanVien.Columns[0].Width = 200;
            dgvNhanVien.Columns[1].Width = 200;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 200;
            dgvNhanVien.Columns[4].Width = 200;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 100;
            dgvNhanVien.Columns[7].Width = 100;
            dgvNhanVien.Columns[8].Width = 90;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["Ngaysinh"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["Diachi_NV"].Value.ToString();
            txtsdt.Text = dgvNhanVien.CurrentRow.Cells["SDT_NV"].Value.ToString();
            txtChucVu.Text = dgvNhanVien.CurrentRow.Cells["ChucVu"].Value.ToString();
            dtpNgayVaoLam.Text = dgvNhanVien.CurrentRow.Cells["NgayVaoLam"].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkNam.Checked = true;
            else chkNam.Checked = false;
            txtAnh.Text = dgvNhanVien.CurrentRow.Cells["HinhAnh_NV"].Value.ToString();
            picAnh.ImageLocation = Directory.GetCurrentDirectory() + dgvNhanVien.CurrentRow.Cells["HinhAnh_NV"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnHA_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho nhân viên";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
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
            txtMaNV.Text = Functions.CreateKey("NV_"); //Khóa sinh tự động
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            chkNam.Checked = false;
            txtDiaChi.Text = "";
            dtpNgaySinh.Text = "";
            txtsdt.Text = "";
            txtChucVu.Text = "";
            dtpNgayVaoLam.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (dtpNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (txtsdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return;
            }
            if (txtChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChucVu.Focus();
                return;
            }
            if (dtpNgayVaoLam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày vào làm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayVaoLam.Focus();
                DateTime dateTime = DateTime.Now;
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh cho nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHA.Focus();
                return;
            }
            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            //Kiểm tra đã tồn tại mã nhân viên chưa
            sql = "SELECT TenNV FROM NhanVien WHERE TenNV=N'" + txtTenNV.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tên nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                txtTenNV.Text = "";
                return;
            }
            if (picAnh.Image == null)
            {
                MessageBox.Show("Bạn phải thêm hình ảnh nhân viên", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHA.Focus();

                return;
            }  
            //Luu HA
            String MaNV = txtMaNV.Text.Trim();
            FileInfo fi = new FileInfo(txtAnh.Text);
            fi.CopyTo(Directory.GetCurrentDirectory() + @"\Data\PicNV\"
            + MaNV + Path.GetExtension(txtAnh.Text));

            string formattedDate = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string formattedDate1 = dtpNgayVaoLam.Value.ToString("yyyy-MM-dd");

            sql = "INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, DiaChi_NV, SDT_NV, ChucVu, NgayVaoLam, GioiTinh, HinhAnh_NV) VALUES (" +
                "N'" + txtMaNV.Text.Trim() + "', " +
                "N'" + txtTenNV.Text.Trim() + "', " +
                "'" + formattedDate + "', " +
                "N'" + txtDiaChi.Text.Trim() + "', " +
                "'" + txtsdt.Text.Trim() + "', " +
                "N'" + txtChucVu.Text.Trim() + "', " +
                "'" + formattedDate1 + "', " +
                "'" + gt + "', " + 
                "N'" + (@"\Data\PicNV\" + MaNV  + Path.GetExtension(txtAnh.Text)) + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }         
            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            string formattedDate = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string formattedDate1 = dtpNgayVaoLam.Value.ToString("yyyy-MM-dd");

            string MaNV = txtMaNV.Text.Trim();
            string imagePath = Directory.GetCurrentDirectory() + @"\Data\PicNV\" + MaNV + Path.GetExtension(txtAnh.Text);
            // kiểm tra ảnh cũ trong thư mục
            if (File.Exists(txtAnh.Text))
            {
                //Xóa hình ảnh cũ trong thư mục
                FileInfo fi = new FileInfo(txtAnh.Text);
                fi.CopyTo(imagePath, true);

            }          

            sql = "UPDATE NhanVien SET  TenNV=N'" + txtTenNV.Text.Trim().ToString() +
                "',NgaySinh=N'" + formattedDate +
                    "',DiaChi_NV=N'" + txtDiaChi.Text.Trim().ToString() +
                    "',SDT_NV='" + txtsdt.Text.ToString() + "'" +
                    ",ChucVu=N'" + txtChucVu.Text.Trim().ToString() +
                      "',NgayVaoLam=N'" +  formattedDate1 +
                      "',GioiTinh=N'" + gt +
                      "',HinhAnh_NV=N'" + (@"\Data\PicNV\" + MaNV + Path.GetExtension(txtAnh.Text)) +
                    "' WHERE MaNV=N'" + txtMaNV.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string MaNV = txtMaNV.Text;
                string image = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PicNV", MaNV + Path.GetExtension(txtAnh.Text));
                if (File.Exists(image))
                {
                    File.Delete(image); // xóa image 
                }
                sql = "DELETE NhanVien WHERE MaNV = N'" + txtMaNV.Text + "'";
                Functions.RunSQL(sql);              
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
            txtMaNV.Enabled = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void txtMaNV_KeyUp(object sender, KeyEventArgs e)
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
                // Nếu vượt quá 15 ký tự, cắt chuỗi lại thành 11 ký tự đầu tiên
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
                for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvNhanVien.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvNhanVien.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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
