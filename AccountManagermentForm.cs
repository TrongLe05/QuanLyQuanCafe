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

namespace QuanLyQuanCafe
{
    public partial class AccountManagermentForm : UserControl
    {
        public AccountManagermentForm()
        {
            InitializeComponent();
        }

        private void accountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLQCafeDataSet);

        }

        private void AccountManagermentForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load dữ liệu Food
                this.accountTableAdapter.Fill(this.qLQCafeDataSet.Account);
                accountBindingSource.Sort = "Username ASC";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string passWord = GetMD5(txtPassword.Text);
            int type = 0;
            string displayName;
            if (Int32.Parse(txtType.Text) == 1)
            {
                displayName = "Quản trị viên";
            }
            else
            {
                displayName = "Nhân viên";
            }
                using (QLQCafeEntities db = new QLQCafeEntities())
                {
                    // Kiểm tra tài khoản đã tồn tại chưa
                    var checkAccount = db.Accounts
                                            .Where(p => p.UserName == userName)
                                            .FirstOrDefault();
                    if (checkAccount != null)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Thêm tài khoản mới
                    Account newAccount = new Account
                    {
                        UserName = userName,
                        Password = passWord,
                        DisplayName = displayName,
                        Type = type

                    };
                    db.Accounts.Add(newAccount);
                    db.SaveChanges();
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tải lại dữ liệu
                    this.accountTableAdapter.Fill(this.qLQCafeDataSet.Account);
                }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string passWord = GetMD5(txtPassword.Text);
            string displayName;
            if (Int32.Parse(txtType.Text) == 1)
            {
                displayName = "Quản trị viên";
            }
            else
            {
                displayName = "Nhân viên";
            }
            int type = Int32.Parse(txtType.Text);
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                var account = db.Accounts
                                .Where(p => p.UserName == userName)
                                .FirstOrDefault();
                if (account != null)
                {
                    account.Password = passWord;
                    account.Type = type;
                    account.DisplayName = displayName;
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tải lại dữ liệu
                    txtUsername.Enabled = true;
                    this.accountTableAdapter.Fill(this.qLQCafeDataSet.Account);
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = accountDataGridView.CurrentCell.RowIndex;
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                string userName = txtUsername.Text;
                var account = db.Accounts
                                .Where(p => p.UserName == userName)
                                .FirstOrDefault();
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa tài khoản này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                if (account != null)
                {
                    db.Accounts.Remove(account);
                    db.SaveChanges();
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tải lại dữ liệu
                    this.accountTableAdapter.Fill(this.qLQCafeDataSet.Account);
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        private void accountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header row thì bỏ qua
                if (e.RowIndex < 0)
                    return;

                // Lấy hàng được chọn
                DataGridViewRow row = accountDataGridView.Rows[e.RowIndex];
                // Đổ dữ liệu lên form
                txtUsername.Text = row.Cells[0].Value?.ToString() ?? "";
                txtUsername.Enabled = false; // Khóa không cho sửa username
                txtPassword.Text = row.Cells[2].Value?.ToString() ?? "";
                txtType.Text = row.Cells[3].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu bảng Food: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtType.Clear();
            this.accountTableAdapter.Fill(this.qLQCafeDataSet.Account);
        }
    }
}
