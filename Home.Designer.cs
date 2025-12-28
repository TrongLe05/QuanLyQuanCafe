namespace QuanLyQuanCafe
{
    partial class Home
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
            this.flp_Ban = new System.Windows.Forms.FlowLayoutPanel();
            this.cbx_Food = new System.Windows.Forms.ComboBox();
            this.cbx_FoodCa = new System.Windows.Forms.ComboBox();
            this.lsv_Bill = new System.Windows.Forms.ListView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.nud_FoodCount = new System.Windows.Forms.NumericUpDown();
            this.txt_Tong = new System.Windows.Forms.TextBox();
            this.nud_Discount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_ChuyenBan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_ChuyenBan = new System.Windows.Forms.Button();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            this.nud_FoodDel = new System.Windows.Forms.NumericUpDown();
            this.btn_TaoQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodDel)).BeginInit();
            this.SuspendLayout();
            // 
            // flp_Ban
            // 
            this.flp_Ban.Location = new System.Drawing.Point(9, 10);
            this.flp_Ban.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flp_Ban.Name = "flp_Ban";
            this.flp_Ban.Size = new System.Drawing.Size(290, 514);
            this.flp_Ban.TabIndex = 0;
            // 
            // cbx_Food
            // 
            this.cbx_Food.FormattingEnabled = true;
            this.cbx_Food.Location = new System.Drawing.Point(687, 34);
            this.cbx_Food.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_Food.Name = "cbx_Food";
            this.cbx_Food.Size = new System.Drawing.Size(161, 21);
            this.cbx_Food.TabIndex = 1;
            // 
            // cbx_FoodCa
            // 
            this.cbx_FoodCa.FormattingEnabled = true;
            this.cbx_FoodCa.Location = new System.Drawing.Point(687, 10);
            this.cbx_FoodCa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_FoodCa.Name = "cbx_FoodCa";
            this.cbx_FoodCa.Size = new System.Drawing.Size(161, 21);
            this.cbx_FoodCa.TabIndex = 2;
            this.cbx_FoodCa.SelectedIndexChanged += new System.EventHandler(this.cbx_FoodCa_SelectedIndexChanged_1);
            // 
            // lsv_Bill
            // 
            this.lsv_Bill.HideSelection = false;
            this.lsv_Bill.Location = new System.Drawing.Point(304, 10);
            this.lsv_Bill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsv_Bill.Name = "lsv_Bill";
            this.lsv_Bill.Size = new System.Drawing.Size(380, 515);
            this.lsv_Bill.TabIndex = 3;
            this.lsv_Bill.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Them.Location = new System.Drawing.Point(780, 89);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(68, 61);
            this.btn_Them.TabIndex = 4;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // nud_FoodCount
            // 
            this.nud_FoodCount.Location = new System.Drawing.Point(810, 71);
            this.nud_FoodCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nud_FoodCount.Name = "nud_FoodCount";
            this.nud_FoodCount.Size = new System.Drawing.Size(38, 20);
            this.nud_FoodCount.TabIndex = 5;
            this.nud_FoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FoodCount.ValueChanged += new System.EventHandler(this.nud_FoodCount_ValueChanged);
            // 
            // txt_Tong
            // 
            this.txt_Tong.Location = new System.Drawing.Point(690, 289);
            this.txt_Tong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Tong.Name = "txt_Tong";
            this.txt_Tong.ReadOnly = true;
            this.txt_Tong.Size = new System.Drawing.Size(68, 20);
            this.txt_Tong.TabIndex = 7;
            // 
            // nud_Discount
            // 
            this.nud_Discount.Location = new System.Drawing.Point(690, 268);
            this.nud_Discount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nud_Discount.Name = "nud_Discount";
            this.nud_Discount.Size = new System.Drawing.Size(68, 20);
            this.nud_Discount.TabIndex = 8;
            this.nud_Discount.ValueChanged += new System.EventHandler(this.nud_Discount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(701, 250);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Giảm giá";
            // 
            // cbx_ChuyenBan
            // 
            this.cbx_ChuyenBan.FormattingEnabled = true;
            this.cbx_ChuyenBan.Location = new System.Drawing.Point(690, 201);
            this.cbx_ChuyenBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbx_ChuyenBan.Name = "cbx_ChuyenBan";
            this.cbx_ChuyenBan.Size = new System.Drawing.Size(68, 21);
            this.cbx_ChuyenBan.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chuyển bàn";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Xoa.Location = new System.Drawing.Point(701, 89);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(68, 61);
            this.btn_Xoa.TabIndex = 12;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_ChuyenBan
            // 
            this.btn_ChuyenBan.Location = new System.Drawing.Point(769, 167);
            this.btn_ChuyenBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ChuyenBan.Name = "btn_ChuyenBan";
            this.btn_ChuyenBan.Size = new System.Drawing.Size(79, 61);
            this.btn_ChuyenBan.TabIndex = 13;
            this.btn_ChuyenBan.Text = "Chuyển";
            this.btn_ChuyenBan.UseVisualStyleBackColor = true;
            this.btn_ChuyenBan.Click += new System.EventHandler(this.btn_ChuyenBan_Click);
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ThanhToan.Location = new System.Drawing.Point(770, 246);
            this.btn_ThanhToan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(78, 61);
            this.btn_ThanhToan.TabIndex = 14;
            this.btn_ThanhToan.Text = "Thanh Toán";
            this.btn_ThanhToan.UseVisualStyleBackColor = false;
            this.btn_ThanhToan.Click += new System.EventHandler(this.btn_ThanhToan_Click);
            // 
            // nud_FoodDel
            // 
            this.nud_FoodDel.Location = new System.Drawing.Point(731, 71);
            this.nud_FoodDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nud_FoodDel.Name = "nud_FoodDel";
            this.nud_FoodDel.Size = new System.Drawing.Size(38, 20);
            this.nud_FoodDel.TabIndex = 15;
            this.nud_FoodDel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FoodDel.ValueChanged += new System.EventHandler(this.nud_FoodDel_ValueChanged);
            // 
            // btn_TaoQR
            // 
            this.btn_TaoQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_TaoQR.Location = new System.Drawing.Point(770, 328);
            this.btn_TaoQR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TaoQR.Name = "btn_TaoQR";
            this.btn_TaoQR.Size = new System.Drawing.Size(78, 61);
            this.btn_TaoQR.TabIndex = 16;
            this.btn_TaoQR.Text = "Tạo QR";
            this.btn_TaoQR.UseVisualStyleBackColor = false;
            this.btn_TaoQR.Click += new System.EventHandler(this.btn_TaoQR_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 534);
            this.Controls.Add(this.btn_TaoQR);
            this.Controls.Add(this.nud_FoodDel);
            this.Controls.Add(this.btn_ThanhToan);
            this.Controls.Add(this.btn_ChuyenBan);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_ChuyenBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_Discount);
            this.Controls.Add(this.txt_Tong);
            this.Controls.Add(this.nud_FoodCount);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.lsv_Bill);
            this.Controls.Add(this.cbx_FoodCa);
            this.Controls.Add(this.cbx_Food);
            this.Controls.Add(this.flp_Ban);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_Ban;
        private System.Windows.Forms.ComboBox cbx_Food;
        private System.Windows.Forms.ComboBox cbx_FoodCa;
        private System.Windows.Forms.ListView lsv_Bill;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.NumericUpDown nud_FoodCount;
        private System.Windows.Forms.TextBox txt_Tong;
        private System.Windows.Forms.NumericUpDown nud_Discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_ChuyenBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_ChuyenBan;
        private System.Windows.Forms.Button btn_ThanhToan;
        private System.Windows.Forms.NumericUpDown nud_FoodDel;
        private System.Windows.Forms.Button btn_TaoQR;
    }
}