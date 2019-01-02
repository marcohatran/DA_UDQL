namespace WindowsFormsApplication1.GUI
{
    partial class frmGoiYDapAn
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
            this.dgvGoiY = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiY)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGoiY
            // 
            this.dgvGoiY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoiY.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvGoiY.Location = new System.Drawing.Point(0, 0);
            this.dgvGoiY.Name = "dgvGoiY";
            this.dgvGoiY.Size = new System.Drawing.Size(582, 150);
            this.dgvGoiY.TabIndex = 0;
            // 
            // frmGoiYDapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 261);
            this.Controls.Add(this.dgvGoiY);
            this.Name = "frmGoiYDapAn";
            this.Text = "frmGoiYDapAn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoiY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoiY;
    }
}