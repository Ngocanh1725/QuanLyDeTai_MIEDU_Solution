using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai_MIEDU.Models
{
    public abstract class DeTai
    {
        private int _soGioGoc;
        private int _namThucHien;

        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string MaGV { get; set; }
        public string TenGV { get; set; }

        public int NamThucHien
        {
            get => _namThucHien;
            set { if (value < 2000) throw new ArgumentException("Năm không hợp lệ!"); _namThucHien = value; }
        }

        public int SoGioGoc
        {
            get => _soGioGoc;
            set { if (value <= 0) throw new ArgumentException("Giờ phải > 0!"); _soGioGoc = value; }
        }

        public DeTai(string ma, string ten, string maGV, string tenGV, int nam, int gio)
        {
            MaDeTai = ma; TenDeTai = ten; MaGV = maGV; TenGV = tenGV; NamThucHien = nam; SoGioGoc = gio;
        }

        // Phương thức ảo cho phép Đa Hình
        public virtual double TinhGioNghienCuu() { return SoGioGoc; }
    }
}
