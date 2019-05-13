using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeacherManagement.Models;
using TeacherManagement.Utils;

namespace TeacherManagement.Repository
{
    public class TBGiaoVienRepository
    {
        private SqlConnection connection;

        public void Connection()
        {
            string connectionString = ConfigurationManager
                                    .ConnectionStrings["TeacherManagementConnectString"].ToString();
            // nếu chưa tồn tại connection thì mới khởi tạo đối tượng
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }
        }

        // GET: Lấy ra danh sách Chức Vụ Đảng
        public List<TBGiaoVien> GetList()
        {
            Connection();
            List<TBGiaoVien> list = new List<TBGiaoVien>();

            SqlCommand conn = new SqlCommand("DanhSachGiaoVien", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            connection.Open();

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(
                    new TBGiaoVien
                    {
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenGV = Convert.ToString(dr["TenGV"]),
                        NgaySinh = Convert.ToDateTime(dr["NgaySinh"]),
                        Email = dr["Email"].ToString(),
                        SDT = dr["SDT"].ToString(),
                        DiaChi = dr["DiaChi"].ToString()
                    }
                );
            }

            return list;
        }
    }
}