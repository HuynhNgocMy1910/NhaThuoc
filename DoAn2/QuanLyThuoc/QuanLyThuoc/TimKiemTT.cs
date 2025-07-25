using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QuanLyThuoc.CLass; //Sử dụng class Functions.cs
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuoc
{
    public partial class frmTimKiemTT : Form
    {
        DataTable HoaDonBan;
        public frmTimKiemTT()
        {
            InitializeComponent();
        }

        private void TimKiemTT_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemTT.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Functions.Connection(); // Đảm bảo kết nối được khởi tạo
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaNV.Text == "") && (txtMaKH.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HoaDonBan WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MaHD Like N'%" + txtMaHDBan.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (txtMaNV.Text != "")
                sql = sql + " AND MaNV Like N'%" + txtMaNV.Text + "%'";
            if (txtMaKH.Text != "")
                sql = sql + " AND MaKH Like N'%" + txtMaKH.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TongTien <=" + txtTongTien.Text;
            HoaDonBan = Functions.GetData(sql);
            if (HoaDonBan.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + HoaDonBan.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiemTT.DataSource = HoaDonBan;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTimKiemTT.Columns[0].HeaderText = "Mã hóa đơn bán";
            dgvTimKiemTT.Columns[1].HeaderText = "Mã nhân viên";
            dgvTimKiemTT.Columns[2].HeaderText = "Mã khách hàng";
            dgvTimKiemTT.Columns[3].HeaderText = "Ngày bán";
            dgvTimKiemTT.Columns[4].HeaderText = "Tổng tiền";
            dgvTimKiemTT.Columns[0].Width = 280;
            dgvTimKiemTT.Columns[1].Width = 280;
            dgvTimKiemTT.Columns[2].Width = 280;
            dgvTimKiemTT.Columns[3].Width = 280;
            dgvTimKiemTT.Columns[4].Width = 200;
            dgvTimKiemTT.EnableHeadersVisualStyles = false;
            dgvTimKiemTT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTimKiemTT.AllowUserToAddRows = false;
            dgvTimKiemTT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemTT.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTimKiemTT TimKiemTT = new frmTimKiemTT();
            TimKiemTT.ShowDialog();
            this.Close();
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
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                workbook = application.Workbooks.Add(Type.Missing); // Tạo workbook mới.
                worksheet = (Excel.Worksheet)workbook.ActiveSheet; // Lấy worksheet đang hoạt động.

                // Ghi tiêu đề cột từ DataGridView
                for (int i = 0; i < dgvTimKiemTT.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvTimKiemTT.Columns[i].HeaderText; // Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvTimKiemTT.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTimKiemTT.Columns.Count; j++)
                    {
                        if (dgvTimKiemTT.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvTimKiemTT.Rows[i].Cells[j].Value.ToString();  // Ghi dữ liệu từ DataGridView vào Excel.
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
