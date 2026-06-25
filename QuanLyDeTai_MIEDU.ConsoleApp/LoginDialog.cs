using System;
using Terminal.Gui;
using QuanLyDeTai_MIEDU.Models;
using QuanLyDeTai_MIEDU.BLL.Services;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public class LoginDialog : Dialog
    {
        // Khởi tạo BLL để xử lý logic đăng nhập
        private AuthBLL _authBll = new AuthBLL();

        // Thuộc tính để lưu trữ người dùng sau khi đăng nhập thành công
        public TaiKhoan AuthenticatedUser { get; private set; } = null;

        public LoginDialog() : base("HỆ THỐNG QUẢN LÝ ĐỀ TÀI - MIEDU", 65, 12)
        {
            this.ColorScheme = ThemeManager.HackerScheme;

            // Các trường nhập liệu
            var txtUser = new TextField("") { X = 18, Y = 2, Width = 40, ColorScheme = ThemeManager.InputScheme };
            var txtPass = new TextField("") { X = 18, Y = 4, Width = 40, Secret = true, ColorScheme = ThemeManager.InputScheme };

            // Các nút bấm
            var btnLogin = new Button("Đăng nhập") { X = 10, Y = 7, IsDefault = true };
            var btnExit = new Button("Thoát") { X = Pos.Right(btnLogin) + 10, Y = 7 };

            // Xử lý sự kiện click Đăng nhập
            btnLogin.Clicked += () => {
                try
                {
                    // Gọi BLL để kiểm tra đăng nhập
                    var user = _authBll.Login(txtUser.Text.ToString(), txtPass.Text.ToString());

                    if (user != null)
                    {
                        AuthenticatedUser = user;
                        Application.RequestStop(); // Đóng hộp thoại khi thành công
                    }
                    else
                    {
                        MessageBox.ErrorQuery("Lỗi", "Sai tài khoản/mật khẩu!", "OK");
                    }
                }
                catch (Exception ex)
                {
                    // Bắt các lỗi nghiệp vụ quăng ra từ tầng BLL (VD: không nhập gì)
                    MessageBox.ErrorQuery("Lỗi Nghiệp vụ", ex.Message, "OK");
                }
            };

            // Xử lý sự kiện click Thoát
            btnExit.Clicked += () => Application.RequestStop();

            // Thêm tất cả control vào Dialog
            this.Add(
                new Label("Tài khoản:") { X = 5, Y = 2 }, txtUser,
                new Label("Mật khẩu:") { X = 5, Y = 4 }, txtPass,
                btnLogin, btnExit
            );
        }
    }
}