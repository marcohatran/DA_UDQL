using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.GUI
{
    public partial class frmThemDeKyThi : Form
    {
        int idKT;
        public frmThemDeKyThi()
        {
            InitializeComponent();
            refeshExam();
        }
        void refeshExam()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvTests.DataSource = from i in db.Tests
                                     select i;
            }
        }
        public void loadValue(int value) { idKT = value; }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvTests.SelectedRows.Count > 0)
                {
                    using (var db = new dbQLThiTracNghiemDataContext())
                    {
                        for (int i = 0; i < gvTests.SelectedRows.Count; i++)
                        {
                            db.Test_Examinations.InsertOnSubmit(new Test_Examination { idExamination = idKT, idTest = (gvTests.SelectedRows[i].DataBoundItem as Test).idTest });
                        }
                        db.SubmitChanges();
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Chọn ít nhất 1 dòng để thêm!");
                }
            }catch(Exception)
            {
                MessageBox.Show("Đề thii đã tồn tại");
            }
            
        }
    }
}
