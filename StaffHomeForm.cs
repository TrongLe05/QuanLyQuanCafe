using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class StaffHomeForm : UserControl
    {
        // Biến lưu ID bàn đang được chọn
        private TableFood currentTable = null;

        public StaffHomeForm()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;
        }

        private void StaffHomeForm_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadCategory();
            LoadComboBoxSwitchTable();

            // Cấu hình ListView (nếu chưa chỉnh trong Design)
            lsv_Bill.View = View.Details;
            lsv_Bill.GridLines = true;
            lsv_Bill.FullRowSelect = true;
            lsv_Bill.Columns.Add("Tên món", 150);
            lsv_Bill.Columns.Add("Số lượng", 70);
            lsv_Bill.Columns.Add("Đơn giá", 100);
            lsv_Bill.Columns.Add("Thành tiền", 100);
        }

        #region 1. Hiển thị danh sách Bàn (FlowLayoutPanel)

        void LoadTable()
        {
            flp_Ban.Controls.Clear();

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                List<TableFood> tableList = db.TableFoods.ToList();

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

            // Reset giảm giá về 0 mỗi khi chọn bàn mới
            nud_Discount.Value = 0;

            // Hiển thị hóa đơn của bàn này
            ShowBill(currentTable.TableID);
        }
        #endregion

        #region 2. Hiển thị Hóa đơn lên ListView

        void ShowBill(int idTable)
        {
            lsv_Bill.Items.Clear();
            double totalPrice = 0; // Tổng tiền chưa giảm

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // 1. Lấy Bill chưa thanh toán của bàn này
                Bill bill = db.Bills.FirstOrDefault(b => b.TableID == idTable && b.status == 0);

                if (bill != null)
                {
                    // 2. Lấy danh sách món ăn
                    List<BillInfo> listBillInfo = bill.BillInfoes.ToList();

                    foreach (BillInfo info in listBillInfo)
                    {
                        Food food = db.Foods.FirstOrDefault(f => f.FoodID == info.FoodID);
                        if (food == null) continue;

                        // Hiển thị lên ListView
                        ListViewItem lsvItem = new ListViewItem(food.name.ToString());
                        lsvItem.SubItems.Add(info.count.ToString());
                        lsvItem.SubItems.Add(food.price.ToString());
                        lsvItem.SubItems.Add((info.count * food.price).ToString());

                        // Cộng dồn vào tổng tiền gốc
                        totalPrice += (double)(info.count * food.price);

                        lsv_Bill.Items.Add(lsvItem);
                    }
                }
            }

            // --- PHẦN TÍNH TOÁN GIẢM GIÁ (MỚI) ---

            // 3. Lấy % Giảm giá từ NumericUpDown (Ví dụ: 10 = 10%)
            // LƯU Ý: Thay 'nud_Discount' bằng tên thực tế của nút giảm giá bên Design của bạn
            int discount = (int)nud_Discount.Value;

            // 4. Tính tiền thực tế phải trả
            // Công thức: Tiền gốc - (Tiền gốc / 100 * %Giảm)
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            // 5. Hiển thị ra màn hình (Format tiền Việt, không số thập phân)
            CultureInfo culture = new CultureInfo("vi-VN");
            txt_Tong.Text = finalTotalPrice.ToString("c0", culture);
        }

        private void nud_Discount_ValueChanged(object sender, EventArgs e)
        {
            // Khi thay đổi số giảm giá -> Load lại Bill để tính lại tiền
            if (currentTable != null)
            {
                ShowBill(currentTable.TableID);
            }
        }


        #endregion

        #region 3. Load Danh mục và Món ăn (ComboBox)

        void LoadCategory()
        {
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                List<FoodCategory> listCategory = db.FoodCategories.ToList();
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
                List<Food> listFood = db.Foods.Where(p => p.FoodCaID == id).ToList();
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
                Bill bill = db.Bills.FirstOrDefault(b => b.TableID == currentTable.TableID && b.status == 0);

                int foodID = (cbx_Food.SelectedItem as Food).FoodID;
                int count = (int)nud_FoodCount.Value;

                if (bill == null)
                {
                    // TRƯỜNG HỢP 1: Bàn chưa có Bill -> Tạo Bill mới -> Thêm BillInfo
                    Bill newBill = new Bill();
                    newBill.DateCheckIn = DateTime.Now;
                    newBill.DateCheckOut = null;
                    newBill.TableID = currentTable.TableID;
                    newBill.status = 0; // Chưa thanh toán

                    db.Bills.Add(newBill);
                    db.SaveChanges(); // Lưu để sinh ra ID Bill

                    idBill = newBill.BillID; // Lấy ID vừa sinh ra

                    // Tạo chi tiết hóa đơn
                    BillInfo newInfo = new BillInfo();
                    newInfo.BillID = idBill;
                    newInfo.FoodID = foodID;
                    newInfo.count = count;

                    db.BillInfoes.Add(newInfo);
                    db.SaveChanges();

                    // Cập nhật trạng thái bàn thành "Có người"
                    TableFood table = db.TableFoods.Find(currentTable.TableID);
                    table.status = "Có người";
                    db.SaveChanges();
                }
                else
                {
                    // TRƯỜNG HỢP 2: Bàn đã có Bill -> Kiểm tra món đã tồn tại chưa
                    idBill = bill.BillID;
                    BillInfo billInfo = db.BillInfoes.FirstOrDefault(bi => bi.BillID == idBill && bi.FoodID == foodID);

                    if (billInfo != null)
                    {
                        // Món đã có -> Cộng dồn số lượng
                        billInfo.count += count;
                        if (billInfo.count <= 0)
                        {
                            // Nếu số lượng <= 0 thì xóa luôn món đó (Entity Framework Remove)
                            db.BillInfoes.Remove(billInfo);
                        }
                    }
                    else
                    {
                        // Món chưa có -> Thêm mới vào Bill cũ
                        if (count > 0) // Chỉ thêm nếu số lượng > 0
                        {
                            BillInfo newInfo = new BillInfo();
                            newInfo.BillID = idBill;
                            newInfo.FoodID = foodID;
                            newInfo.count = count;
                            db.BillInfoes.Add(newInfo);
                        }
                    }
                    db.SaveChanges();
                }
            }

            // Load lại dữ liệu giao diện
            ShowBill(currentTable.TableID);
            LoadTable(); // Để cập nhật màu sắc nếu bàn chuyển từ Trống -> Có người

            // --- CẬP NHẬT MỚI: Reset số lượng về 1 ---
            nud_FoodCount.Value = 1;
        }

        #endregion

        #region 5. Chức năng Xóa món (Nút Xóa)
        // Lưu ý: Logic này sẽ xóa món đang được chọn (bôi đen) trong ListView
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (lsv_Bill.SelectedItems.Count == 0 || currentTable == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn trong danh sách để xóa!");
                return;
            }

            // Lấy thông tin từ giao diện
            string foodName = lsv_Bill.SelectedItems[0].Text;
            int countToDelete = (int)nud_FoodDel.Value; // Lấy số lượng muốn xóa

            // Tạo thông báo xác nhận cho rõ ràng
            string msg = "";
            if (countToDelete == 0)
                msg = "Bạn có chắc muốn xóa TẤT CẢ món " + foodName + "?";
            else
                msg = "Bạn có chắc muốn bớt " + countToDelete + " ly/đĩa " + foodName + "?";

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (QLQCafeEntities db = new QLQCafeEntities())
                {
                    // Tìm món ăn và Bill
                    Food food = db.Foods.FirstOrDefault(f => f.name == foodName);
                    Bill bill = db.Bills.FirstOrDefault(b => b.TableID == currentTable.TableID && b.status == 0);

                    if (bill != null && food != null)
                    {
                        // Tìm dòng thông tin món ăn trong Bill (BillInfo)
                        BillInfo info = db.BillInfoes.FirstOrDefault(bi => bi.BillID == bill.BillID && bi.FoodID == food.FoodID);

                        if (info != null)
                        {
                            // --- LOGIC XÓA THEO YÊU CẦU ---

                            // Trường hợp 1: Người dùng để số 0 HOẶC Số muốn xóa >= Số đang có
                            // => Xóa luôn dòng này khỏi database
                            if (countToDelete == 0 || countToDelete >= info.count)
                            {
                                db.BillInfoes.Remove(info);
                            }
                            else
                            {
                                // Trường hợp 2: Số muốn xóa nhỏ hơn số đang có
                                // => Chỉ trừ bớt số lượng
                                info.count -= countToDelete;
                            }

                            // Lưu thay đổi món ăn
                            db.SaveChanges();

                            // --- KIỂM TRA TRẠNG THÁI BÀN ---
                            // Kiểm tra xem Bill này còn món nào không?
                            bool billConMonAn = db.BillInfoes.Any(bi => bi.BillID == bill.BillID);

                            if (!billConMonAn)
                            {
                                // Nếu Bill trống rỗng (không còn món nào)

                                // A. Cập nhật trạng thái bàn về "Trống"
                                TableFood table = db.TableFoods.Find(currentTable.TableID);
                                table.status = "Trống";

                                // B. Xóa luôn cái Bill rỗng đi cho sạch Data
                                db.Bills.Remove(bill);

                                db.SaveChanges();
                            }
                        }
                    }
                }

                // Cập nhật lại giao diện
                ShowBill(currentTable.TableID);
                LoadTable();

                // Reset lại ô số lượng về 1 để lần sau thao tác cho tiện (tuỳ chọn)
                nud_FoodDel.Value = 1;
            }
        }
        #endregion

        #region 6. Chức năng Chuyển bàn (Nút Chuyển)
        void LoadComboBoxSwitchTable()
        {
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // Chỉ lấy những bàn có trạng thái là "Trống"
                List<TableFood> listTable = db.TableFoods.Where(t => t.status == "Trống").ToList();

                cbx_ChuyenBan.DataSource = listTable;
                cbx_ChuyenBan.DisplayMember = "name"; // Hiển thị tên bàn
            }
        }


        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            {
                // 1. Kiểm tra đầu vào
                if (currentTable == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn cần chuyển đi!", "Thông báo");
                    return;
                }

                TableFood tableOld = currentTable;
                TableFood tableNew = cbx_ChuyenBan.SelectedItem as TableFood;

                if (tableNew == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn mới để chuyển đến!", "Thông báo");
                    return;
                }

                // Kiểm tra xem bàn cũ có Bill nào không (Bàn trống thì không có gì để chuyển)
                using (QLQCafeEntities db = new QLQCafeEntities())
                {
                    Bill bill = db.Bills.FirstOrDefault(b => b.TableID == tableOld.TableID && b.status == 0);

                    if (bill == null)
                    {
                        MessageBox.Show("Bàn hiện tại đang trống, không có hóa đơn để chuyển!", "Cảnh báo");
                        return;
                    }

                    if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển {0} sang {1}?", tableOld.name, tableNew.name),
                        "Xác nhận chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // 2. THỰC HIỆN CHUYỂN BÀN

                        // A. Cập nhật Bill: Đổi idTable của Bill từ bàn cũ sang bàn mới
                        // Lưu ý: Phải tìm lại Bill trong context hiện tại để update
                        Bill billToUpdate = db.Bills.Find(bill.BillID);
                        billToUpdate.TableID = tableNew.TableID;

                        // B. Cập nhật trạng thái Bàn Cũ -> "Trống"
                        TableFood dbTableOld = db.TableFoods.Find(tableOld.TableID);
                        dbTableOld.status = "Trống";

                        // C. Cập nhật trạng thái Bàn Mới -> "Có người"
                        TableFood dbTableNew = db.TableFoods.Find(tableNew.TableID);
                        dbTableNew.status = "Có người";

                        // Lưu tất cả thay đổi
                        db.SaveChanges();

                        MessageBox.Show("Chuyển bàn thành công!", "Thông báo");

                        // 3. CẬP NHẬT GIAO DIỆN
                        LoadTable();             // Vẽ lại màu sắc các bàn
                        LoadComboBoxSwitchTable(); // Load lại danh sách bàn trống (vì bàn mới giờ đã hết trống)

                        // Mặc định sau khi chuyển xong thì coi như đang chọn bàn mới luôn
                        ShowBill(tableNew.TableID);

                        // Cập nhật lại biến currentTable để trỏ vào bàn mới (để nếu ấn Thêm món thì thêm đúng bàn)
                        // (Phải lấy lại object bàn mới từ DB hoặc gán tạm)
                        // Cách đơn giản nhất: Gán Tag từ nút bàn mới (nhưng vì ta vừa reload table, nên ta gán thủ công)
                        tableNew.status = "Có người"; // Cập nhật local
                        currentTable = tableNew;
                        lsv_Bill.Tag = currentTable;
                    }
                }
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }


        #endregion

        #region 7. Chức năng Thanh toán (Nút Thanh toán)


        // HÀM XỬ LÝ DATABASE CHUNG (Dùng cho cả thanh toán thường và QR)
        private void ProcessingCheckout(Bill bill, TableFood table)
        {
            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // Tìm lại bill và table trong context mới để update
                var billUpdate = db.Bills.Find(bill.BillID);
                var tableUpdate = db.TableFoods.Find(table.TableID);

                if (billUpdate != null && tableUpdate != null)
                {
                    billUpdate.DateCheckOut = DateTime.Now;
                    billUpdate.status = 1; // Đã thanh toán

                    tableUpdate.status = "Trống"; // Trả bàn

                    db.SaveChanges();
                }
            }

            // Cập nhật giao diện sau khi lưu xong
            MessageBox.Show("Thanh toán thành công!", "Thông báo");
            ShowBill(table.TableID);
            LoadTable();
            LoadComboBoxSwitchTable();
            nud_Discount.Value = 0;
        }


        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                Bill bill = db.Bills.FirstOrDefault(b => b.TableID == currentTable.TableID && b.status == 0);

                if (bill != null)
                {
                    double finalTotalPrice = CalculateTotalPrice(bill, db); // Hàm tính tiền (xem bên dưới)

                    CultureInfo culture = new CultureInfo("vi-VN");
                    string strTotal = finalTotalPrice.ToString("c0", culture);

                    if (MessageBox.Show($"Thanh toán tiền mặt cho {currentTable.name}?\nTổng: {strTotal}",
                        "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ProcessingCheckout(bill, currentTable); // Gọi hàm xử lý chung
                    }
                }
            }
        }
        private double CalculateTotalPrice(Bill bill, QLQCafeEntities db)
        {
            double totalPrice = 0;
            foreach (BillInfo info in bill.BillInfoes)
            {
                Food food = db.Foods.FirstOrDefault(f => f.FoodID == info.FoodID);
                if (food != null) totalPrice += (double)(info.count * food.price);
            }
            int discount = (int)nud_Discount.Value;
            return totalPrice - (totalPrice / 100) * discount;
        }
        #endregion

        #region 8. Chức năng Tạo QR thanh toán (Nút Tạo QR)
        private void btn_TaoQR_Click(object sender, EventArgs e)
        {
            if (currentTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn để thanh toán!", "Thông báo");
                return;
            }

            using (QLQCafeEntities db = new QLQCafeEntities())
            {
                // 1. Lấy thông tin Bill
                Bill bill = db.Bills.FirstOrDefault(b => b.TableID == currentTable.TableID && b.status == 0);

                if (bill != null)
                {
                    // 2. Tính tổng tiền cần thanh toán
                    double finalPrice = CalculateTotalPrice(bill, db);

                    if (finalPrice <= 0)
                    {
                        MessageBox.Show("Số tiền không hợp lệ để tạo QR!", "Lỗi");
                        return;
                    }

                    // 3. Mở Form QR (Form2)
                    // Truyền số tiền và Tên bàn sang Form2
                    QR fQr = new QR(finalPrice, currentTable.name);

                    // ShowDialog sẽ chặn thao tác ở Form chính cho đến khi Form QR đóng lại
                    DialogResult result = fQr.ShowDialog();

                    // 4. Kiểm tra kết quả trả về từ Form QR
                    if (result == DialogResult.OK)
                    {
                        // Nếu Form QR trả về OK (đã thanh toán thành công)
                        // -> Thực hiện lưu Bill xuống Database
                        ProcessingCheckout(bill, currentTable);
                    }
                    else
                    {
                        // Người dùng đóng form mà chưa thanh toán xong
                        // Không làm gì cả
                    }
                }
                else
                {
                    MessageBox.Show("Bàn này không có hóa đơn!", "Cảnh báo");
                }
            }
        }

        #endregion
    }
}
