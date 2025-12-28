namespace QuanLyQuanCafe
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnQuanLyMonAn = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.invoiceForm1 = new QuanLyQuanCafe.InvoiceForm();
            this.foodManagermentForm1 = new QuanLyQuanCafe.FoodManagermentForm();
            this.dashboardForm1 = new QuanLyQuanCafe.DashboardForm();
            this.accountManagermentForm1 = new QuanLyQuanCafe.AccountManagermentForm();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(82)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.btnTaiKhoan);
            this.panel1.Controls.Add(this.btnDangXuat);
            this.panel1.Controls.Add(this.btnHoaDon);
            this.panel1.Controls.Add(this.btnQuanLyMonAn);
            this.panel1.Controls.Add(this.btnTrangChu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 661);
            this.panel1.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(51)))), ((int)(((byte)(31)))));
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Location = new System.Drawing.Point(0, 621);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(200, 40);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(141)))), ((int)(((byte)(131)))));
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.Location = new System.Drawing.Point(0, 258);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(0);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(200, 40);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Hoá đơn";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnQuanLyMonAn
            // 
            this.btnQuanLyMonAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(141)))), ((int)(((byte)(131)))));
            this.btnQuanLyMonAn.FlatAppearance.BorderSize = 0;
            this.btnQuanLyMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyMonAn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyMonAn.Location = new System.Drawing.Point(0, 218);
            this.btnQuanLyMonAn.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLyMonAn.Name = "btnQuanLyMonAn";
            this.btnQuanLyMonAn.Size = new System.Drawing.Size(200, 40);
            this.btnQuanLyMonAn.TabIndex = 3;
            this.btnQuanLyMonAn.Text = "Quản lý món ăn";
            this.btnQuanLyMonAn.UseVisualStyleBackColor = false;
            this.btnQuanLyMonAn.Click += new System.EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(141)))), ((int)(((byte)(131)))));
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.Location = new System.Drawing.Point(0, 178);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(200, 40);
            this.btnTrangChu.TabIndex = 2;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xin chào, Admin!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.user_setting;
            this.pictureBox1.Location = new System.Drawing.Point(65, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // invoiceForm1
            // 
            this.invoiceForm1.ForeColor = System.Drawing.Color.Black;
            this.invoiceForm1.Location = new System.Drawing.Point(195, 0);
            this.invoiceForm1.Name = "invoiceForm1";
            this.invoiceForm1.Size = new System.Drawing.Size(980, 661);
            this.invoiceForm1.TabIndex = 3;
            // 
            // foodManagermentForm1
            // 
            this.foodManagermentForm1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodManagermentForm1.Location = new System.Drawing.Point(195, 0);
            this.foodManagermentForm1.Margin = new System.Windows.Forms.Padding(0);
            this.foodManagermentForm1.Name = "foodManagermentForm1";
            this.foodManagermentForm1.Size = new System.Drawing.Size(980, 661);
            this.foodManagermentForm1.TabIndex = 2;
            // 
            // dashboardForm1
            // 
            this.dashboardForm1.Location = new System.Drawing.Point(195, 0);
            this.dashboardForm1.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardForm1.Name = "dashboardForm1";
            this.dashboardForm1.Size = new System.Drawing.Size(980, 661);
            this.dashboardForm1.TabIndex = 1;
            // 
            // accountManagermentForm1
            // 
            this.accountManagermentForm1.Location = new System.Drawing.Point(195, 0);
            this.accountManagermentForm1.Margin = new System.Windows.Forms.Padding(0);
            this.accountManagermentForm1.Name = "accountManagermentForm1";
            this.accountManagermentForm1.Size = new System.Drawing.Size(980, 661);
            this.accountManagermentForm1.TabIndex = 4;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(141)))), ((int)(((byte)(131)))));
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 298);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(200, 40);
            this.btnTaiKhoan.TabIndex = 7;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.accountManagermentForm1);
            this.Controls.Add(this.invoiceForm1);
            this.Controls.Add(this.foodManagermentForm1);
            this.Controls.Add(this.dashboardForm1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "AdminForm";
            this.Text = "AdminForrm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnQuanLyMonAn;
        private DashboardForm dashboardForm1;
        private FoodManagermentForm foodManagermentForm1;
        private InvoiceForm invoiceForm1;
        private AccountManagermentForm accountManagermentForm1;
        private System.Windows.Forms.Button btnTaiKhoan;
    }
}