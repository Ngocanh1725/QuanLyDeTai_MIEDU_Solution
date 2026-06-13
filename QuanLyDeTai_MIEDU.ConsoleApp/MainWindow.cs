using NStack;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public class MainWindow : Toplevel
    {
        private IQuanLyDeTai _db;
        private TableView _tableView;

        public MainWindow(TaiKhoan user, IQuanLyDeTai db)
        {
            _db = db; this.ColorScheme = ThemeManager.HackerScheme;
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_Hệ thống", new MenuItem [] { new MenuItem ("_Đăng xuất", "", () => Application.RequestStop()) })
            });

            var win = new Window($"BẢNG ĐIỀU KHIỂN - {user.HoTen}") { X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };
            var leftPane = new FrameView("Chức năng") { X = 0, Y = 0, Width = Dim.Percent(20), Height = Dim.Fill() };
            var rightPane = new FrameView("Dữ liệu") { X = Pos.Right(leftPane), Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

            var menuList = new ListView(new ustring[] { "1. Xem tất cả", "2. Thêm mới", "3. Sửa ĐT", "4. Xóa ĐT", "5. Tìm kiếm" }) { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };
            _tableView = new TableView() { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill(), FullRowSelect = true };

            menuList.OpenSelectedItem += (e) => {
                if (e.Item == 0) RefreshData();
                if (e.Item == 1) ShowAddDialog(null);
                if (e.Item == 2) EditSelected();
                if (e.Item == 3) DeleteSelected();
                if (e.Item == 4) SearchData();
            };

            leftPane.Add(menuList); rightPane.Add(_tableView); win.Add(leftPane, rightPane);
            this.Add(menu, win); RefreshData();
        }

        private void RefreshData() => LoadDataToTable(_db.LayDanhSach());
        private void LoadDataToTable(List<DeTai> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã ĐT"); dt.Columns.Add("Tên Đề Tài"); dt.Columns.Add("Mã GV"); dt.Columns.Add("Giờ Gốc"); dt.Columns.Add("Giờ Quy Đổi");
            foreach (var item in list) dt.Rows.Add(item.MaDeTai, item.TenDeTai, item.MaGV, item.SoGioGoc, item.TinhGioNghienCuu());
            _tableView.Table = dt; _tableView.Update();
        }

        private void ShowAddDialog(DeTai dt)
        {
            var dialog = new AddDeTaiDialog(_db, dt);
            Application.Run(dialog);
            if (dialog.IsSaved) RefreshData();
        }

        private void EditSelected()
        {
            if (_tableView.SelectedRow < 0) return;
            string ma = _tableView.Table.Rows[_tableView.SelectedRow][0].ToString();
            // Lấy tạm object cũ để sửa
            var list = _db.TimKiem(ma);
            if (list.Count > 0) ShowAddDialog(list[0]);
        }

        private void DeleteSelected()
        {
            if (_tableView.SelectedRow < 0) return;
            string ma = _tableView.Table.Rows[_tableView.SelectedRow][0].ToString();
            if (MessageBox.Query("Xóa", $"Bạn muốn xóa Đề tài {ma}?", "Có", "Không") == 0) { _db.XoaDeTai(ma); RefreshData(); }
        }

        private void SearchData()
        {
            var dialog = new Dialog("Tìm kiếm", 40, 8);
            var txtQuery = new TextField("") { X = 10, Y = 2, Width = 20 };
            var btnTim = new Button("Tìm") { X = Pos.Center(), Y = 4 };
            btnTim.Clicked += () => { LoadDataToTable(_db.TimKiem(txtQuery.Text.ToString())); Application.RequestStop(); };
            dialog.Add(new Label("Từ khóa:") { X = 2, Y = 2 }, txtQuery, btnTim); Application.Run(dialog);
        }
    }
}

