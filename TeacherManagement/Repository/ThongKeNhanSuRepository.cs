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
    public class ThongKeNhanSuRepository
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

        public ThongKeNhanSuRepository()
        {
            Connection();
        }

        public List<ThongKeNhanLucDTO> ThongKeNhanLucHienTai()
        {
            TBDonViRepository tBDonViRepository = new TBDonViRepository();

            TBGiaoVienRepository tBGiaoVienRepository = new TBGiaoVienRepository();

            List<ThongKeNhanLucDTO> list = new List<ThongKeNhanLucDTO>();

            List<DonViDTO> danhSachDonVi = tBDonViRepository.DanhSachDonVi();
            foreach(DonViDTO donvi in danhSachDonVi)
            {
                List<TBGiaoVien> giaoViens = new List<TBGiaoVien>();

                List<DonViNhanSuDTO> nhanSuCuaDonVi = tBDonViRepository
                    .NhanSuCuaDonVi(donvi.MaDonVi, false);
                foreach(DonViNhanSuDTO nhanSu in nhanSuCuaDonVi)
                {
                    TBGiaoVien giaoVien = tBGiaoVienRepository
                        .ThongTinNghiepVuGiaoVien(nhanSu.MaGV, nhanSu.TenGV);

                    giaoViens.Add(giaoVien);
                }

                // xu ly thong tin thong ke cua don vi
                ThongKeNhanLucDTO thongke = XuLyThongKe(giaoViens, donvi);

                list.Add(thongke);
            }
            return list;
        }

        public ThongKeNhanLucDTO XuLyThongKe(List<TBGiaoVien> giaoViens, DonViDTO donVi)
        {
            ThongKeNhanLucDTO thongKeNhanLuc = new ThongKeNhanLucDTO();


            int tongSo = giaoViens.Count;

            thongKeNhanLuc.TongSo = tongSo;
            thongKeNhanLuc.TenDonVi = donVi.TenDonVi;
            thongKeNhanLuc.MaDonVi = donVi.MaDonVi; 

            foreach (var giaovien in giaoViens)
            {
                // kiem tra hoc ham phai Giao Su hay khong?
                IEnumerable<TBChiTietHocHam> flagGS = giaovien.TBChiTietHocHams
                    .Where(model => model.TBHocHam.TenHocHam.Equals("Giáo sư"));
                if (flagGS.ToList().Count > 0)
                {
                    thongKeNhanLuc.GiaoSu = thongKeNhanLuc.GiaoSu + 1;
                }

                // kiem tra hoc vi phai Pho giao su hay khong?
                IEnumerable<TBChiTietHocHam> flagPGS = giaovien.TBChiTietHocHams
                    .Where(model => model.TBHocHam.TenHocHam.Equals("Phó giáo sư"));
                if (flagPGS.ToList().Count > 0)
                {
                    thongKeNhanLuc.PhoGiaoSu = thongKeNhanLuc.PhoGiaoSu + 1;
                }

                // kiem tra tien sy 
                IEnumerable<TBChiTietTienSi> flagTienSi = giaovien.TBChiTietTienSis;
                if (flagTienSi.ToList().Count > 0)
                {
                    thongKeNhanLuc.TienSy = thongKeNhanLuc.TienSy + 1;
                }

                // kiem tra thac sy
                IEnumerable<TBChiTietThacSi> flagThacSi = giaovien.TBChiTietThacSis;
                if (flagThacSi.ToList().Count > 0)
                {
                    thongKeNhanLuc.ThacSy = thongKeNhanLuc.ThacSy + 1;
                }

                // kiem tra dai hoc
                IEnumerable<TBChiTietDaiHoc> flagDH = giaovien.TBChiTietDaiHocs;
                if (flagDH.ToList().Count > 0)
                {
                    thongKeNhanLuc.DaiHoc = thongKeNhanLuc.DaiHoc + 1;
                }
            }
            return thongKeNhanLuc;
        }
    }
}