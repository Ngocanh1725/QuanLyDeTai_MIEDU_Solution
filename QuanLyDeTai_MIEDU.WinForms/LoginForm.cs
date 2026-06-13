using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class LoginForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        public LoginForm() { InitializeComponent(); }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TaiKhoan user = db.DangNhap(txtUser.Text, txtPass.Text);
            if (user != null)
            {
                this.Hide();
                MainForm main = new MainForm(user);
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            else MessageBox.Show("Sai tài khoản / mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
