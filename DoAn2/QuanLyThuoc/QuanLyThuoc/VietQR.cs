using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QuanLyThuoc
{
    public partial class frmVietQR : Form
    {
        public frmVietQR()
        {
            InitializeComponent();
        }

        private void btnVietQR_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin nhập vào
                if (string.IsNullOrWhiteSpace(txtSTK.Text))
                {
                    MessageBox.Show("Số tài khoản không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Giữ nguyên số tài khoản dưới dạng chuỗi
                var accountNo = txtSTK.Text.Trim();

                if (nupSoTien.Value <= 0)
                {
                    MessageBox.Show("Số tiền phải lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbonganhang.SelectedValue == null || !int.TryParse(cbonganhang.SelectedValue.ToString(), out int acqId))
                {
                    MessageBox.Show("Vui lòng chọn ngân hàng hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng yêu cầu API
                var apiRequest = new ApiRequest
                {
                    accountNo = accountNo, // Số tài khoản (dạng chuỗi, bảo toàn số 0)
                    accountName = txtTenTaiKhoan.Text, // Tên tài khoản
                    acqId = acqId, // Mã ngân hàng
                    amount = (int)nupSoTien.Value, // Số tiền
                    addInfo = txtThongTinThem.Text, // Thông tin thêm
                    format = "text", // Định dạng
                    template = cbotemplate.Text // Template (compact hoặc full)
                };

                // Chuyển đổi đối tượng sang JSON
                var jsonRequest = JsonConvert.SerializeObject(apiRequest);

                // Debug: In ra JSON gửi đi để kiểm tra
                Console.WriteLine("JSON Request gửi đến API:");
                Console.WriteLine(jsonRequest);

                // Gửi yêu cầu API
                var client = new RestClient("https://api.vietqr.io/v2/generate");
                var request = new RestRequest
                {
                    Method = Method.Post
                };
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

                var response = client.Execute(request);

                // Debug: In ra phản hồi từ API
                Console.WriteLine("Phản hồi từ API:");
                Console.WriteLine(response.Content);

                // Xử lý phản hồi từ API
                if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
                {
                    var dataResult = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                    if (dataResult?.data?.qrDataURL != null)
                    {
                        // Hiển thị ảnh QR
                        var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
                        pictureBox1.Image = image;
                    }
                    else
                    {
                        MessageBox.Show("Không nhận được dữ liệu QR từ API.", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Lỗi API: {response.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Image Base64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    return Image.FromStream(ms, true);
                }
            }
            catch
            {
                MessageBox.Show("Không thể chuyển đổi Base64 thành ảnh.", "Lỗi chuyển đổi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void frmVietQR_Load(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Tải danh sách ngân hàng
                    var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                    var bankRawJson = Encoding.UTF8.GetString(htmlData);
                    var listBankData = JsonConvert.DeserializeObject<Bank>(bankRawJson);

                    if (listBankData == null || listBankData.data == null)
                    {
                        MessageBox.Show("Không thể tải danh sách ngân hàng.", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Gán danh sách ngân hàng vào ComboBox
                    cbonganhang.DataSource = listBankData.data;
                    cbonganhang.DisplayMember = "custom_name";
                    cbonganhang.ValueMember = "bin";
                    cbonganhang.SelectedValue = listBankData.data.FirstOrDefault()?.bin; // Giá trị mặc định

                    // Gán template mặc định
                    cbotemplate.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách ngân hàng: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}
