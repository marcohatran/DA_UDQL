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
    public partial class frmDSCauHoi : Form
    {
        int idTest;
        public frmDSCauHoi()
        {
            InitializeComponent();
            Load += frmDSCauHoi_Load;
        }
        public void loadValue(int value) { idTest = value; }
        void frmDSCauHoi_Load(object sender, EventArgs e)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvQuestions.DataSource = db.Questions.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gvQuestions.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvQuestions.SelectedRows.Count; i++)
                    {
                        db.Question_Tests.InsertOnSubmit(new Question_Test { idTest = idTest, idQuestion = (gvQuestions.SelectedRows[i].DataBoundItem as Question).idQuestion });
                    }
                    db.SubmitChanges();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để thêm!");
            }
        }
    }
}
