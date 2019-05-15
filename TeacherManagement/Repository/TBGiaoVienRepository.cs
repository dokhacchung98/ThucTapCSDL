﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TeacherManagement.DTOs;
using TeacherManagement.Models;

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

        public TBGiaoVienRepository()
        {
            Connection();
        }

        #region Thông tin hiện tại của giáo viên
        public List<TBGiaoVien> GetList()
        {
            List<TBGiaoVien> list = new List<TBGiaoVien>();
            List<TBGiaoVien> giaoViens = new List<TBGiaoVien>();

            SqlCommand conn = new SqlCommand("DanhSachGiaoVien", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int giaoVienId = Convert.ToInt32(dr["MaGV"]);

                // Lấy ra học hàm hiện tại của giáo viên
                GiaoVienHocHamDTO hocHamDTOs = HocHamGiaoVienHienTai(giaoVienId);

                List<TBChiTietHocHam> tBChiTietHocHams = new List<TBChiTietHocHam>();
                if (hocHamDTOs != null)
                {
                    tBChiTietHocHams.Add(new TBChiTietHocHam
                    {
                        Ma = hocHamDTOs.Ma,
                        MaGV = hocHamDTOs.MaGV,
                        MaHocHam = hocHamDTOs.MaHocHam,
                        ThoiDiemNhan = hocHamDTOs.ThoiDiemNhan,
                        TBHocHam = new TBHocHam
                        {
                            MaHocHam = hocHamDTOs.MaHocHam,
                            TenHocHam = hocHamDTOs.TenHocHam
                        }
                    });
                }
                // Lấy ra học vị hiện tại của giáo viên
                GiaoVienHocViDTO hocViDTO = HocViGiaoVienHienTai(giaoVienId);

                List<TBChiTietHocVi> tBChiTietHocVis = new List<TBChiTietHocVi>();
                if (hocViDTO != null)
                {
                    tBChiTietHocVis.Add(
                        new TBChiTietHocVi
                        {
                            Ma = hocViDTO.Ma,
                            MaGV = hocViDTO.MaGV,
                            MaHocVi = hocViDTO.MaHocVi,
                            ThoiDiemNhan = hocViDTO.ThoiDiemNhan,
                            TBHocVi = new TBHocVi
                            {
                                MaHocVi = hocViDTO.MaHocVi,
                                TenHocVi = hocViDTO.TenHocVi
                            }
                        }
                    );
                }
                // Lấy ra đơn vị hiện tại của giáo viên
                GiaoVienDonViDTO giaoVienDonViDTO = DonViGiaoVienHienTai(giaoVienId);
                List<TBChiTietChucVuChinhQuyen> tBChiTietChucVuChinhQuyens = new List<TBChiTietChucVuChinhQuyen>();
                if (giaoVienDonViDTO != null)
                {
                    tBChiTietChucVuChinhQuyens.Add(
                        new TBChiTietChucVuChinhQuyen
                        {
                            Ma = giaoVienDonViDTO.Ma,
                            MaGV = giaoVienDonViDTO.MaGV,
                            MaDonVi = giaoVienDonViDTO.MaDonVi,
                            ThoiDiemNhan = giaoVienDonViDTO.ThoiDiemNhan,
                            ThoiDiemKetThuc = giaoVienDonViDTO.ThoiDiemKetThuc,
                            TBDonVi = new TBDonVi
                            {
                                MaDonVi = giaoVienDonViDTO.MaDonVi,
                                TenDonVi = giaoVienDonViDTO.TenDonVi
                            }
                        });
                }

                // lấy ra chức vụ chuyên môn hiện tại của giáo viên
                GiaoVienChuyenMonDTO giaoVienChuyenMonDTO = ChuyenMonGiaoVienHienTai(giaoVienId);
                List<TBChiTietChuVuChuyenMon> tBChiTietChucVuChuyenMons = new List<TBChiTietChuVuChuyenMon>();

                if (giaoVienChuyenMonDTO != null)
                {
                    tBChiTietChucVuChuyenMons.Add(new TBChiTietChuVuChuyenMon
                    {
                        Ma = giaoVienChuyenMonDTO.Ma,
                        MaGV = giaoVienChuyenMonDTO.MaGV,
                        MaChucVuCM = giaoVienChuyenMonDTO.MaChucVuCM,
                        ThoiDiemNhan = giaoVienChuyenMonDTO.ThoiDiemNhan,
                        TBChucVuChuyenMon = new TBChucVuChuyenMon
                        {
                            MaChucVuCM = giaoVienChuyenMonDTO.MaChucVuCM,
                            TenChuVuCM = giaoVienChuyenMonDTO.TenChucVuCM
                        }
                    });
                }
                giaoViens.Add(new TBGiaoVien
                {
                    MaGV = Convert.ToInt32(dr["MaGV"]),
                    TenGV = Convert.ToString(dr["TenGV"]),
                    TBChiTietHocHams = tBChiTietHocHams,
                    TBChiTietHocVis = tBChiTietHocVis,
                    TBChiTietChucVuChinhQuyens = tBChiTietChucVuChinhQuyens,
                    TBChiTietChuVuChuyenMons = tBChiTietChucVuChuyenMons
                });
            }
;
            return giaoViens;
        }

        public GiaoVienChuyenMonDTO ChuyenMonGiaoVienHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChucVuChuyenMonHienTai", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienChuyenMonDTO giaoVienChuyenMonDTO = new GiaoVienChuyenMonDTO
                {
                    Ma = Convert.ToInt32(dataTable.Rows[0]["Ma"]),
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenChucVuCM = Convert.ToString(dataTable.Rows[0]["TenChuVuCM"]),
                    MaChucVuCM = Convert.ToInt32(dataTable.Rows[0]["MaChucVuCM"]),
                    ThoiDiemNhan = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemNhan"]),
                };
                return giaoVienChuyenMonDTO;
            }

            return null;
        }

        public GiaoVienDonViDTO DonViGiaoVienHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.DonViHienTai", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienDonViDTO giaoVienDonViDTO = new GiaoVienDonViDTO
                {
                    Ma = Convert.ToInt32(dataTable.Rows[0]["Ma"]),
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenDonVi = Convert.ToString(dataTable.Rows[0]["TenDonVi"]),
                    MaDonVi = Convert.ToInt32(dataTable.Rows[0]["MaDonVi"]),
                    ThoiDiemNhan = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemNhan"]),
                    ThoiDiemKetThuc = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemKetThuc"])
                };
                return giaoVienDonViDTO;
            }

            return null;

        }

        public GiaoVienHocViDTO HocViGiaoVienHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.HocViHienTai", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienHocViDTO giaoVienHocViDTO = new GiaoVienHocViDTO
                {
                    Ma = Convert.ToInt32(dataTable.Rows[0]["Ma"]),
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenHocVi = Convert.ToString(dataTable.Rows[0]["TenHocVi"]),
                    MaHocVi = Convert.ToInt32(dataTable.Rows[0]["MaHocVi"]),
                    ThoiDiemNhan = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemNhan"])
                };

                return giaoVienHocViDTO;
            }

            

            return null;
        }

        public GiaoVienHocHamDTO HocHamGiaoVienHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.HocHamHienTai", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienHocHamDTO giaoVienHocHamDTO = new GiaoVienHocHamDTO
                {
                    Ma = Convert.ToInt32(dataTable.Rows[0]["Ma"]),
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenHocHam = Convert.ToString(dataTable.Rows[0]["TenHocHam"]),
                    MaHocHam = Convert.ToInt32(dataTable.Rows[0]["MaHocHam"]),
                    ThoiDiemNhan = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemNhan"])
                };

                return giaoVienHocHamDTO;
            }

            return null;
        }

        public GiaoVienChucVuDangDTO ChucVuDangHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.GiaoVienChucVuDang", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienChucVuDangDTO giaoVienChucVuDangDTO = new GiaoVienChucVuDangDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenChucVuDang = Convert.ToString(dataTable.Rows[0]["TenChucVuDang"]),
                    TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"])
                };

                return giaoVienChucVuDangDTO;
            }

            return null;
        }

        #endregion

        #region Thông tin theo lịch sử của giáo viên
        public TBGiaoVien LayGiaoVienTheoMaGV(int maGV)
        {
            // Lấy thông tin cơ bản của giáo viên
            GiaoVienDTO giaoVienDTO = ThongTinCoBan(maGV);

            // Lấy lịch sử Học Hàm của giáo viên
            List<GiaoVienHocHamDTO> hocHamDTOs = LichSuHocHam(maGV);

            List<TBChiTietHocHam> tBChiTietHocHams = new List<TBChiTietHocHam>();
            
            if (hocHamDTOs.Count > 0)
            {
                foreach(var hocHam in hocHamDTOs)
                {
                    tBChiTietHocHams.Add(new TBChiTietHocHam
                    {
                        Ma = hocHam.Ma,
                        MaGV = hocHam.MaGV,
                        MaHocHam = hocHam.MaHocHam,
                        ThoiDiemNhan = hocHam.ThoiDiemNhan,
                        TBHocHam = new TBHocHam
                        {
                            MaHocHam = hocHam.MaHocHam,
                            TenHocHam = hocHam.TenHocHam
                        }
                    });
                }
            }

            // Lấy lịch sử học vị của giáo viên
            List<GiaoVienHocViDTO> hocViDTOs = LichSuHocVi(maGV);

            List<TBChiTietHocVi> tBChiTietHocVis = new List<TBChiTietHocVi>();

            if (hocViDTOs.Count > 0)
            {
                foreach (var hocVi in hocViDTOs)
                {
                    tBChiTietHocVis.Add(new TBChiTietHocVi
                    {
                        Ma = hocVi.Ma,
                        MaGV = hocVi.MaGV,
                        MaHocVi = hocVi.MaHocVi,
                        ThoiDiemNhan = hocVi.ThoiDiemNhan,
                        TBHocVi = new TBHocVi
                        {
                            MaHocVi = hocVi.MaHocVi,
                            TenHocVi = hocVi.TenHocVi
                        }
                    });
                }
            }

            // Lấy lịch sử đơn vị của giáo viên
            List<GiaoVienDonViDTO> donViDTOs = LichSuDonVi(maGV);

            List<TBChiTietChucVuChinhQuyen> tBChiTietChucVuChinhQuyens = new List<TBChiTietChucVuChinhQuyen>();

            if (donViDTOs.Count > 0)
            {
                foreach (var donVi in donViDTOs)
                {
                    tBChiTietChucVuChinhQuyens.Add(new TBChiTietChucVuChinhQuyen
                    {
                        Ma = donVi.Ma,
                        MaGV = donVi.MaGV,
                        ThoiDiemNhan = donVi.ThoiDiemNhan,
                        ThoiDiemKetThuc = donVi.ThoiDiemKetThuc,
                        TBDonVi = new TBDonVi
                        {
                            MaDonVi = donVi.MaDonVi,
                            TenDonVi = donVi.TenDonVi
                        }
                    });
                }
            }

            // Lấy ra lịch sử chức vụ chuyên môn của giáo viên
            List<GiaoVienChuyenMonDTO> chuyenMonDTOs = LichSuChuyenMon(maGV);

            List<TBChiTietChuVuChuyenMon> tBChiTietChuVuChuyenMons = new List<TBChiTietChuVuChuyenMon>();

            if (chuyenMonDTOs.Count > 0)
            {
                foreach (var chuyenMonDTO in chuyenMonDTOs)
                {
                    tBChiTietChuVuChuyenMons.Add(new TBChiTietChuVuChuyenMon
                    {
                        Ma = chuyenMonDTO.Ma,
                        MaGV = chuyenMonDTO.MaGV,
                        ThoiDiemNhan = chuyenMonDTO.ThoiDiemNhan,
                        TBChucVuChuyenMon = new TBChucVuChuyenMon
                        {
                            MaChucVuCM = chuyenMonDTO.MaChucVuCM,
                            TenChuVuCM = chuyenMonDTO.TenChucVuCM
                        }
                    });
                }
            }
            // Trả về thông tin giáo viên
            TBGiaoVien tBGiaoVien = new TBGiaoVien
            {
                // Thông tin cơ bản
                MaGV = giaoVienDTO.MaGV,
                TenGV = giaoVienDTO.TenGV,
                NgaySinh = giaoVienDTO.NgaySinh,
                Email = giaoVienDTO.Email,
                SDT = giaoVienDTO.SDT,
                DiaChi = giaoVienDTO.DiaChi,
                GioiTinh = giaoVienDTO.GioiTinh,

                // Lịch sử Học hàm của giáo viên
                TBChiTietHocHams = tBChiTietHocHams,
                // Lịch sử Học vị của giáo viên
                TBChiTietHocVis = tBChiTietHocVis,
                // Lịch sử đơn vị của giáo viên
                TBChiTietChucVuChinhQuyens = tBChiTietChucVuChinhQuyens,
                // Lịch sử chức vụ chuyên môn của giáo viên
                TBChiTietChuVuChuyenMons = tBChiTietChuVuChuyenMons
            };

            return tBGiaoVien;
        }

        public List<GiaoVienChuyenMonDTO> LichSuChuyenMon(int maGV)
        {
            SqlCommand conn = new SqlCommand("dbo.LichSuChucVuChuyenMon", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<GiaoVienChuyenMonDTO> list = new List<GiaoVienChuyenMonDTO>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienChuyenMonDTO
                    {
                        Ma = Convert.ToInt32(dr["Ma"]),
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenChucVuCM = Convert.ToString(dr["TenChuVuCM"]),
                        MaChucVuCM = Convert.ToInt32(dr["MaChucVuCM"]),
                        ThoiDiemNhan = Convert.ToDateTime(dr["ThoiDiemNhan"]),
                    });
                }
            }

            return list;
        }

        public List<GiaoVienDonViDTO> LichSuDonVi(int maGV)
        {
            SqlCommand conn = new SqlCommand("dbo.LichSuDonVi", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<GiaoVienDonViDTO> list = new List<GiaoVienDonViDTO>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienDonViDTO
                    {
                        Ma = Convert.ToInt32(dr["Ma"]),
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenDonVi = Convert.ToString(dr["TenDonVi"]),
                        MaDonVi = Convert.ToInt32(dr["MaDonVi"]),
                        ThoiDiemNhan = Convert.ToDateTime(dr["ThoiDiemNhan"]),
                        ThoiDiemKetThuc = Convert.ToDateTime(dr["ThoiDiemKetThuc"])
                    });
                }
            }

            return list;
        }

        public List<GiaoVienHocViDTO> LichSuHocVi(int maGV)
        {
            SqlCommand conn = new SqlCommand("dbo.LichSuHocVi", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<GiaoVienHocViDTO> list = new List<GiaoVienHocViDTO>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienHocViDTO
                    {
                        Ma = Convert.ToInt32(dr["Ma"]),
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenHocVi = Convert.ToString(dr["TenHocVi"]),
                        MaHocVi = Convert.ToInt32(dr["MaHocVi"]),
                        ThoiDiemNhan = Convert.ToDateTime(dr["ThoiDiemNhan"])
                    });
                }
            }

            return list;
        }

        public GiaoVienDTO ThongTinCoBan(int maGV)
        {
            SqlCommand conn = new SqlCommand("ThongTinGiaoVienCoBan", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            GiaoVienDTO giaoVienDTO = new GiaoVienDTO
            {
                MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"]),
                NgaySinh = Convert.ToDateTime(dataTable.Rows[0]["NgaySinh"]),
                Email = Convert.ToString(dataTable.Rows[0]["Email"]),
                SDT = Convert.ToString(dataTable.Rows[0]["SDT"]),
                DiaChi = Convert.ToString(dataTable.Rows[0]["DiaChi"]),
                GioiTinh = Convert.ToBoolean(dataTable.Rows[0]["GioiTinh"]),
            };

            return giaoVienDTO;
        }

        public List<GiaoVienHocHamDTO> LichSuHocHam(int maGV)
        {
            SqlCommand conn = new SqlCommand("dbo.LichSuHocHam", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<GiaoVienHocHamDTO> list = new List<GiaoVienHocHamDTO>();
            if (dataTable.Rows.Count > 0)
            {
                foreach(DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienHocHamDTO
                    {
                        Ma = Convert.ToInt32(dr["Ma"]),
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenHocHam = Convert.ToString(dr["TenHocHam"]),
                        MaHocHam = Convert.ToInt32(dr["MaHocHam"]),
                        ThoiDiemNhan = Convert.ToDateTime(dr["ThoiDiemNhan"])
                    });
                }
            }

            return list;
        }
        #endregion
    }
}