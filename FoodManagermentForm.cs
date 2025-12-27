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
    }
}
