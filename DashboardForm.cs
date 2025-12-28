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
    public partial class DashboardForm : UserControl
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();

                int soMon = db.Foods.Count();
                int soBan = db.TableFoods.Count();
                var tongDoanhThu = (from b in db.Bills
                                     join bi in db.BillInfoes on b.BillID equals bi.BillID
                                     join f in db.Foods on bi.FoodID equals f.FoodID
                                     where b.status == 1
                                     select bi.count * f.price
                                    ).Sum();
                var doanhThuNgay = (from b in db.Bills
                                     join bi in db.BillInfoes on b.BillID equals bi.BillID
                                     join f in db.Foods on bi.FoodID equals f.FoodID
                                     where b.status == 1 && b.DateCheckOut.Value == DateTime.Today
                                    select (int?)(bi.count * f.price)
                                    ).Sum() ?? 0;

                DateTime today = DateTime.Today;
                DateTime tomorrow = today.AddDays(1);

                var monBanHomNay =
                    from b in db.Bills
                    join bi in db.BillInfoes on b.BillID equals bi.BillID
                    join f in db.Foods on bi.FoodID equals f.FoodID
                    where b.status == 1
                          && b.DateCheckOut >= today
                          && b.DateCheckOut < tomorrow
                    select new
                    {
                        MaMon = f.FoodID,
                        TenMon = f.name,
                        SoLuong = bi.count,
                        Gia = f.price,
                        ThanhTien = bi.count * f.price
                    };

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = monBanHomNay.ToList();

                lblSoMon.Text = soMon.ToString();
                lblSoBan.Text = soBan.ToString();
                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VND";
                lblDoanhThuNgay.Text = doanhThuNgay.ToString("N0") + " VND";
            }
            catch
            {
                if (!this.DesignMode)
                    throw;
            }
        }
    }
}
