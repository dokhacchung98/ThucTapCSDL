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
    public class TBGiaoVienCongTacRepository
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

        public TBGiaoVienCongTacRepository()
        {
            Connection();
        }

        public List<HocVienHuongDanDTO> LayDanhSachHocVienHuongDan()
        {
            SqlCommand conn = new SqlCommand("dbo.LayTatCaHocVienHuongDan", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<HocVienHuongDanDTO> list = new List<HocVienHuongDanDTO>();
            foreach (DataRow d in dataTable.Rows)
            {
                list.Add(new HocVienHuongDanDTO()
                {
                    MaHocVien = Convert.ToInt32(d["MaHocVien"]),
                    MaLoaiHuongDan = Convert.ToInt32(d["MaLoaiHuongDan"]),
                    MaLopHuongDan = Convert.ToInt32(d["MaLopHuongDan"]),
                    TenHocVien = Convert.ToString(d["TenHocVien"])
                });
            }
            return list;
        }

        public List<HoiDongDTO> LayDanhSachHoiDong()
        {
            SqlCommand conn = new SqlCommand("dbo.LayDanhSachHoiDong", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<HoiDongDTO> list = new List<HoiDongDTO>();
            foreach (DataRow d in dataTable.Rows)
            {
                list.Add(new HoiDongDTO()
                {
                    MaHoiDong = Convert.ToInt32(d["MaHoiDong"]),
                    TenHoiDong = Convert.ToString(d["TenHoiDong"]),
                    MaLoaiHoiDong = Convert.ToInt32(d["MaLoaiHoiDong"])
                });
            }
            return list;
        }

        public List<CongTacKhacsDTO> LayDanhSachCongTacKhac()
        {
            SqlCommand conn = new SqlCommand("dbo.LayDanhSachCongTac", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<CongTacKhacsDTO> list = new List<CongTacKhacsDTO>();
            foreach (DataRow d in dataTable.Rows)
            {
                list.Add(new CongTacKhacsDTO()
                {
                    MaCongTac = Convert.ToInt32(d["MaCongTac"]),
                    NoiDungCongTac = Convert.ToString(d["NoidungCongTac"]),
                });
            }
            return list;
        }

        public List<LopMonHocGiangDayDTO> LayDanhSachLopGiangDay()
        {
            SqlCommand conn = new SqlCommand("dbo.LayDanhSachLop", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<LopMonHocGiangDayDTO> list = new List<LopMonHocGiangDayDTO>();
            foreach (DataRow d in dataTable.Rows)
            {
                list.Add(new LopMonHocGiangDayDTO()
                {
                    MaLopMonHocGiangDay = Convert.ToInt32(d["MaLopMonHocGiangDay"]),
                    MaHeDaoTao = Convert.ToInt32(d["MaHeDaoTao"]),
                    MaHocPhan = Convert.ToInt32(d["MaHocPhan"]),
                    SiSo = Convert.ToInt32(d["SiSo"]),
                    TenLopMonHocGiangDay = Convert.ToString(d["TenLopMonHocGiangDay"]),
                    ThoiDiem = Convert.ToDateTime(d["ThoiDiem"]),
                });
            }
            return list;
        }
    }
}