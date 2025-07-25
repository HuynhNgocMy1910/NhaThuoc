using QuanLyThuoc.CLass;
using System;
using System.Windows.Forms;

namespace QuanLyThuoc
{
    public partial class frmIndex : Form
    {
        public frmIndex()
        {
            InitializeComponent();
        }
        private void Index_Load(object sender, EventArgs e)
        {
            //Functions.Connection();
        }
        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void nHÓMTHUỐCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhomThuoc frm = new frmNhomThuoc(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void tHUỐCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuoc frm = new frmThuoc(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }
        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCC frm = new frmNhaCC(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void hÓAĐƠNBÁNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }
        private void qUẢNLÝKHOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLKho frm = new frmQLKho(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void bÁOCÁODOANHTHUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frm = new frmBaoCaoDoanhThu(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }

        private void tHOÁTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tÌMKIẾMTHÔNGTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTT frm = new frmTimKiemTT(); //Khởi tạo đối tượng
            frm.Show(); //Hiển thị
        }
    }
}
