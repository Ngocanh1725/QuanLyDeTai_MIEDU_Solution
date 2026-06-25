namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class DeTaiControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cmbLocLoai;
        private System.Windows.Forms.DataGridView dgvData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cmbLocLoai = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnTim);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.cmbLocLoai);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 70;

            // Các nút chức năng
            this.btnThem.Location = new System.Drawing.Point(20, 20); this.btnThem.Size = new System.Drawing.Size(80, 32); this.btnThem.Text = "Thêm"; this.btnThem.BackColor = System.Drawing.Color.SeaGreen; this.btnThem.ForeColor = System.Drawing.Color.White; this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(110, 20); this.btnSua.Size = new System.Drawing.Size(80, 32); this.btnSua.Text = "Sửa"; this.btnSua.BackColor = System.Drawing.Color.Orange; this.btnSua.ForeColor = System.Drawing.Color.White; this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(200, 20); this.btnXoa.Size = new System.Drawing.Size(80, 32); this.btnXoa.Text = "Xóa"; this.btnXoa.BackColor = System.Drawing.Color.Crimson; this.btnXoa.ForeColor = System.Drawing.Color.White; this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Bộ lọc
            this.cmbLocLoai.Location = new System.Drawing.Point(300, 25); this.cmbLocLoai.Size = new System.Drawing.Size(120, 26); this.cmbLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Tìm kiếm
            this.txtTimKiem.Location = new System.Drawing.Point(560, 23); this.txtTimKiem.Size = new System.Drawing.Size(150, 26);
            this.btnTim.Location = new System.Drawing.Point(720, 20); this.btnTim.Size = new System.Drawing.Size(70, 32); this.btnTim.Text = "Tìm"; this.btnTim.BackColor = System.Drawing.Color.DodgerBlue; this.btnTim.ForeColor = System.Drawing.Color.White; this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // dgvData
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // DeTaiControl
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlTop);
            this.Size = new System.Drawing.Size(800, 500);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }
    }
}