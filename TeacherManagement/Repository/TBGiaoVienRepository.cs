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

        // GET: Lấy ra danh sách Chức Vụ Đảng
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
                if (tBChiTietHocHams != null)
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
                if (tBChiTietHocVis != null)
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

        private GiaoVienChuyenMonDTO ChuyenMonGiaoVienHienTai(int giaoVienId)
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

        private GiaoVienDonViDTO DonViGiaoVienHienTai(int giaoVienId)
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

        private GiaoVienHocViDTO HocViGiaoVienHienTai(int giaoVienId)
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
    }
}