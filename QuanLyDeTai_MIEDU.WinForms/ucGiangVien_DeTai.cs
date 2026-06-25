using QuanLyDeTai_MIEDU.BLL.Services;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class ucGiangVien_DeTai : UserControl
    {
        private DeTaiBLL _bll = new DeTaiBLL();

        public ucGiangVien_DeTai()
        {
            InitializeComponent();

            // Tải danh sách Giảng viên vào ComboBox
            LoadGiangVien();

            // Lắng nghe sự kiện khi người dùng đổi Giảng viên
            cmbGiangVien.SelectedIndexChanged += CmbGiangVien_SelectedIndexChanged;
        }

        private void LoadGiangVien()
        {
            var dsGV = _bll.LayDanhSachGiangVien();
            cmbGiangVien.Items.AddRange(dsGV.ToArray());
            if (cmbGiangVien.Items.Count > 0)
                cmbGiangVien.SelectedIndex = 0; // Tự động chọn người đầu tiên để load Data
        }

        private void CmbGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGV = cmbGiangVien.SelectedItem.ToString();

            // 1. Hiển thị danh sách Đề tài tham gia
            var dsDeTai = _bll.LayDeTaiTheoGiangVien(selectedGV);
            dgvData.DataSource = dsDeTai.Select(d => new {
                MaDeTai = d.MaDeTai,
                TenDeTai = d.TenDeTai,
                Loai = d is DeTaiCapBo ? "Cấp Bộ" : "Cấp Trường",
                Nam = d.NamThucHien,
                GioQuyDoi = d.TinhGioNghienCuu()
            }).ToList();

            // 2. Cập nhật Biểu đồ Thống kê giờ theo năm
            var thongKeGio = _bll.ThongKeGioTheoNam(selectedGV);
            chartThongKe.Series["Giờ NCKH"].Points.Clear(); // Xóa dữ liệu cũ

            foreach (var item in thongKeGio.OrderBy(x => x.Key))
            {
                // Thêm cột vào biểu đồ (Trục X: Năm, Trục Y: Tổng giờ)
                chartThongKe.Series["Giờ NCKH"].Points.AddXY(item.Key.ToString(), item.Value);
            }

            // 3. Hiển thị năm có số giờ nhiều nhất
            var maxYear = _bll.TimNamNhieuGioNhat(selectedGV);
            if (maxYear.Key > 0)
                lblNamCaoNhat.Text = $"Năm cống hiến cao nhất: {maxYear.Key} ({maxYear.Value} giờ)";
            else
                lblNamCaoNhat.Text = "Chưa có dữ liệu thống kê";
        }
    }
}