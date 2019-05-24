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

                string tenGiaoVien = Convert.ToString(dr["TenGV"]);
                TBGiaoVien giaoVien = ThongTinNghiepVuGiaoVien(giaoVienId, tenGiaoVien);

                giaoViens.Add(giaoVien);
            }
;
            return giaoViens;
        }

        public TBGiaoVien ThongTinNghiepVuGiaoVien(int giaoVienId, string tenGiaoVien)
        {
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

            // lay thong tin thac si

            List<GiaoVienThacSiDTO> giaoVienThacSiDTO = LayThongTinThacSi(giaoVienId);
            List<TBChiTietThacSi> tBChiTietThacSis = new List<TBChiTietThacSi>();
            if (giaoVienThacSiDTO != null)
            {
                foreach (GiaoVienThacSiDTO item in giaoVienThacSiDTO)
                {
                    tBChiTietThacSis.Add(
                new TBChiTietThacSi
                {
                    MaGV = item.MaGV,
                    NamCapBang = item.NamCapBang,
                    TenLuanVan = item.TenLuanVan,
                    ThacSyChuyenNganh = item.ThacSyChuyenNganh,
                    NoiDaoTao = item.NoiDaoTao
                });
                }
            }

            // lay thong tin tien si

            List<GiaoVienTienSiDTO> giaoVienTienSiDTO = LayThongTinTienSi(giaoVienId);
            List<TBChiTietTienSi> tBChiTietTienSis = new List<TBChiTietTienSi>();
            if (giaoVienTienSiDTO != null)
            {
                foreach (GiaoVienTienSiDTO item in giaoVienTienSiDTO)
                {
                    tBChiTietTienSis.Add(
                    new TBChiTietTienSi
                    {
                        MaGV = item.MaGV,
                        NamCapBang = item.NamCapBang,
                        TenLuanAn = item.TenLuanAn,
                        NoiDaoTao = item.NoiDaoTao
                    });
                }
            }

            List<GiaoVienTrinhDoNgoaiNguDTO> giaoVienTrinhDoNgoaiNguDTOs = LayThongTinNgoaiNgu(giaoVienId);
            List<TBChiTietTrinhDoNgoaiNgu> tBChiTietTrinhDoNgoaiNgus = new List<TBChiTietTrinhDoNgoaiNgu>();
            if (giaoVienTrinhDoNgoaiNguDTOs != null)
            {
                foreach (GiaoVienTrinhDoNgoaiNguDTO item in giaoVienTrinhDoNgoaiNguDTOs)
                {
                    tBChiTietTrinhDoNgoaiNgus.Add(
                    new TBChiTietTrinhDoNgoaiNgu
                    {
                        MaGV = item.MaGV,
                        TenTrinhDo = item.TenTrinhDo,
                        NamCapBang = item.NamCapBang
                    });
                }
            }


            TBGiaoVien giaoVien = new TBGiaoVien
            {
                MaGV = Convert.ToInt32(giaoVienId),
                TenGV = Convert.ToString(tenGiaoVien),
                TBChiTietHocHams = tBChiTietHocHams,
                TBChiTietHocVis = tBChiTietHocVis,
                TBChiTietChucVuChinhQuyens = tBChiTietChucVuChinhQuyens,
                TBChiTietChuVuChuyenMons = tBChiTietChucVuChuyenMons,
                TBChiTietDaiHocs = tBChiTietDaiHocs,
                TBChiTietThacSis = tBChiTietThacSis,
                TBChiTietTienSis = tBChiTietTienSis,
                TBChiTietTrinhDoNgoaiNgus = tBChiTietTrinhDoNgoaiNgus
            };
            return giaoVien;
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

        public List<GiaoVienThacSiDTO> LayThongTinThacSi(int giaoVienId)
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
                List<GiaoVienThacSiDTO> lst = new List<GiaoVienThacSiDTO>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    GiaoVienThacSiDTO thacSi = new GiaoVienThacSiDTO
                    {
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        NamCapBang = Convert.ToDateTime(dr["NamCapBang"]),
                        TenLuanVan = Convert.ToString(dr["TenLuanVan"]),
                        ThacSyChuyenNganh = Convert.ToString(dr["ThacSyChuyenNganh"]),
                        NoiDaoTao = Convert.ToString(dr["NoiDaoTao"])
                    };
                    lst.Add(thacSi);
                }
                return lst;
            }
            return null;
        }

        public List<GiaoVienTienSiDTO> LayThongTinTienSi(int giaoVienId)
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
                List<GiaoVienTienSiDTO> lst = new List<GiaoVienTienSiDTO>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    GiaoVienTienSiDTO tienSi = new GiaoVienTienSiDTO
                    {
                        MaGV = Convert.ToInt32(dr["MaGV"]),
                        NamCapBang = Convert.ToDateTime(dr["NamCapBang"]),
                        TenLuanAn = Convert.ToString(dr["TenLuanAn"]),
                        NoiDaoTao = Convert.ToString(dr["NoiDaoTao"])
                    };
                    lst.Add(tienSi);
                }
                return lst;
            }
            return null;
        }

        public List<GiaoVienTrinhDoNgoaiNguDTO> LayThongTinNgoaiNgu(int giaoVienId)
        {
            SqlCommand conn = new SqlCommand("dbo.ChiTietNgoaiNgu", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienId;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                List<GiaoVienTrinhDoNgoaiNguDTO> lst = new List<GiaoVienTrinhDoNgoaiNguDTO>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    GiaoVienTrinhDoNgoaiNguDTO ngoaiNgu = new GiaoVienTrinhDoNgoaiNguDTO
                    {
                        MaGV = giaoVienId,
                        TenTrinhDo = Convert.ToString(dr["TenTrinhDo"]),
                        NamCapBang = Convert.ToDateTime(dr["NamCapBang"])
                    };
                    lst.Add(ngoaiNgu);
                }
                return lst;
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
                    GhiChu = ghiChu,
                    NamHoc = namHoc
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
                string nh = Convert.ToString(dr["NamHoc"]);
                giaoVienHuongDanDTOs.Add(new GiaoVienHuongDanDTO()
                {
                    MaGV = maGV,
                    TenDeTai = tenDT,
                    TenHeDaoTao = tenHDT,
                    TenHocVien = tenHV,
                    TenLoaiHuongDan = tenLoaiHD,
                    TenLopHuongDan = tenLHD,
                    NamHoc = nh
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
                    TongTiet = tongTiet,
                    NamHoc = namHoc
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
                    VaiTro = vaiTro,
                    NamHoc = namHoc
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
                var taiNCKH = TongHopTaiNCKHCuaGiaoVienTheoNamHoc(maGV, namHoc);
                GiaoVienDTO giaoVienDTO = ThongTinCoBan(maGV);

                giaoVienTongHopTais.Add(new GiaoVienTongHopTaiDTO()
                {
                    GiaoVien = giaoVienDTO,
                    TaiDaoTao = taiDaoTao,
                    TaiNCKH = taiNCKH
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

        public double LayDinhMucNCKH(int maGV, string namHoc)
        {
            double dinhMuc;
            //string date = namHoc.Substring(0, 4).ToString() + "-05-19";
            string date = "2018-05-19";
            SqlCommand conn = new SqlCommand("dbo.DinhMucNghienCuuKhoaHoc", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@namhoc", SqlDbType.Char).Value = Convert.ToDateTime(date);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                dinhMuc = Convert.ToDouble(dataTable.Rows[0]["DinhMucGioChuan"]);
                return dinhMuc;
            }
            return 0;
        }

        public GiaoVienTongHopTaiNCKH TongHopTaiNCKHCuaGiaoVienTheoNamHoc(int maGV, string namHoc)
        {
            SqlCommand conn = new SqlCommand("dbo.TinhTaiCongTacNghienCuuKhoaHoc", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@magv", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@nam", SqlDbType.Char).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                GiaoVienTongHopTaiNCKH taiNCKH = new GiaoVienTongHopTaiNCKH()
                {
                    MaGV = Convert.ToInt32(dataTable.Rows[0]["MaGV"]),
                    TenGV = Convert.ToString(dataTable.Rows[0]["TenGV"]),
                    SoTaiYeuCau = LayDinhMucNCKH(maGV, namHoc),
                    SoTaiNCKHThucTe = Convert.ToDouble(dataTable.Rows[0]["TaiVietSach"]) + Convert.ToDouble(dataTable.Rows[0]["TaiVietBaiBao"]) +
                                        Convert.ToDouble(dataTable.Rows[0]["TaiNghienCuu"])
                };
                return taiNCKH;
            }
            return null;
        }
        #endregion

        #region Thông tin nghiên cứu khoa học
        public List<GiaoVienVietSachDTO> LayGiaoVienVietSaches(int maGV, string namHoc)
        {
            List<GiaoVienVietSachDTO> giaoVienVietSachDTOs = new List<GiaoVienVietSachDTO>();

            SqlCommand conn = new SqlCommand("dbo.ChiTietVietSachChuyenKhao", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char, 10).Value = namHoc.Trim();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                giaoVienVietSachDTOs.Add(new GiaoVienVietSachDTO()
                {
                    MaGV = maGV,
                    TenSach = Convert.ToString(dr["TenSach"]),
                    LoaiSach = Convert.ToString(dr["TenLoaiSach"]),
                    VaiTro = Convert.ToString(dr["TenVaiTro"]),
                    LoaiHinh = Convert.ToString(dr["TenLoaiHinh"]),
                    SoTacGia = TinhSoTacGiaVietSach(Convert.ToInt32(dr["MaSach"])),
                    NamHoc = Convert.ToString(dr["NamHoc"]),
                    GioChuan = Convert.ToDouble(dr["QuyRaGioChuan"])
                });
            }
            return giaoVienVietSachDTOs;
        }

        public List<GiaoVienDeTaiKHDTO> LayGiaoVienDeTaiKHDTOs(int maGV, string namHoc)
        {
            List<GiaoVienDeTaiKHDTO> giaoVienDeTaiKHDTOs = new List<GiaoVienDeTaiKHDTO>();

            SqlCommand conn = new SqlCommand("dbo.ChiTietDeTaiNghienCuuKhoaHoc", connection)
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
                giaoVienDeTaiKHDTOs.Add(new GiaoVienDeTaiKHDTO()
                {
                    MaGV = maGV,
                    TenDeTaiNCKH = Convert.ToString(dr["TenDeTaiKhoaHoc"]),
                    LoaiDeTai = Convert.ToString(dr["TenLoaiDeTaiKH"]),
                    VaiTro = Convert.ToString(dr["TenVaiTro"]),
                    LoaiHinh = Convert.ToString(dr["TenLoaiHinh"]),
                    SoTacGia = TinhSoTacGiaLamDeTai(Convert.ToInt32(dr["MaDeTaiKhoaHoc"])),
                    NamHoc = Convert.ToString(dr["NamHoc"]),
                    GioChuan = Convert.ToDouble(dr["QuyRaGioChuan"])
                });
            }
            return giaoVienDeTaiKHDTOs;
        }

        public List<GiaoVienVietBaoDTO> LayGiaoVienVietBaos(int maGV, string namHoc)
        {
            List<GiaoVienVietBaoDTO> giaoVienVietBaoDTOs = new List<GiaoVienVietBaoDTO>();

            SqlCommand conn = new SqlCommand("dbo.ChiTietVietBaiBaoKhoaHoc", connection)
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
                giaoVienVietBaoDTOs.Add(new GiaoVienVietBaoDTO()
                {
                    MaGV = maGV,
                    TenBaiBao = Convert.ToString(dr["TenBaiBao"]),
                    LoaiBaiBao = Convert.ToString(dr["TenLoaiBao"]),
                    VaiTro = Convert.ToString(dr["TenVaiTro"]),
                    LoaiHinh = Convert.ToString(dr["TenLoaiHinh"]),
                    SoTacGia = TinhSoTacGiaVietBao(Convert.ToInt32(dr["MaBaiBao"])),
                    NamHoc = Convert.ToString(dr["NamHoc"]),
                    GioChuan = Convert.ToDouble(dr["QuyRaGioChuan"])
                });
            }
            return giaoVienVietBaoDTOs;
        }

        public int TinhSoTacGiaVietSach(int maSach)
        {
            SqlCommand conn = new SqlCommand("dbo.TinhSoTacGiaVietSach", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@maSach", SqlDbType.Int).Value = maSach;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            return Convert.ToInt32(dataTable.Rows[0]["TongTacGia"]);
        }

        public int TinhSoTacGiaVietBao(int maSach)
        {
            SqlCommand conn = new SqlCommand("dbo.TinhSoTacGiaVietBao", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@maBao", SqlDbType.Int).Value = maSach;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            return Convert.ToInt32(dataTable.Rows[0]["TongTacGia"]);
        }

        public int TinhSoTacGiaLamDeTai(int maSach)
        {
            SqlCommand conn = new SqlCommand("dbo.TinhSoTacGiaLamDeTai", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@maDeTai", SqlDbType.Int).Value = maSach;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            return Convert.ToInt32(dataTable.Rows[0]["TongTacGia"]);
        }

        public GiaoVienNghienCuuKhoaHocDTO GiaoVienNghienCuuKhoaHoc(int maGV, string namHoc)
        {
            GiaoVienNghienCuuKhoaHocDTO giaoVienNghienCuuKhoaHocDTO = new GiaoVienNghienCuuKhoaHocDTO
            {
                GiaoVienVietSach = LayGiaoVienVietSaches(maGV, namHoc),
                GiaoVienVietBao = LayGiaoVienVietBaos(maGV, namHoc),
                GiaoVienDeTaiKH = LayGiaoVienDeTaiKHDTOs(maGV, namHoc)
            };
            return giaoVienNghienCuuKhoaHocDTO;
        }
        #endregion

        #region Thêm mới giáo viên
        public void SuaThongTinGiaoVien(TBGiaoVien giaoVien,
            string MaHocHam, string MaHocVi, string MaDonVi, string MaChucVuChuyenMon, string MaChucVuChinhQuyen,
            DateTime? ThoiDiemNhanHocHam, DateTime? ThoiDiemNhanHocVi, DateTime? thoiDiemNhanDonVi, DateTime? thoiDiemKetThucDonVi, DateTime? thoiDiemNhanCVCM)
        {
            SuaThongTinCoBanGiaoVien(giaoVien);

            var lichSuHocHam = LichSuHocHam(giaoVien.MaGV);

            if (!ExistHocHam(lichSuHocHam, Convert.ToInt32(MaHocHam)))
            {
                ThemHocHamGiaoVien(giaoVien.MaGV, MaHocHam, ThoiDiemNhanHocHam);
            }

            var lichSuHocVi = LichSuHocVi(giaoVien.MaGV);
            if (!ExistHocVi(lichSuHocVi, Convert.ToInt32(MaHocVi)))
            {
                ThemHocViGiaoVien(giaoVien.MaGV, MaHocVi, ThoiDiemNhanHocVi);
            }

            var lichSuCVCQ = LichSuCVChinhQuyen(giaoVien.MaGV);
            if (!ExistChucVuChinhQuyen(lichSuCVCQ, Convert.ToInt32(MaDonVi), Convert.ToInt32(MaChucVuChinhQuyen)))
            {
                ThemChucVuChinhQuyenGiaoVien(giaoVien.MaGV, MaDonVi, MaChucVuChinhQuyen, thoiDiemNhanDonVi, thoiDiemKetThucDonVi);
            }

            var lichSUCVCM = LichSuChuyenMon(giaoVien.MaGV);
            if (!ExistCVCM(lichSUCVCM, Convert.ToInt32(MaChucVuChuyenMon)))
            {
                ThemChucVuChuyenMonGiaoVien(giaoVien.MaGV, MaChucVuChuyenMon, thoiDiemNhanCVCM);
            }
        }

        private bool ExistHocHam(List<GiaoVienHocHamDTO> lichSuHocHam, int maHocHam)
        {
            foreach (var hocHam in lichSuHocHam)
            {
                if (hocHam.MaHocHam == maHocHam)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExistCVCM(List<GiaoVienChuyenMonDTO> lichSuChuyenMon, int maCVCM)
        {
            foreach (var chuyenMon in lichSuChuyenMon)
            {
                if (chuyenMon.MaChucVuCM == maCVCM)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExistChucVuChinhQuyen(List<GiaoVienCVChinhQuyenDTO> lichSuCVCQ, int maDonVi, int maChucVuCQ)
        {
            foreach (var chucVuCQ in lichSuCVCQ)
            {
                if (chucVuCQ.MaDonVi == maDonVi && chucVuCQ.MaChucVuCQ == maChucVuCQ)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExistHocVi(List<GiaoVienHocViDTO> lichSuHocVi, int maHocVi)
        {
            foreach (var hocVi in lichSuHocVi)
            {
                if (hocVi.MaHocVi == maHocVi)
                {
                    return true;
                }
            }

            return false;
        }

        public void ThemGiaoVien(TBGiaoVien giaoVien)
        {
            ThemThongTinCoBanGiaoVien(giaoVien);
        }

        private void ThemChucVuChuyenMonGiaoVien(int maGV, string maChucVuChuyenMon, DateTime? thoiDiemNhanCVCM)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietChucVuChuyenMon", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@MaChucVuCM", SqlDbType.Int).Value = Convert.ToInt32(maChucVuChuyenMon);
            conn.Parameters.Add("@ThoiDiemNhan", SqlDbType.Date).Value = thoiDiemNhanCVCM ?? DateTime.Now;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void ThemChucVuChinhQuyenGiaoVien(int maGV, string maDonVi, string maChucVuChinhQuyen, DateTime? thoiDiemNhanDonVi, DateTime? thoiDiemKetThucDonVi)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietChucVuChinhQuyen", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaDonVi", SqlDbType.Int).Value = maDonVi;
            conn.Parameters.Add("@MaChucVuCQ", SqlDbType.Int).Value = maChucVuChinhQuyen;
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@ThoiDiemNhan", SqlDbType.Date).Value = thoiDiemNhanDonVi ?? DateTime.Now;
            conn.Parameters.Add("@ThoiDiemKetThuc", SqlDbType.Date).Value = thoiDiemKetThucDonVi ?? DateTime.Now;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void ThemHocViGiaoVien(int maGV, string maHocVi, DateTime? thoiDiemNhanHocVi)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietHocVi", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@MaHocVi", SqlDbType.Int).Value = Convert.ToInt32(maHocVi);
            conn.Parameters.Add("@ThoiDiemNhan", SqlDbType.Date).Value = thoiDiemNhanHocVi ?? DateTime.Now;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void ThemHocHamGiaoVien(int maGV, string maHocHam, DateTime? thoiDiemNhanHocHam)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietHocHam", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = maGV;
            conn.Parameters.Add("@MaHocHam", SqlDbType.Int).Value = Convert.ToInt32(maHocHam);
            conn.Parameters.Add("@ThoiDiemNhan", SqlDbType.Date).Value = thoiDiemNhanHocHam ?? DateTime.Now;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void ThemThongTinCoBanGiaoVien(TBGiaoVien giaoVien)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemGiaoVien", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@TenGV", SqlDbType.NVarChar).Value = giaoVien.TenGV;
            conn.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = giaoVien.NgaySinh;
            conn.Parameters.Add("@Email", SqlDbType.NVarChar).Value = giaoVien.Email;
            conn.Parameters.Add("@SDT", SqlDbType.VarChar).Value = giaoVien.SDT;
            conn.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = giaoVien.DiaChi;
            conn.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = Convert.ToInt32(giaoVien.GioiTinh);
            conn.Parameters.Add("@MaChucVuDang", SqlDbType.Int).Value = 1;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void SuaThongTinCoBanGiaoVien(TBGiaoVien giaoVien)
        {
            SqlCommand conn = new SqlCommand("dbo.SuaGiaoVien", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVien.MaGV;
            conn.Parameters.Add("@TenGV", SqlDbType.NVarChar).Value = giaoVien.TenGV;
            conn.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = giaoVien.NgaySinh;
            conn.Parameters.Add("@Email", SqlDbType.NVarChar).Value = giaoVien.Email;
            conn.Parameters.Add("@SDT", SqlDbType.VarChar).Value = giaoVien.SDT;
            conn.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = giaoVien.DiaChi;
            conn.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = Convert.ToInt32(giaoVien.GioiTinh);
            conn.Parameters.Add("@ChucVuDang", SqlDbType.Int).Value = 1;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }


        #endregion

        #region Thêm thông tin học vấn

        public void ThemDaiHoc(GiaoVienDaiHocDTO giaoVienDaiHocDTO)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietDaiHoc", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienDaiHocDTO.MaGV;
            conn.Parameters.Add("@NganhHoc", SqlDbType.Char).Value = giaoVienDaiHocDTO.NganhHoc;
            conn.Parameters.Add("@NamTotNghiep", SqlDbType.Date).Value = giaoVienDaiHocDTO.NamTotNghiep;
            conn.Parameters.Add("@HeDaoTao", SqlDbType.Char).Value = giaoVienDaiHocDTO.HeDaoTao;
            conn.Parameters.Add("@NoiDaoTao", SqlDbType.Char).Value = giaoVienDaiHocDTO.NoiDaoTao;
            conn.Parameters.Add("@NuocDaoTao", SqlDbType.Char).Value = giaoVienDaiHocDTO.NuocDaoTao;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        public void ThemThacSi(GiaoVienThacSiDTO giaoVienThacSiDTO)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietThacSi", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienThacSiDTO.MaGV;
            conn.Parameters.Add("@TenLuanVan", SqlDbType.Char).Value = giaoVienThacSiDTO.TenLuanVan;
            conn.Parameters.Add("@NamCapBang", SqlDbType.Date).Value = giaoVienThacSiDTO.NamCapBang;
            conn.Parameters.Add("@ThacSyChuyenNganh", SqlDbType.Char).Value = giaoVienThacSiDTO.ThacSyChuyenNganh;
            conn.Parameters.Add("@NoiDaoTao", SqlDbType.Char).Value = giaoVienThacSiDTO.NoiDaoTao;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        public void ThemTienSi(GiaoVienTienSiDTO giaoVienTienSiDTO)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietTienSi", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienTienSiDTO.MaGV;
            conn.Parameters.Add("@TenLuanAn", SqlDbType.Char).Value = giaoVienTienSiDTO.TenLuanAn;
            conn.Parameters.Add("@NamCapBang", SqlDbType.Date).Value = giaoVienTienSiDTO.NamCapBang;
            conn.Parameters.Add("@NoiDaoTao", SqlDbType.Char).Value = giaoVienTienSiDTO.NoiDaoTao;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        #endregion

        #region Thêm thông hướng dẫn giáo viên
        public void ThemChiTietHuongDan(ChiTietHuongDanDTO chiTietHuongDanDTO)
        {
            if (chiTietHuongDanDTO.TenDeTai == null)
            {
                chiTietHuongDanDTO.TenDeTai = "";
            }
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietHuongDan", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = chiTietHuongDanDTO.MaGV;
            conn.Parameters.Add("@MaHocVien", SqlDbType.Int).Value = chiTietHuongDanDTO.MaHocVien;
            conn.Parameters.Add("@TenDeTai", SqlDbType.NVarChar).Value = chiTietHuongDanDTO.TenDeTai;
            conn.Parameters.Add("@SoGio", SqlDbType.Float).Value = chiTietHuongDanDTO.SoGio;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char).Value = chiTietHuongDanDTO.NamHoc;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }
        #endregion


        #region Thêm thông tin tham gia hội đồng
        public void ThemChiTietThamGiaHoiDong(ChiTietThamGiaHoiDongDTO chiTietThamGiaHoiDongDTO)
        {
            if (chiTietThamGiaHoiDongDTO.GhiChu == null)
            {
                chiTietThamGiaHoiDongDTO.GhiChu = "";
            }
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietThamGiaHoiDong", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = chiTietThamGiaHoiDongDTO.MaGV;
            conn.Parameters.Add("@MaHoiDong", SqlDbType.Int).Value = chiTietThamGiaHoiDongDTO.MaHoiDong;
            conn.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = chiTietThamGiaHoiDongDTO.GhiChu;
            conn.Parameters.Add("@SoLanThamGia", SqlDbType.Int).Value = chiTietThamGiaHoiDongDTO.SoLanThamGia;
            conn.Parameters.Add("@SoGio", SqlDbType.Float).Value = chiTietThamGiaHoiDongDTO.SoGio;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char).Value = chiTietThamGiaHoiDongDTO.NamHoc;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }
        #endregion


        #region Thêm thông tin tham gia công tác khác
        public void ThemChiTietThamGiaCongTacKhac(ChiTietCongTacKhacDTO chiTietCongTacKhacDTO)
        {
            if (chiTietCongTacKhacDTO.GhiChu == null)
            {
                chiTietCongTacKhacDTO.GhiChu = "";
            }
            if (chiTietCongTacKhacDTO.VaiTro == null)
            {
                chiTietCongTacKhacDTO.VaiTro = "";
            }
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietCongTacKhac", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = chiTietCongTacKhacDTO.MaGV;
            conn.Parameters.Add("@MaCongTac", SqlDbType.Int).Value = chiTietCongTacKhacDTO.MaCongTac;
            conn.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = chiTietCongTacKhacDTO.GhiChu;
            conn.Parameters.Add("@VaiTro", SqlDbType.NVarChar).Value = chiTietCongTacKhacDTO.VaiTro;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char).Value = chiTietCongTacKhacDTO.NamHoc;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }
        #endregion


        #region Thêm thông tin tham gia giảng dạy
        public void ThemChiTietThamGiaGiangDay(ChiTietGiangDayDTO chiTietGiangDayDTO)
        {
            SqlCommand conn = new SqlCommand("dbo.ThemChiTietGiangDay", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = chiTietGiangDayDTO.MaGV;
            conn.Parameters.Add("@MaLop", SqlDbType.Int).Value = chiTietGiangDayDTO.MaLop;
            conn.Parameters.Add("@SoTiet", SqlDbType.Int).Value = chiTietGiangDayDTO.SoTiet;
            conn.Parameters.Add("@MaLoaiGiangDay", SqlDbType.Int).Value = chiTietGiangDayDTO.MaLoaiGiangDay;
            conn.Parameters.Add("@NamHoc", SqlDbType.Char).Value = chiTietGiangDayDTO.NamHoc;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }
        #endregion
    }
}