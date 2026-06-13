using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai_MIEDU.Models
{
    public class DeTaiCapBo : DeTai
    {
        public DeTaiCapBo(string ma, string ten, string maGv, string tenGv, int nam, int gio)
            : base(ma, ten, maGv, tenGv, nam, gio) { }

        public override double TinhGioNghienCuu() => base.SoGioGoc * 1.5;
    }
}
