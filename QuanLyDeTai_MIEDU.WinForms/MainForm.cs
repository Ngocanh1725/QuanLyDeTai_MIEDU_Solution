using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Khởi tạo Component Quản lý 
            OpenControl(new DeTaiControl());
        }

        private void OpenControl(UserControl uc)
        {
            pnlContent.Controls.Clear(); uc.Dock = DockStyle.Fill; pnlContent.Controls.Add(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e) => Application.Restart();
    }
}
