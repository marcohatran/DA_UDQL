namespace WindowsFormsApplication1.GUI
{
    partial class DataBaseForm
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
            this.gbSQLServerConnect = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.gbDBSelect = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDBSelect = new System.Windows.Forms.ComboBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.gbDBBackup = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.gbDatabaseRestore = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBrowseRestore = new System.Windows.Forms.Button();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.btnAdminForm = new System.Windows.Forms.Button();
            this.gbSQLServerConnect.SuspendLayout();
            this.gbDBSelect.SuspendLayout();
            this.gbDBBackup.SuspendLayout();
            this.gbDatabaseRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSQLServerConnect
            // 
            this.gbSQLServerConnect.Controls.Add(this.txtPassword);
            this.gbSQLServerConnect.Controls.Add(this.label1);
            this.gbSQLServerConnect.Controls.Add(this.btnDisConnect);
            this.gbSQLServerConnect.Controls.Add(this.txtDataSource);
            this.gbSQLServerConnect.Controls.Add(this.txtUserId);
            this.gbSQLServerConnect.Controls.Add(this.btnConnect);
            this.gbSQLServerConnect.Controls.Add(this.lblUserId);
            this.gbSQLServerConnect.Controls.Add(this.lblDataSource);
            this.gbSQLServerConnect.Location = new System.Drawing.Point(29, 41);
            this.gbSQLServerConnect.Name = "gbSQLServerConnect";
            this.gbSQLServerConnect.Size = new System.Drawing.Size(592, 111);
            this.gbSQLServerConnect.TabIndex = 0;
            this.gbSQLServerConnect.TabStop = false;
            this.gbSQLServerConnect.Text = "SQL Server Connection";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(331, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(115, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(485, 69);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisConnect.TabIndex = 5;
            this.btnDisConnect.Text = "Disconnect";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(123, 39);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(323, 20);
            this.txtDataSource.TabIndex = 4;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(123, 70);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(116, 20);
            this.txtUserId.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(485, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(44, 73);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 13);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "User Id";
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(44, 42);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(64, 13);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "DataSource";
            // 
            // gbDBSelect
            // 
            this.gbDBSelect.Controls.Add(this.btnSave);
            this.gbDBSelect.Controls.Add(this.cbDBSelect);
            this.gbDBSelect.Controls.Add(this.lblDataBase);
            this.gbDBSelect.Location = new System.Drawing.Point(29, 171);
            this.gbDBSelect.Name = "gbDBSelect";
            this.gbDBSelect.Size = new System.Drawing.Size(592, 65);
            this.gbDBSelect.TabIndex = 1;
            this.gbDBSelect.TabStop = false;
            this.gbDBSelect.Text = "Database Selection";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(485, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDBSelect
            // 
            this.cbDBSelect.FormattingEnabled = true;
            this.cbDBSelect.Location = new System.Drawing.Point(123, 23);
            this.cbDBSelect.Name = "cbDBSelect";
            this.cbDBSelect.Size = new System.Drawing.Size(323, 21);
            this.cbDBSelect.TabIndex = 2;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Location = new System.Drawing.Point(44, 31);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(54, 13);
            this.lblDataBase.TabIndex = 1;
            this.lblDataBase.Text = "DataBase";
            // 
            // gbDBBackup
            // 
            this.gbDBBackup.Controls.Add(this.btnBackup);
            this.gbDBBackup.Controls.Add(this.txtLocation);
            this.gbDBBackup.Controls.Add(this.btnBrowseBackup);
            this.gbDBBackup.Controls.Add(this.lblLocation);
            this.gbDBBackup.Location = new System.Drawing.Point(29, 254);
            this.gbDBBackup.Name = "gbDBBackup";
            this.gbDBBackup.Size = new System.Drawing.Size(592, 91);
            this.gbDBBackup.TabIndex = 2;
            this.gbDBBackup.TabStop = false;
            this.gbDBBackup.Text = "Database Backup";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(485, 56);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(123, 29);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(323, 20);
            this.txtLocation.TabIndex = 4;
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Location = new System.Drawing.Point(485, 27);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBackup.TabIndex = 2;
            this.btnBrowseBackup.Text = "Browse";
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(34, 32);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";
            // 
            // gbDatabaseRestore
            // 
            this.gbDatabaseRestore.Controls.Add(this.btnRestore);
            this.gbDatabaseRestore.Controls.Add(this.txtBackupPath);
            this.gbDatabaseRestore.Controls.Add(this.btnBrowseRestore);
            this.gbDatabaseRestore.Controls.Add(this.lblBackupPath);
            this.gbDatabaseRestore.Location = new System.Drawing.Point(29, 361);
            this.gbDatabaseRestore.Name = "gbDatabaseRestore";
            this.gbDatabaseRestore.Size = new System.Drawing.Size(592, 91);
            this.gbDatabaseRestore.TabIndex = 6;
            this.gbDatabaseRestore.TabStop = false;
            this.gbDatabaseRestore.Text = "Database Restore";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(485, 56);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(123, 29);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(323, 20);
            this.txtBackupPath.TabIndex = 4;
            // 
            // btnBrowseRestore
            // 
            this.btnBrowseRestore.Location = new System.Drawing.Point(485, 27);
            this.btnBrowseRestore.Name = "btnBrowseRestore";
            this.btnBrowseRestore.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseRestore.TabIndex = 2;
            this.btnBrowseRestore.Text = "Browse";
            this.btnBrowseRestore.UseVisualStyleBackColor = true;
            this.btnBrowseRestore.Click += new System.EventHandler(this.btnBrowseRestore_Click);
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(34, 32);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(69, 13);
            this.lblBackupPath.TabIndex = 0;
            this.lblBackupPath.Text = "Backup Path";
            // 
            // btnAdminForm
            // 
            this.btnAdminForm.Location = new System.Drawing.Point(531, 12);
            this.btnAdminForm.Name = "btnAdminForm";
            this.btnAdminForm.Size = new System.Drawing.Size(101, 23);
            this.btnAdminForm.TabIndex = 7;
            this.btnAdminForm.Text = "AdminForm";
            this.btnAdminForm.UseVisualStyleBackColor = true;
            this.btnAdminForm.Click += new System.EventHandler(this.btnAdminForm_Click);
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 478);
            this.Controls.Add(this.btnAdminForm);
            this.Controls.Add(this.gbDatabaseRestore);
            this.Controls.Add(this.gbDBBackup);
            this.Controls.Add(this.gbDBSelect);
            this.Controls.Add(this.gbSQLServerConnect);
            this.Name = "DataBaseForm";
            this.Text = "DataBaseForm";
            this.Load += new System.EventHandler(this.DataBaseForm_Load);
            this.gbSQLServerConnect.ResumeLayout(false);
            this.gbSQLServerConnect.PerformLayout();
            this.gbDBSelect.ResumeLayout(false);
            this.gbDBSelect.PerformLayout();
            this.gbDBBackup.ResumeLayout(false);
            this.gbDBBackup.PerformLayout();
            this.gbDatabaseRestore.ResumeLayout(false);
            this.gbDatabaseRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSQLServerConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.GroupBox gbDBSelect;
        private System.Windows.Forms.ComboBox cbDBSelect;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.GroupBox gbDBBackup;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.GroupBox gbDatabaseRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBrowseRestore;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdminForm;
    }
}