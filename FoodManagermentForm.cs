using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class FoodManagermentForm : UserControl
    {
        public FoodManagermentForm()
        {
            InitializeComponent();
        }

        private void foodBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.foodBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLQCafeDataSet);

        }

        private void FoodManagermentForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load dữ liệu Food
                this.foodTableAdapter.Fill(this.qLQCafeDataSet.Food);
                foodBindingSource.Sort = "FoodCaID ASC";
                // Load dữ liệu FoodCategory (nếu có)
                this.foodCategoryTableAdapter.Fill(this.qLQCafeDataSet.FoodCategory);

                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                Food newFood = new Food
                {
                    name = txtTenMon.Text,
                    FoodCaID = (int)cbLoaiMon.SelectedValue,
                    price = int.Parse(txtGia.Text)
                };
                db.Foods.Add(newFood);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                this.foodTableAdapter.Fill(this.qLQCafeDataSet.Food);
                this.foodBindingSource.ResetBindings(false);
                this.foodDataGridView.Refresh();

                this.foodCategoryTableAdapter.Fill(this.qLQCafeDataSet.FoodCategory);
                this.foodCategoryBindingSource.ResetBindings(false);
                this.foodCategoryDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void foodDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header row thì bỏ qua
                if (e.RowIndex < 0)
                    return;

                // Lấy hàng được chọn
                DataGridViewRow row = foodDataGridView.Rows[e.RowIndex];

                // Đổ dữ liệu lên form
                txtTenMon.Text = row.Cells[1].Value?.ToString() ?? "";
                txtGia.Text = row.Cells[3].Value?.ToString() ?? "";

                //Set giá trị cho ComboBox
                if (row.Cells[2].Value != null)
                {
                    cbLoaiMon.SelectedValue = Convert.ToInt32(row.Cells[2].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu bảng Food: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                int foodId = Convert.ToInt32(foodDataGridView.CurrentRow.Cells[0].Value);
                Food foodToUpdate = db.Foods.Find(foodId);
                if (foodToUpdate != null)
                {
                    foodToUpdate.name = txtTenMon.Text;
                    foodToUpdate.FoodCaID = (int)cbLoaiMon.SelectedValue;
                    foodToUpdate.price = int.Parse(txtGia.Text);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                int rowIndex = foodDataGridView.CurrentRow.Index;
                Food food = db.Foods.Find(Convert.ToInt32(foodDataGridView.Rows[rowIndex].Cells[0].Value));
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa món ăn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
                if (food != null)
                {
                    db.Foods.Remove(food);
                    db.SaveChanges();
                    MessageBox.Show("Xoá món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Món này đang được sử dụng ở bàn nào đó" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void foodCategoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào header row thì bỏ qua
                if (e.RowIndex < 0)
                    return;

                // Lấy hàng được chọn
                DataGridViewRow row = foodCategoryDataGridView.Rows[e.RowIndex];

                // Đổ dữ liệu lên form
                txtTenLoai.Text = row.Cells[1].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu bảng FoodCategory: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                FoodCategory newFoodCa = new FoodCategory
                {
                    name = txtTenLoai.Text
                };
                db.FoodCategories.Add(newFoodCa);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm loại món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                int foodCaID = Convert.ToInt32(foodCategoryDataGridView.CurrentRow.Cells[0].Value);
                FoodCategory foodCaUpdate = db.FoodCategories.Find(foodCaID);
                if (foodCaUpdate != null)
                {
                    foodCaUpdate.name = txtTenLoai.Text;
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Sửa loại món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa loại món: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            try
            {
                QLQCafeEntities db = new QLQCafeEntities();
                int rowIndex = foodCategoryDataGridView.CurrentRow.Index;
                FoodCategory foodCa = db.FoodCategories.Find(Convert.ToInt32(foodCategoryDataGridView.Rows[rowIndex].Cells[0].Value));
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa món ăn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                if (foodCa != null)
                {
                    db.FoodCategories.Remove(foodCa);
                    db.SaveChanges();
                    MessageBox.Show("Xoá món thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại món!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Loại món này đang được sử dụng ở bàn nào đó", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Danh Sách Món");

                    // Xuất HEADER từ DataGridView
                    for (int i = 0; i < foodDataGridView.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = foodDataGridView.Columns[i].HeaderText;
                    }

                    // Format header
                    var headerRange = worksheet.Range(1, 1, 1, foodDataGridView.Columns.Count);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    // Xuất DỮ LIỆU
                    for (int i = 0; i < foodDataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < foodDataGridView.Columns.Count; j++)
                        {
                            var cellValue = foodDataGridView.Rows[i].Cells[j].Value;
                            worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString() ?? "";
                        }
                    }

                    // Format dữ liệu
                    var dataRange = worksheet.Range(2, 1, foodDataGridView.Rows.Count + 1, foodDataGridView.Columns.Count);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Auto fit columns
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Xuất Excel thành công!\nFile: " + filePath, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hỏi có muốn mở file không
                DialogResult result = MessageBox.Show("Bạn có muốn mở file Excel không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExel_Click(object sender, EventArgs e)
        {
            try
            {
                if (foodDataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = "DanhSachMonAn_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx",
                    Title = "Lưu file Excel"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapExel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Chọn file Excel để nhập"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            ImportFoodFromExcel(ofd.FileName);
        }

        private void ImportFoodFromExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Sheet đầu tiên
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua header

                    QLQCafeEntities db = new QLQCafeEntities();
                    int successCount = 0;
                    int errorCount = 0;
                    string errorMessage = "";

                    foreach (var row in rows)
                    {
                        try
                        {
                            // Đọc dữ liệu từ Excel
                            string name = row.Cell(1).GetString().Trim();
                            string foodCaIDStr = row.Cell(2).GetString().Trim();
                            string priceStr = row.Cell(3).GetString().Trim();

                            // Validate dữ liệu
                            if (string.IsNullOrEmpty(name))
                            {
                                errorCount++;
                                errorMessage += $"Dòng {row.RowNumber()}: Thiếu tên món\n";
                                continue;
                            }

                            if (!int.TryParse(foodCaIDStr, out int foodCaID))
                            {
                                errorCount++;
                                errorMessage += $"Dòng {row.RowNumber()}: FoodCaID không hợp lệ\n";
                                continue;
                            }

                            if (!int.TryParse(priceStr.Replace(",", "").Replace(".", ""), out int price))
                            {
                                errorCount++;
                                errorMessage += $"Dòng {row.RowNumber()}: Giá không hợp lệ\n";
                                continue;
                            }

                            // Kiểm tra FoodCaID có tồn tại không
                            bool categoryExists = db.FoodCategories.Any(fc => fc.FoodCaID == foodCaID);
                            if (!categoryExists)
                            {
                                errorCount++;
                                errorMessage += $"Dòng {row.RowNumber()}: FoodCaID={foodCaID} không tồn tại\n";
                                continue;
                            }

                            // Kiểm tra trùng tên món
                            bool exists = db.Foods.Any(f => f.name == name);
                            if (exists)
                            {
                                errorCount++;
                                errorMessage += $"Dòng {row.RowNumber()}: Món '{name}' đã tồn tại\n";
                                continue;
                            }

                            // Thêm món mới
                            Food food = new Food
                            {
                                name = name,
                                FoodCaID = foodCaID,
                                price = price
                            };

                            db.Foods.Add(food);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            errorCount++;
                            errorMessage += $"Dòng {row.RowNumber()}: {ex.Message}\n";
                        }
                    }

                    // Lưu vào database
                    db.SaveChanges();
                    LoadData();

                    // Hiển thị kết quả
                    string result = $"Nhập thành công: {successCount} món\n";
                    if (errorCount > 0)
                    {
                        result += $"Lỗi: {errorCount} dòng\n\n{errorMessage}";
                    }

                    MessageBox.Show(result, "Kết quả Import",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
