namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class ucGiangVien_DeTai
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblChonGV;
        private System.Windows.Forms.ComboBox cmbGiangVien;
        private System.Windows.Forms.Label lblNamCaoNhat;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.Panel pnlChart;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblChonGV = new System.Windows.Forms.Label();
            this.cmbGiangVien = new System.Windows.Forms.ComboBox();
            this.lblNamCaoNhat = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.lblNamCaoNhat);
            this.pnlTop.Controls.Add(this.cmbGiangVien);
            this.pnlTop.Controls.Add(this.lblChonGV);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 70;

            // lblChonGV
            this.lblChonGV.AutoSize = true;
            this.lblChonGV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChonGV.Location = new System.Drawing.Point(20, 25);
            this.lblChonGV.Text = "Chọn Giảng Viên:";

            // cmbGiangVien
            this.cmbGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiangVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbGiangVien.Location = new System.Drawing.Point(160, 22);
            this.cmbGiangVien.Size = new System.Drawing.Size(250, 28);

            // lblNamCaoNhat
            this.lblNamCaoNhat.AutoSize = true;
            this.lblNamCaoNhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNamCaoNhat.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblNamCaoNhat.Location = new System.Drawing.Point(450, 25);
            this.lblNamCaoNhat.Text = "Năm cống hiến cao nhất: -";

            // dgvData (Chiếm 40% màn hình bên trên)
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvData.Height = 250;
            this.dgvData.ReadOnly = true;

            // pnlChart (Chứa biểu đồ bên dưới)
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Controls.Add(this.chartThongKe);

            // chartThongKe (BIỂU ĐỒ)
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Giờ NCKH";
            this.chartThongKe.Series.Add(series1);

            // ucGiangVien_DeTai
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlTop);
            this.Size = new System.Drawing.Size(900, 600);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);
        }
    }
}