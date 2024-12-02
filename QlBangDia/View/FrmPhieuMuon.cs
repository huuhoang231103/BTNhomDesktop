using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QlBangDia.View
{
    public partial class FrmPhieuMuon : Form
    {
        private DatabaseHelper dbHelper;

        public FrmPhieuMuon()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtTienCoc.Clear();
            txtTienThue.Clear();
            dtpNgayMuon.Value = DateTime.Now;  
            dtpNgayTra.Checked = false; 
            cbbTrangThai.SelectedIndex = -1; 
            cbbBangDia.SelectedIndex = -1;
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                button1.Enabled = true;
                button2.Enabled = false;
                btnExport.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                btnExport.Enabled = true;
                button3.Enabled = true;
            }

            LoadPhieuMuonData();
        }

        private void FrmPhieuMuon_Load(object sender, EventArgs e)
        {
            LoadPhieuMuonData();
            LoadBangDiaToComboBox();
            button1.Enabled = true;
            button2.Enabled = false;
            btnExport.Enabled = false;
            button3.Enabled = false;
        }
        private void LoadBangDiaToComboBox()
        {
            string query = "SELECT MaBangDia, TenBangDia FROM BangDia"; // Truy vấn lấy MaBangDia và TenBangDia

            try
            {
                DataTable result = dbHelper.Select(query, null);

                if (result != null && result.Rows.Count > 0)
                {
                    cbbBangDia.DataSource = result;
                    cbbBangDia.ValueMember = "MaBangDia"; 
                    cbbBangDia.DisplayMember = "TenBangDia";
                }
                else
                {
                    MessageBox.Show("Không có băng đĩa nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu băng đĩa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuMuonData()
        {
            string query = "SELECT PhieuMuon.MaPhieuMuon, PhieuMuon.TenNguoiMuon, PhieuMuon.NgayMuon, PhieuMuon.NgayTra, PhieuMuon.TongTienCoc, PhieuMuon.TongTienThue, PhieuMuon.TrangThai, BangDia.MaBangDia " +
                           "FROM PhieuMuon " +
                           "JOIN BangDia ON PhieuMuon.MaBangDia = BangDia.MaBangDia";

            try
            {
                DataTable result = dbHelper.Select(query, null);

                if (result != null && result.Rows.Count > 0)
                {
                    // Đổ dữ liệu vào DataGridView
                    dtgvPhieuMuon.DataSource = result;

                    // Tự động điều chỉnh kích thước cột cho vừa với dữ liệu
                    dtgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có phiếu mượn nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi truy vấn dữ liệu
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tenNguoiMuon = txtTen.Text; // Tên người mượn
            DateTime ngayMuon = dtpNgayMuon.Value; // Ngày mượn từ DateTimePicker
            decimal tongTienCoc = Convert.ToDecimal(txtTienCoc.Text); // Tổng tiền cọc
            decimal tongTienThue = Convert.ToDecimal(txtTienThue.Text); // Tổng tiền thuê
            DateTime? ngayTra = dtpNgayTra.Checked ? dtpNgayTra.Value : (DateTime?)null; // Ngày trả (nullable)
            string trangThai = cbbTrangThai.SelectedItem.ToString(); // Trạng thái mượn
            int maBangDia = Convert.ToInt32(cbbBangDia.SelectedValue); // Mã băng đĩa từ ComboBox

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(tenNguoiMuon) || maBangDia == 0 || string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO PhieuMuon (TenNguoiMuon, NgayMuon, TongTienCoc, TongTienThue, NgayTra, TrangThai, MaBangDia) " +
                           "VALUES (@TenNguoiMuon, @NgayMuon, @TongTienCoc, @TongTienThue, @NgayTra, @TrangThai, @MaBangDia)";

            SqlParameter[] parameters = {
                new SqlParameter("@TenNguoiMuon", tenNguoiMuon),
                new SqlParameter("@NgayMuon", ngayMuon),
                new SqlParameter("@TongTienCoc", tongTienCoc),
                new SqlParameter("@TongTienThue", tongTienThue),
                new SqlParameter("@NgayTra", (object)ngayTra ?? DBNull.Value),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaBangDia", maBangDia)
            };

            try
            {
                // Thực thi câu lệnh INSERT
                int result = dbHelper.Insert(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm phiếu mượn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuMuonData();  // Tải lại dữ liệu phiếu mượn

                    // Xóa các ô nhập liệu sau khi thêm thành công
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm phiếu mượn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtTen.Clear();
            txtTienCoc.Clear();
            txtTienThue.Clear();
            dtpNgayMuon.Value = DateTime.Now;  // Đặt lại ngày mượn mặc định
            dtpNgayTra.Checked = false;  // Bỏ chọn ngày trả
            cbbTrangThai.SelectedIndex = -1; // Bỏ chọn trạng thái
            cbbBangDia.SelectedIndex = -1;  // Bỏ chọn băng đĩa
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                button1.Enabled = false;
                button2.Enabled = true;
                btnExport.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                btnExport.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void dtgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvPhieuMuon.Rows[e.RowIndex];

                txtMa.Text = row.Cells["MaPhieuMuon"].Value.ToString();
                txtTen.Text = row.Cells["TenNguoiMuon"].Value.ToString();
                dtpNgayMuon.Value = Convert.ToDateTime(row.Cells["NgayMuon"].Value);
                txtTienCoc.Text = row.Cells["TongTienCoc"].Value.ToString();
                txtTienThue.Text = row.Cells["TongTienThue"].Value.ToString();

                if (row.Cells["NgayTra"].Value != DBNull.Value)
                {
                    dtpNgayTra.Value = Convert.ToDateTime(row.Cells["NgayTra"].Value);
                    dtpNgayTra.Checked = true;  
                }
                else
                {
                    dtpNgayTra.Checked = false;
                }
                cbbTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                cbbBangDia.SelectedValue = row.Cells["MaBangDia"].Value.ToString();
            }
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                button1.Enabled = false;
                button2.Enabled = true;
                btnExport.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                btnExport.Enabled = false;
                button3.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các ô input
                int maPhieuMuon = Convert.ToInt32(txtMa.Text); // Mã phiếu mượn
                string tenNguoiMuon = txtTen.Text; // Tên người mượn
                DateTime ngayMuon = dtpNgayMuon.Value; // Ngày mượn từ DateTimePicker
                decimal tongTienCoc = Convert.ToDecimal(txtTienCoc.Text); // Tổng tiền cọc
                decimal tongTienThue = Convert.ToDecimal(txtTienThue.Text); // Tổng tiền thuê
                DateTime? ngayTra = dtpNgayTra.Checked ? dtpNgayTra.Value : (DateTime?)null; // Ngày trả (nullable)
                string trangThai = cbbTrangThai.SelectedItem.ToString(); // Trạng thái mượn
                int maBangDia = Convert.ToInt32(cbbBangDia.SelectedValue); // Mã băng đĩa từ ComboBox

                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(tenNguoiMuon) || maBangDia == 0 || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Truy vấn SQL để cập nhật phiếu mượn
                string query = "UPDATE PhieuMuon SET TenNguoiMuon = @TenNguoiMuon, NgayMuon = @NgayMuon, " +
                               "TongTienCoc = @TongTienCoc, TongTienThue = @TongTienThue, NgayTra = @NgayTra, " +
                               "TrangThai = @TrangThai, MaBangDia = @MaBangDia WHERE MaPhieuMuon = @MaPhieuMuon";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhieuMuon", maPhieuMuon),
                    new SqlParameter("@TenNguoiMuon", tenNguoiMuon),
                    new SqlParameter("@NgayMuon", ngayMuon),
                    new SqlParameter("@TongTienCoc", tongTienCoc),
                    new SqlParameter("@TongTienThue", tongTienThue),
                    new SqlParameter("@NgayTra", (object)ngayTra ?? DBNull.Value),
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@MaBangDia", maBangDia)
                };

                // Thực thi câu lệnh UPDATE
                int result = dbHelper.Update(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật phiếu mượn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi cập nhật thành công, làm sạch các ô input
                    ClearInputFields();
                    LoadPhieuMuonData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật phiếu mượn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maPhieuMuon = Convert.ToInt32(txtMa.Text);
                if (maPhieuMuon == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                string query = "DELETE FROM PhieuMuon WHERE MaPhieuMuon = @MaPhieuMuon";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhieuMuon", maPhieuMuon)
                };

                int result = dbHelper.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa phiếu mượn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputFields();
                    LoadPhieuMuonData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa phiếu mượn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNguoiMuon = txtTim.Text.Trim();
                if (string.IsNullOrEmpty(tenNguoiMuon))
                {
                    MessageBox.Show("Vui lòng nhập tên người mượn để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = "SELECT PhieuMuon.MaPhieuMuon, PhieuMuon.TenNguoiMuon, PhieuMuon.NgayMuon, PhieuMuon.NgayTra, PhieuMuon.TongTienCoc, PhieuMuon.TongTienThue, PhieuMuon.TrangThai, BangDia.MaBangDia " +
                               "FROM PhieuMuon " +
                               "JOIN BangDia ON PhieuMuon.MaBangDia = BangDia.MaBangDia " +
                               "WHERE PhieuMuon.TenNguoiMuon LIKE @TenNguoiMuon";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenNguoiMuon", "%" + tenNguoiMuon + "%") 
                };

                DataTable result = dbHelper.Select(query, parameters);
                if (result != null && result.Rows.Count > 0)
                {
                    dtgvPhieuMuon.DataSource = result;
                    dtgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn với tên người mượn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieuMuon = int.Parse(txtMa.Text);

            try
            {
                // Query SQL lấy thông tin phiếu mượn
                string query = @"
            SELECT pm.MaPhieuMuon, pm.TenNguoiMuon, pm.NgayMuon, pm.TongTienCoc, pm.TongTienThue, pm.NgayTra, pm.TrangThai, bd.TenBangDia
            FROM PhieuMuon pm
            INNER JOIN BangDia bd ON pm.MaBangDia = bd.MaBangDia
            WHERE pm.MaPhieuMuon = @MaPhieuMuon";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaPhieuMuon", SqlDbType.Int) { Value = maPhieuMuon }
                };

                DataTable result = dbHelper.Select(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow row = result.Rows[0];
                string tenNguoiMuon = row["TenNguoiMuon"].ToString();
                DateTime ngayMuon = Convert.ToDateTime(row["NgayMuon"]);
                decimal tongTienCoc = Convert.ToDecimal(row["TongTienCoc"]);
                decimal tongTienThue = Convert.ToDecimal(row["TongTienThue"]);
                DateTime ngayTra = Convert.ToDateTime(row["NgayTra"]);
                string trangThai = row["TrangThai"].ToString();
                string tenBangDia = row["TenBangDia"].ToString();

                // Đường dẫn thư mục Downloads
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                string fileName = $"HoaDon_{maPhieuMuon}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(downloadsPath, fileName);

                // Tạo file PDF với QuestPDF
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(20);
                        page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                        page.Header().Text("HÓA ĐƠN THUÊ BĂNG ĐĨA").Bold().FontSize(18).AlignCenter();
                        page.Content().PaddingVertical(10).Column(column =>
                        {
                            column.Item().Text($"Mã Phiếu Mượn: {maPhieuMuon}");
                            column.Item().Text($"Tên Người Mượn: {tenNguoiMuon}");
                            column.Item().Text($"Ngày Mượn: {ngayMuon:dd/MM/yyyy}");
                            column.Item().Text($"Ngày Trả: {ngayTra:dd/MM/yyyy}");
                            column.Item().Text($"Băng Đĩa: {tenBangDia}");
                            column.Item().Text($"Tổng Tiền Cọc: {tongTienCoc.ToString("C0", new CultureInfo("vi-VN"))}");
                            column.Item().Text($"Tổng Tiền Thuê: {tongTienThue.ToString("C0", new CultureInfo("vi-VN"))}");
                            column.Item().Text($"Trạng Thái: {trangThai}");
                        });

                        page.Footer().AlignCenter().Text("Cảm ơn quý khách đã sử dụng dịch vụ!").FontSize(10).Italic();
                    });
                }).GeneratePdf(filePath);

                // Thông báo thành công
                MessageBox.Show("Hóa đơn đã được xuất thành công vào thư mục Downloads!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
