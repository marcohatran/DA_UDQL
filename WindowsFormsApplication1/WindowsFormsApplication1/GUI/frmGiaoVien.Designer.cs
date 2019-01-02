namespace WindowsFormsApplication1.GUI
{
    partial class frmGiaoVien
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.XoaCauHoiDongGop = new System.Windows.Forms.Button();
            this.DuyetCauHoi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvContributeQuestions = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportQuestion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ThemFile = new System.Windows.Forms.Button();
            this.SuaCauHoi = new System.Windows.Forms.Button();
            this.ThemCauHoi = new System.Windows.Forms.Button();
            this.XoaCauHoi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvQuestions = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.addTest = new System.Windows.Forms.Button();
            this.delTest = new System.Windows.Forms.Button();
            this.editTest = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvTests = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cbExamType = new System.Windows.Forms.ComboBox();
            this.editExam = new System.Windows.Forms.Button();
            this.delExam = new System.Windows.Forms.Button();
            this.addExam = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gvExams = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbExams = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContributeQuestions)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestions)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExams)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 355);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.XoaCauHoiDongGop);
            this.tabPage1.Controls.Add(this.DuyetCauHoi);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Câu hỏi đóng góp";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // XoaCauHoiDongGop
            // 
            this.XoaCauHoiDongGop.Location = new System.Drawing.Point(402, 298);
            this.XoaCauHoiDongGop.Name = "XoaCauHoiDongGop";
            this.XoaCauHoiDongGop.Size = new System.Drawing.Size(75, 23);
            this.XoaCauHoiDongGop.TabIndex = 1;
            this.XoaCauHoiDongGop.Text = "Xóa";
            this.XoaCauHoiDongGop.UseVisualStyleBackColor = true;
            this.XoaCauHoiDongGop.Click += new System.EventHandler(this.XoaCauHoiDongGop_Click);
            // 
            // DuyetCauHoi
            // 
            this.DuyetCauHoi.Location = new System.Drawing.Point(483, 298);
            this.DuyetCauHoi.Name = "DuyetCauHoi";
            this.DuyetCauHoi.Size = new System.Drawing.Size(75, 23);
            this.DuyetCauHoi.TabIndex = 0;
            this.DuyetCauHoi.Text = "Duyệt";
            this.DuyetCauHoi.UseVisualStyleBackColor = true;
            this.DuyetCauHoi.Click += new System.EventHandler(this.DuyetCauHoi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvContributeQuestions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách câu hỏi";
            // 
            // gvContributeQuestions
            // 
            this.gvContributeQuestions.AllowUserToAddRows = false;
            this.gvContributeQuestions.AllowUserToDeleteRows = false;
            this.gvContributeQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvContributeQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvContributeQuestions.Location = new System.Drawing.Point(3, 16);
            this.gvContributeQuestions.Name = "gvContributeQuestions";
            this.gvContributeQuestions.ReadOnly = true;
            this.gvContributeQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvContributeQuestions.Size = new System.Drawing.Size(554, 270);
            this.gvContributeQuestions.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportQuestion);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.ThemFile);
            this.tabPage2.Controls.Add(this.SuaCauHoi);
            this.tabPage2.Controls.Add(this.ThemCauHoi);
            this.tabPage2.Controls.Add(this.XoaCauHoi);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý câu hỏi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportQuestion
            // 
            this.btnExportQuestion.Location = new System.Drawing.Point(159, 300);
            this.btnExportQuestion.Name = "btnExportQuestion";
            this.btnExportQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnExportQuestion.TabIndex = 6;
            this.btnExportQuestion.Text = "Xuất file";
            this.btnExportQuestion.UseVisualStyleBackColor = true;
            this.btnExportQuestion.Click += new System.EventHandler(this.btnExportQuestion_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thồng kê";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThemFile
            // 
            this.ThemFile.Location = new System.Drawing.Point(240, 300);
            this.ThemFile.Name = "ThemFile";
            this.ThemFile.Size = new System.Drawing.Size(75, 23);
            this.ThemFile.TabIndex = 4;
            this.ThemFile.Text = "Thêm file";
            this.ThemFile.UseVisualStyleBackColor = true;
            this.ThemFile.Click += new System.EventHandler(this.ThemFile_Click);
            // 
            // SuaCauHoi
            // 
            this.SuaCauHoi.Location = new System.Drawing.Point(321, 300);
            this.SuaCauHoi.Name = "SuaCauHoi";
            this.SuaCauHoi.Size = new System.Drawing.Size(75, 23);
            this.SuaCauHoi.TabIndex = 3;
            this.SuaCauHoi.Text = "Sửa";
            this.SuaCauHoi.UseVisualStyleBackColor = true;
            this.SuaCauHoi.Click += new System.EventHandler(this.SuaCauHoi_Click);
            // 
            // ThemCauHoi
            // 
            this.ThemCauHoi.Location = new System.Drawing.Point(483, 300);
            this.ThemCauHoi.Name = "ThemCauHoi";
            this.ThemCauHoi.Size = new System.Drawing.Size(75, 23);
            this.ThemCauHoi.TabIndex = 2;
            this.ThemCauHoi.Text = "Thêm";
            this.ThemCauHoi.UseVisualStyleBackColor = true;
            this.ThemCauHoi.Click += new System.EventHandler(this.ThemCauHoi_Click);
            // 
            // XoaCauHoi
            // 
            this.XoaCauHoi.Location = new System.Drawing.Point(402, 300);
            this.XoaCauHoi.Name = "XoaCauHoi";
            this.XoaCauHoi.Size = new System.Drawing.Size(75, 23);
            this.XoaCauHoi.TabIndex = 1;
            this.XoaCauHoi.Text = "Xóa";
            this.XoaCauHoi.UseVisualStyleBackColor = true;
            this.XoaCauHoi.Click += new System.EventHandler(this.XoaCauHoi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvQuestions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 291);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách câu hỏi";
            // 
            // gvQuestions
            // 
            this.gvQuestions.AllowUserToAddRows = false;
            this.gvQuestions.AllowUserToDeleteRows = false;
            this.gvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvQuestions.Location = new System.Drawing.Point(3, 16);
            this.gvQuestions.Name = "gvQuestions";
            this.gvQuestions.ReadOnly = true;
            this.gvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvQuestions.Size = new System.Drawing.Size(554, 272);
            this.gvQuestions.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.addTest);
            this.tabPage3.Controls.Add(this.delTest);
            this.tabPage3.Controls.Add(this.editTest);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(566, 329);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Quản lý đề thi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // addTest
            // 
            this.addTest.Location = new System.Drawing.Point(483, 298);
            this.addTest.Name = "addTest";
            this.addTest.Size = new System.Drawing.Size(75, 23);
            this.addTest.TabIndex = 3;
            this.addTest.Text = "Thêm";
            this.addTest.UseVisualStyleBackColor = true;
            this.addTest.Click += new System.EventHandler(this.addTest_Click);
            // 
            // delTest
            // 
            this.delTest.Location = new System.Drawing.Point(402, 298);
            this.delTest.Name = "delTest";
            this.delTest.Size = new System.Drawing.Size(75, 23);
            this.delTest.TabIndex = 2;
            this.delTest.Text = "Xóa";
            this.delTest.UseVisualStyleBackColor = true;
            this.delTest.Click += new System.EventHandler(this.delTest_Click);
            // 
            // editTest
            // 
            this.editTest.Location = new System.Drawing.Point(321, 298);
            this.editTest.Name = "editTest";
            this.editTest.Size = new System.Drawing.Size(75, 23);
            this.editTest.TabIndex = 1;
            this.editTest.Text = "Sửa";
            this.editTest.UseVisualStyleBackColor = true;
            this.editTest.Click += new System.EventHandler(this.editTest_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvTests);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 292);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách đề thi";
            // 
            // gvTests
            // 
            this.gvTests.AllowUserToAddRows = false;
            this.gvTests.AllowUserToDeleteRows = false;
            this.gvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTests.Location = new System.Drawing.Point(3, 16);
            this.gvTests.Name = "gvTests";
            this.gvTests.ReadOnly = true;
            this.gvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTests.Size = new System.Drawing.Size(560, 273);
            this.gvTests.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.cbExamType);
            this.tabPage4.Controls.Add(this.editExam);
            this.tabPage4.Controls.Add(this.delExam);
            this.tabPage4.Controls.Add(this.addExam);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(566, 329);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Quản lý kỳ thi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Loại kỳ thi:";
            // 
            // cbExamType
            // 
            this.cbExamType.FormattingEnabled = true;
            this.cbExamType.Items.AddRange(new object[] {
            "Thật",
            "Thử"});
            this.cbExamType.Location = new System.Drawing.Point(72, 10);
            this.cbExamType.Name = "cbExamType";
            this.cbExamType.Size = new System.Drawing.Size(80, 21);
            this.cbExamType.TabIndex = 4;
            // 
            // editExam
            // 
            this.editExam.Location = new System.Drawing.Point(321, 8);
            this.editExam.Name = "editExam";
            this.editExam.Size = new System.Drawing.Size(75, 23);
            this.editExam.TabIndex = 3;
            this.editExam.Text = "Sửa";
            this.editExam.UseVisualStyleBackColor = true;
            this.editExam.Click += new System.EventHandler(this.editExam_Click);
            // 
            // delExam
            // 
            this.delExam.Location = new System.Drawing.Point(402, 8);
            this.delExam.Name = "delExam";
            this.delExam.Size = new System.Drawing.Size(75, 23);
            this.delExam.TabIndex = 2;
            this.delExam.Text = "Xóa";
            this.delExam.UseVisualStyleBackColor = true;
            this.delExam.Click += new System.EventHandler(this.delExam_Click);
            // 
            // addExam
            // 
            this.addExam.Location = new System.Drawing.Point(483, 8);
            this.addExam.Name = "addExam";
            this.addExam.Size = new System.Drawing.Size(75, 23);
            this.addExam.TabIndex = 1;
            this.addExam.Text = "Thêm";
            this.addExam.UseVisualStyleBackColor = true;
            this.addExam.Click += new System.EventHandler(this.addExam_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gvExams);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(566, 292);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách kỳ thi";
            // 
            // gvExams
            // 
            this.gvExams.AllowUserToAddRows = false;
            this.gvExams.AllowUserToDeleteRows = false;
            this.gvExams.AllowUserToResizeRows = false;
            this.gvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvExams.Location = new System.Drawing.Point(3, 16);
            this.gvExams.Name = "gvExams";
            this.gvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExams.Size = new System.Drawing.Size(560, 273);
            this.gvExams.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.cbExams);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(566, 329);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Kết quả học sinh";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kỳ thi:";
            // 
            // cbExams
            // 
            this.cbExams.FormattingEnabled = true;
            this.cbExams.Items.AddRange(new object[] {
            "Xem tất cả"});
            this.cbExams.Location = new System.Drawing.Point(217, 11);
            this.cbExams.Name = "cbExams";
            this.cbExams.Size = new System.Drawing.Size(164, 21);
            this.cbExams.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gvResult);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 37);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(566, 292);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách kết quả học sinh";
            // 
            // gvResult
            // 
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AllowUserToResizeRows = false;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvResult.Location = new System.Drawing.Point(3, 16);
            this.gvResult.Name = "gvResult";
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(560, 273);
            this.gvResult.TabIndex = 0;
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 355);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "frmGiaoVien";
            this.Text = "Giáo viên";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvContributeQuestions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestions)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvExams)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button XoaCauHoiDongGop;
        private System.Windows.Forms.Button DuyetCauHoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvContributeQuestions;
        private System.Windows.Forms.Button ThemFile;
        private System.Windows.Forms.Button SuaCauHoi;
        private System.Windows.Forms.Button ThemCauHoi;
        private System.Windows.Forms.Button XoaCauHoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvQuestions;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button addTest;
        private System.Windows.Forms.Button delTest;
        private System.Windows.Forms.Button editTest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gvTests;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button editExam;
        private System.Windows.Forms.Button delExam;
        private System.Windows.Forms.Button addExam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gvExams;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ComboBox cbExams;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView gvResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbExamType;
        private System.Windows.Forms.Button btnExportQuestion;
    }
}

