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
    public class TBChucVuChuyenMonRepository
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

        public TBChucVuChuyenMonRepository()
        {
            Connection();
        }

        public List<TBChucVuChuyenMon> DanhSachChucVuChuyenMon()
        {
            {
                SqlCommand conn = new SqlCommand("dbo.DanhSachChucVuChuyenMon", _connection)
                {
                    CommandType = CommandType.StoredProcedure,
                };

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                List<TBChucVuChuyenMon> list = new List<TBChucVuChuyenMon>();

                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new TBChucVuChuyenMon
                    {
                        MaChucVuCM = Convert.ToInt32(dr["MaChucVuCM"]),
                        TenChuVuCM = Convert.ToString(dr["TenChuVuCM"])
                    });
                }

                return list;
            }
        }
    }
}