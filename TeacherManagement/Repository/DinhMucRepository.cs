using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeacherManagement.DTOs;

namespace TeacherManagement.Repository
{
    public class DinhMucRepository
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

        public DinhMucRepository()
        {
            Connection();
        }

        #region Định mức giảng dạy của giáo viên
        public List<DinhMucGiangDayDTO> DanhSachDinhMucGiangDay(DateTime namHoc)
        {
            List<DinhMucGiangDayDTO> dinhMucGiaoViens = new List<DinhMucGiangDayDTO>();

            TBGiaoVienRepository _giaoVienRepository = new TBGiaoVienRepository();

            var giaoViens = _giaoVienRepository.GetList();

            foreach (var giaovien in giaoViens)
            {
                DinhMucGiangDayDTO dinhMucGiangDay = DinhMucGiangDayCuaGiaoVienTheoNamHoc(giaovien.MaGV, namHoc, 0);

                if (dinhMucGiangDay != null)
                {
                    dinhMucGiaoViens.Add(dinhMucGiangDay);
                }
            }

            return dinhMucGiaoViens;
        }

        public DinhMucGiangDayDTO DinhMucGiangDayCuaGiaoVienTheoNamHoc(int maGV, DateTime namHoc, int loaiGiangDay)
        {
            SqlCommand conn = new SqlCommand("DinhMucGiangDay", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@namhoc", SqlDbType.DateTime).Value = namHoc;
            conn.Parameters.Add("@loaiGiangDay", SqlDbType.Int).Value = loaiGiangDay;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DinhMucGiangDayDTO dinhMucGiangDay = new DinhMucGiangDayDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"]),
                    TenChucVuChuyenMon = Convert.ToString(dataTable.Rows[0]["TenChuVuCM"]),
                    TenHocHam = Convert.ToString(dataTable.Rows[0]["TenHocHam"]),
                    TenLoaiMon = Convert.ToString(dataTable.Rows[0]["TenLoaiMon"]),
                    DinhMuc = Convert.ToInt32(dataTable.Rows[0]["DinhMuc"])
                };

                return dinhMucGiangDay;
            }

            return null;
        }

        #endregion

        #region Định mức nghiên cứu khoa học của giáo viên
        public List<DinhMucNghienCuuKHDTO> DanhSachDinhMucNghienCuuKH(DateTime namHoc)
        {
            List<DinhMucNghienCuuKHDTO> dinhMucGiaoViens = new List<DinhMucNghienCuuKHDTO>();

            TBGiaoVienRepository _giaoVienRepository = new TBGiaoVienRepository();

            var giaoViens = _giaoVienRepository.GetList();

            foreach (var giaovien in giaoViens)
            {
                DinhMucNghienCuuKHDTO dinhMucGiangDay = DinhMucNCKHCuaGiaoVienTheoNamHoc(giaovien.MaGV, namHoc);

                if (dinhMucGiangDay != null)
                {
                    dinhMucGiaoViens.Add(dinhMucGiangDay);
                }
            }

            return dinhMucGiaoViens;
        }

        public DinhMucNghienCuuKHDTO DinhMucNCKHCuaGiaoVienTheoNamHoc(int maGV, DateTime namHoc)
        {
            SqlCommand conn = new SqlCommand("DinhMucNghienCuuKhoaHoc", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@namhoc", SqlDbType.DateTime).Value = namHoc;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DinhMucNghienCuuKHDTO dinhMucNghienCuu = new DinhMucNghienCuuKHDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"]),
                    TenChucVuChuyenMon = Convert.ToString(dataTable.Rows[0]["TenChuVuCM"]),
                    TenHocHam = Convert.ToString(dataTable.Rows[0]["TenHocHam"]),
                    DinhMucGioChuan = Convert.ToInt32(dataTable.Rows[0]["DinhMucGioChuan"]),
                    DinhMucThoiGian = Convert.ToInt32(dataTable.Rows[0]["DinhMucThoiGian"]),
                };

                return dinhMucNghienCuu;
            }

            return null;
        }
        #endregion
    }
}