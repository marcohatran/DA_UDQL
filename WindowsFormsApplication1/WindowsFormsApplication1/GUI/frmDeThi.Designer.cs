namespace WindowsFormsApplication1.GUI
{
    partial class frmDeThi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvQuestions = new System.Windows.Forms.DataGridView();
            this.TaoDeThi = new System.Windows.Forms.Button();
            this.testname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.grade = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvQuestions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách câu hỏi";
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
            this.gvQuestions.Size = new System.Drawing.Size(340, 174);
            this.gvQuestions.TabIndex = 0;
            // 
            // TaoDeThi
            // 
            this.TaoDeThi.Location = new System.Drawing.Point(273, 261);
            this.TaoDeThi.Name = "TaoDeThi";
            this.TaoDeThi.Size = new System.Drawing.Size(60, 23);
            this.TaoDeThi.TabIndex = 1;
            this.TaoDeThi.Text = "Lưu";
            this.TaoDeThi.UseVisualStyleBackColor = true;
            this.TaoDeThi.Click += new System.EventHandler(this.TaoDeThi_Click);
            // 
            // testname
            // 
            this.testname.Location = new System.Drawing.Point(67, 199);
            this.testname.Name = "testname";
            this.testname.Size = new System.Drawing.Size(100, 20);
            this.testname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên đề:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Môn học:";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(67, 233);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(100, 20);
            this.subject.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thời gian:";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(237, 199);
            this.time.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.time.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(96, 20);
            this.time.TabIndex = 7;
            this.time.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thêm câu hỏi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khối lớp:";
            // 
            // grade
            // 
            this.grade.Location = new System.Drawing.Point(237, 232);
            this.grade.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.grade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.grade.Name = "grade";
            this.grade.Size = new System.Drawing.Size(96, 20);
            this.grade.TabIndex = 7;
            this.grade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Xóa câu hỏi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testname);
            this.Controls.Add(this.TaoDeThi);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDeThi";
            this.Text = "Đề thi";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvQuestions;
        private System.Windows.Forms.Button TaoDeThi;
        private System.Windows.Forms.TextBox testname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown grade;
        private System.Windows.Forms.Button button2;
    }
}