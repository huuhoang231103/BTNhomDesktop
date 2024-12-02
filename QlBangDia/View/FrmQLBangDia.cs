using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlBangDia.View
{
    public partial class FrmQLBangDia : Form
    {
        private DatabaseHelper dbHelper;

        public FrmQLBangDia()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void FrmQLBangDia_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM BangDia";
                DataTable data = dbHelper.Select(query);
                dtgvBangDia.DataSource = data;
                dtgvBangDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckRequiredFields()
        {
            // Kiểm tra tên băng đĩa
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên băng đĩa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra thể loại
            if (cbbTheLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thể loại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra giá thuê
            if (string.IsNullOrWhiteSpace(txtGiaThue.Text) || !decimal.TryParse(txtGiaThue.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập giá thuê hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra tiền cọc
            if (string.IsNullOrWhiteSpace(txtTienCoc.Text) || !decimal.TryParse(txtTienCoc.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập tiền cọc hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra trạng thái
            if (cbbTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredFields()) return;

            string tenBangDia = txtTen.Text;
            string theLoai = cbbTheLoai.SelectedItem.ToString();
            decimal giaMoiNgay = Convert.ToDecimal(txtGiaThue.Text);
            decimal tienCoc = Convert.ToDecimal(txtTienCoc.Text);
            string trangThai = cbbTrangThai.SelectedItem.ToString();
            string query = "INSERT INTO BangDia (TenBangDia, TheLoai, GiaMoiNgay, TienCoc, TrangThai) " +
                            "VALUES (@TenBangDia, @TheLoai, @GiaMoiNgay, @TienCoc, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@TenBangDia", tenBangDia),
                new SqlParameter("@TheLoai", theLoai),
                new SqlParameter("@GiaMoiNgay", giaMoiNgay),
                new SqlParameter("@TienCoc", tienCoc),
                new SqlParameter("@TrangThai", trangThai)
            };

            try
            {
                // Thực thi câu lệnh thêm vào cơ sở dữ liệu
                int result = dbHelper.Insert(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm băng đĩa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    txtTen.Clear();
                    cbbTheLoai.SelectedIndex = -1;
                    txtGiaThue.Clear();
                    txtTienCoc.Clear();
                    cbbTrangThai.SelectedIndex = -1; 
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm băng đĩa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Xóa thông tin trong các ô nhập liệu
            txtMa.Clear();
            txtTen.Clear();
            txtGiaThue.Clear();
            txtTienCoc.Clear();
            cbbTheLoai.SelectedIndex = -1; 
            cbbTrangThai.SelectedIndex = -1;
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            // Làm mới DataGridView để đảm bảo dữ liệu luôn được cập nhật
            LoadData();
        }

        private void dtgvBangDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBangDia.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaBangDia"].Value.ToString();
                txtTen.Text = row.Cells["TenBangDia"].Value.ToString();
                cbbTheLoai.SelectedItem = row.Cells["TheLoai"].Value.ToString();
                txtGiaThue.Text = row.Cells["GiaMoiNgay"].Value.ToString();
                txtTienCoc.Text = row.Cells["TienCoc"].Value.ToString();
                cbbTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();

                // Kiểm tra nếu txtMa có giá trị thì ẩn button1 và bật button2, button3
                if (!string.IsNullOrEmpty(txtMa.Text))
                {
                    button1.Enabled = false; 
                    button2.Enabled = true;  
                    button3.Enabled = true; 
                }
                else
                {
                    button1.Enabled = true;  
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn một băng đĩa để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận hành động xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa băng đĩa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // Thực hiện câu lệnh xóa
                string query = "DELETE FROM BangDia WHERE MaBangDia = @MaBangDia";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaBangDia", Convert.ToInt32(txtMa.Text))
                };

                try
                {
                    int result = dbHelper.Delete(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa băng đĩa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); 
                        txtMa.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa băng đĩa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn một băng đĩa để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckRequiredFields())
            {
                return;
            }

            string tenBangDia = txtTen.Text;
            string theLoai = cbbTheLoai.SelectedItem.ToString();
            decimal giaMoiNgay = Convert.ToDecimal(txtGiaThue.Text);
            decimal tienCoc = Convert.ToDecimal(txtTienCoc.Text);
            string trangThai = cbbTrangThai.SelectedItem.ToString();
            int maBangDia = Convert.ToInt32(txtMa.Text);

            string query = "UPDATE BangDia SET TenBangDia = @TenBangDia, TheLoai = @TheLoai, GiaMoiNgay = @GiaMoiNgay, " +
                           "TienCoc = @TienCoc, TrangThai = @TrangThai WHERE MaBangDia = @MaBangDia";

            SqlParameter[] parameters = {
                new SqlParameter("@TenBangDia", tenBangDia),
                new SqlParameter("@TheLoai", theLoai),
                new SqlParameter("@GiaMoiNgay", giaMoiNgay),
                new SqlParameter("@TienCoc", tienCoc),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaBangDia", maBangDia)
            };

            try
            {
                int result = dbHelper.Update(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật băng đĩa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); 
                    txtMa.Clear();
                    txtTen.Clear();
                    cbbTheLoai.SelectedIndex = -1;
                    txtGiaThue.Clear();
                    txtTienCoc.Clear();
                    cbbTrangThai.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật băng đĩa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tenBangDia = txtTim.Text;

            if (string.IsNullOrEmpty(tenBangDia))
            {
                MessageBox.Show("Vui lòng nhập tên băng đĩa để tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT * FROM BangDia WHERE TenBangDia LIKE '%' + @TenBangDia + '%'";
            SqlParameter[] parameters = {
                new SqlParameter("@TenBangDia", tenBangDia)
            };

            try
            {
                // Thực thi câu lệnh SELECT và lấy kết quả
                DataTable result = dbHelper.Select(query, parameters);

                if (result != null && result.Rows.Count > 0)
                {
                    dtgvBangDia.DataSource = result;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy băng đĩa nào với tên vừa nhập.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
