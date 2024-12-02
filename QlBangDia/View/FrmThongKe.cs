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
    public partial class FrmThongKe : Form
    {
        private DatabaseHelper dbHelper;
        public FrmThongKe()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                // Câu truy vấn để lấy thông tin phiếu trả cùng với tên người mượn và tên băng đĩa
                string query = @"
                    SELECT 
                        PhieuTra.MaPhieuTra,
                        PhieuMuon.MaPhieuMuon,
                        PhieuTra.NgayTra,
                        PhieuTra.TongTien,
                        PhieuTra.PhiTraMuon,
                        PhieuMuon.TenNguoiMuon, 
                        BangDia.TenBangDia
                    FROM PhieuTra
                    JOIN PhieuMuon ON PhieuTra.MaPhieuMuon = PhieuMuon.MaPhieuMuon
                    JOIN BangDia ON PhieuMuon.MaBangDia = BangDia.MaBangDia";
                DataTable dataTable = dbHelper.Select(query);
                dtgvThongKe.DataSource = dataTable;
                dtgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBD = dtpNgayBD.Value;
                DateTime ngayKT = dtpKT.Value;

                if (ngayBD > ngayKT)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                    SELECT 
                        PhieuTra.MaPhieuTra,
                        PhieuMuon.MaPhieuMuon,
                        PhieuTra.NgayTra,
                        PhieuTra.TongTien,
                        PhieuTra.PhiTraMuon,
                        PhieuMuon.TenNguoiMuon, 
                        BangDia.TenBangDia
                    FROM PhieuTra
                    JOIN PhieuMuon ON PhieuTra.MaPhieuMuon = PhieuMuon.MaPhieuMuon
                    JOIN BangDia ON PhieuMuon.MaBangDia = BangDia.MaBangDia
                    WHERE PhieuTra.NgayTra BETWEEN @NgayBD AND @NgayKT"; 
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NgayBD", SqlDbType.DateTime) { Value = ngayBD },
                    new SqlParameter("@NgayKT", SqlDbType.DateTime) { Value = ngayKT }
                };

                // Thực thi câu truy vấn và lấy dữ liệu
                DataTable dataTable = dbHelper.Select(query, parameters);

                // Gán dữ liệu vào DataGridView
                dtgvThongKe.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Câu truy vấn để lấy thông tin phiếu trả cùng với tên người mượn và tên băng đĩa
                string query = @"
                    SELECT 
                        PhieuTra.MaPhieuTra,
                        PhieuMuon.MaPhieuMuon,
                        PhieuTra.NgayTra,
                        PhieuTra.TongTien,
                        PhieuTra.PhiTraMuon,
                        PhieuMuon.TenNguoiMuon, 
                        BangDia.TenBangDia
                    FROM PhieuTra
                    JOIN PhieuMuon ON PhieuTra.MaPhieuMuon = PhieuMuon.MaPhieuMuon
                    JOIN BangDia ON PhieuMuon.MaBangDia = BangDia.MaBangDia";
                DataTable dataTable = dbHelper.Select(query);
                dtgvThongKe.DataSource = dataTable;
                dtgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
