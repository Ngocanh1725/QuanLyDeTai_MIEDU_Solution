using System;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm(TaiKhoan user)
        {
            InitializeComponent();
            lblTitle.Text = $"Xin chào: {user.HoTen}";

            // Khởi tạo Màn hình chính
            OpenControl(new DeTaiControl(), "BẢNG ĐIỀU KHIỂN - QUẢN LÝ ĐỀ TÀI");
        }

        private void OpenControl(UserControl uc, string title)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            lblTitle.Text = title;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
            => OpenControl(new DeTaiControl(), "QUẢN LÝ ĐỀ TÀI CHUNG");

        private void btnThongKe_Click(object sender, EventArgs e)
            => OpenControl(new ucGiangVien_DeTai(), "BÁO CÁO & THỐNG KÊ GIẢNG VIÊN");

        private void btnLogout_Click(object sender, EventArgs e)
            => Application.Restart();
    }
}