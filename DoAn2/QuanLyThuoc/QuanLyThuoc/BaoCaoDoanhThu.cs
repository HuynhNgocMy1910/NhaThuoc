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
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuoc
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

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

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo kết nối
                Functions.Connection();

                // Lấy ngày bắt đầu và kết thúc
                DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
                DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
                int nguongSapHet = 10; // Ngưỡng thuốc sắp hết

                // Khởi tạo DataTable để hiển thị kết hợp trên dgvBCDT
                DataTable combinedData = new DataTable();
                combinedData.Columns.Add("Loại Thông Tin");
                combinedData.Columns.Add("Chi Tiết");
                combinedData.Columns.Add("Giá Trị");

                // Lấy dữ liệu doanh thu
                string sqlDoanhThu = @"SELECT NgayBan, SUM(TongTien) AS DoanhThu 
                               FROM HoaDonBan 
                               WHERE NgayBan BETWEEN @ngayBatDau AND @ngayKetThuc 
                               GROUP BY NgayBan 
                               ORDER BY NgayBan";

                DataTable dtDoanhThu = new DataTable();
                using (SqlCommand cmdDoanhThu = new SqlCommand(sqlDoanhThu, Functions.Con))
                {
                    cmdDoanhThu.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
                    cmdDoanhThu.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmdDoanhThu))
                    {
                        da.Fill(dtDoanhThu);
                    }

                    // Tính tổng doanh thu và hiển thị trên label
                    decimal tongDoanhThu = 0;
                    foreach (DataRow row in dtDoanhThu.Rows)
                    {
                        tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                        combinedData.Rows.Add("Doanh thu", row["NgayBan"], row["DoanhThu"]);
                    }
                    lblTongDoanhThu.Text = "Tổng doanh thu: " + tongDoanhThu.ToString("N2") + " VND";
                }

                // Lấy thuốc bán nhiều nhất
                string sqlThuocBanNhieuNhat = @"SELECT TOP 1 
                                        ChiTietHoaDon.MaThuoc, 
                                        Thuoc.TenThuoc, 
                                        SUM(ChiTietHoaDon.SoLuong) AS SoLuongBan
                                        FROM ChiTietHoaDon 
                                        JOIN HoaDonBan ON ChiTietHoaDon.MaHD = HoaDonBan.MaHD
                                        JOIN Thuoc ON ChiTietHoaDon.MaThuoc = Thuoc.MaThuoc
                                        WHERE HoaDonBan.NgayBan BETWEEN @ngayBatDau AND @ngayKetThuc
                                        GROUP BY ChiTietHoaDon.MaThuoc, Thuoc.TenThuoc
                                        ORDER BY SoLuongBan DESC";

                using (SqlCommand cmdThuocBanNhieuNhat = new SqlCommand(sqlThuocBanNhieuNhat, Functions.Con))
                {
                    cmdThuocBanNhieuNhat.Parameters.AddWithValue("@ngayBatDau", ngayBatDau);
                    cmdThuocBanNhieuNhat.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmdThuocBanNhieuNhat))
                    {
                        DataTable dtThuoc = new DataTable();
                        da.Fill(dtThuoc);

                        if (dtThuoc.Rows.Count > 0)
                        {
                            DataRow topRow = dtThuoc.Rows[0];
                            lblThuocBanNhieuNhat.Text = $"Thuốc bán nhiều nhất:\n- {topRow["TenThuoc"]} ({topRow["SoLuongBan"]} sản phẩm)";
                            combinedData.Rows.Add("Thuốc bán nhiều nhất", topRow["TenThuoc"], $"{topRow["SoLuongBan"]} sản phẩm");
                        }
                        else
                        {
                            lblThuocBanNhieuNhat.Text = "Thuốc bán nhiều nhất:\n- Không có dữ liệu.";
                        }
                    }
                }

                // Lấy thuốc sắp hết
                string sqlThuocSapHet = @"SELECT MaThuoc, TenThuoc, SoLuong 
                                  FROM Thuoc 
                                  WHERE SoLuong <= @nguongSapHet 
                                  ORDER BY SoLuong ASC";

                using (SqlCommand cmdThuocSapHet = new SqlCommand(sqlThuocSapHet, Functions.Con))
                {
                    cmdThuocSapHet.Parameters.AddWithValue("@nguongSapHet", nguongSapHet);

                    using (SqlDataAdapter daThuocSapHet = new SqlDataAdapter(cmdThuocSapHet))
                    {
                        DataTable dtThuocSapHet = new DataTable();
                        daThuocSapHet.Fill(dtThuocSapHet);

                        if (dtThuocSapHet.Rows.Count > 0)
                        {
                            StringBuilder sapHetInfo = new StringBuilder("Thuốc sắp hết:\n");
                            foreach (DataRow row in dtThuocSapHet.Rows)
                            {
                                combinedData.Rows.Add("Thuốc sắp hết", row["TenThuoc"], $"{row["SoLuong"]} sản phẩm");
                                sapHetInfo.AppendLine($"- {row["TenThuoc"]} (Còn lại: {row["SoLuong"]} sản phẩm)");
                            }
                            lblThuocSapHet.Text = sapHetInfo.ToString();
                        }
                        else
                        {
                            lblThuocSapHet.Text = "Thuốc sắp hết:\n- Không có loại thuốc nào.";
                        }
                    }
                }

                // Hiển thị dữ liệu trong DataGridView
                dgvBCDT.DataSource = combinedData;

                // Hiển thị biểu đồ doanh thu
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Series.Add("Doanh Thu");
                chartDoanhThu.Series["Doanh Thu"].ChartType = SeriesChartType.Column;
                chartDoanhThu.Series["Doanh Thu"].XValueType = ChartValueType.Date;

                chartDoanhThu.DataSource = dtDoanhThu;
                chartDoanhThu.Series["Doanh Thu"].XValueMember = "NgayBan";
                chartDoanhThu.Series["Doanh Thu"].YValueMembers = "DoanhThu";
                chartDoanhThu.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Functions.Disconnect();
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
                for (int i = 0; i < dgvBCDT.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvBCDT.Columns[i].HeaderText;// Ghi tiêu đề cột từ DataGridView.
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvBCDT.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvBCDT.Columns.Count; j++)
                    {
                        if (dgvBCDT.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvBCDT.Rows[i].Cells[j].Value.ToString();// Ghi dữ liệu từ DataGridView vào Excel.
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

