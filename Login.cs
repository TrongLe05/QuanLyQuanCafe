using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // [QUAN TRỌNG] Thư viện để dùng MD5

namespace QuanLyQuanCafe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            string userName = txt_Username.Text;
            string passWord = txt_Password.Text;

            if (Login_check(userName, passWord))
            {
                // Đăng nhập thành công
                Home f = new Home(); // Form1 là cái form quản lý bàn cafe chính
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool Login_check(string userName, string passWord)
        {
            // 1. Mã hóa mật khẩu người dùng vừa nhập thành MD5
            string hashPass = GetMD5(passWord);

            // 2. Kết nối Database và so sánh
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // So sánh UserName VÀ Mật khẩu đã mã hóa (hashPass)
                var result = db.Account
                               .Where(p => p.UserName == userName && p.Password == hashPass)
                               .FirstOrDefault();

                return result != null;
            }
        }

        // HÀM MÃ HÓA MD5 (Giống hệt bên form SignUp)
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

        // Nút chuyển sang màn hình Đăng ký
        private void button1_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}