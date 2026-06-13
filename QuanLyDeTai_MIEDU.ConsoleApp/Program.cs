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

            IQuanLyDeTai db = new DatabaseHelper();
            while (true)
            {
                var loginDialog = new LoginDialog(db);
                Application.Run(loginDialog);
                if (loginDialog.AuthenticatedUser == null) break;

                var mainWindow = new MainWindow(loginDialog.AuthenticatedUser, db);
                Application.Run(mainWindow);
            }
            Application.Shutdown();
        }
    }
}

