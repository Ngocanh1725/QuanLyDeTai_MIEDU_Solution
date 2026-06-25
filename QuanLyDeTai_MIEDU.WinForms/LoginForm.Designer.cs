namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label lblTitle, lblUser, lblPass;
        public System.Windows.Forms.TextBox txtUser, txtPass;
        public System.Windows.Forms.Button btnLogin, btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 50);
            this.lblTitle.Text = "ĐĂNG NHẬP MIEDU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUser & txtUser
            this.lblUser.Location = new System.Drawing.Point(50, 90);
            this.lblUser.Text = "Tài Khoản:";
            this.txtUser.Location = new System.Drawing.Point(150, 85);
            this.txtUser.Size = new System.Drawing.Size(180, 26);

            // lblPass & txtPass
            this.lblPass.Location = new System.Drawing.Point(50, 130);
            this.lblPass.Text = "Mật khẩu:";
            this.txtPass.Location = new System.Drawing.Point(150, 125);
            this.txtPass.Size = new System.Drawing.Size(180, 26);
            this.txtPass.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(120, 180);
            this.btnLogin.Size = new System.Drawing.Size(150, 40);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitle);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}