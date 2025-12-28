namespace QuanLyQuanCafe
{
    partial class InvoiceForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXuatBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(10, 61);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(10);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(960, 590);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(10, 28);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 20);
            this.dtpNgay.TabIndex = 1;
            // 
            // btnXuatBC
            // 
            this.btnXuatBC.Location = new System.Drawing.Point(232, 25);
            this.btnXuatBC.Name = "btnXuatBC";
            this.btnXuatBC.Size = new System.Drawing.Size(75, 23);
            this.btnXuatBC.TabIndex = 2;
            this.btnXuatBC.Text = "Xuất";
            this.btnXuatBC.UseVisualStyleBackColor = true;
            this.btnXuatBC.Click += new System.EventHandler(this.button1_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXuatBC);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.reportViewer1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "InvoiceForm";
            this.Size = new System.Drawing.Size(980, 661);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnXuatBC;
    }
}
