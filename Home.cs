using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization; // Để format tiền tệ (VND)

namespace QuanLyQuanCafe
{
    public partial class Home : Form
    {
        // Biến lưu ID bàn đang được chọn
        private TableFood currentTable = null;

        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load_1(object sender, EventArgs e)
        {
            {
                LoadTable();
                LoadCategory();

                // Cấu hình ListView (nếu chưa chỉnh trong Design)
                lsv_Bill.View = View.Details;
                lsv_Bill.GridLines = true;
                lsv_Bill.FullRowSelect = true;
                lsv_Bill.Columns.Add("Tên món", 150);
                lsv_Bill.Columns.Add("Số lượng", 70);
                lsv_Bill.Columns.Add("Đơn giá", 100);
                lsv_Bill.Columns.Add("Thành tiền", 100);
            }
        }

        #region 1. Hiển thị danh sách Bàn (FlowLayoutPanel)

        void LoadTable()
        {
            flp_Ban.Controls.Clear();

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                List<TableFood> tableList = db.TableFood.ToList();

                foreach (TableFood item in tableList)
                {
                    Button btn = new Button() { Width = 90, Height = 90 };
                    btn.Text = item.name + Environment.NewLine + item.status;

                    // Gắn sự kiện Click cho từng nút bàn
                    btn.Click += Btn_Click;
                    btn.Tag = item; // Lưu object bàn vào Tag để dùng sau

                    // Xử lý màu sắc
                    switch (item.status)
                    {
                        case "Trống":
                            btn.BackColor = Color.Aqua;
                            break;
                        default:
                            btn.BackColor = Color.LightPink;
                            break;
                    }

                    flp_Ban.Controls.Add(btn);
                }
            }
        }

        // Sự kiện khi bấm vào một bàn
        private void Btn_Click(object sender, EventArgs e)
        {
            // Lấy thông tin bàn từ nút vừa bấm
            currentTable = (sender as Button).Tag as TableFood;

            // Lưu ID bàn vào Tag của ListView để dùng cho nút Thêm/Xóa
            lsv_Bill.Tag = currentTable;

            // Hiển thị hóa đơn của bàn này
            ShowBill(currentTable.TableID);
        }
        #endregion

        #region 2. Hiển thị Hóa đơn lên ListView

        void ShowBill(int idTable)
        {
            lsv_Bill.Items.Clear();
            double totalPrice = 0; // Dùng double hoặc decimal cho tiền tệ

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // 1. Lấy Bill chưa thanh toán
                Bill bill = db.Bill.FirstOrDefault(b => b.idTable == idTable && b.status == 0);

                if (bill != null)
                {
                    // 2. Lấy chi tiết hóa đơn
                    List<BillInfo> listBillInfo = bill.BillInfo.ToList();

                    foreach (BillInfo info in listBillInfo)
                    {
                        Food food = db.Food.FirstOrDefault(f => f.id == info.idFood);
                        if (food == null) continue;

                        ListViewItem lsvItem = new ListViewItem(food.name.ToString());
                        lsvItem.SubItems.Add(info.count.ToString());
                        lsvItem.SubItems.Add(food.price.ToString());
                        lsvItem.SubItems.Add((info.count * food.price).ToString());

                        // Tính tổng tiền
                        totalPrice += (double)(info.count * food.price);

                        lsv_Bill.Items.Add(lsvItem);
                    }
                }
            }

            // 3. Hiển thị tổng tiền ra TextBox
            // "c" là format currency (tiền tệ) -> tự động thêm đ hoặc $ tùy máy
            CultureInfo culture = new CultureInfo("vi-VN");

            // Giả sử tên TextBox hiển thị tiền là txt_ThanhTien
            // Nếu tên khác, bạn đổi lại cho đúng (ví dụ: txtTotalPrice)
            txt_Tong.Text = totalPrice.ToString("c0", culture);
        }
        #endregion

        #region 3. Load Danh mục và Món ăn (ComboBox)

        void LoadCategory()
        {
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                List<FoodCategory> listCategory = db.FoodCategory.ToList();
                cbx_FoodCa.DataSource = listCategory;
                cbx_FoodCa.DisplayMember = "name"; // Hiển thị tên

                // Khi load xong Category thì load luôn món của Category đầu tiên
                if (listCategory.Count > 0)
                    LoadFoodListByCategoryID(listCategory[0].FoodCaID);
            }
        }
        private void cbx_FoodCa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;

            FoodCategory selected = cb.SelectedItem as FoodCategory;
            LoadFoodListByCategoryID(selected.FoodCaID);
        }

        void LoadFoodListByCategoryID(int id)
        {
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                List<Food> listFood = db.Food.Where(p => p.idCategory == id).ToList();
                cbx_Food.DataSource = listFood;
                cbx_Food.DisplayMember = "name";
            }
        }
        #endregion

        #region 4. Chức năng Thêm món (Nút Thêm)
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (currentTable == null)
            {
                MessageBox.Show("Hãy chọn bàn trước khi thêm món!");
                return;
            }

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // Lấy thông tin từ giao diện
                int idBill = 0;

                // Kiểm tra bàn này đã có Bill chưa
                Bill bill = db.Bill.FirstOrDefault(b => b.idTable == currentTable.TableID && b.status == 0);

                int foodID = (cbx_Food.SelectedItem as Food).id;
                int count = (int)nud_FoodCount.Value;

                if (bill == null)
                {
                    // TRƯỜNG HỢP 1: Bàn chưa có Bill -> Tạo Bill mới -> Thêm BillInfo
                    Bill newBill = new Bill();
                    newBill.DateCheckIn = DateTime.Now;
                    newBill.DateCheckOut = null;
                    newBill.idTable = currentTable.TableID;
                    newBill.status = 0; // Chưa thanh toán

                    db.Bill.Add(newBill);
                    db.SaveChanges(); // Lưu để sinh ra ID Bill

                    idBill = newBill.BillID; // Lấy ID vừa sinh ra

                    // Tạo chi tiết hóa đơn
                    BillInfo newInfo = new BillInfo();
                    newInfo.idBill = idBill;
                    newInfo.idFood = foodID;
                    newInfo.count = count;

                    db.BillInfo.Add(newInfo);
                    db.SaveChanges();

                    // Cập nhật trạng thái bàn thành "Có người"
                    TableFood table = db.TableFood.Find(currentTable.TableID);
                    table.status = "Có người";
                    db.SaveChanges();
                }
                else
                {
                    // TRƯỜNG HỢP 2: Bàn đã có Bill -> Kiểm tra món đã tồn tại chưa
                    idBill = bill.BillID;
                    BillInfo billInfo = db.BillInfo.FirstOrDefault(bi => bi.idBill == idBill && bi.idFood == foodID);

                    if (billInfo != null)
                    {
                        // Món đã có -> Cộng dồn số lượng
                        billInfo.count += count;
                        if (billInfo.count <= 0)
                        {
                            // Nếu số lượng <= 0 thì xóa luôn món đó (Entity Framework Remove)
                            db.BillInfo.Remove(billInfo);
                        }
                    }
                    else
                    {
                        // Món chưa có -> Thêm mới vào Bill cũ
                        if (count > 0) // Chỉ thêm nếu số lượng > 0
                        {
                            BillInfo newInfo = new BillInfo();
                            newInfo.idBill = idBill;
                            newInfo.idFood = foodID;
                            newInfo.count = count;
                            db.BillInfo.Add(newInfo);
                        }
                    }
                    db.SaveChanges();
                }
            }

            // Load lại dữ liệu giao diện
            ShowBill(currentTable.TableID);
            LoadTable(); // Để cập nhật màu sắc nếu bàn chuyển từ Trống -> Có người
        }

        #endregion

        #region 5. Chức năng Xóa món (Nút Xóa)
        // Lưu ý: Logic này sẽ xóa món đang được chọn (bôi đen) trong ListView
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (lsv_Bill.SelectedItems.Count == 0 || currentTable == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn trong danh sách để xóa!");
                return;
            }

            string foodName = lsv_Bill.SelectedItems[0].Text;

            if (MessageBox.Show("Bạn có chắc muốn xóa món " + foodName + "?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (QLQCafeEntities db = new QLQCafeEntities())
                {
                    Food food = db.Food.FirstOrDefault(f => f.name == foodName);
                    Bill bill = db.Bill.FirstOrDefault(b => b.idTable == currentTable.TableID && b.status == 0);

                    if (bill != null && food != null)
                    {
                        BillInfo info = db.BillInfo.FirstOrDefault(bi => bi.idBill == bill.BillID && bi.idFood == food.id);

                        if (info != null)
                        {
                            // 1. Xóa món ăn khỏi BillInfo
                            db.BillInfo.Remove(info);
                            db.SaveChanges(); // Lưu thay đổi ngay lập tức

                            // 2. KIỂM TRA QUAN TRỌNG:
                            // Xem thử trong Bill này còn món nào không?
                            bool conMonAnNaoKhong = db.BillInfo.Any(bi => bi.idBill == bill.BillID);

                            if (!conMonAnNaoKhong)
                            {
                                // Nếu KHÔNG còn món nào (Bill trống rỗng)

                                // A. Cập nhật trạng thái bàn về "Trống"
                                TableFood table = db.TableFood.Find(currentTable.TableID);
                                table.status = "Trống";

                                // B. (Tùy chọn) Xóa luôn cái Bill rỗng đó đi cho đỡ rác database
                                db.Bill.Remove(bill);

                                db.SaveChanges();
                            }
                        }
                    }
                }

                // Load lại Bill và danh sách bàn (để cập nhật màu sắc bàn)
                ShowBill(currentTable.TableID);
                LoadTable();
            }
        }
        #endregion

        
    }
}