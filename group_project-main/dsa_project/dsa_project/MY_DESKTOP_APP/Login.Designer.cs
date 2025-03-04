namespace MY_DESKTOP_APP
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtusername = new Guna.UI2.WinForms.Guna2TextBox();
            txtpassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnclose = new PictureBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnclose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(207, 16);
            label1.Name = "label1";
            label1.Size = new Size(102, 38);
            label1.TabIndex = 2;
            label1.Text = "LOGIN";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.ForeColor = Color.Firebrick;
            label2.Location = new Point(36, 182);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(36, 313);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtusername
            // 
            txtusername.BorderColor = Color.OrangeRed;
            txtusername.BorderRadius = 15;
            txtusername.CustomizableEdges = customizableEdges7;
            txtusername.DefaultText = "";
            txtusername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtusername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtusername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtusername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtusername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtusername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtusername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtusername.Location = new Point(36, 234);
            txtusername.Margin = new Padding(3, 4, 3, 4);
            txtusername.Name = "txtusername";
            txtusername.PasswordChar = '\0';
            txtusername.PlaceholderForeColor = Color.LightCoral;
            txtusername.PlaceholderText = "Enter Username";
            txtusername.SelectedText = "";
            txtusername.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtusername.Size = new Size(420, 47);
            txtusername.TabIndex = 5;
            txtusername.TextChanged += txtusername_TextChanged;
            // 
            // txtpassword
            // 
            txtpassword.BorderColor = Color.OrangeRed;
            txtpassword.BorderRadius = 15;
            txtpassword.CustomizableEdges = customizableEdges9;
            txtpassword.DefaultText = "";
            txtpassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtpassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtpassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtpassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtpassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtpassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtpassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtpassword.Location = new Point(36, 354);
            txtpassword.Margin = new Padding(3, 4, 3, 4);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.PlaceholderForeColor = Color.LightCoral;
            txtpassword.PlaceholderText = "Enter Password";
            txtpassword.SelectedText = "";
            txtpassword.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtpassword.Size = new Size(420, 47);
            txtpassword.TabIndex = 6;
            // 
            // btnclose
            // 
            btnclose.Image = (Image)resources.GetObject("btnclose.Image");
            btnclose.Location = new Point(868, 0);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(27, 23);
            btnclose.SizeMode = PictureBoxSizeMode.Zoom;
            btnclose.TabIndex = 9;
            btnclose.TabStop = false;
            btnclose.Click += btnclose_Click;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 20;
            btnLogin.CustomizableEdges = customizableEdges11;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.Salmon;
            btnLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(115, 439);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLogin.Size = new Size(225, 56);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.FromArgb(192, 0, 0);
            linkLabel1.Location = new Point(153, 522);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(156, 23);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Continue As Guest";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(306, 658);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(txtusername);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtpassword);
            panel1.Location = new Point(366, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 600);
            panel1.TabIndex = 13;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(168, 71);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(172, 107);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(897, 656);
            Controls.Add(pictureBox2);
            Controls.Add(btnclose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)btnclose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtusername;
        private Guna.UI2.WinForms.Guna2TextBox txtpassword;
        private PictureBox btnclose;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox pictureBox3;
    }
}
