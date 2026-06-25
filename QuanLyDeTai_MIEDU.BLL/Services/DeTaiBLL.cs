using QuanLyDeTai_MIEDU.DAL.Repositories;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDeTai_MIEDU.BLL.Services
{
    public class DeTaiBLL
    {
        private DeTaiDAL _dal = new DeTaiDAL();

        public List<DeTai> LayDanhSach() => _dal.LayDanhSach();
        public List<DeTai> TimKiem(string tk) => _dal.TimKiem(tk);
        public List<DeTai> LocTheoLoai(string loai) => _dal.LocTheoLoai(loai);

        public void ThemDeTai(DeTai dt, string loai)
        {
            if (string.IsNullOrWhiteSpace(dt.MaDeTai) || string.IsNullOrWhiteSpace(dt.TenDeTai))
                throw new Exception("Mã và Tên Đề tài không được để trống!");
            _dal.ThemDeTai(dt, loai);
        }

        public void SuaDeTai(DeTai dt)
        {
            if (string.IsNullOrWhiteSpace(dt.TenDeTai)) throw new Exception("Tên đề tài không được trống!");
            _dal.SuaDeTai(dt);
        }

        public void XoaDeTai(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma)) throw new Exception("Không xác định được mã cần xóa!");
            _dal.XoaDeTai(ma);
        }

        // =========================================================================
        // CÁC CHỨC NĂNG THỐNG KÊ & BÁO CÁO
        // =========================================================================

        public List<string> LayDanhSachGiangVien()
        {
            return _dal.LayDanhSach().Select(x => x.TenGV).Distinct().ToList();
        }

        // Cập nhật: Dùng ValueTuple thay vì dynamic để truyền dữ liệu an toàn giữa các Project
        public List<(string MaGV, string TenGV, int SoLuongDeTai, double TongGio)> LayDanhSachGiangVienChiTiet()
        {
            var data = _dal.LayDanhSach();
            var thongKe = data.GroupBy(x => new { x.MaGV, x.TenGV })
                              .Select(g => (
                                  g.Key.MaGV,
                                  g.Key.TenGV,
                                  g.Count(),
                                  g.Sum(x => x.TinhGioNghienCuu()) // Tính đa hình
                              )).ToList();
            return thongKe;
        }

        public List<DeTai> LayDeTaiTheoGiangVien(string tenGV)
        {
            return _dal.LayDanhSach().Where(x => x.TenGV.Equals(tenGV, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Dictionary<int, double> ThongKeGioTheoNam(string tenGV)
        {
            var data = LayDeTaiTheoGiangVien(tenGV);
            return data.GroupBy(x => x.NamThucHien)
                       .ToDictionary(g => g.Key, g => g.Sum(x => x.TinhGioNghienCuu()));
        }

        public KeyValuePair<int, double> TimNamNhieuGioNhat(string tenGV)
        {
            var thongKe = ThongKeGioTheoNam(tenGV);
            if (thongKe.Count == 0) return new KeyValuePair<int, double>(0, 0);
            var max = thongKe.Aggregate((l, r) => l.Value > r.Value ? l : r);
            return max;
        }
    }
}