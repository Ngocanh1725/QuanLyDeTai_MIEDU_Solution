using Microsoft.Data.SqlClient;
using QuanLyDeTai_MIEDU.Models;
using System;

namespace QuanLyDeTai_MIEDU.DAL.Repositories
{
    public class AuthDAL
    {
        private string connString = @"Server=localhost;Database=QuanLy_DeTaiMIEDU;Trusted_Connection=True;TrustServerCertificate=True;";

        public TaiKhoan KiemTraDangNhap(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TaiKhoan WHERE TenDangNhap=@u AND MatKhau=@p", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return new TaiKhoan(r["TenDangNhap"].ToString(), r["MatKhau"].ToString(), r["HoTen"].ToString(), r["Quyen"].ToString());
                }
                return null;
            }
        }
    }
}