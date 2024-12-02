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
    public partial class FrmPhieuTra : Form
    {
        private DatabaseHelper dbHelper;
        public FrmPhieuTra()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        private void FrmPhieuTra_Load(object sender, EventArgs e)
        {
            LoadPhieuTraData();
            LoadMaPhieuMuonToComboBox();
        }
        private void LoadMaPhieuMuonToComboBox()
        {
            string query = @"
                SELECT MaPhieuMuon 
                FROM PhieuMuon 
                WHERE MaPhieuMuon NOT IN (SELECT DISTINCT MaPhieuMuon FROM PhieuTra)";
            try
            {
                DataTable result = dbHelper.Select(query, null);

                // Kiểm tra nếu có dữ liệu
                if (result != null && result.Rows.Count > 0)
                {
                    cbbMaPhieuMuon.DataSource = result;
                    cbbMaPhieuMuon.DisplayMember = "MaPhieuMuon";
                    cbbMaPhieuMuon.ValueMember = "MaPhieuMuon";
                }
                else
                {
                    MessageBox.Show("Không có phiếu mượn chưa trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuTraData()
        {
            try
            {
                // Truy vấn SQL đã được chỉnh sửa để bao gồm các cột cần thiết
                string query = "SELECT PhieuTra.MaPhieuTra, PhieuMuon.TenNguoiMuon, PhieuTra.NgayTra, PhieuTra.MaPhieuMuon, PhieuTra.TongTien, PhieuTra.PhiTraMuon " +
                               "FROM PhieuTra " +
                               "JOIN PhieuMuon ON PhieuTra.MaPhieuMuon = PhieuMuon.MaPhieuMuon";

                // Thực hiện truy vấn và lấy dữ liệu từ cơ sở dữ liệu
                DataTable result = dbHelper.Select(query, null);

                if (result != null && result.Rows.Count > 0)
                {
                    // Đặt dữ liệu vào DataGridView
                    dtgvPhieuTra.DataSource = result;

                    // Đảm bảo các cột có thể tự động điều chỉnh kích thước
                    dtgvPhieuTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có phiếu trả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbbMaPhieuMuon.SelectedValue == null || Convert.ToInt32(cbbMaPhieuMuon.SelectedValue) <= 0)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu mượn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTongTien.Text) || !decimal.TryParse(txtTongTien.Text, out decimal tongTien) || tongTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal phiTraMuon = 0;
            if (!string.IsNullOrEmpty(txtPhiTraMuon.Text) && !decimal.TryParse(txtPhiTraMuon.Text, out phiTraMuon))
            {
                MessageBox.Show("Vui lòng nhập phí trả mượn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maPhieuMuon = Convert.ToInt32(cbbMaPhieuMuon.SelectedValue);
            DateTime ngayTra = dtpNgayTra.Value;

            string query = "INSERT INTO PhieuTra (MaPhieuMuon, NgayTra, TongTien, PhiTraMuon) " +
                           "VALUES (@MaPhieuMuon, @NgayTra, @TongTien, @PhiTraMuon)";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhieuMuon", maPhieuMuon),
                new SqlParameter("@NgayTra", ngayTra),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@PhiTraMuon", phiTraMuon) // Đảm bảo giá trị phiTraMuon được sử dụng
            };

            try
            {
                // Thực thi câu lệnh INSERT
                int result = dbHelper.Insert(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm phiếu trả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuTraData(); // Cập nhật lại DataGridView
                    ClearInputFields();  // Xóa các ô nhập sau khi thêm
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm phiếu trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearInputFields()
        {
            txtMa.Clear();
            cbbMaPhieuMuon.SelectedIndex = -1; 
            dtpNgayTra.Value = DateTime.Now; 
            txtTongTien.Clear(); 
            txtPhiTraMuon.Clear();
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

        private void dtgvPhieuTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvPhieuTra.Rows[e.RowIndex];

                txtMa.Text = row.Cells["MaPhieuTra"].Value.ToString();

                if (row.Cells["MaPhieuMuon"].Value != DBNull.Value)
                {
                    int maPhieuMuon;
                    if (int.TryParse(row.Cells["MaPhieuMuon"].Value.ToString(), out maPhieuMuon))
                    {
                        cbbMaPhieuMuon.SelectedValue = maPhieuMuon;
                    }
                    else
                    {
                        MessageBox.Show("Giá trị MaPhieuMuon không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                dtpNgayTra.Value = Convert.ToDateTime(row.Cells["NgayTra"].Value);

                // Kiểm tra cột TongTien trước khi truy xuất
                if (row.Cells["TongTien"].Value != DBNull.Value)
                {
                    txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                }
                else
                {
                    txtTongTien.Text = string.Empty;
                }

                // Kiểm tra cột PhiTraMuon trước khi truy xuất
                if (row.Cells["PhiTraMuon"].Value != DBNull.Value)
                {
                    txtPhiTraMuon.Text = row.Cells["PhiTraMuon"].Value.ToString();
                }
                else
                {
                    txtPhiTraMuon.Text = string.Empty;
                }

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
                MessageBox.Show("Vui lòng chọn phiếu trả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu trả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Truy vấn xóa phiếu trả
                    string query = "DELETE FROM PhieuTra WHERE MaPhieuTra = @MaPhieuTra";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaPhieuTra", SqlDbType.Int) { Value = int.Parse(txtMa.Text) }
                    };

                    dbHelper.Update(query, parameters);
                    LoadPhieuTraData();

                    MessageBox.Show("Xóa phiếu trả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button21_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu trả để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbMaPhieuMuon.SelectedValue == null || Convert.ToInt32(cbbMaPhieuMuon.SelectedValue) <= 0)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu mượn hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTongTien.Text) || !decimal.TryParse(txtTongTien.Text, out decimal tongTien) || tongTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal phiTraMuon = 0;
            if (!string.IsNullOrEmpty(txtPhiTraMuon.Text) && !decimal.TryParse(txtPhiTraMuon.Text, out phiTraMuon))
            {
                MessageBox.Show("Vui lòng nhập phí trả mượn hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE PhieuTra SET " +
                               "MaPhieuMuon = @MaPhieuMuon, " +
                               "NgayTra = @NgayTra, " +
                               "TongTien = @TongTien, " +
                               "PhiTraMuon = @PhiTraMuon " +
                               "WHERE MaPhieuTra = @MaPhieuTra";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaPhieuMuon", SqlDbType.Int) { Value = cbbMaPhieuMuon.SelectedValue },
                    new SqlParameter("@NgayTra", SqlDbType.DateTime) { Value = dtpNgayTra.Value },
                    new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien },
                    new SqlParameter("@PhiTraMuon", SqlDbType.Decimal) { Value = string.IsNullOrEmpty(txtPhiTraMuon.Text) ? (object)DBNull.Value : phiTraMuon },
                    new SqlParameter("@MaPhieuTra", SqlDbType.Int) { Value = int.Parse(txtMa.Text) }
                };

                int result = dbHelper.Update(query, parameters);
                if (result > 0)
                {
                    LoadPhieuTraData();
                    MessageBox.Show("Cập nhật phiếu trả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu trả cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
