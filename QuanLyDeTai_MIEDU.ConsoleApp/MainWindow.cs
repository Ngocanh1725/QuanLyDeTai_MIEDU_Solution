using NStack;
using QuanLyDeTai_MIEDU.BLL.Services;
using QuanLyDeTai_MIEDU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Terminal.Gui;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public class MainWindow : Toplevel
    {
        private DeTaiBLL _bll = new DeTaiBLL();
        private TableView _tableView;

        public MainWindow(TaiKhoan user)
        {
            this.ColorScheme = ThemeManager.HackerScheme;

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_Hệ thống", new MenuItem [] { new MenuItem ("_Đăng xuất", "", () => Application.RequestStop()) }),
                new MenuBarItem ("_Báo Cáo NCKH", new MenuItem [] {
                    new MenuItem ("_1. Xem Đề tài theo Giảng viên", "", () => ChonGiangVienDeThongKe("XEM_DETAI")),
                    new MenuItem ("_2. Thống kê giờ theo Năm", "", () => ChonGiangVienDeThongKe("THONG_KE_NAM")),
                    new MenuItem ("_3. Xem Năm cống hiến cao nhất", "", () => ChonGiangVienDeThongKe("NAM_CAO_NHAT"))
                })
            });

            var win = new Window($"💻 BẢNG ĐIỀU KHIỂN - TÀI KHOẢN: {user.HoTen} 💻") { X = 0, Y = 1, Width = Dim.Fill(), Height = Dim.Fill() };
            var leftPane = new FrameView("Trình Đơn") { X = 0, Y = 0, Width = Dim.Percent(20), Height = Dim.Fill() };
            var rightPane = new FrameView("Bảng Dữ Liệu") { X = Pos.Right(leftPane), Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

            var menuList = new ListView(new ustring[] { "1. Xem tất cả ĐT", "2. Thêm mới ĐT", "3. Sửa ĐT", "4. Xóa ĐT", "5. Tìm kiếm", "6. Danh sách Giảng Viên" })
            { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill() };

            _tableView = new TableView() { X = 0, Y = 0, Width = Dim.Fill(), Height = Dim.Fill(), FullRowSelect = true };

            menuList.OpenSelectedItem += (e) => {
                if (e.Item == 0) RefreshData();
                if (e.Item == 1) ShowAddDialog(null);
                if (e.Item == 2) EditSelected();
                if (e.Item == 3) DeleteSelected();
                if (e.Item == 4) SearchData();
                if (e.Item == 5) XemDanhSachGV();
            };

            leftPane.Add(menuList);
            rightPane.Add(_tableView);
            win.Add(leftPane, rightPane);
            this.Add(menu, win);

            RefreshData();
        }

        private void RefreshData() => LoadDataToTable(_bll.LayDanhSach());

        private void LoadDataToTable(List<DeTai> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã ĐT"); dt.Columns.Add("Tên Đề Tài");
            dt.Columns.Add("Tên Giảng Viên"); dt.Columns.Add("Loại");
            dt.Columns.Add("Năm"); dt.Columns.Add("Giờ Gốc"); dt.Columns.Add("Giờ Quy Đổi");

            foreach (var item in list)
            {
                string loai = item is DeTaiCapBo ? "Cấp Bộ" : "Cấp Trường";
                dt.Rows.Add(item.MaDeTai, item.TenDeTai, item.TenGV, loai, item.NamThucHien, item.SoGioGoc, item.TinhGioNghienCuu());
            }

            _tableView.Table = dt;
            _tableView.Update();
        }

        // ==========================================
        // CÁC HÀM THỐNG KÊ ĐÃ ĐƯỢC FIX
        // ==========================================
        private void XemDanhSachGV()
        {
            // Cập nhật: Hiển thị chi tiết số lượng đề tài và tổng giờ
            var ds = _bll.LayDanhSachGiangVienChiTiet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã GV"); dt.Columns.Add("Họ và Tên Giảng Viên");
            dt.Columns.Add("Tổng số Đề tài"); dt.Columns.Add("Tổng giờ NCKH");

            foreach (var gv in ds)
            {
                dt.Rows.Add(gv.MaGV, gv.TenGV, gv.SoLuongDeTai, gv.TongGio);
            }
            _tableView.Table = dt; _tableView.Update();
        }

        // FIX LỖI: Gom chung hàm chọn GV để tái sử dụng, nút Xem không bị đè
        private void ChonGiangVienDeThongKe(string action)
        {
            var ds = _bll.LayDanhSachGiangVien();
            if (ds.Count == 0) return;

            // Tính toán chiều cao linh hoạt dựa vào số lượng GV
            int height = ds.Count + 8;
            var dialog = new Dialog("Chọn Giảng Viên", 50, height);

            var radioGV = new RadioGroup(ds.Select(x => (ustring)x).ToArray()) { X = 2, Y = 2 };
            // Đặt nút Xem ở tọa độ Y nằm dưới radioGV
            var btnXem = new Button("Thực Hiện") { X = Pos.Center(), Y = Pos.Bottom(radioGV) + 1, IsDefault = true };

            btnXem.Clicked += () => {
                string tenGV = ds[radioGV.SelectedItem];
                Application.RequestStop();

                if (action == "XEM_DETAI")
                    LoadDataToTable(_bll.LayDeTaiTheoGiangVien(tenGV));
                else if (action == "THONG_KE_NAM")
                {
                    var dict = _bll.ThongKeGioTheoNam(tenGV);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Giảng Viên"); dt.Columns.Add("Năm Thực Hiện"); dt.Columns.Add("Tổng Giờ NCKH");
                    foreach (var item in dict.OrderByDescending(x => x.Key))
                        dt.Rows.Add(tenGV, item.Key, item.Value);
                    _tableView.Table = dt; _tableView.Update();
                }
                else if (action == "NAM_CAO_NHAT")
                {
                    var result = _bll.TimNamNhieuGioNhat(tenGV);
                    if (result.Key > 0)
                        MessageBox.Query("Kết quả", $"Năm cống hiến nhiều nhất của {tenGV}:\nNăm {result.Key} với tổng {result.Value} giờ NCKH.", "Đóng");
                    else
                        MessageBox.Query("Kết quả", $"{tenGV} chưa có dữ liệu đề tài.", "Đóng");
                }
            };

            dialog.Add(radioGV, btnXem);
            Application.Run(dialog);
        }

        // ==========================================
        // CÁC HÀM CRUD CƠ BẢN
        // ==========================================
        private bool IsEditingDeTai()
        {
            // FIX LỖI: Kiểm tra xem bảng hiện tại có phải là bảng Đề tài không (có chứa cột Mã ĐT không)
            if (_tableView.Table == null || !_tableView.Table.Columns.Contains("Mã ĐT"))
            {
                MessageBox.ErrorQuery("Lỗi", "Tính năng này chỉ dùng trong màn hình [Xem tất cả ĐT] hoặc [Tìm kiếm]!", "OK");
                return false;
            }
            if (_tableView.SelectedRow < 0) return false;
            return true;
        }

        private void EditSelected()
        {
            if (!IsEditingDeTai()) return;
            string ma = _tableView.Table.Rows[_tableView.SelectedRow]["Mã ĐT"].ToString();
            var list = _bll.TimKiem(ma);
            if (list.Count > 0) ShowAddDialog(list[0]);
        }

        private void DeleteSelected()
        {
            if (!IsEditingDeTai()) return;
            string ma = _tableView.Table.Rows[_tableView.SelectedRow]["Mã ĐT"].ToString();

            if (MessageBox.Query("Xóa", $"Bạn muốn xóa Đề tài {ma}?", "Có", "Không") == 0)
            {
                try { _bll.XoaDeTai(ma); RefreshData(); }
                catch (Exception ex) { MessageBox.ErrorQuery("Lỗi", ex.Message, "OK"); }
            }
        }

        private void ShowAddDialog(DeTai dt)
        {
            var dialog = new AddDeTaiDialog(dt);
            Application.Run(dialog);
            if (dialog.IsSaved) RefreshData();
        }

        private void SearchData()
        {
            var dialog = new Dialog("Tìm kiếm", 40, 8);
            var txtQuery = new TextField("") { X = 10, Y = 2, Width = 20, ColorScheme = ThemeManager.InputScheme };
            var btnTim = new Button("Tìm") { X = Pos.Center(), Y = 4, IsDefault = true };

            btnTim.Clicked += () => {
                LoadDataToTable(_bll.TimKiem(txtQuery.Text.ToString()));
                Application.RequestStop();
            };

            dialog.Add(new Label("Từ khóa:") { X = 2, Y = 2 }, txtQuery, btnTim);
            Application.Run(dialog);
        }
    }
}