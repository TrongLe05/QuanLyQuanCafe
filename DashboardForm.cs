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
                lblSoMon.Text = soMon.ToString();
                lblSoBan.Text = soBan.ToString();
            }
            catch
            {
                if (!this.DesignMode)
                    throw;
            }
        }
    }
}
