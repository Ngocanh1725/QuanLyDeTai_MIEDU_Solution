using System;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;
using QuanLyDeTai_MIEDU.BLL.Services;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class LoginForm : Form
    {
        // Khởi tạo BLL, tuyệt đối không dùng DAL hay SQL ở đây
        private AuthBLL _authBll = new AuthBLL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan user = _authBll.Login(txtUser.Text, txtPass.Text);
                if (user != null)
                {
                    this.Hide();
                    MainForm main = new MainForm(user);
                    main.FormClosed += (s, args) => this.Close();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi từ tầng BLL (Ví dụ: để trống tài khoản)
                MessageBox.Show(ex.Message, "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}