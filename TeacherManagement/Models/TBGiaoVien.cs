namespace TeacherManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBGiaoVien")]
    public partial class TBGiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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
            TBChiTietThacSis = new HashSet<TBChiTietThacSi>();
            TBChiTietThamGiaHoiDongs = new HashSet<TBChiTietThamGiaHoiDong>();
            TBChiTietTienSis = new HashSet<TBChiTietTienSi>();
            TBChiTietTrinhDoNgoaiNgus = new HashSet<TBChiTietTrinhDoNgoaiNgu>();
            TBDeTaiNghienCuuKHs = new HashSet<TBDeTaiNghienCuuKH>();
            TBVietBaiBaoKhoaHocs = new HashSet<TBVietBaiBaoKhoaHoc>();
            TBVietSachChuyenKhaos = new HashSet<TBVietSachChuyenKhao>();
            TBChiTietTrinhDoNgoaiNgus = new HashSet<TBChiTietTrinhDoNgoaiNgu>();
        }

        [Key]
        public int MaGV { get; set; }

        [StringLength(255)]
        public string TenGV { get; set; }
        
        public DateTime NgaySinh { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public bool? GioiTinh { get; set; }

        public int? MaChucVuDang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietChucVuChinhQuyen> TBChiTietChucVuChinhQuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietChuVuChuyenMon> TBChiTietChuVuChuyenMons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietCongTacKhac> TBChiTietCongTacKhacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietCongTacKhaoThi> TBChiTietCongTacKhaoThis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDaiHoc> TBChiTietDaiHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietDaoTaoThucTe> TBChiTietDaoTaoThucTes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietGiangDay> TBChiTietGiangDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHoatDongNghienCuuKH> TBChiTietHoatDongNghienCuuKHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHocHam> TBChiTietHocHams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHocVi> TBChiTietHocVis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietHuongDan> TBChiTietHuongDans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietKhenThuong> TBChiTietKhenThuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietKyLuat> TBChiTietKyLuats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietThacSi> TBChiTietThacSis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietThamGiaHoiDong> TBChiTietThamGiaHoiDongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietTienSi> TBChiTietTienSis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBChiTietTrinhDoNgoaiNgu> TBChiTietTrinhDoNgoaiNgus { get; set; }

        public virtual TBChucVuDang TBChucVuDang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBDeTaiNghienCuuKH> TBDeTaiNghienCuuKHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietBaiBaoKhoaHoc> TBVietBaiBaoKhoaHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBVietSachChuyenKhao> TBVietSachChuyenKhaos { get; set; }
    }
}
