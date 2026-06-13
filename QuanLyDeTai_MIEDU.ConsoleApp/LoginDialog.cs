using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using QuanLyDeTai_MIEDU.Models;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public class LoginDialog : Dialog
    {
        public TaiKhoan AuthenticatedUser { get; private set; } = null;

        public LoginDialog(IQuanLyDeTai db) : base("HỆ THỐNG QUẢN LÝ ĐỀ TÀI - MIEDU", 65, 12)
        {
            this.ColorScheme = ThemeManager.HackerScheme;
            var txtUser = new TextField("") { X = 18, Y = 2, Width = 40, ColorScheme = ThemeManager.InputScheme };
            var txtPass = new TextField("") { X = 18, Y = 4, Width = 40, Secret = true, ColorScheme = ThemeManager.InputScheme };

            var btnLogin = new Button("Đăng nhập") { X = 10, Y = 7, IsDefault = true };
            var btnExit = new Button("Thoát") { X = Pos.Right(btnLogin) + 10, Y = 7 };

            btnLogin.Clicked += () => {
                var user = db.DangNhap(txtUser.Text.ToString(), txtPass.Text.ToString());
                if (user != null) { AuthenticatedUser = user; Application.RequestStop(); }
                else MessageBox.ErrorQuery("Lỗi", "Sai tài khoản/mật khẩu!", "OK");
            };
            btnExit.Clicked += () => Application.RequestStop();

            this.Add(new Label("Tài khoản:") { X = 5, Y = 2 }, txtUser, new Label("Mật khẩu:") { X = 5, Y = 4 }, txtPass, btnLogin, btnExit);
        }
    }
}

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    internal class LoginDialog
    {
    }
}
