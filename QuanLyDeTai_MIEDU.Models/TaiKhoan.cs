  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai_MIEDU.Models
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string Quyen { get; set; }

        public TaiKhoan(string ten, string mk, string hoTen, string quyen)
        {
            TenDangNhap = ten; MatKhau = mk; HoTen = hoTen; Quyen = quyen;
        }
    }
}

