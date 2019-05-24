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
    public class CongTacNghienCuuKHResipotary
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

        public CongTacNghienCuuKHResipotary()
        {
            Connection();
        }

        #region Lấy danh sách thể loại, vai trò, loại hình

        public ThemCongTacNCKHDTO themCongTacNCKHDTO(string maGV ,string namHoc)
        {
            return new ThemCongTacNCKHDTO
            {
                MaGV = Convert.ToInt32(maGV),
                NamHoc = namHoc,
                LoaiSach = LayListLoaiSach(),
                LoaiBao = LayListLoaiBao(),
                LoaiDeTai = LayListLoaiDeTai(),
                LoaiVaiTro = LayListVaiTro(),
                LoaiHinh = LayListLoaiHinh()
            };
        }

        public List<KeyValuePair<int, string>> LayListLoaiSach()
        {
            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            SqlCommand conn = new SqlCommand("LayListLoaiSach", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach(DataRow dr in dataTable.Rows)
            {
                int key = Convert.ToInt32(dr["MaLoaiSach"]);
                string value = Convert.ToString(dr["TenLoaiSach"]);
                lst.Add(new KeyValuePair<int, string>(key, value));
            }

            return lst;
        }

        public List<KeyValuePair<int, string>> LayListLoaiBao()
        {
            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            SqlCommand conn = new SqlCommand("LayListLoaiBao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int key = Convert.ToInt32(dr["MaLoaiBaiBao"]);
                string value = Convert.ToString(dr["TenLoaiBao"]);
                lst.Add(new KeyValuePair<int, string>(key, value));
            }

            return lst;
        }

        public List<KeyValuePair<int, string>> LayListLoaiDeTai()
        {
            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            SqlCommand conn = new SqlCommand("LayListLoaiDeTai", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int key = Convert.ToInt32(dr["MaLoaiDeTaiKH"]);
                string value = Convert.ToString(dr["TenLoaiDeTaiKH"]);
                lst.Add(new KeyValuePair<int, string>(key, value));
            }

            return lst;
        }

        public List<KeyValuePair<int, string>> LayListVaiTro()
        {
            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            SqlCommand conn = new SqlCommand("LayListVaiTro", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int key = Convert.ToInt32(dr["MaVaiTro"]);
                string value = Convert.ToString(dr["TenVaiTro"]);
                lst.Add(new KeyValuePair<int, string>(key, value));
            }

            return lst;
        }


        public List<KeyValuePair<int, string>> LayListLoaiHinh()
        {
            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            SqlCommand conn = new SqlCommand("LayListLoaiHinh", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                int key = Convert.ToInt32(dr["MaLoaiHinh"]);
                string value = Convert.ToString(dr["TenLoaiHinh"]);
                lst.Add(new KeyValuePair<int, string>(key, value));
            }

            return lst;
        }
        #endregion

        #region Thêm công tác NCKH

        public void ThemVietSachChuyenKhao(GiaoVienVietSachDTO giaoVienVietSach)
        {
            // Thêm vào TBSachChuyenKhao

            SqlCommand conn = new SqlCommand("ThemSachChuyenKhao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@tenSach", SqlDbType.NVarChar).Value = giaoVienVietSach.TenSach;
            conn.Parameters.Add("@soISBN", SqlDbType.NVarChar).Value = giaoVienVietSach.SoISBN;
            conn.Parameters.Add("@noiXuatBan", SqlDbType.NVarChar).Value = giaoVienVietSach.NoiXuatBan;
            conn.Parameters.Add("@maLoaiSach", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietSach.LoaiSach.Substring(0, 1));
            conn.Parameters.Add("@namXuatBan", SqlDbType.Date).Value =Convert.ToDateTime(giaoVienVietSach.NamXuatBan);
            conn.Parameters.Add("@tongTrang", SqlDbType.Int).Value = giaoVienVietSach.SoTrang;
            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();

            // Lấy mã sách ms thêm

            int maSach = 0;

            conn = new SqlCommand("FindSach", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@tenSach", SqlDbType.NVarChar).Value = giaoVienVietSach.TenSach;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                maSach = Convert.ToInt32(dataTable.Rows[0]["MaSach"]);
            }
            // Thêm vào TBVietSachChuyenKhao

            conn = new SqlCommand("ThemVietSachChuyenKhao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@maSach", SqlDbType.Int).Value = maSach;
            conn.Parameters.Add("@maGV", SqlDbType.Int).Value = giaoVienVietSach.MaGV;
            conn.Parameters.Add("@soTrang", SqlDbType.Int).Value = giaoVienVietSach.SoTrang;
            conn.Parameters.Add("@maVaiTro", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietSach.VaiTro.Substring(0, 1));
            conn.Parameters.Add("@maHinhThuc", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietSach.LoaiHinh.Split('.')[0]);
            conn.Parameters.Add("@namHoc", SqlDbType.Char).Value = giaoVienVietSach.NamHoc;
            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();
        }

        public void ThemVietBaiBao(GiaoVienVietBaoDTO giaoVienVietBaoDTO)
        {
            // Thêm vào TBBaiBao

            SqlCommand conn = new SqlCommand("ThemBaiBao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@TenBaiBao", SqlDbType.NVarChar).Value = giaoVienVietBaoDTO.TenBaiBao;
            conn.Parameters.Add("@SoISBN", SqlDbType.NVarChar).Value = giaoVienVietBaoDTO.SoISBN;
            conn.Parameters.Add("@NoiXuatBan", SqlDbType.NVarChar).Value = giaoVienVietBaoDTO.NoiXuatBan;
            conn.Parameters.Add("@MaLoaiBaiBao", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietBaoDTO.LoaiBaiBao.Substring(0, 1));
            conn.Parameters.Add("@NgayXuatBan", SqlDbType.Date).Value = Convert.ToDateTime(giaoVienVietBaoDTO.NgayXuatBan);

            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();

            // Lấy mã sách ms thêm

            int maBaiBao = 0;

            conn = new SqlCommand("FindBaiBao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@tenBaiBao", SqlDbType.NVarChar).Value = giaoVienVietBaoDTO.TenBaiBao;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                maBaiBao = Convert.ToInt32(dataTable.Rows[0]["MaBaiBao"]);
            }
            // Thêm vào TBVietSachChuyenKhao

            conn = new SqlCommand("ThemVietBaiBao", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaBaiBao", SqlDbType.Int).Value = maBaiBao;
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienVietBaoDTO.MaGV;
            conn.Parameters.Add("@SoBaiBao", SqlDbType.Int).Value = giaoVienVietBaoDTO.SoISBN;
            conn.Parameters.Add("@MaVaiTro", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietBaoDTO.VaiTro.Substring(0, 1));
            conn.Parameters.Add("@MaLoaiHinhThucNghienCuu", SqlDbType.Int).Value = Convert.ToInt32(giaoVienVietBaoDTO.LoaiHinh.Substring(0, 1));
            conn.Parameters.Add("@namHoc", SqlDbType.Char).Value = giaoVienVietBaoDTO.NamHoc;
            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();
        }

        public void ThemLamDeTaiKhoaHoc(GiaoVienDeTaiKHDTO giaoVienDeTaiKHDTO)
        {
            // Thêm vào TBBaiBao

            SqlCommand conn = new SqlCommand("ThemDeTaiKhoaHoc", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@TenDeTaiKhoaHoc", SqlDbType.NVarChar).Value = giaoVienDeTaiKHDTO.TenDeTaiNCKH;
            conn.Parameters.Add("@SoISBN", SqlDbType.NVarChar).Value = giaoVienDeTaiKHDTO.SoISBN;
            conn.Parameters.Add("@MaLoaiDeTai", SqlDbType.Int).Value = Convert.ToInt32(giaoVienDeTaiKHDTO.LoaiDeTai.Substring(0, 1));
            conn.Parameters.Add("@NgayXuatBan", SqlDbType.Date).Value = Convert.ToDateTime(giaoVienDeTaiKHDTO.NgayXuatBan);

            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();

            // Lấy mã sách ms thêm

            int maDeTai = 0;

            conn = new SqlCommand("FindDeTaiKhoaHoc", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@tenDeTai", SqlDbType.NVarChar).Value = giaoVienDeTaiKHDTO.TenDeTaiNCKH;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(conn);

            DataTable dataTable = new DataTable(); ;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                maDeTai = Convert.ToInt32(dataTable.Rows[0]["MaDeTaiKhoaHoc"]);
            }
            // Thêm vào TBVietSachChuyenKhao

            conn = new SqlCommand("ThemLamDeTaiKhoaHoc", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.Add("@MaBaiBao", SqlDbType.Int).Value = maDeTai;
            conn.Parameters.Add("@MaGV", SqlDbType.Int).Value = giaoVienDeTaiKHDTO.MaGV;
            conn.Parameters.Add("@SoDeTai", SqlDbType.Int).Value = giaoVienDeTaiKHDTO.SoDeTai;
            conn.Parameters.Add("@MaVaiTro", SqlDbType.Int).Value = Convert.ToInt32(giaoVienDeTaiKHDTO.VaiTro.Substring(0, 1));
            conn.Parameters.Add("@MaLoaiHinhThucNghienCuu", SqlDbType.Int).Value = Convert.ToInt32(giaoVienDeTaiKHDTO.LoaiHinh.Substring(0, 1));
            conn.Parameters.Add("@namHoc", SqlDbType.Char).Value = giaoVienDeTaiKHDTO.NamHoc;
            _connection.Open();

            conn.ExecuteNonQuery();

            _connection.Close();
        }

        #endregion
    }
}