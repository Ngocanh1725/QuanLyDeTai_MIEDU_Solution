using Terminal.Gui;
using QuanLyDeTai_MIEDU.Models;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            ThemeManager.Initialize();

            // Xóa dòng tạo DB ở đây, các form sẽ tự gọi BLL
            while (true)
            {
                var loginDialog = new LoginDialog();
                Application.Run(loginDialog);

                if (loginDialog.AuthenticatedUser == null) break;

                var mainWindow = new MainWindow(loginDialog.AuthenticatedUser);
                Application.Run(mainWindow);
            }

            Application.Shutdown();
        }
    }
}