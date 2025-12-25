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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_ChuyenBan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // flp_Ban
            // 
            this.flp_Ban.Location = new System.Drawing.Point(12, 12);
            this.flp_Ban.Name = "flp_Ban";
            this.flp_Ban.Size = new System.Drawing.Size(387, 633);
            this.flp_Ban.TabIndex = 0;
            // 
            // cbx_Food
            // 
            this.cbx_Food.FormattingEnabled = true;
            this.cbx_Food.Location = new System.Drawing.Point(916, 42);
            this.cbx_Food.Name = "cbx_Food";
            this.cbx_Food.Size = new System.Drawing.Size(200, 24);
            this.cbx_Food.TabIndex = 1;
            // 
            // cbx_FoodCa
            // 
            this.cbx_FoodCa.FormattingEnabled = true;
            this.cbx_FoodCa.Location = new System.Drawing.Point(916, 12);
            this.cbx_FoodCa.Name = "cbx_FoodCa";
            this.cbx_FoodCa.Size = new System.Drawing.Size(200, 24);
            this.cbx_FoodCa.TabIndex = 2;
            this.cbx_FoodCa.SelectedIndexChanged += new System.EventHandler(this.cbx_FoodCa_SelectedIndexChanged_1);
            // 
            // lsv_Bill
            // 
            this.lsv_Bill.HideSelection = false;
            this.lsv_Bill.Location = new System.Drawing.Point(405, 12);
            this.lsv_Bill.Name = "lsv_Bill";
            this.lsv_Bill.Size = new System.Drawing.Size(505, 633);
            this.lsv_Bill.TabIndex = 3;
            this.lsv_Bill.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Them.Location = new System.Drawing.Point(1025, 111);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(90, 75);
            this.btn_Them.TabIndex = 4;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // nud_FoodCount
            // 
            this.nud_FoodCount.Location = new System.Drawing.Point(1066, 72);
            this.nud_FoodCount.Name = "nud_FoodCount";
            this.nud_FoodCount.Size = new System.Drawing.Size(50, 22);
            this.nud_FoodCount.TabIndex = 5;
            // 
            // txt_Tong
            // 
            this.txt_Tong.Location = new System.Drawing.Point(920, 372);
            this.txt_Tong.Name = "txt_Tong";
            this.txt_Tong.ReadOnly = true;
            this.txt_Tong.Size = new System.Drawing.Size(90, 22);
            this.txt_Tong.TabIndex = 7;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(920, 346);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 22);
            this.numericUpDown2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(935, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Giảm giá";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(920, 247);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(90, 24);
            this.comboBox3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(925, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chuyển bàn";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Xoa.Location = new System.Drawing.Point(920, 111);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(90, 75);
            this.btn_Xoa.TabIndex = 12;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_ChuyenBan
            // 
            this.btn_ChuyenBan.Location = new System.Drawing.Point(1025, 205);
            this.btn_ChuyenBan.Name = "btn_ChuyenBan";
            this.btn_ChuyenBan.Size = new System.Drawing.Size(90, 75);
            this.btn_ChuyenBan.TabIndex = 13;
            this.btn_ChuyenBan.Text = "Chuyển";
            this.btn_ChuyenBan.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(1026, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 75);
            this.button1.TabIndex = 14;
            this.button1.Text = "Thanh Toán";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 657);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ChuyenBan);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.txt_Tong);
            this.Controls.Add(this.nud_FoodCount);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.lsv_Bill);
            this.Controls.Add(this.cbx_FoodCa);
            this.Controls.Add(this.cbx_Food);
            this.Controls.Add(this.flp_Ban);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.nud_FoodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_ChuyenBan;
        private System.Windows.Forms.Button button1;
    }
}