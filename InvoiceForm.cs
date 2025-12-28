using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class InvoiceForm : UserControl
    {
        QLQCafeEntities db = new QLQCafeEntities(); 
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void LoadReport()
        {
            DateTime ngay = dtpNgay.Value.Date;

            // 1. Tổng tiền từng hoá đơn
            var tongTienHoaDon = from bi in db.BillInfoes
                                 join f in db.Foods on bi.FoodID equals f.FoodID
                                 group new { bi, f } by bi.BillID into g
                                 select new
                                 {
                                     BillID = g.Key,
                                     TongTien = g.Sum(x => x.bi.count * (int)x.f.price)
                                 };

            // 2. Bảng báo cáo
            var reportData = from b in db.Bills
                             join bi in db.BillInfoes on b.BillID equals bi.BillID
                             join f in db.Foods on bi.FoodID equals f.FoodID
                             join t in tongTienHoaDon on b.BillID equals t.BillID
                             where b.status == 1
                                && b.DateCheckIn == ngay
                             orderby b.BillID
                             select new BillReportDTO
                             {
                                 MaHoaDon = b.BillID,
                                 MaBan = b.TableID,
                                 TenMonAn = f.name,
                                 SoLuong = bi.count,
                                 TongGiaTienHoaDon = t.TongTien
                             };

            List<BillReportDTO> list = reportData.ToList();

            // Đổ vào RDLC
            reportViewer1.LocalReport.ReportPath = "D:/WORKSPACE/C#/QuanLyQuanCafe/BaoCaoHoaDonNgay.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource(
                    "DataSet1", list)
            );

            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
