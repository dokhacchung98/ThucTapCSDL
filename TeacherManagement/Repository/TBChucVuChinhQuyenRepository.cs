using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeacherManagement.Models;

namespace TeacherManagement.Repository
{
    public class TBChucVuChinhQuyenRepository
    {
        private SqlConnection _connection;

        public void Connection()
        {
            string connectionString = ConfigurationManager
                                    .ConnectionStrings["TeacherManagementConnectString"].ToString();
            // nếu chưa tồn tại _connection thì mới khởi tạo đối tượng
            if (_connection == null)
            {
                _connection = new SqlConnection(connectionString);
            }
        }

        public TBChucVuChinhQuyenRepository()
        {
            Connection();
        }

        public List<TBChucVuChinhQuyen> DanhSachChucVuChinhQuyen()
        {
            {
                SqlCommand conn = new SqlCommand("dbo.DanhSachChucVuChinhQuyen", _connection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                List<TBChucVuChinhQuyen> list = new List<TBChucVuChinhQuyen>();

                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new TBChucVuChinhQuyen
                    {
                        MaChucVuChinhQuyen = Convert.ToInt32(dr["MaChucVuChinhQuyen"]),
                        TenChucVuChinhQuyen = Convert.ToString(dr["TenChucVuChinhQuyen"])
                    });
                }

                return list;
            }
        }
    }
}