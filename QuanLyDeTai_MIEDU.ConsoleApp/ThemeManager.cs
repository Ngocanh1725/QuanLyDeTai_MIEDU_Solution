using Terminal.Gui;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public static class ThemeManager
    {
        public static ColorScheme HackerScheme { get; private set; }
        public static ColorScheme InputScheme { get; private set; }

        public static void Initialize()
        {
            // Tone màu Tím (Magenta) và Đen cho giao diện chính (Hiện đại hơn)
            HackerScheme = new ColorScheme()
            {
                Normal = Application.Driver.MakeAttribute(Color.White, Color.Black),
                Focus = Application.Driver.MakeAttribute(Color.Black, Color.Magenta),
                HotNormal = Application.Driver.MakeAttribute(Color.Magenta, Color.Black),
                HotFocus = Application.Driver.MakeAttribute(Color.White, Color.Magenta)
            };

            // Tone màu cho ô nhập liệu TextBox
            InputScheme = new ColorScheme()
            {
                Normal = Application.Driver.MakeAttribute(Color.Cyan, Color.DarkGray),
                Focus = Application.Driver.MakeAttribute(Color.White, Color.Blue)
            };
        }
    }
}