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
    public partial class FrmQlNguoiDung : Form
    {
        private DatabaseHelper dbHelper;

        public FrmQlNguoiDung()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void FrmQlNguoiDung_Load(object sender, EventArgs e)
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
                string query = "SELECT * FROM NguoiDung";
                DataTable data = dbHelper.Select(query);
                dtgvNguoiDung.DataSource = data;
                dtgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckRequiredFields()
        {
			if (string.IsNullOrWhiteSpace(txtTenDN.Text) ||
					string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
					string.IsNullOrWhiteSpace(txtSDT.Text) ||
					cbbVaiTro.SelectedIndex == -1)
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}

        private void button1_Click(object sender, EventArgs e)
        {
			if (!CheckRequiredFields()) return;

			string tenDangNhap = txtTenDN.Text;
			string matKhau = txtMatKhau.Text;
			string hoTen = txtHoTen.Text;
			string soDienThoai = txtSDT.Text;
			string vaiTro = cbbVaiTro.SelectedItem.ToString();

			string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, SoDienThoai, VaiTro) " +
						   "VALUES (@TenDangNhap, @MatKhau, @HoTen, @SoDienThoai, @VaiTro)";

			SqlParameter[] parameters = {
		        new SqlParameter("@TenDangNhap", tenDangNhap),
		        new SqlParameter("@MatKhau", matKhau),
		        new SqlParameter("@HoTen", hoTen ?? (object)DBNull.Value), 
                new SqlParameter("@SoDienThoai", soDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@VaiTro", vaiTro)
	        };

			try
			{
				int result = dbHelper.Insert(query, parameters);

				if (result > 0)
				{
					MessageBox.Show("Thêm người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();  
					txtTenDN.Clear();
					txtMatKhau.Clear();
					txtHoTen.Clear();
					txtSDT.Clear();
					cbbVaiTro.SelectedIndex = -1;
				}
				else
				{
					MessageBox.Show("Có lỗi khi thêm người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtTenDN.Clear();
            txtSDT.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
			cbbVaiTro.SelectedIndex = -1;
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

            LoadData();
        }

		private void dtgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dtgvNguoiDung.Rows[e.RowIndex];
				txtMa.Text = row.Cells["MaNguoiDung"].Value.ToString();
				txtTenDN.Text = row.Cells["TenDangNhap"].Value.ToString();
				txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
				txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
				txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
				cbbVaiTro.SelectedItem = row.Cells["VaiTro"].Value.ToString();
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
				MessageBox.Show("Vui lòng chọn một người dùng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
				SqlParameter[] parameters = {
			        new SqlParameter("@MaNguoiDung", Convert.ToInt32(txtMa.Text)) 
                };

				try
				{
					int result = dbHelper.Delete(query, parameters);

					if (result > 0)
					{
						MessageBox.Show("Xóa người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadData();
						txtMa.Clear();
					}
					else
					{
						MessageBox.Show("Có lỗi khi xóa người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("Vui lòng chọn một người dùng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!CheckRequiredFields())
			{
				return;
			}

			string tenDangNhap = txtTenDN.Text;
			string hoTen = txtHoTen.Text;
			string soDienThoai = txtSDT.Text;
			string matKhau = txtMatKhau.Text;
			string vaiTro = cbbVaiTro.SelectedItem.ToString();
			int maNguoiDung = Convert.ToInt32(txtMa.Text);

			string query = "UPDATE NguoiDung SET TenDangNhap = @TenDangNhap, HoTen = @HoTen, SoDienThoai = @SoDienThoai, " +
						   "MatKhau = @MatKhau, VaiTro = @VaiTro WHERE MaNguoiDung = @MaNguoiDung";

			SqlParameter[] parameters = {
				new SqlParameter("@TenDangNhap", tenDangNhap),
				new SqlParameter("@HoTen", hoTen),
				new SqlParameter("@SoDienThoai", soDienThoai),
				new SqlParameter("@MatKhau", matKhau),
				new SqlParameter("@VaiTro", vaiTro),
				new SqlParameter("@MaNguoiDung", maNguoiDung)
			};

			try
			{
				int result = dbHelper.Update(query, parameters);

				if (result > 0)
				{
					MessageBox.Show("Cập nhật người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData(); 
					txtMa.Clear();
					txtTenDN.Clear();
					txtHoTen.Clear();
					txtSDT.Clear();
					txtMatKhau.Clear();
					cbbVaiTro.SelectedIndex = -1;
				}
				else
				{
					MessageBox.Show("Có lỗi khi cập nhật người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void button5_Click(object sender, EventArgs e)
		{
			string tenNguoiDung = txtTim.Text;

			if (string.IsNullOrEmpty(tenNguoiDung))
			{
				MessageBox.Show("Vui lòng nhập tên người dùng để tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string query = "SELECT * FROM NguoiDung WHERE TenDangNhap LIKE '%' + @TenNguoiDung + '%'";
			SqlParameter[] parameters = {
				new SqlParameter("@TenNguoiDung", tenNguoiDung)
			};

			try
			{
				DataTable result = dbHelper.Select(query, parameters);

				if (result != null && result.Rows.Count > 0)
				{
					dtgvNguoiDung.DataSource = result;
				}
				else
				{
					MessageBox.Show("Không tìm thấy người dùng nào với tên vừa nhập.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
