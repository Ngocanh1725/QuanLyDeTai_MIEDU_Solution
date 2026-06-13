namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar, pnlTop, pnlContent;
        private System.Windows.Forms.Label lblLogo, lblTitle;
        private System.Windows.Forms.Button btnQuanLy, btnLogout;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel(); this.btnLogout = new System.Windows.Forms.Button(); this.btnQuanLy = new System.Windows.Forms.Button(); this.lblLogo = new System.Windows.Forms.Label(); this.pnlTop = new System.Windows.Forms.Panel(); this.lblTitle = new System.Windows.Forms.Label(); this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout(); this.pnlTop.SuspendLayout(); this.SuspendLayout();

            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80))))); this.pnlSidebar.Controls.Add(this.btnQuanLy); this.pnlSidebar.Controls.Add(this.btnLogout); this.pnlSidebar.Controls.Add(this.lblLogo); this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left; this.pnlSidebar.Width = 220;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top; this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold); this.lblLogo.ForeColor = System.Drawing.Color.White; this.lblLogo.Height = 100; this.lblLogo.Text = "MIEDU NCKH"; this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnQuanLy.Dock = System.Windows.Forms.DockStyle.Top; this.btnQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnQuanLy.ForeColor = System.Drawing.Color.White; this.btnQuanLy.Height = 60; this.btnQuanLy.Text = "📚 Quản lý Đề Tài";
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom; this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnLogout.ForeColor = System.Drawing.Color.White; this.btnLogout.Height = 60; this.btnLogout.Text = "🚪 Đăng Xuất"; this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke; this.pnlTop.Controls.Add(this.lblTitle); this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold); this.lblTitle.Text = "BẢNG ĐIỀU KHIỂN"; this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlContent.BackColor = System.Drawing.Color.White;

            this.ClientSize = new System.Drawing.Size(1000, 600); this.Controls.Add(this.pnlContent); this.Controls.Add(this.pnlTop); this.Controls.Add(this.pnlSidebar);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Hệ Thống Quản Lý";
            this.pnlSidebar.ResumeLayout(false); this.pnlTop.ResumeLayout(false); this.ResumeLayout(false);
        }
    }
}
