namespace QuanLyDeTai_MIEDU.WinForms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubText;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblRightText;
        private System.Windows.Forms.Label lblClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubText = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblRightText = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // Form Cấu hình (Bỏ viền để làm giao diện tràn viền hiện đại)
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // pnlLeft (Màu trắng)
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 450;

            // pnlRight (Màu tím nhạt giống thiết kế Tasky)
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(144, 142, 255);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;

            // lblLogo
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 200);
            this.lblLogo.Location = new System.Drawing.Point(50, 40);
            this.lblLogo.Text = "📝 MIEDU Tasky";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(45, 100);
            this.lblWelcome.Text = "Welcome Back!";

            // lblSubText
            this.lblSubText.AutoSize = true;
            this.lblSubText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubText.ForeColor = System.Drawing.Color.Gray;
            this.lblSubText.Location = new System.Drawing.Point(52, 160);
            this.lblSubText.Text = "Please enter login details below";

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(52, 210);
            this.lblEmail.Text = "Username";

            // txtUser (Giả lập border bằng cách nhét vào 1 panel nếu cần, ở đây dùng Font to)
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtUser.Location = new System.Drawing.Point(55, 240);
            this.txtUser.Size = new System.Drawing.Size(340, 32);

            // lblPass
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPass.Location = new System.Drawing.Point(52, 290);
            this.lblPass.Text = "Password";

            // txtPass
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtPass.Location = new System.Drawing.Point(55, 320);
            this.txtPass.Size = new System.Drawing.Size(340, 32);
            this.txtPass.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(55, 390);
            this.btnLogin.Size = new System.Drawing.Size(340, 50);
            this.btnLogin.Text = "Sign in";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Nút tắt (X) bên phải
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(410, 10);
            this.lblClose.Text = "X";
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Click += (s, e) => { System.Windows.Forms.Application.Exit(); };

            // Text minh hoạ bên phải
            this.lblRightText.AutoSize = false;
            this.lblRightText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.lblRightText.ForeColor = System.Drawing.Color.White;
            this.lblRightText.Location = new System.Drawing.Point(50, 420);
            this.lblRightText.Size = new System.Drawing.Size(350, 100);
            this.lblRightText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRightText.Text = "Manage your tasks in an easy and more efficient way with MIEDU Tasky...";

            // Thêm control vào Panel Trái
            this.pnlLeft.Controls.Add(this.lblLogo);
            this.pnlLeft.Controls.Add(this.lblWelcome);
            this.pnlLeft.Controls.Add(this.lblSubText);
            this.pnlLeft.Controls.Add(this.lblEmail);
            this.pnlLeft.Controls.Add(this.txtUser);
            this.pnlLeft.Controls.Add(this.lblPass);
            this.pnlLeft.Controls.Add(this.txtPass);
            this.pnlLeft.Controls.Add(this.btnLogin);

            // Thêm control vào Panel Phải
            this.pnlRight.Controls.Add(this.lblClose);
            this.pnlRight.Controls.Add(this.lblRightText);

            // Thêm Panel vào Form
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);

            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}