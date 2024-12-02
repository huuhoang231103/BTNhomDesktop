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

namespace QlBangDia
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Khởi tạo đối tượng DatabaseHelper
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Khai báo biến kiểm tra vai trò
            bool isAdmin = false;

            // Kiểm tra đăng nhập và vai trò
            if (CheckLogin(username, password, dbHelper, out isAdmin))
            {
                // Kiểm tra nếu người dùng là Admin
                if (isAdmin)
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập Admin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool CheckLogin(string username, string password, DatabaseHelper dbHelper, out bool isAdmin)
        {
            // Câu truy vấn SQL để lấy cả mật khẩu và vai trò của người dùng
            string query = "SELECT COUNT(*), VaiTro FROM NguoiDung WHERE TenDangNhap = @username AND MatKhau = @password GROUP BY VaiTro";
                    SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable result = dbHelper.Select(query, parameters);
            if (result != null && result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0)
            {
                string role = result.Rows[0]["VaiTro"].ToString();
                isAdmin = role.Equals("Admin", StringComparison.OrdinalIgnoreCase); // Kiểm tra nếu là Admin
                return true; 
            }

            isAdmin = false;
            return false; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
