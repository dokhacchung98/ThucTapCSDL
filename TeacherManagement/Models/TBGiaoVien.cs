namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBGiaoVien")]
    public partial class TBGiaoVien
    {
        public TBGiaoVien()
        {
            TBChiTietChucVuChinhQuyens = new HashSet<TBChiTietChucVuChinhQuyen>();
            TBChiTietChuVuChuyenMons = new HashSet<TBChiTietChuVuChuyenMon>();
            TBChiTietCongTacKhacs = new HashSet<TBChiTietCongTacKhac>();
            TBChiTietCongTacKhaoThis = new HashSet<TBChiTietCongTacKhaoThi>();
            TBChiTietDaiHocs = new HashSet<TBChiTietDaiHoc>();
            TBChiTietDaoTaoThucTes = new HashSet<TBChiTietDaoTaoThucTe>();
            TBChiTietGiangDays = new HashSet<TBChiTietGiangDay>();
            TBChiTietHoatDongNghienCuuKHs = new HashSet<TBChiTietHoatDongNghienCuuKH>();
            TBChiTietHocHams = new HashSet<TBChiTietHocHam>();
            TBChiTietHocVis = new HashSet<TBChiTietHocVi>();
            TBChiTietHuongDans = new HashSet<TBChiTietHuongDan>();
            TBChiTietKhenThuongs = new HashSet<TBChiTietKhenThuong>();
            TBChiTietKyLuats = new HashSet<TBChiTietKyLuat>();
            TBChiTietNghienCuus = new HashSet<TBChiTietNghienCuu>();
            TBChiTietThacSis = new HashSet<TBChiTietThacSi>();
            TBChiTietThamGiaHoiDongs = new HashSet<TBChiTietThamGiaHoiDong>();
            TBChiTietTienSis = new HashSet<TBChiTietTienSi>();
            TBChiTietTrinhDoes = new HashSet<TBChiTietTrinhDo>();
            TBDeTaiNghienCuuKHs = new HashSet<TBDeTaiNghienCuuKH>();
            TBTuDaoTaos = new HashSet<TBTuDaoTao>();
            TBVietBaiBaoKhoaHocs = new HashSet<TBVietBaiBaoKhoaHoc>();
            TBVietSachChuyenKhaos = new HashSet<TBVietSachChuyenKhao>();
        }

        [Key]
        public int MaGV { get; set; }
        
        public string TenGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        
        public string Email { get; set; }
        
        public string SDT { get; set; }

        public string DiaChi { get; set; }

        public bool? GioiTinh { get; set; }

        public int? MaChucVuDang { get; set; }

        
        public virtual ICollection<TBChiTietChucVuChinhQuyen> TBChiTietChucVuChinhQuyens { get; set; }

        
        public virtual ICollection<TBChiTietChuVuChuyenMon> TBChiTietChuVuChuyenMons { get; set; }

        
        public virtual ICollection<TBChiTietCongTacKhac> TBChiTietCongTacKhacs { get; set; }

        
        public virtual ICollection<TBChiTietCongTacKhaoThi> TBChiTietCongTacKhaoThis { get; set; }

        
        public virtual ICollection<TBChiTietDaiHoc> TBChiTietDaiHocs { get; set; }

        
        public virtual ICollection<TBChiTietDaoTaoThucTe> TBChiTietDaoTaoThucTes { get; set; }

        
        public virtual ICollection<TBChiTietGiangDay> TBChiTietGiangDays { get; set; }

        
        public virtual ICollection<TBChiTietHoatDongNghienCuuKH> TBChiTietHoatDongNghienCuuKHs { get; set; }

        
        public virtual ICollection<TBChiTietHocHam> TBChiTietHocHams { get; set; }

        
        public virtual ICollection<TBChiTietHocVi> TBChiTietHocVis { get; set; }

        
        public virtual ICollection<TBChiTietHuongDan> TBChiTietHuongDans { get; set; }

        
        public virtual ICollection<TBChiTietKhenThuong> TBChiTietKhenThuongs { get; set; }

        
        public virtual ICollection<TBChiTietKyLuat> TBChiTietKyLuats { get; set; }

        
        public virtual ICollection<TBChiTietNghienCuu> TBChiTietNghienCuus { get; set; }

        
        public virtual ICollection<TBChiTietThacSi> TBChiTietThacSis { get; set; }

        
        public virtual ICollection<TBChiTietThamGiaHoiDong> TBChiTietThamGiaHoiDongs { get; set; }

        
        public virtual ICollection<TBChiTietTienSi> TBChiTietTienSis { get; set; }

        
        public virtual ICollection<TBChiTietTrinhDo> TBChiTietTrinhDoes { get; set; }

        public virtual TBChucVuDang TBChucVuDang { get; set; }

        
        public virtual ICollection<TBDeTaiNghienCuuKH> TBDeTaiNghienCuuKHs { get; set; }

        
        public virtual ICollection<TBTuDaoTao> TBTuDaoTaos { get; set; }

        
        public virtual ICollection<TBVietBaiBaoKhoaHoc> TBVietBaiBaoKhoaHocs { get; set; }

        
        public virtual ICollection<TBVietSachChuyenKhao> TBVietSachChuyenKhaos { get; set; }
    }
}