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
    public class TBHocViRepository
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

        public TBHocViRepository()
        {
            Connection();
        }

        public List<TBHocVi> DanhSachHocVi()
        {
            SqlCommand conn = new SqlCommand("dbo.DanhSachHocVi", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            List<TBHocVi> list = new List<TBHocVi>();

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new TBHocVi
                {
                    MaHocVi = Convert.ToInt32(dr["MaHocVi"]),
                    TenHocVi = Convert.ToString(dr["TenHocVi"])
                });
            }

            return list;
        }
    }
}