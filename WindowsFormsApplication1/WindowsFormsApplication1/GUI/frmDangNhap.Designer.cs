namespace WindowsFormsApplication1.GUI
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbusername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lbpassword = new System.Windows.Forms.Label();
            this.btlogin = new System.Windows.Forms.Button();
            this.llbRegister = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Location = new System.Drawing.Point(11, 22);
            this.lbusername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(64, 15);
            this.lbusername.TabIndex = 0;
            this.lbusername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(80, 22);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(172, 21);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "hs01";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(80, 54);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(172, 21);
            this.txtPass.TabIndex = 1;
            this.txtPass.Text = "123";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.Location = new System.Drawing.Point(11, 57);
            this.lbpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(61, 15);
            this.lbpassword.TabIndex = 0;
            this.lbpassword.Text = "Mật khẩu:";
            // 
            // btlogin
            // 
            this.btlogin.Location = new System.Drawing.Point(173, 91);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(79, 23);
            this.btlogin.TabIndex = 2;
            this.btlogin.Text = "Đăng nhập";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // llbRegister
            // 
            this.llbRegister.ActiveLinkColor = System.Drawing.Color.Red;
            this.llbRegister.AutoSize = true;
            this.llbRegister.Location = new System.Drawing.Point(55, 95);
            this.llbRegister.Name = "llbRegister";
            this.llbRegister.Size = new System.Drawing.Size(112, 15);
            this.llbRegister.TabIndex = 3;
            this.llbRegister.TabStop = true;
            this.llbRegister.Text = "Chưa có tài khoản?";
            this.llbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbRegister_LinkClicked);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 126);
            this.Controls.Add(this.llbRegister);
            this.Controls.Add(this.btlogin);
            this.Controls.Add(this.lbpassword);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsername);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.LinkLabel llbRegister;
    }
}