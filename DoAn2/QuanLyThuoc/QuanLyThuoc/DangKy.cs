using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyThuoc.CLass;

namespace QuanLyThuoc
{
    public partial class frmDangKy : Form
    {
        private bool isPasswordVisible = false; // Mặc định là ẩn mật khẩu
        public frmDangKy()
        {
            InitializeComponent();
            btnPassW.Text = "Ẩn"; // Đặt giá trị mặc định cho nút
        }
        public static string GenerateSHA512(string input)
        {
            using (SHA512 sha512 = SHA512.Create()) // Tạo đối tượng SHA-512
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input); // Chuyển chuỗi thành byte
                byte[] hashBytes = sha512.ComputeHash(inputBytes); // Tính toán băm SHA-512

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Chuyển từng byte thành chuỗi hex
                }

                return builder.ToString(); // Trả về chuỗi băm SHA-512
            }
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ giao diện
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string xacNhanMatKhau = txtXNMK.Text.Trim();

            // Kiểm tra xem người dùng đã nhập thông tin chưa
            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(xacNhanMatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản, mật khẩu và xác nhận mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu
            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mã hóa tài khoản và mật khẩu
            string taikhoanHash = GenerateSHA512(taiKhoan);
            string matKhauHash = GenerateSHA512(matKhau);

            // Gọi hàm kết nối từ Functions
            Functions.Connection();

            // Kiểm tra kết nối
            if (Functions.Con.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem tài khoản đã tồn tại chưa
            string checkSql = "SELECT COUNT(*) FROM Admin WHERE TaiKhoan = @TaiKhoan";
            using (SqlCommand checkCommand = new SqlCommand(checkSql, Functions.Con))
            {
                checkCommand.Parameters.AddWithValue("@TaiKhoan", taikhoanHash); // Sử dụng tài khoản mã hóa
                int exists = (int)checkCommand.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại, vui lòng chọn tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Thêm tài khoản mới
            string insertSql = "INSERT INTO Admin (TaiKhoan, MatKhau) VALUES (@TaiKhoan, @MatKhau)";
            using (SqlCommand insertCommand = new SqlCommand(insertSql, Functions.Con))
            {
                insertCommand.Parameters.AddWithValue("@TaiKhoan", taikhoanHash);
                insertCommand.Parameters.AddWithValue("@MatKhau", matKhauHash);

                int rowsAffected = insertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hiển thị form đăng nhập
                    frmAdmin Admin = new frmAdmin();
                    Admin.Show();

                    // Đóng form đăng ký
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPassW_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Ẩn mật khẩu
                txtXNMK.UseSystemPasswordChar = true;
                txtMatKhau.UseSystemPasswordChar = true; // Bật chế độ mật khẩu
                btnPassW.Text = "Hiển thị";              // Cập nhật nút
            }
            else
            {
                // Hiển thị mật khẩu
                txtXNMK.UseSystemPasswordChar = false; // Tắt chế độ mật khẩu
                txtMatKhau.UseSystemPasswordChar = false; // Tắt chế độ mật khẩu
                btnPassW.Text = "Ẩn";                  // Cập nhật nút
            }

            // Đảo trạng thái hiển thị mật khẩu
            isPasswordVisible = !isPasswordVisible;
        }
    }   
}
