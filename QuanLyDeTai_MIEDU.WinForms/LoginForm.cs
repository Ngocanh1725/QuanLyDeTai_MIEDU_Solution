using System;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;
using QuanLyDeTai_MIEDU.BLL.Services;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class LoginForm : Form
    {
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
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}