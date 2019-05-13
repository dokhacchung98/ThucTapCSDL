using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TeacherManagement.Models;
using TeacherManagement.Utils;

namespace TeacherManagement.Repository
{
    public class TBChucVuDangRepository
    {
        private SqlConnection connection = ConnectionString.Connection();

        
        // GET: Lấy ra danh sách Chức Vụ Đảng
        public List<TBChucVuDang> GetList()
        {

            List<TBChucVuDang> list = new List<TBChucVuDang>();

            SqlCommand conn = new SqlCommand("DanhSachTBChucVuDang", connection)
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
                    new TBChucVuDang
                    {
                        MaChucVuDang = Convert.ToInt32(dr["MaChucVuDang"]),
                        TenChucVuDang = Convert.ToString(dr["TenChucVuDang"])
                    }
                );
            }

            return list;
        }

        // POST: Thêm mới Chức vụ Đảng
    }
}