using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeacherManagement.DTOs;
using TeacherManagement.Models;

namespace TeacherManagement.Repository
{
    public class TBHocHamRepository
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

        public TBHocHamRepository()
        {
            Connection();
        }

        public List<TBHocHam> DanhSachHocHam()
        {
            SqlCommand conn = new SqlCommand("dbo.DanhSachHocHam", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            List<TBHocHam> list = new List<TBHocHam>();

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new TBHocHam
                {
                    MaHocHam = Convert.ToInt32(dr["MaHocHam"]),
                    TenHocHam = Convert.ToString(dr["TenHocHam"])
                });
            }

            return list;
        }
    }
}