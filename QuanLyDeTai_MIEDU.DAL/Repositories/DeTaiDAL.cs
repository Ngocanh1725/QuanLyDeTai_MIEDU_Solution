using Microsoft.Data.SqlClient;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Collections.Generic;

namespace QuanLyDeTai_MIEDU.DAL.Repositories
{
    // Cài đặt Interface IQuanLyDeTai từ Models
    public class DeTaiDAL : IQuanLyDeTai
    {
        private string connString = @"Server=localhost;Database=QuanLy_DeTaiMIEDU;Trusted_Connection=True;TrustServerCertificate=True;";

        public TaiKhoan DangNhap(string username, string password)
        {
            throw new NotImplementedException("Hàm này đã chuyển sang AuthDAL");
        }

        public List<DeTai> LayDanhSach(string query = "SELECT * FROM DeTaiNghienCuu")
        {
            List<DeTai> list = new List<DeTai>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    string ma = r["MaDeTai"].ToString(), ten = r["TenDeTai"].ToString();
                    string maGv = r["MaGV"].ToString(), tenGv = r["TenGV"].ToString();
                    int nam = Convert.ToInt32(r["NamThucHien"]), gio = Convert.ToInt32(r["SoGioGoc"]);

                    if (r["LoaiDeTai"].ToString() == "CapBo") list.Add(new DeTaiCapBo(ma, ten, maGv, tenGv, nam, gio));
                    else list.Add(new DeTaiCapTruong(ma, ten, maGv, tenGv, nam, gio));
                }
            }
            return list;
        }

        public void ThemDeTai(DeTai dt, string loai)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string q = "INSERT INTO DeTaiNghienCuu VALUES (@ma, @ten, @magv, @tengv, @loai, @nam, @gio)";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@ma", dt.MaDeTai); cmd.Parameters.AddWithValue("@ten", dt.TenDeTai);
                cmd.Parameters.AddWithValue("@magv", dt.MaGV); cmd.Parameters.AddWithValue("@tengv", dt.TenGV);
                cmd.Parameters.AddWithValue("@loai", loai); cmd.Parameters.AddWithValue("@nam", dt.NamThucHien);
                cmd.Parameters.AddWithValue("@gio", dt.SoGioGoc);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }

        public void SuaDeTai(DeTai dt)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string q = "UPDATE DeTaiNghienCuu SET TenDeTai=@ten, MaGV=@magv, TenGV=@tengv, NamThucHien=@nam, SoGioGoc=@gio WHERE MaDeTai=@ma";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@ma", dt.MaDeTai); cmd.Parameters.AddWithValue("@ten", dt.TenDeTai);
                cmd.Parameters.AddWithValue("@magv", dt.MaGV); cmd.Parameters.AddWithValue("@tengv", dt.TenGV);
                cmd.Parameters.AddWithValue("@nam", dt.NamThucHien); cmd.Parameters.AddWithValue("@gio", dt.SoGioGoc);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }

        public void XoaDeTai(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM DeTaiNghienCuu WHERE MaDeTai=@ma", conn);
                cmd.Parameters.AddWithValue("@ma", ma); conn.Open(); cmd.ExecuteNonQuery();
            }
        }

        public List<DeTai> TimKiem(string tk) => LayDanhSach($"SELECT * FROM DeTaiNghienCuu WHERE TenDeTai LIKE N'%{tk}%' OR TenGV LIKE N'%{tk}%'");
        public List<DeTai> LocTheoLoai(string loai) => LayDanhSach($"SELECT * FROM DeTaiNghienCuu WHERE LoaiDeTai = '{loai}'");
    }
}