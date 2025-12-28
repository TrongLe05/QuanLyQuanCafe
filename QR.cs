using Newtonsoft.Json; // Thư viện xử lý JSON
using Newtonsoft.Json.Linq; // Thư viện xử lý JObject
using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyQuanCafe
{
    public partial class QR : Form
    {
        // --- CẤU HÌNH KEY (Thay key của bạn vào đây) ---
        private const string CLIENT_ID = "6fdd9ed4-ca46-4105-9b73-650c6d4c4c47";
        private const string API_KEY = "fd49eee3-f9c3-462a-a254-c1d064f88856";
        private const string CHECKSUM_KEY = "13dd6694f147f2ac7726e1e3b8fd873223e10465fef61eea0a12ecc5e08ff10a";

        // Khai báo biến toàn cục để lưu dữ liệu truyền từ Home sang
        private bool _isChecking = false;
        private double _amount;      // Biến lưu số tiền
        private string _description; // Biến lưu tên bàn

        // Constructor nhận tham số (SỬA LỖI CS1729)
        public QR(double amount, string description)
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Gán dữ liệu vào biến toàn cục
            this._amount = amount;
            this._description = description;
        }

        private async void QR_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa điền Key
            if (CLIENT_ID.Contains("CUA_BAN"))
            {
                MessageBox.Show("Bạn chưa điền API Key trong file QR.cs!", "Lỗi cấu hình");
                this.Close();
                return;
            }

            // Gọi hàm tạo QR
            await CreateAndCheckQR();
        }

        private async Task CreateAndCheckQR()
        {
            try
            {
                // 1. Tạo mã đơn hàng ngẫu nhiên theo thời gian
                long orderCode = long.Parse(DateTime.Now.ToString("yyMMddHHmmss"));

                // 2. Tạo mã QR từ PayOS
                // (int)_amount: Ép kiểu double về int vì PayOS yêu cầu số nguyên
                string qrContent = await CreatePaymentLinkManual(orderCode, (int)_amount, _description);

                if (!string.IsNullOrEmpty(qrContent))
                {
                    // Hiển thị mã QR lên PictureBox (Đảm bảo bên Design bạn đã có picQR)
                    ShowQrOnForm(qrContent);

                    // 3. Bắt đầu kiểm tra trạng thái thanh toán
                    _isChecking = true;
                    await CheckPaymentStatusManual(orderCode);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tạo được mã QR. Kiểm tra kết nối mạng hoặc API Key.", "Lỗi");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}");
                this.Close();
            }
        }

        private async Task CheckPaymentStatusManual(long orderCode)
        {
            while (_isChecking)
            {
                try
                {
                    if (this.IsDisposed || !this.Visible) return;

                    using (var client = new HttpClient())
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api-merchant.payos.vn/v2/payment-requests/{orderCode}");
                        request.Headers.Add("x-client-id", CLIENT_ID);
                        request.Headers.Add("x-api-key", API_KEY);

                        var response = await client.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();
                            var jsonResponse = JObject.Parse(responseString);
                            string status = jsonResponse["data"]?["status"]?.ToString();

                            if (status == "PAID")
                            {
                                _isChecking = false;
                                MessageBox.Show("Thanh toán thành công!", "Thông báo");

                                // Trả về kết quả OK để Form Home biết đường lưu bill
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                return;
                            }
                            else if (status == "CANCELLED")
                            {
                                _isChecking = false;
                                MessageBox.Show("Giao dịch đã bị hủy.");
                                this.Close();
                                return;
                            }
                        }
                    }
                }
                catch { }

                await Task.Delay(2000); // Đợi 2 giây rồi check tiếp
            }
        }

        private async Task<string> CreatePaymentLinkManual(long orderCode, int amount, string description)
        {
            try
            {
                // Xử lý chuỗi tên bàn (bỏ dấu tiếng Việt nếu cần, ở đây thêm prefix)
                string cleanDesc = "Thanh toan " + description.Replace(" ", "");
                // Giới hạn độ dài description nếu quá dài (PayOS giới hạn ký tự)
                if (cleanDesc.Length > 25) cleanDesc = cleanDesc.Substring(0, 25);

                string cancelUrl = "http://localhost/cancel";
                string returnUrl = "http://localhost/success";

                // Tạo chữ ký bảo mật
                string signatureData = $"amount={amount}&cancelUrl={cancelUrl}&description={cleanDesc}&orderCode={orderCode}&returnUrl={returnUrl}";
                string signature = ComputeHmacSha256(signatureData, CHECKSUM_KEY);

                var payload = new
                {
                    orderCode = orderCode,
                    amount = amount,
                    description = cleanDesc,
                    cancelUrl = cancelUrl,
                    returnUrl = returnUrl,
                    signature = signature
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);

                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://api-merchant.payos.vn/v2/payment-requests");
                    request.Headers.Add("x-client-id", CLIENT_ID);
                    request.Headers.Add("x-api-key", API_KEY);
                    request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var response = await client.SendAsync(request);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = JObject.Parse(responseString);
                        return jsonResponse["data"]?["qrCode"]?.ToString();
                    }
                    return null;
                }
            }
            catch { return null; }
        }

        private void ShowQrOnForm(string qrContent)
        {
            try
            {
                // Sử dụng API của qrserver để tạo ảnh QR code
                string qrApiUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=300x300&margin=10&data={Uri.EscapeDataString(qrContent)}";
                picQR.Load(qrApiUrl); // Đảm bảo PictureBox tên là picQR
                picQR.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private string ComputeHmacSha256(string data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isChecking = false;
            base.OnFormClosing(e);
        }
    }
}