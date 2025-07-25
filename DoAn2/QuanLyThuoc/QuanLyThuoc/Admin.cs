using Microsoft.ReportingServices.Diagnostics.Internal;
using QuanLyThuoc.CLass;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuoc
{
    public partial class frmAdmin : Form
    {
        private bool isPasswordVisible = false; // Mặc định là ẩn mật khẩu
        public frmAdmin()
        {
            InitializeComponent();
            btnPassW.Text = "Ẩn"; // Đặt giá trị mặc định cho nút
        }
        // Hàm mã hóa SHA512
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string taiKhoan = txtTaiKhoan.Text; 
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mã hóa tài khoản và mật khẩu bằng SHA512
            string taiKhoanHash = GenerateSHA512(taiKhoan);
            string matKhauHash = GenerateSHA512(matKhau);

            // Đảm bảo kết nối
            Functions.Connection(); // Gọi hàm Connection để mở kết nối và sử dụng biến tĩnh Con

            {
                try
                {
                    string sql = "SELECT MatKhau FROM Admin WHERE TaiKhoan = @TaiKhoan";
                    using (SqlCommand command = new SqlCommand(sql, Functions.Con)) // Sử dụng Functions.Con
                    {
                        // Gán tham số mã hóa
                        command.Parameters.AddWithValue("@TaiKhoan", taiKhoanHash);

                        object result = command.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string storedPassword = result.ToString();

                        if (storedPassword == matKhauHash)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmIndex frmIndex = new frmIndex();
                            frmIndex.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;  // Cancel closing if user chooses No
            }
        }
   

        private void btnPassW_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Ẩn mật khẩu
                txtMatKhau.UseSystemPasswordChar = true; // Bật chế độ mật khẩu
                btnPassW.Text = "Hiển thị";              // Cập nhật nút
            }
            else
            {
                // Hiển thị mật khẩu
                txtMatKhau.UseSystemPasswordChar = false; // Tắt chế độ mật khẩu
                btnPassW.Text = "Ẩn";                     // Cập nhật nút
            }

            // Đảo trạng thái hiển thị mật khẩu
            isPasswordVisible = !isPasswordVisible;
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            frmDangKy dangKy = new frmDangKy();
            dangKy.Show();
            this.Hide();
        }
    }
    }

