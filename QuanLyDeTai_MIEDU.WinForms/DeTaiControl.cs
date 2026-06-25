using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;
using QuanLyDeTai_MIEDU.BLL.Services;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class DeTaiControl : UserControl
    {
        // Khởi tạo BLL (Đường dây liên lạc với Database)
        private DeTaiBLL _bll = new DeTaiBLL();

        public DeTaiControl()
        {
            InitializeComponent();

            // Nạp dữ liệu vào ComboBox (Do designer không add sẵn items)
            cmbLocLoai.Items.AddRange(new string[] { "Tất cả", "Cấp Trường", "Cấp Bộ" });
            cmbLocLoai.SelectedIndex = 0;

            // Gắn các sự kiện (Event wiring)
            this.Load += DeTaiControl_Load;
            btnThem.Click += (s, e) => ShowDialogDeTai(null);
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTim.Click += (s, e) => LoadData(txtTimKiem.Text);

            cmbLocLoai.SelectedIndexChanged += (s, e) => {
                string loaiDb = "";
                if (cmbLocLoai.SelectedIndex == 1) loaiDb = "CapTruong";
                if (cmbLocLoai.SelectedIndex == 2) loaiDb = "CapBo";
                LoadData("", loaiDb);
            };
        }

        private void DeTaiControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string keyword = "", string loai = "")
        {
            var list = string.IsNullOrEmpty(loai) ? _bll.LayDanhSach() : _bll.LocTheoLoai(loai);
            if (!string.IsNullOrEmpty(keyword)) list = _bll.TimKiem(keyword);

            dgvData.DataSource = list.Select(d => new {
                MaDeTai = d.MaDeTai,
                TenDeTai = d.TenDeTai,
                GiangVien = d.TenGV,
                Nam = d.NamThucHien,
                Loai = d is DeTaiCapBo ? "Cấp Bộ" : "Cấp Trường",
                GioGoc = d.SoGioGoc,
                // [TÍNH ĐA HÌNH] - Hàm này sẽ tự động nội suy tính hệ số 1.0 hoặc 1.5
                GioQuyDoi = d.TinhGioNghienCuu()
            }).ToList();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _bll.XoaDeTai(dgvData.SelectedRows[0].Cells["MaDeTai"].Value.ToString());
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi từ tầng BLL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;

            string ma = dgvData.SelectedRows[0].Cells["MaDeTai"].Value.ToString();
            string ten = dgvData.SelectedRows[0].Cells["TenDeTai"].Value.ToString();
            string tengv = dgvData.SelectedRows[0].Cells["GiangVien"].Value.ToString();
            int nam = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Nam"].Value);
            int gio = Convert.ToInt32(dgvData.SelectedRows[0].Cells["GioGoc"].Value);
            string loai = dgvData.SelectedRows[0].Cells["Loai"].Value.ToString() == "Cấp Bộ" ? "CapBo" : "CapTruong";

            // Khởi tạo đối tượng lớp con để ném vào Form Sửa
            DeTai dt = loai == "CapBo"
                ? new DeTaiCapBo(ma, ten, "GV", tengv, nam, gio)
                : new DeTaiCapTruong(ma, ten, "GV", tengv, nam, gio);

            ShowDialogDeTai(dt);
        }

        // Hộp thoại popup Thêm / Sửa
        private void ShowDialogDeTai(DeTai dt)
        {
            bool isEdit = dt != null;
            using (Form form = new Form() { Text = isEdit ? "Sửa Đề Tài" : "Thêm Đề Tài", Size = new Size(350, 400), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false })
            {
                TextBox txtMa = new TextBox() { Left = 100, Top = 20, Width = 200, Text = isEdit ? dt.MaDeTai : "", Enabled = !isEdit };
                TextBox txtTen = new TextBox() { Left = 100, Top = 60, Width = 200, Text = isEdit ? dt.TenDeTai : "" };
                TextBox txtMaGv = new TextBox() { Left = 100, Top = 100, Width = 200, Text = isEdit ? dt.MaGV : "" };
                TextBox txtTenGv = new TextBox() { Left = 100, Top = 140, Width = 200, Text = isEdit ? dt.TenGV : "" };
                TextBox txtNam = new TextBox() { Left = 100, Top = 180, Width = 200, Text = isEdit ? dt.NamThucHien.ToString() : "" };
                TextBox txtGio = new TextBox() { Left = 100, Top = 220, Width = 200, Text = isEdit ? dt.SoGioGoc.ToString() : "" };

                ComboBox cmbL = new ComboBox() { Left = 100, Top = 260, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Enabled = !isEdit };
                cmbL.Items.AddRange(new string[] { "Cấp Trường", "Cấp Bộ" });
                cmbL.SelectedIndex = isEdit ? (dt is DeTaiCapBo ? 1 : 0) : 0;

                form.Controls.AddRange(new Control[] {
                    new Label() { Text = "Mã ĐT:", Left = 10, Top = 20 }, txtMa,
                    new Label() { Text = "Tên ĐT:", Left = 10, Top = 60 }, txtTen,
                    new Label() { Text = "Mã GV:", Left = 10, Top = 100 }, txtMaGv,
                    new Label() { Text = "Tên GV:", Left = 10, Top = 140 }, txtTenGv,
                    new Label() { Text = "Năm TH:", Left = 10, Top = 180 }, txtNam,
                    new Label() { Text = "Giờ gốc:", Left = 10, Top = 220 }, txtGio,
                    new Label() { Text = "Loại ĐT:", Left = 10, Top = 260 }, cmbL
                });

                Button btnLuu = new Button() { Text = "Lưu lại", Left = 100, Top = 310, Width = 100, BackColor = Color.SeaGreen, ForeColor = Color.White };
                btnLuu.Click += (s, ev) => {
                    try
                    {
                        string loai = cmbL.SelectedIndex == 1 ? "CapBo" : "CapTruong";
                        int nam = int.Parse(txtNam.Text);
                        int gio = int.Parse(txtGio.Text);

                        // Tạo đối tượng dựa theo loại (Tính kế thừa)
                        DeTai t = loai == "CapBo"
                            ? new DeTaiCapBo(txtMa.Text, txtTen.Text, txtMaGv.Text, txtTenGv.Text, nam, gio)
                            : new DeTaiCapTruong(txtMa.Text, txtTen.Text, txtMaGv.Text, txtTenGv.Text, nam, gio);

                        // Đẩy đối tượng xuống BLL để kiểm tra và xử lý
                        if (isEdit) _bll.SuaDeTai(t);
                        else _bll.ThemDeTai(t, loai);

                        form.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi Nhập Liệu/Nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                form.Controls.Add(btnLuu);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}