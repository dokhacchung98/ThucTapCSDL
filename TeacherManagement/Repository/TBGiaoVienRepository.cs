using System;
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
            // nếu chưa tồn tại _connection thì mới khởi tạo đối tượng
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
                GiaoVienCVChinhQuyenDTO giaoVienDonViDTO = DonViGiaoVienHienTai(giaoVienId);
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

                // lay thong tin dai hoc

                List<GiaoVienDaiHocDTO> giaoVienDaiHocDTOs = LayThongTinDaiHoc(giaoVienId);
                List<TBChiTietDaiHoc> tBChiTietDaiHocs = new List<TBChiTietDaiHoc>();
                if (giaoVienDaiHocDTOs != null)
                {
                    foreach (GiaoVienDaiHocDTO item in giaoVienDaiHocDTOs)
                    {
                        tBChiTietDaiHocs.Add(
                        new TBChiTietDaiHoc
                        {
                            MaGV = item.MaGV,
                            NamTotNghiep = item.NamTotNghiep,
                            HeDaoTao = item.HeDaoTao,
                            NganhHoc = item.NganhHoc,
                            NoiDaoTao = item.NoiDaoTao
                        });
                    }
                }

                GiaoVienThacSiDTO giaoVienThacSiDTO = LayThongTinThacSi(giaoVienId);
                List<TBChiTietThacSi> tBChiTietThacSis = new List<TBChiTietThacSi>();
                if (giaoVienThacSiDTO != null)
                {
                    tBChiTietThacSis.Add(
                    new TBChiTietThacSi
                    {
                        MaGV = giaoVienThacSiDTO.MaGV,
                        NamCapBang = giaoVienThacSiDTO.NamCapBang,
                        TenLuanVan = giaoVienThacSiDTO.TenLuanVan,
                        ThacSyChuyenNganh = giaoVienThacSiDTO.ThacSyChuyenNganh,
                        NoiDaoTao = giaoVienThacSiDTO.NoiDaoTao
                    });
                }

                GiaoVienTienSiDTO giaoVienTienSiDTO = LayThongTinTienSi(giaoVienId);
                List<TBChiTietTienSi> tBChiTietTienSis = new List<TBChiTietTienSi>();
                if (giaoVienTienSiDTO != null)
                {
                    tBChiTietTienSis.Add(
                    new TBChiTietTienSi
                    {
                        MaGV = giaoVienTienSiDTO.MaGV,
                        NamCapBang = giaoVienTienSiDTO.NamCapBang,
                        TenLuanAn = giaoVienTienSiDTO.TenLuanAn,
                        NoiDaoTao = giaoVienTienSiDTO.NoiDaoTao
                    });
                }

                giaoViens.Add(new TBGiaoVien
                {
                    MaGV = Convert.ToInt32(dr["MaGV"]),
                    TenGV = Convert.ToString(dr["TenGV"]),
                    TBChiTietHocHams = tBChiTietHocHams,
                    TBChiTietHocVis = tBChiTietHocVis,
                    TBChiTietChucVuChinhQuyens = tBChiTietChucVuChinhQuyens,
                    TBChiTietChuVuChuyenMons = tBChiTietChucVuChuyenMons,
                    TBChiTietDaiHocs = tBChiTietDaiHocs,
                    TBChiTietThacSis = tBChiTietThacSis,
                    TBChiTietTienSis = tBChiTietTienSis
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

        public GiaoVienCVChinhQuyenDTO DonViGiaoVienHienTai(int giaoVienId)
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
                GiaoVienCVChinhQuyenDTO giaoVienDonViDTO = new GiaoVienCVChinhQuyenDTO
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

        public GiaoVienCVChinhQuyenDTO ChucVuChinhQuyenHienTai(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChucVuChinhQuyenHienTai", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienCVChinhQuyenDTO giaoVienChucVuCQDTO = new GiaoVienCVChinhQuyenDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    ThoiDiemNhan = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemNhan"]),
                    ThoiDiemKetThuc = Convert.ToDateTime(dataTable.Rows[0]["ThoiDiemKetThuc"]),
                    TenChucVuChinhQuyen = Convert.ToString(dataTable.Rows[0]["TenChucVuChinhQuyen"])
                };

                return giaoVienChucVuCQDTO;
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
                foreach (var hocHam in hocHamDTOs)
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
            List<GiaoVienCVChinhQuyenDTO> chucVuChinhQuyenDTOs = LichSuCVChinhQuyen(maGV);

            List<TBChiTietChucVuChinhQuyen> tBChiTietChucVuChinhQuyens = new List<TBChiTietChucVuChinhQuyen>();

            if (chucVuChinhQuyenDTOs.Count > 0)
            {
                foreach (var chucVuChinhQuyen in chucVuChinhQuyenDTOs)
                {
                    tBChiTietChucVuChinhQuyens.Add(new TBChiTietChucVuChinhQuyen
                    {
                        Ma = chucVuChinhQuyen.Ma,
                        MaGV = chucVuChinhQuyen.MaGV,
                        ThoiDiemNhan = chucVuChinhQuyen.ThoiDiemNhan,
                        ThoiDiemKetThuc = chucVuChinhQuyen.ThoiDiemKetThuc,
                        TBDonVi = new TBDonVi
                        {
                            MaDonVi = chucVuChinhQuyen.MaDonVi,
                            TenDonVi = chucVuChinhQuyen.TenDonVi
                        },
                        TBChucVuChinhQuyen = new TBChucVuChinhQuyen
                        {
                            MaChucVuChinhQuyen = chucVuChinhQuyen.MaChucVuCQ,
                            TenChucVuChinhQuyen = chucVuChinhQuyen.TenChucVuChinhQuyen
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

        public List<GiaoVienCVChinhQuyenDTO> LichSuCVChinhQuyen(int maGV)
        {
            SqlCommand conn = new SqlCommand("dbo.LichSuCVChinhQuyen", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            List<GiaoVienCVChinhQuyenDTO> list = new List<GiaoVienCVChinhQuyenDTO>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienCVChinhQuyenDTO
                    {
                        Ma = Convert.ToInt32(dr["Ma"]),
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        TenDonVi = Convert.ToString(dr["TenDonVi"]),
                        MaDonVi = Convert.ToInt32(dr["MaDonVi"]),
                        MaChucVuCQ = Convert.ToInt32(dr["MaChucVuCQ"]),
                        TenChucVuChinhQuyen = Convert.ToString(dr["TenChucVuChinhQuyen"]),
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
                foreach (DataRow dr in dataTable.Rows)
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

        #region Thông tin học vấn của giáo viên
        public List<GiaoVienDaiHocDTO> LayThongTinDaiHoc(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChiTietDaiHoc", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            List<GiaoVienDaiHocDTO> list = new List<GiaoVienDaiHocDTO>();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new GiaoVienDaiHocDTO
                    {
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        NamTotNghiep = Convert.ToDateTime(dr["NamTotNghiep"]),
                        HeDaoTao = Convert.ToString(dr["HeDaoTao"]),
                        NganhHoc = Convert.ToString(dr["NganhHoc"]),
                        NoiDaoTao = Convert.ToString(dr["NuocDaoTao"])
                    });
                }
            }
            return list;
        }

        public GiaoVienThacSiDTO LayThongTinThacSi(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChiTietThacSy", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienThacSiDTO thacSi = new GiaoVienThacSiDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    NamCapBang = Convert.ToDateTime(dataTable.Rows[0]["NamCapBang"]),
                    TenLuanVan = Convert.ToString(dataTable.Rows[0]["TenLuanVan"]),
                    ThacSyChuyenNganh = Convert.ToString(dataTable.Rows[0]["ThacSyChuyenNganh"]),
                    NoiDaoTao = Convert.ToString(dataTable.Rows[0]["NoiDaoTao"])
                };
                return thacSi;
            }
            return null;
        }

        public GiaoVienTienSiDTO LayThongTinTienSi(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChiTietTienSy", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienTienSiDTO tienSi = new GiaoVienTienSiDTO
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    NamCapBang = Convert.ToDateTime(dataTable.Rows[0]["NamCapBang"]),
                    TenLuanAn = Convert.ToString(dataTable.Rows[0]["TenLuanAn"]),
                    NoiDaoTao = Convert.ToString(dataTable.Rows[0]["NoiDaoTao"])
                };
                return tienSi;
            }
            return null;
        }
        #endregion

        #region Thông tin tham gia hội đồng của giáo viên
        public IList<GiaoVienHoiDongDTO> LayThongTinGiaovienThamGiaHoiDong(int maGv, string namHoc)
        {
            IList<GiaoVienHoiDongDTO> listGVHoiDong = new List<GiaoVienHoiDongDTO>();

            SqlCommand conn = new SqlCommand("dbo.LayThongTinThamGiaHoiDongTheoNamHoc", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            List<SqlParameter> prm = new List<SqlParameter>()
             {
                 new SqlParameter("@NamHoc",SqlDbType.Char, 10) {Value = namHoc.Trim()},
                 new SqlParameter("@MaGV", SqlDbType.Int) {Value = maGv}
             };

            conn.Parameters.AddRange(prm.ToArray());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                string tenHoiDong = Convert.ToString(dr["TenHoiDong"]);
                string tenLoaiHoiDong = Convert.ToString(dr["TenLoaiHoiDong"]);
                int soLanThamGia = Convert.ToInt32(dr["SoLanThamGia"]);
                double soGioThamGia = Convert.ToDouble(dr["SoGioThamGia"]);
                string ghiChu = Convert.ToString(dr["GhiChu"]);
                listGVHoiDong.Add(new GiaoVienHoiDongDTO()
                {
                    MaGV = maGv,
                    TenHoiDong = tenHoiDong,
                    TenLoaiHoiDong = tenLoaiHoiDong,
                    SoGioThamGia = soGioThamGia,
                    SoLanThamGia = soLanThamGia,
                    GhiChu = ghiChu
                });
            }

            return listGVHoiDong;
        }
        #endregion

        #region Thông tin hướng dẫn của giáo viên
        public IList<GiaoVienHuongDanDTO> LayThongTinHuongDanGiaoVien(int maGV, string namHoc)
        {
            IList<GiaoVienHuongDanDTO> giaoVienHuongDanDTOs = new List<GiaoVienHuongDanDTO>();

            SqlCommand conn = new SqlCommand("LayThongTinHuongDanTheoNamHoc", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char, 10).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                string tenHV = Convert.ToString(dr["TenHocVien"]);
                string tenDT = Convert.ToString(dr["TenDeTai"]);
                string tenLHD = Convert.ToString(dr["TenLopHuongDan"]);
                string tenHDT = Convert.ToString(dr["TenDeDaoTao"]);
                string tenLoaiHD = Convert.ToString(dr["TenLoaiHD"]);
                double gio = Convert.ToDouble(dr["SoGio"]);
                giaoVienHuongDanDTOs.Add(new GiaoVienHuongDanDTO()
                {
                    MaGV = maGV,
                    TenDeTai = tenDT,
                    TenHeDaoTao = tenHDT,
                    TenHocVien = tenHV,
                    TenLoaiHuongDan = tenLoaiHD,
                    TenLopHuongDan = tenLHD
                });
            }

            return giaoVienHuongDanDTOs;
        }
        #endregion

        #region Thông tin giảng dạy của giáo viên
        public IList<GiaoVienGiangDayDTO> LayThongTinGiangDayGiaoVien(int maGV, string namHoc)
        {
            IList<GiaoVienGiangDayDTO> giaoVienCongTacKhacDTOs = new List<GiaoVienGiangDayDTO>();

            SqlCommand conn = new SqlCommand("LayThongTinGiaoVienGiangDayTheoNamHoc", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char, 10).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                string ghiChu = Convert.ToString(dr["GhiChu"]);
                string tenLoaiDoiTuongDaoTao = Convert.ToString(dr["TenLoaiDoiTuongDaoTao"]);
                string tenHeDaoTao = Convert.ToString(dr["TenHeDaoTao"]);
                string tenHocPhan = Convert.ToString(dr["TenHocPhan"]);
                string tenLoaiHocPhan = Convert.ToString(dr["TenLoaiHocPhan"]);
                int soTinChi = Convert.ToInt32(dr["SoTinChi"]);
                int tongTiet = Convert.ToInt32(dr["TongTiet"]);
                int siSo = Convert.ToInt32(dr["SiSo"]);
                int soTietDay = Convert.ToInt32(dr["SoTietDay"]);
                double quyRaGioChuan = Convert.ToDouble(dr["QuyRaGioChuan"]);
                string donViTinh = Convert.ToString(dr["DonViTinh"]);
                DateTime thoiDiem = Convert.ToDateTime(dr["ThoiDiem"]);

                giaoVienCongTacKhacDTOs.Add(new GiaoVienGiangDayDTO()
                {
                    MaGV = maGV,
                    GhiChu = ghiChu,
                    DonViTinh = donViTinh,
                    QuyRaGioChuan = quyRaGioChuan,
                    SiSo = siSo,
                    SoTietDay = soTietDay,
                    SoTinChi = soTinChi,
                    TenHeDaoTao = tenHeDaoTao,
                    ThoiDiem = thoiDiem,
                    TenHocPhan = tenHocPhan,
                    TenLoaiDoiTuongDaoTao = tenLoaiDoiTuongDaoTao,
                    TenLoaiHocPhan = tenLoaiHocPhan,
                    TongTiet = tongTiet
                });
            }

            return giaoVienCongTacKhacDTOs;
        }
        #endregion

        #region Thông tin giáo viên tham gia công tác khác
        public IList<GiaoVienCongTacKhacDTO> LayThongTinCongTacKhacGiaoVien(int maGV, string namHoc)
        {
            IList<GiaoVienCongTacKhacDTO> giaoVienCongTacKhacDTOs = new List<GiaoVienCongTacKhacDTO>();

            SqlCommand conn = new SqlCommand("LayThongTinGiaoVienThamGiaCongTacKhacTheoNamHoc", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char, 10).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                string noiDung = Convert.ToString(dr["NoidungCongTac"]);
                string vaiTro = Convert.ToString(dr["VaiTro"]);
                string ghiChu = Convert.ToString(dr["GhiChu"]);
                giaoVienCongTacKhacDTOs.Add(new GiaoVienCongTacKhacDTO()
                {
                    MaGV = maGV,
                    GhiChu = ghiChu,
                    NoiDungCongTac = noiDung,
                    VaiTro = vaiTro
                });
            }

            return giaoVienCongTacKhacDTOs;
        }
        #endregion

        #region tổng hợp tải theo năm học
        public IList<GiaoVienTongHopTaiDTO> TongHopTaiTheoNamHoc(string namHoc)
        {
            List<TBGiaoVien> giaoViens = new List<TBGiaoVien>();
            IList<GiaoVienTongHopTaiDTO> giaoVienTongHopTais = new List<GiaoVienTongHopTaiDTO>();

            SqlCommand conn = new SqlCommand("DanhSachGiaoVien", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int maGV = Convert.ToInt32(dr["MaGV"]);
                var taiDaoTao = TongHopTaiDaoTaoCuaGiaoVienTheoNamHoc(maGV, namHoc);
                GiaoVienDTO giaoVienDTO = ThongTinCoBan(maGV);

                giaoVienTongHopTais.Add(new GiaoVienTongHopTaiDTO()
                {
                    GiaoVien = giaoVienDTO,
                    TaiDaoTao = taiDaoTao
                });
            }
            return giaoVienTongHopTais;
        }

        public AbsGiaoVienTongHopTaiDaoTaoDTO TongHopTaiDaoTaoCuaGiaoVienTheoNamHoc(int maGV, string namHoc)
        {
            SqlCommand conn = new SqlCommand("dbo.TinhTaiDaoTaoTheoGV", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                AbsGiaoVienTongHopTaiDaoTaoDTO taiDaoTao = new GiaoVienTongHopTaiDaoTaoDTO()
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"]),
                    SoTietYeuCau = Convert.ToDouble(dataTable.Rows[0]["SoTietYeuCau"]),
                    SoTietThucTe = Convert.ToDouble(dataTable.Rows[0]["SoTietThucTe"])
                };
                return taiDaoTao;
            }
            return null;
        }
        #endregion
    }
}