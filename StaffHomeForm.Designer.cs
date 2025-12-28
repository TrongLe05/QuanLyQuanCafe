namespace QuanLyQuanCafe
{
    partial class StaffHomeForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsv_Bill = new System.Windows.Forms.ListView();
            this.cbx_FoodCa = new System.Windows.Forms.ComboBox();
            this.cbx_Food = new System.Windows.Forms.ComboBox();
            this.flp_Ban = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_FoodDel = new System.Windows.Forms.NumericUpDown();
            this.btn_ChuyenBan = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_ChuyenBan = new System.Windows.Forms.ComboBox();
            this.nud_FoodCount = new System.Windows.Forms.NumericUpDown();
            this.btn_Them = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_TaoQR = new System.Windows.Forms.Button();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Discount = new System.Windows.Forms.NumericUpDown();
            this.txt_Tong = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lsv_Bill);
            this.panel1.Controls.Add(this.flp_Ban);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 641);
            this.panel1.TabIndex = 0;
            // 
            // lsv_Bill
            // 
            this.lsv_Bill.HideSelection = false;
            this.lsv_Bill.Location = new System.Drawing.Point(332, 10);
            this.lsv_Bill.Margin = new System.Windows.Forms.Padding(2);
            this.lsv_Bill.Name = "lsv_Bill";
            this.lsv_Bill.Size = new System.Drawing.Size(390, 621);
            this.lsv_Bill.TabIndex = 36;
            this.lsv_Bill.UseCompatibleStateImageBehavior = false;
            // 
            // cbx_FoodCa
            // 
            this.cbx_FoodCa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_FoodCa.FormattingEnabled = true;
            this.cbx_FoodCa.Location = new System.Drawing.Point(12, 27);
            this.cbx_FoodCa.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_FoodCa.Name = "cbx_FoodCa";
            this.cbx_FoodCa.Size = new System.Drawing.Size(192, 25);
            this.cbx_FoodCa.TabIndex = 35;
            // 
            // cbx_Food
            // 
            this.cbx_Food.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Food.FormattingEnabled = true;
            this.cbx_Food.Location = new System.Drawing.Point(12, 63);
            this.cbx_Food.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_Food.Name = "cbx_Food";
            this.cbx_Food.Size = new System.Drawing.Size(192, 25);
            this.cbx_Food.TabIndex = 34;
            // 
            // flp_Ban
            // 
            this.flp_Ban.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flp_Ban.ForeColor = System.Drawing.Color.Black;
            this.flp_Ban.Location = new System.Drawing.Point(10, 10);
            this.flp_Ban.Margin = new System.Windows.Forms.Padding(10);
            this.flp_Ban.Name = "flp_Ban";
            this.flp_Ban.Size = new System.Drawing.Size(290, 621);
            this.flp_Ban.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_FoodCa);
            this.groupBox1.Controls.Add(this.cbx_Food);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(734, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(216, 100);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn món";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_FoodDel);
            this.groupBox2.Controls.Add(this.btn_ChuyenBan);
            this.groupBox2.Controls.Add(this.btn_Xoa);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbx_ChuyenBan);
            this.groupBox2.Controls.Add(this.nud_FoodCount);
            this.groupBox2.Controls.Add(this.btn_Them);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(734, 123);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(216, 229);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // nud_FoodDel
            // 
            this.nud_FoodDel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_FoodDel.Location = new System.Drawing.Point(40, 37);
            this.nud_FoodDel.Margin = new System.Windows.Forms.Padding(0);
            this.nud_FoodDel.Name = "nud_FoodDel";
            this.nud_FoodDel.Size = new System.Drawing.Size(38, 29);
            this.nud_FoodDel.TabIndex = 59;
            this.nud_FoodDel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_ChuyenBan
            // 
            this.btn_ChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChuyenBan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChuyenBan.Location = new System.Drawing.Point(117, 150);
            this.btn_ChuyenBan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ChuyenBan.Name = "btn_ChuyenBan";
            this.btn_ChuyenBan.Size = new System.Drawing.Size(79, 61);
            this.btn_ChuyenBan.TabIndex = 57;
            this.btn_ChuyenBan.Text = "Chuyển";
            this.btn_ChuyenBan.UseVisualStyleBackColor = true;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(10, 66);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(68, 61);
            this.btn_Xoa.TabIndex = 56;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 55;
            this.label2.Text = "Chuyển bàn";
            // 
            // cbx_ChuyenBan
            // 
            this.cbx_ChuyenBan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ChuyenBan.FormattingEnabled = true;
            this.cbx_ChuyenBan.Location = new System.Drawing.Point(16, 182);
            this.cbx_ChuyenBan.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_ChuyenBan.Name = "cbx_ChuyenBan";
            this.cbx_ChuyenBan.Size = new System.Drawing.Size(92, 29);
            this.cbx_ChuyenBan.TabIndex = 54;
            // 
            // nud_FoodCount
            // 
            this.nud_FoodCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_FoodCount.Location = new System.Drawing.Point(139, 37);
            this.nud_FoodCount.Margin = new System.Windows.Forms.Padding(2);
            this.nud_FoodCount.Name = "nud_FoodCount";
            this.nud_FoodCount.Size = new System.Drawing.Size(38, 29);
            this.nud_FoodCount.TabIndex = 50;
            this.nud_FoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(109, 66);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(68, 61);
            this.btn_Them.TabIndex = 49;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_TaoQR);
            this.groupBox3.Controls.Add(this.btn_ThanhToan);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nud_Discount);
            this.groupBox3.Controls.Add(this.txt_Tong);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(734, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(216, 195);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thanh toán";
            // 
            // btn_TaoQR
            // 
            this.btn_TaoQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_TaoQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TaoQR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoQR.Location = new System.Drawing.Point(12, 121);
            this.btn_TaoQR.Margin = new System.Windows.Forms.Padding(2);
            this.btn_TaoQR.Name = "btn_TaoQR";
            this.btn_TaoQR.Size = new System.Drawing.Size(78, 61);
            this.btn_TaoQR.TabIndex = 65;
            this.btn_TaoQR.Text = "Tạo QR";
            this.btn_TaoQR.UseVisualStyleBackColor = false;
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_ThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThanhToan.Location = new System.Drawing.Point(126, 121);
            this.btn_ThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(78, 61);
            this.btn_ThanhToan.TabIndex = 64;
            this.btn_ThanhToan.Text = "Thanh Toán";
            this.btn_ThanhToan.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 63;
            this.label1.Text = "Giảm giá";
            // 
            // nud_Discount
            // 
            this.nud_Discount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Discount.Location = new System.Drawing.Point(13, 55);
            this.nud_Discount.Margin = new System.Windows.Forms.Padding(2);
            this.nud_Discount.Name = "nud_Discount";
            this.nud_Discount.Size = new System.Drawing.Size(68, 29);
            this.nud_Discount.TabIndex = 62;
            // 
            // txt_Tong
            // 
            this.txt_Tong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tong.Location = new System.Drawing.Point(13, 88);
            this.txt_Tong.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Tong.Name = "txt_Tong";
            this.txt_Tong.ReadOnly = true;
            this.txt_Tong.Size = new System.Drawing.Size(68, 29);
            this.txt_Tong.TabIndex = 61;
            // 
            // StaffHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StaffHomeForm";
            this.Size = new System.Drawing.Size(980, 661);
            this.Load += new System.EventHandler(this.StaffHomeForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Discount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsv_Bill;
        private System.Windows.Forms.ComboBox cbx_FoodCa;
        private System.Windows.Forms.ComboBox cbx_Food;
        private System.Windows.Forms.FlowLayoutPanel flp_Ban;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_FoodDel;
        private System.Windows.Forms.Button btn_ChuyenBan;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_ChuyenBan;
        private System.Windows.Forms.NumericUpDown nud_FoodCount;
        private System.Windows.Forms.Button btn_Them;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_TaoQR;
        private System.Windows.Forms.Button btn_ThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Discount;
        private System.Windows.Forms.TextBox txt_Tong;
    }
}
