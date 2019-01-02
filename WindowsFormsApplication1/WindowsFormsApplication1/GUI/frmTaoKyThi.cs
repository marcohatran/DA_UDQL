using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.GUI;

namespace WindowsFormsApplication1
{
    public partial class frmTaoKyThi : Form
    {
        public int idExam;
        public bool subEdit = false;
        public frmTaoKyThi()
        {
            InitializeComponent();
        }
        void refestGV()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvTests.DataSource = (from test in db.Tests
                                      from te in db.Test_Examinations
                                      where te.idExamination == idExam && te.idTest == test.idTest
                                      select test).Distinct();
            }
        }
        int countStudent(int grade)
        {
            int x;
            using(var db = new dbQLThiTracNghiemDataContext())
            {
                x = (from s in db.Students
                     from c in db.Classes
                     where s.@class == c.className && c.grade == grade
                     select s).Count();
            }
            return x;
        }
        public void setValue(ref Examination t)
        {
            t.idExamination = idExam;
            t.nameExamination = txtNameExam.Text;
            t.grade = (int)nudGrade.Value;
            t.startTime = DateTime.Parse(dtpStartTime.Value.ToShortDateString());
            t.time = (int)nudTime.Value;
            t.countStudent = countStudent((int)t.grade);
            if (rdTrue.Checked)
                t.type = "Thi thật";
            else
                t.type = "Thi thử";
        }
        public Examination getValue()
        {
            var t = new Examination()
            {
                nameExamination = txtNameExam.Text,
                countStudent = countStudent((int)nudGrade.Value),
                time = (int)nudTime.Value,
                grade = (int)nudGrade.Value,
                startTime = DateTime.Parse(dtpStartTime.Value.ToShortDateString()),
                idExamination = idExam
            };
            if (rdTrue.Checked)
                t.type = "Thi thật";
            else
                t.type = "Thi thử";
            return t;
        }
        public void loadValue(Examination t)
        {
            txtNameExam.Text = t.nameExamination;
            dtpStartTime.Value = (DateTime)t.startTime;
            nudGrade.Value = (decimal)t.grade;
            nudTime.Value = (decimal)t.time;
            idExam = t.idExamination;
            refestGV();
        }
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            subEdit = true;
            if (gvTests.SelectedRows.Count < 0)
            {
                MessageBox.Show("Chọn ít nhất 1 đề.");
                subEdit = false;
            }
            else
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvTests.SelectedRows.Count; i++)
                    {
                        Test qs = (Test)gvTests.SelectedRows[i].DataBoundItem;
                        if (qs.grade != nudGrade.Value)
                        {
                            MessageBox.Show("Đề thi không hợp với khối.");
                            subEdit = false;
                            break;
                        }
                    }
                    if (subEdit)
                    {
                        for (int i = 0; i < gvTests.SelectedRows.Count; i++)
                        {
                            var id = (gvTests.SelectedRows[i].DataBoundItem as Test).idTest;
                            Test_Examination te = new Test_Examination()
                            {
                                idExamination = idExam,
                                idTest = id
                            };
                            db.Test_Examinations.Attach(te);
                        }
                        db.SubmitChanges();
                    }
                }
            }
            if (subEdit)
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemDeKyThi frm = new frmThemDeKyThi();
            frm.loadValue(idExam);
            frm.ShowDialog();
            refestGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gvTests.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvTests.SelectedRows.Count; i++)
                    {
                        var id = (gvTests.SelectedRows[i].DataBoundItem as Test).idTest;
                        Test_Examination qs = db.Test_Examinations.Where(r => r.idExamination == idExam && r.idTest == id).Select(r => r).Single();
                        //db.Question_Tests.Attach(qs);
                        db.Test_Examinations.DeleteOnSubmit(qs);
                    }
                    db.SubmitChanges();
                }
                refestGV();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }
    }
}
