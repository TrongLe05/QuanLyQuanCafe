using System;
using System.Linq; // Thư viện LINQ
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography; // Thư viện MD5

namespace QuanLyQuanCafe
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            // Focus vào ô nhập tên tài khoản khi mở form
            if (txt_Username != null)
                txt_Username.Focus();
        }

        // Sự kiện click nút Đăng Ký (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txt_Username.Text;
            string pass = txt_Password.Text;
            string confirmPass = txt_RePassword.Text;

            // 1. Kiểm tra dữ liệu đầu vào (Validation)
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!pass.Equals(confirmPass))
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi hàm xử lý đăng ký
            // Mình truyền userName vào làm displayName mặc định luôn
            if (RegisterAccount(userName, userName, pass))
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form đăng ký
            }
            else
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại! Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM XỬ LÝ LOGIC (DATABASE & MÃ HÓA)
        private bool RegisterAccount(string user, string displayName, string pass)
        {
            try
            {
                // LƯU Ý: Kiểm tra tên class kết nối (QLQCafeEntities hay QuanLyQuanCafeEntities?)
                using (QLQCafeEntities db = new QLQCafeEntities())
                {
                    // LƯU Ý: Kiểm tra tên bảng (db.Account hay db.Accounts?)
                    var checkExist = db.Account.Any(x => x.UserName == user);

                    if (checkExist)
                    {
                        return false; // Đã tồn tại
                    }

                    // Tạo tài khoản mới
                    Account newAcc = new Account();
                    newAcc.UserName = user;

                    // QUAN TRỌNG: Phải có DisplayName để tránh lỗi DB
                    newAcc.DisplayName = displayName;

                    // Mã hóa mật khẩu
                    newAcc.Password = GetMD5(pass);

                    newAcc.Type = 0; // 0: Staff

                    // Lưu vào Database
                    db.Account.Add(newAcc);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                return false;
            }
        }

        // HÀM MÃ HÓA MD5
        private string GetMD5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        // Nút Thoát (Nếu có)
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}