using NStack;
using QuanLyDeTai_MIEDU.BLL.Services;
using QuanLyDeTai_MIEDU.Models;
using System;
using Terminal.Gui;

namespace QuanLyDeTai_MIEDU.ConsoleApp
{
    public class AddDeTaiDialog : Dialog
    {
        // Khởi tạo BLL
        private DeTaiBLL _bll = new DeTaiBLL();
        private bool _isEdit;
        public bool IsSaved { get; private set; } = false;

        public AddDeTaiDialog(DeTai dt = null) : base(dt == null ? "Thêm Đề Tài" : "Sửa Đề Tài", 60, 20)
        {
            _isEdit = dt != null;
            this.ColorScheme = ThemeManager.HackerScheme;

            var txtMa = new TextField(_isEdit ? dt.MaDeTai : "") { X = 15, Y = 2, Width = 35, ReadOnly = _isEdit };
            var txtTen = new TextField(_isEdit ? dt.TenDeTai : "") { X = 15, Y = 4, Width = 35 };
            var txtMaGV = new TextField(_isEdit ? dt.MaGV : "") { X = 15, Y = 6, Width = 35 };
            var txtTenGV = new TextField(_isEdit ? dt.TenGV : "") { X = 15, Y = 8, Width = 35 };
            var txtNam = new TextField(_isEdit ? dt.NamThucHien.ToString() : "") { X = 15, Y = 10, Width = 35 };
            var txtGio = new TextField(_isEdit ? dt.SoGioGoc.ToString() : "") { X = 15, Y = 12, Width = 35 };

            var radioLoai = new RadioGroup(new ustring[] { "Cấp Trường", "Cấp Bộ" }) { X = 15, Y = 14 };
            if (_isEdit) radioLoai.SelectedItem = dt is DeTaiCapBo ? 1 : 0;

            var btnSave = new Button("Lưu Lại", is_default: true) { X = Pos.Center() - 10, Y = 18 };
            var btnBack = new Button("Quay lại") { X = Pos.Center() + 4, Y = 18 };

            btnBack.Clicked += () => Application.RequestStop();
            btnSave.Clicked += () => {
                try
                {
                    int nam = int.Parse(txtNam.Text.ToString());
                    int gio = int.Parse(txtGio.Text.ToString());

                    // Tính kế thừa: Khởi tạo đối tượng lớp con tùy theo người dùng chọn
                    DeTai t = radioLoai.SelectedItem == 1
                        ? new DeTaiCapBo(txtMa.Text.ToString(), txtTen.Text.ToString(), txtMaGV.Text.ToString(), txtTenGV.Text.ToString(), nam, gio)
                        : new DeTaiCapTruong(txtMa.Text.ToString(), txtTen.Text.ToString(), txtMaGV.Text.ToString(), txtTenGV.Text.ToString(), nam, gio);

                    // Gọi BLL để xử lý
                    if (_isEdit) _bll.SuaDeTai(t);
                    else _bll.ThemDeTai(t, radioLoai.SelectedItem == 1 ? "CapBo" : "CapTruong");

                    IsSaved = true;
                    Application.RequestStop();
                }
                catch (Exception ex)
                {
                    // Nếu nhập chữ vào ô số hoặc bắt các lỗi nghiệp vụ khác
                    MessageBox.ErrorQuery("Lỗi", ex.Message, "OK");
                }
            };

            this.Add(new Label("Mã ĐT:") { X = 2, Y = 2 }, txtMa,
                     new Label("Tên ĐT:") { X = 2, Y = 4 }, txtTen,
                     new Label("Mã GV:") { X = 2, Y = 6 }, txtMaGV,
                     new Label("Tên GV:") { X = 2, Y = 8 }, txtTenGV,
                     new Label("Năm:") { X = 2, Y = 10 }, txtNam,
                     new Label("Giờ gốc:") { X = 2, Y = 12 }, txtGio,
                     new Label("Cấp:") { X = 2, Y = 14 }, radioLoai,
                     btnSave, btnBack);
        }
    }
}