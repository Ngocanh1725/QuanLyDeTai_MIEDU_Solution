using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai_MIEDU.Models
{
    public interface IQuanLyDeTai
    {
        TaiKhoan DangNhap(string username, string password);
        List<DeTai> LayDanhSach(string query = "SELECT * FROM DeTaiNghienCuu");
        void ThemDeTai(DeTai dt, string loaiDeTai);
        void SuaDeTai(DeTai dt);
        void XoaDeTai(string maDeTai);
        List<DeTai> TimKiem(string tuKhoa);
        List<DeTai> LocTheoLoai(string loaiDeTai);
    }
}
