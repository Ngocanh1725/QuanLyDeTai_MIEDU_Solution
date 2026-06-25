using QuanLyDeTai_MIEDU.DAL.Repositories;
using QuanLyDeTai_MIEDU.Models;
using System;

namespace QuanLyDeTai_MIEDU.BLL.Services
{
    public class AuthBLL
    {
        private AuthDAL _authDAL = new AuthDAL();

        public TaiKhoan Login(string username, string password)
        {
            // Kiểm tra nghiệp vụ
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Tài khoản và mật khẩu không được để trống!");
            }

            return _authDAL.KiemTraDangNhap(username, password);
        }
    }
}