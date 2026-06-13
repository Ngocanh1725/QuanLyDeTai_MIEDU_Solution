namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class DeTaiControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvData;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel(); this.btnTim = new System.Windows.Forms.Button(); this.txtTimKiem = new System.Windows.Forms.TextBox(); this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit(); this.SuspendLayout();

            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke; this.pnlTop.Controls.Add(this.btnTim); this.pnlTop.Controls.Add(this.txtTimKiem); this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.txtTimKiem.Location = new System.Drawing.Point(560, 18); this.txtTimKiem.Size = new System.Drawing.Size(150, 26);
            this.btnTim.BackColor = System.Drawing.Color.DodgerBlue; this.btnTim.ForeColor = System.Drawing.Color.White; this.btnTim.Location = new System.Drawing.Point(720, 15); this.btnTim.Size = new System.Drawing.Size(70, 32); this.btnTim.Text = "Tìm"; this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            this.dgvData.AllowUserToAddRows = false; this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvData.BackgroundColor = System.Drawing.Color.White; this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvData.ReadOnly = true; this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.Controls.Add(this.dgvData); this.Controls.Add(this.pnlTop); this.Size = new System.Drawing.Size(800, 500); this.Load += new System.EventHandler(this.DeTaiControl_Load);
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit(); this.ResumeLayout(false);
        }
    }
}