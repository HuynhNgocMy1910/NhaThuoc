using Microsoft.Reporting.WinForms;
using QuanLyThuoc.CLass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QuanLyThuoc
{
    public partial class frmReport : Form
    {
        //Khai báo biến toàn cục 
        SqlConnection conn; //Nối kết đến SQL, khai báo đối tượng conn 
        //SqlDataAdapter myAdapter;
        DataSet dSet;
        public frmReport()
        {

            InitializeComponent();
            dSet = new DataSet(); // Khởi tạo dSet ở đây
        }      
        private void frmReport_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-CKDHHJ1\\KHAVY;Initial Catalog=QLThuoc;Integrated Security=True";
            conn.Open();
            DataSet1 dataSet = new DataSet1();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT top 1 KhachHang.TenKH, KhachHang.SDT_KH, KhachHang.DiaChi_KH, KhachHang.GioiTinh_KH, NhanVien.TenNV, HoaDonBan.MaHD, HoaDonBan.NgayBan, HoaDonBan.TongTien FROM " +
                "KhachHang INNER JOIN HoaDonBan ON KhachHang.MaKH = HoaDonBan.MaKH INNER JOIN NhanVien ON HoaDonBan.MaNV = NhanVien.MaNV WHERE HoaDonBan.MaHD = '" + Functions.MaHD + "'", conn);
            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Thuoc.TenThuoc, ChiTietHoaDon.SoLuong, ChiTietHoaDon.DonGia, ChiTietHoaDon.GiamGia, ChiTietHoaDon.ThanhTien " +
                "FROM ChiTietHoaDon INNER JOIN Thuoc ON ChiTietHoaDon.MaThuoc = Thuoc.MaThuoc WHERE ChiTietHoaDon.MaHD = '" + Functions.MaHD + "'", conn);
            //Nạp dữ liệu lên dataGridview 
            adapter.Fill(dataSet.DataTable2);
            adapter2.Fill(dataSet.DataTable1);

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;// Chế độ xử lý Local.
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;// Zoom theo tỷ lệ phần trăm.
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyThuoc.Report1.rdlc";// Nguồn báo cáo nhúng.
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);// Hiển thị ở chế độ bố cục in.

            // Kiểm tra xem DataSet có dữ liệu không trước khi thêm vào ReportDataSource

            ReportDataSource rds = new ReportDataSource();
                rds.Name = dataSet.DataTable2.TableName;
                rds.Value = dataSet.DataTable2; // Thay đổi tên bảng ở đây
                ReportDataSource rds2 = new ReportDataSource();
                rds2.Name = dataSet.DataTable1.TableName;
                rds2.Value = dataSet.DataTable1; // Thay đổi tên bảng ở đây
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.DataSources.Add(rds2);
                reportViewer1.RefreshReport();           
        }
    }
}
