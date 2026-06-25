using QuanLyDeTai_MIEDU.DAL.Repositories;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Collections.Generic;

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
            if (string.IsNullOrWhiteSpace(dt.TenDeTai))
                throw new Exception("Tên đề tài không được để trống!");

            _dal.SuaDeTai(dt);
        }

        public void XoaDeTai(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
                throw new Exception("Không xác định được mã cần xóa!");

            _dal.XoaDeTai(ma);
        }
    }
}