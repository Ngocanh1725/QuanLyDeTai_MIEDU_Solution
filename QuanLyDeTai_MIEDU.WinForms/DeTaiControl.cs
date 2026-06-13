using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyDeTai_MIEDU.Models;

namespace QuanLyDeTai_MIEDU.WinForms
{
    public partial class DeTaiControl : UserControl
    {
        IQuanLyDeTai db = new DatabaseHelper();
        ComboBox cmbLocLoai;

        public DeTaiControl()
        {
            InitializeComponent();

            // Khởi tạo các nút động (Đúng theo format repo chuẩn đã gửi)
            Button btnThem = new Button() { Text = "Thêm", Left = 20, Top = 15, Width = 80, Height = 32, BackColor = Color.SeaGreen, ForeColor = Color.White };
            Button btnSua = new Button() { Text = "Sửa", Left = 110, Top = 15, Width = 80, Height = 32, BackColor = Color.Orange, ForeColor = Color.White };
            Button btnXoa = new Button() { Text = "Xóa", Left = 200, Top = 15, Width = 80, Height = 32, BackColor = Color.Crimson, ForeColor = Color.White };

            cmbLocLoai = new ComboBox() { Left = 300, Top = 20, Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbLocLoai.Items.AddRange(new string[] { "Tất cả", "Cấp Trường", "Cấp Bộ" });
            cmbLocLoai.SelectedIndex = 0;

            btnThem.Click += (s, e) => ShowDialog(null);
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            cmbLocLoai.SelectedIndexChanged += (s, e) => LoadData("", cmbLocLoai.SelectedIndex == 0 ? "" : (cmbLocLoai.SelectedItem.ToString() == "Cấp Bộ" ? "CapBo" : "CapTruong"));

            pnlTop.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, cmbLocLoai });
        }

        private void DeTaiControl_Load(object sender, EventArgs e) => LoadData();

        private void LoadData(string keyword = "", string loai = "")
        {
            var list = string.IsNullOrEmpty(loai) ? db.LayDanhSach() : db.LocTheoLoai(loai);
            if (!string.IsNullOrEmpty(keyword)) list = db.TimKiem(keyword);

            dgvData.DataSource = list.Select(d => new {
                MaDeTai = d.MaDeTai,
                TenDeTai = d.TenDeTai,
                GiangVien = d.TenGV,
                Nam = d.NamThucHien,
                Loai = d is DeTaiCapBo ? "Cấp Bộ" : "Cấp Trường",
                GioGoc = d.SoGioGoc,
                GioQuyDoi = d.TinhGioNghienCuu() // ĐA HÌNH Ở ĐÂY
            }).ToList();
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadData(txtTimKiem.Text);

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0 && MessageBox.Show("Xác nhận xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.XoaDeTai(dgvData.SelectedRows[0].Cells["MaDeTai"].Value.ToString()); LoadData();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            string ma = dgvData.SelectedRows[0].Cells["MaDeTai"].Value.ToString();
            string ten = dgvData.SelectedRows[0].Cells["TenDeTai"].Value.ToString();
            string magv = "GV"; string tengv = dgvData.SelectedRows[0].Cells["GiangVien"].Value.ToString();
            int nam = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Nam"].Value);
            int gio = Convert.ToInt32(dgvData.SelectedRows[0].Cells["GioGoc"].Value);
            string loai = dgvData.SelectedRows[0].Cells["Loai"].Value.ToString() == "Cấp Bộ" ? "CapBo" : "CapTruong";

            DeTai dt = loai == "CapBo" ? new DeTaiCapBo(ma, ten, magv, tengv, nam, gio) : new DeTaiCapTruong(ma, ten, magv, tengv, nam, gio);
            ShowDialog(dt);
        }

        private void ShowDialog(DeTai dt)
        {
            // Popup logic giống form add của MISUP
            bool isEdit = dt != null;
            using (Form form = new Form() { Text = isEdit ? "Sửa" : "Thêm", Size = new Size(350, 400), StartPosition = FormStartPosition.CenterParent })
            {
                // Fields
                TextBox txtMa = new TextBox() { Left = 100, Top = 20, Width = 200, Text = isEdit ? dt.MaDeTai : "" };
                TextBox txtTen = new TextBox() { Left = 100, Top = 60, Width = 200, Text = isEdit ? dt.TenDeTai : "" };
                TextBox txtMaGv = new TextBox() { Left = 100, Top = 100, Width = 200, Text = isEdit ? dt.MaGV : "" };
                TextBox txtTenGv = new TextBox() { Left = 100, Top = 140, Width = 200, Text = isEdit ? dt.TenGV : "" };
                TextBox txtNam = new TextBox() { Left = 100, Top = 180, Width = 200, Text = isEdit ? dt.NamThucHien.ToString() : "" };
                TextBox txtGio = new TextBox() { Left = 100, Top = 220, Width = 200, Text = isEdit ? dt.SoGioGoc.ToString() : "" };
                ComboBox cmbL = new ComboBox() { Left = 100, Top = 260, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbL.Items.AddRange(new string[] { "Cấp Trường", "Cấp Bộ" }); cmbL.SelectedIndex = isEdit ? (dt is DeTaiCapBo ? 1 : 0) : 0;

                form.Controls.AddRange(new Control[] {
                    new Label() { Text = "Mã ĐT:", Left = 10, Top = 20 }, txtMa, new Label() { Text = "Tên ĐT:", Left = 10, Top = 60 }, txtTen,
                    new Label() { Text = "Mã GV:", Left = 10, Top = 100 }, txtMaGv, new Label() { Text = "Tên GV:", Left = 10, Top = 140 }, txtTenGv,
                    new Label() { Text = "Năm:", Left = 10, Top = 180 }, txtNam, new Label() { Text = "Giờ gốc:", Left = 10, Top = 220 }, txtGio,
                    new Label() { Text = "Loại:", Left = 10, Top = 260 }, cmbL
                });

                Button btnLuu = new Button() { Text = "Lưu lại", Left = 100, Top = 300 };
                btnLuu.Click += (s, ev) => {
                    string loai = cmbL.SelectedIndex == 1 ? "CapBo" : "CapTruong";
                    DeTai t = loai == "CapBo" ? new DeTaiCapBo(txtMa.Text, txtTen.Text, txtMaGv.Text, txtTenGv.Text, int.Parse(txtNam.Text), int.Parse(txtGio.Text)) : new DeTaiCapTruong(txtMa.Text, txtTen.Text, txtMaGv.Text, txtTenGv.Text, int.Parse(txtNam.Text), int.Parse(txtGio.Text));
                    if (isEdit) db.SuaDeTai(t); else db.ThemDeTai(t, loai);
                    form.DialogResult = DialogResult.OK;
                };
                form.Controls.Add(btnLuu);
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            }
        }
    }
}