using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QlBangDia
{
    internal class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// Thêm dữ liệu vào bảng
        /// </summary>
        public int Insert(string query, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Sửa dữ liệu trong bảng
        /// </summary>
        public int Update(string query, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Xóa dữ liệu khỏi bảng
        /// </summary>
        public int Delete(string query, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Truy vấn dữ liệu từ bảng
        /// </summary>
        public DataTable Select(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        /// <summary>
        /// Hàm chung thực thi câu lệnh NonQuery
        /// </summary>
        private int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi câu lệnh: " + ex.Message);
            }
        }
    }
}
