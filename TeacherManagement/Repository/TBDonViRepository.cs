using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TeacherManagement.DTOs;
using TeacherManagement.Models;

namespace TeacherManagement.Repository
{
    public class TBDonViRepository
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

        public TBDonViRepository()
        {
            Connection();
        }

        public List<DonViDTO> DanhSachDonVi()
        {
            SqlCommand conn = new SqlCommand("dbo.SoLuongGiaoVienDonViHienNay", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            List<DonViDTO> list = new List<DonViDTO>();

            foreach(DataRow dr in dataTable.Rows)
            {
                list.Add(new DonViDTO
                {
                    MaDonVi = Convert.ToInt32(dr["MaDonVi"]),
                    TenDonVi = Convert.ToString(dr["TenDonVi"]),
                    SoLuong = Convert.ToInt32(dr["SoLuong"])
                });
            }

            return list;
        }

        public TBDonVi DonViTheoMaDonVi(int maDonVi)
        {
            SqlCommand conn = new SqlCommand("dbo.ThongTinDonVi", _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaDonVi", SqlDbType.Int).Value = maDonVi;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            
            if (dataTable.Rows.Count > 0)
            {
                return new TBDonVi
                {
                    MaDonVi = Convert.ToInt32(dataTable.Rows[0]["MaDonVi"]),
                    TenDonVi = Convert.ToString(dataTable.Rows[0]["TenDonVi"])
                };
            }

            return null;
        }

        public List<DonViNhanSuDTO> NhanSuCuaDonVi(int maDonVi, bool isHistory)
        {
            string storedProcedure = "";
            List<DonViNhanSuDTO> list = new List<DonViNhanSuDTO>();
            if (isHistory != true)
            {
                storedProcedure = "dbo.DonViCoGiaoVien";
            } else
            {
                storedProcedure = "dbo.LichSuNhanSuTheoMaDonVi";
            }
            SqlCommand conn = new SqlCommand(storedProcedure, _connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaDonVi", SqlDbType.Int).Value = maDonVi;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new DonViNhanSuDTO
                {
                    MaGV = Convert.ToInt32(row["MaGV"]),
                    TenGV = Convert.ToString(row["TenGV"]),
                    MaDonVi = Convert.ToInt32(row["MaDonVi"]),
                    ThoiGianNhan = Convert.ToDateTime(row["ThoiDiemNhan"]),
                    ThoiGianKetThuc = Convert.ToDateTime(row["ThoiDiemKetThuc"])
                });
            }

            if (list.Count > 0)
            {
                foreach(DonViNhanSuDTO giaoVien in list)
                {
                    TBGiaoVienRepository tBGiaoVienRepository = new TBGiaoVienRepository();
                    GiaoVienCVChinhQuyenDTO giaoVienCVChinhQuyenDTO = tBGiaoVienRepository.ChucVuChinhQuyenHienTai(giaoVien.MaGV);
                    GiaoVienHocHamDTO giaoVienHocHamDTO = tBGiaoVienRepository.HocHamGiaoVienHienTai(giaoVien.MaGV);
                    GiaoVienHocViDTO giaoVienHocViDTO = tBGiaoVienRepository.HocViGiaoVienHienTai(giaoVien.MaGV);

                    giaoVien.HocHam = giaoVienHocHamDTO.TenHocHam;
                    giaoVien.HocVi = giaoVienHocViDTO.TenHocVi;
                    giaoVien.ChucVu = giaoVienCVChinhQuyenDTO.TenChucVuChinhQuyen;
                }
            }
            return list;
        }
    }
}