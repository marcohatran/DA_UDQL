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
    public partial class frmDeThi : Form
    {
        public int idTest;
        public bool subEdit = false;
        public frmDeThi()
        {
            InitializeComponent();
            refeshGV();
        }
        void refeshGV()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvQuestions.DataSource = from i in db.Question_Tests
                                         from q in db.Questions
                                         where i.idQuestion == q.idQuestion && i.idTest == idTest
                                         select q;
            }
        }
        public void setValue(ref Test t)
        {
            t.nameTest = testname.Text;
            t.subject = subject.Text;
            t.time = (int)time.Value;
            t.grade = (int)grade.Value;
        }
        public Test getValue()
        {
            var t = new Test()
            {
                nameTest=testname.Text,
                subject=subject.Text,
                time=(int)time.Value,
                grade=(int)grade.Value
            };
            return t;
        }
        public void loadValue(Test t)
        {
            testname.Text = t.nameTest;
            subject.Text = t.subject;
            time.Value = (decimal)t.time;
            grade.Value = (decimal)t.grade;
            idTest = t.idTest;
            refeshGV();
        }

        private void TaoDeThi_Click(object sender, EventArgs e)
        {
            subEdit = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDSCauHoi frm = new frmDSCauHoi();
            frm.loadValue(idTest);
            frm.ShowDialog();
            refeshGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (gvQuestions.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvQuestions.SelectedRows.Count; i++)
                    {
                        var id = (gvQuestions.SelectedRows[i].DataBoundItem as Question).idQuestion;
                        Question_Test qs = db.Question_Tests.Where(r => r.idQuestion == id && r.idTest==idTest).Select(r => r).Single();
                        //db.Question_Tests.Attach(qs);
                        db.Question_Tests.DeleteOnSubmit(qs);
                    }
                    db.SubmitChanges();
                }
                refeshGV();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }
    }
}
