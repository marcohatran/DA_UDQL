using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Object;
using System.Data.Linq;

namespace WindowsFormsApplication1.GUI
{
    public partial class frmGiaoVien : Form
    {
        Teacher curTeacher;
        BindingSource bs;
        //dbQLThiTracNghiemDataContext db;
        public frmGiaoVien()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            //refeshGVCauHoiDongGop();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                bs = new BindingSource { DataSource = db.QuestionRequests.ToList() };
            }
            gvContributeQuestions.DataSource = bs;
            gvQuestions.DataSource = bs;
            gvTests.DataSource = bs;
            //cbExams.DataSource = bs;
            //cbExams.DisplayMember = "nameExamination";
            cbExams.SelectedIndexChanged += CbExams_SelectedIndexChanged;
            cbExamType.SelectedIndexChanged += cbExamType_SelectedIndexChanged;
        }

        public void LoadID(int id)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                curTeacher = db.Teachers.Where(t => t.idAccount == id).Select(t => t).Single();
            }
        }
        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedTab == tabPage1) {
                //refeshGVCauHoiDongGop();
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    bs.DataSource = db.QuestionRequests.ToList();
                }
            }
            if ((sender as TabControl).SelectedTab == tabPage2) { 
                //refeshGVQLCauHoi();
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    bs.DataSource = db.Questions.ToList();
                }
            }
            if ((sender as TabControl).SelectedTab == tabPage3) { 
                //refeshGVDeThi(); 
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    bs.DataSource = db.Tests.ToList();
                }
            }
            if ((sender as TabControl).SelectedTab == tabPage4)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {

                    cbExamType.SelectedIndex = 0;
                    refreshExam();
                }
            }
            if ((sender as TabControl).SelectedTab == tabPage5)
            {
                List<Examination> lst = new List<Examination>();
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    lst = (from ex in db.Examinations
                          from r in db.Results
                          where ex.idExamination == r.idExamination
                          select ex).Distinct().ToList();
                }
                foreach (Examination i in lst)
                {
                    i.nameExamination += " - " + i.startTime.Value.Year.ToString() + " - " + i.type;
                }
                cbExams.DataSource = lst;
                cbExams.DisplayMember = "nameExamination";
                refrestGVKQ();
            }
        }
        /*
        void refeshGVQLCauHoi()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvQuestions.DataSource = db.Questions.ToList();
            }
        }
        void refeshGVCauHoiDongGop()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvContributeQuestions.DataSource = db.QuestionRequests.ToList();
            }
        }
        void refeshGVDeThi()
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvTests.DataSource = db.Tests.ToList();
            }
        }
        */
        //
        //================================Tab Quan Ly Cau Hoi Dong Gop================================
        //

        private void XoaCauHoiDongGop_Click(object sender, EventArgs e)
        {
            if (gvContributeQuestions.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvContributeQuestions.SelectedRows.Count; i++)
                    {
                        QuestionRequest qs = (QuestionRequest)gvContributeQuestions.SelectedRows[i].DataBoundItem;
                        db.QuestionRequests.Attach(qs);
                        db.QuestionRequests.DeleteOnSubmit(qs);
                        bs.Remove(qs);
                    }
                    db.SubmitChanges();
                }
                //refeshGVCauHoiDongGop();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }

        private void DuyetCauHoi_Click(object sender, EventArgs e)
        {
            if (gvContributeQuestions.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvContributeQuestions.SelectedRows.Count; i++)
                    {
                        QuestionRequest qs = (QuestionRequest)gvContributeQuestions.SelectedRows[i].DataBoundItem;
                        var nq = new Question()
                        {
                            question = qs.question,
                            answerA = qs.answerA,
                            answerB = qs.answerB,
                            answerC = qs.answerC,
                            answerD = qs.answerD,
                            answerTrue = qs.answerTrue,
                            hardlevel = qs.hardlevel,
                            subject = qs.subject,
                            grade=qs.grade
                        };
                        if(MyTool.SoCauHoiTrung(nq.question)==0) {
                            db.Questions.InsertOnSubmit(nq);
                        }
                        else
                        {
                            MessageBox.Show("Câu hỏi đã tồn tại!");
                        }
                        db.QuestionRequests.Attach(qs);
                        db.QuestionRequests.DeleteOnSubmit(qs);
                        bs.Remove(qs);
                    }
                    db.SubmitChanges();
                }
                //refeshGVCauHoiDongGop();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để duyệt!");
            }
        }

        //
        //================================Tab Quan Ly Cau Hoi================================
        //
        private void ThemFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.Filter = "Excel file | *.xls;*.xlsx";
            DialogResult r = browser.ShowDialog();
            if (browser.FileName != "")
            {
                myExcel.read(browser.FileName);
                using(var db = new dbQLThiTracNghiemDataContext())
                {
                    bs.DataSource = db.Questions.ToList();
                }
                //refeshGVQLCauHoi();
            }
        }

        private void XoaCauHoi_Click(object sender, EventArgs e)
        {
            if (gvQuestions.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvQuestions.SelectedRows.Count; i++)
                    {
                        Question qs = (Question)gvQuestions.SelectedRows[i].DataBoundItem;
                        db.Questions.Attach(qs);
                        db.Questions.DeleteOnSubmit(qs);
                        bs.Remove(qs);
                    }
                    db.SubmitChanges();
                }
                //refeshGVQLCauHoi();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }

        private void ThemCauHoi_Click(object sender, EventArgs e)
        {
            frmCauHoi frm = new frmCauHoi();
            frm.ShowDialog();
            if (frm.subEdit)
            {
                var q = frm.getValue();
                if (MyTool.SoCauHoiTrung(q.question) == 0)
                {
                    using (var db = new dbQLThiTracNghiemDataContext())
                    {
                        db.Questions.InsertOnSubmit(q);
                        bs.Add(q);
                        db.SubmitChanges();
                    }
                    //refeshGVQLCauHoi();
                }
                else MessageBox.Show("Câu hỏi đã tồn tại!");
            }
        }

        private void SuaCauHoi_Click(object sender, EventArgs e)
        {
            if (gvQuestions.SelectedRows.Count == 1)
            {
                frmCauHoi frm = new frmCauHoi();
                Question oldq = (Question)gvQuestions.SelectedRows[0].DataBoundItem;
                frm.loadvalue(oldq);
                frm.ShowDialog();
                if (frm.subEdit)
                {
                    Question newq = frm.getValue();
                    if (MyTool.SoCauHoiTrung(newq.question) <= 1)
                    {
                        using (var db = new dbQLThiTracNghiemDataContext())
                        {
                            Question question = db.Questions.Where(q => q == oldq).Select(q => q).Single();
                            question.hardlevel = newq.hardlevel;
                            if (newq.question != "") question.question = newq.question;
                            if (newq.answerA != "") question.answerA = newq.answerA;
                            if (newq.answerB != "") question.answerB = newq.answerB;
                            if (newq.answerC != "") question.answerC = newq.answerC;
                            if (newq.answerD != "") question.answerD = newq.answerD;
                            if (newq.answerTrue != "") question.answerTrue = newq.answerTrue;
                            if (newq.subject != "") question.subject = newq.subject;
                            if (newq.grade != 0) question.grade = newq.grade;
                            db.SubmitChanges();
                            int index = bs.IndexOf(oldq);
                            bs.Remove(oldq);
                            bs.Insert(index, question);
                        }
                        //refeshGVQLCauHoi();
                    }
                    else MessageBox.Show("Câu hỏi đã tồn tại!");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 dòng để chỉnh sửa!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmThongKeCauHoi frm = new frmThongKeCauHoi();
            frm.Show();
        }
        private void btnExportQuestion_Click(object sender, EventArgs e)
        {
            List<Question> lst = new List<Question>();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                lst = db.Questions.ToList();
            }
            myExcel.Export(MyTool.ConvertToDataTable(lst));
            MessageBox.Show("Xuất câu hỏi thành công!");
        }

        //
        //================================Tab Quan Ly De Thi================================
        //

        private void delTest_Click(object sender, EventArgs e)
        {
            if (gvTests.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvTests.SelectedRows.Count; i++)
                    {
                        Test qs = (Test)gvTests.SelectedRows[i].DataBoundItem;
                        db.Tests.Attach(qs);
                        db.Tests.DeleteOnSubmit(qs);
                        bs.Remove(qs);
                    }
                    db.SubmitChanges();
                }
                //refeshGVDeThi();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }

        private void addTest_Click(object sender, EventArgs e)
        {
            frmDeThi frm = new frmDeThi();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var t = new Test();
                db.Tests.InsertOnSubmit(t);
                bs.Add(t);
                db.SubmitChanges();
                frm.idTest = t.idTest;
                frm.ShowDialog();
                if (frm.subEdit)
                {
                    frm.setValue(ref t);
                }
                else
                {
                    //db.Tests.Attach(t);
                    db.Tests.DeleteOnSubmit(t);
                    bs.Remove(t);
                }
                db.SubmitChanges();
            }
            //refeshGVDeThi();
        }

        private void editTest_Click(object sender, EventArgs e)
        {
            if (gvTests.SelectedRows.Count == 1)
            {
                frmDeThi frm = new frmDeThi();
                Test oldTest = (Test)gvTests.SelectedRows[0].DataBoundItem;
                frm.loadValue(oldTest);
                frm.ShowDialog();
                if (frm.subEdit)
                {
                    var newTest = frm.getValue();
                    using (var db = new dbQLThiTracNghiemDataContext())
                    {
                        Test t = db.Tests.Where(p => p.idTest == oldTest.idTest).Select(p => p).Single();
                        t.grade = newTest.grade;
                        t.time = newTest.time;
                        if (newTest.nameTest != "") t.nameTest = newTest.nameTest;
                        if (newTest.subject != "") t.subject = newTest.subject;
                        db.SubmitChanges();
                        int index = bs.IndexOf(oldTest);
                        bs.Remove(oldTest);
                        bs.Insert(index, t);
                    }
                    //refeshGVDeThi();
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 dòng để chỉnh sửa!");
            }
        }

        //
        //=============================Tab Ket Qua SV=============================
        //
        void refrestGVKQ()
        {
            Examination ex = cbExams.SelectedItem as Examination;
            if (ex != null)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    gvResult.DataSource = db.Results.Where(r => r.idExamination == ex.idExamination).ToList();
                }
            }
        }
        private void CbExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            refrestGVKQ();
        }

        //
        //=============================Quan Ly ky thi=============================
        //
        void refreshExam() {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvExams.DataSource = db.Examinations.Where(p => p.type.Contains(cbExamType.SelectedItem.ToString()));
            };
        }
        private void addExam_Click(object sender, EventArgs e)
        {
            frmTaoKyThi frm = new frmTaoKyThi();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var t = new Examination();
                db.Examinations.InsertOnSubmit(t);
                //bs.Add(t);
                db.SubmitChanges();
                frm.idExam = t.idExamination;
                frm.ShowDialog();
                if (frm.subEdit)
                {
                    frm.setValue(ref t);
                }
                else
                {
                    //db.Examinations.Attach(t);
                    db.Examinations.DeleteOnSubmit(t);
                    //bs.Remove(t);
                }
                db.SubmitChanges();
            }
            refreshExam();
        }

        private void delExam_Click(object sender, EventArgs e)
        {
            if (gvExams.SelectedRows.Count > 0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    for (int i = 0; i < gvExams.SelectedRows.Count; i++)
                    {
                        Examination qs = (Examination)gvExams.SelectedRows[i].DataBoundItem;
                        db.Examinations.Attach(qs);
                        db.Examinations.DeleteOnSubmit(qs);
                        bs.Remove(qs);
                    }
                    db.SubmitChanges();
                }
                refreshExam();
            }
            else
            {
                MessageBox.Show("Chọn ít nhất 1 dòng để xóa!");
            }
        }

        private void editExam_Click(object sender, EventArgs e)
        {
            if (gvExams.SelectedRows.Count == 1)
            {
                frmTaoKyThi frm = new frmTaoKyThi();
                Examination oldTest = (Examination)gvExams.SelectedRows[0].DataBoundItem;
                frm.loadValue(oldTest);
                frm.ShowDialog();
                if (frm.subEdit)
                {
                    var newTest = frm.getValue();
                    using (var db = new dbQLThiTracNghiemDataContext())
                    {
                        Examination t = db.Examinations.Where(p => p.idExamination == oldTest.idExamination).Select(p => p).Single();
                        t.nameExamination = newTest.nameExamination;
                        t.grade = newTest.grade;
                        t.startTime = newTest.startTime;
                        t.time = newTest.time;
                        t.countStudent = newTest.countStudent;
                        t.type = newTest.type;
                        db.SubmitChanges();
                        //int index = bs.IndexOf(oldTest);
                        //bs.Remove(oldTest);
                        //bs.Insert(index, t);
                        bs.DataSource = db.Examinations.ToList();
                    }
                    refreshExam();
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 dòng để chỉnh sửa!");
            }
        }
        private void cbExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbExamType.Text == "Thật")
            //{
            //    using (var db = new dbQLThiTracNghiemDataContext())
            //    {
            //        gvExams.DataSource = db.Examinations.Where(p => p.type.Contains("thật"));
            //    }
            //}
            //if (cbExamType.Text == "Thử")
            //{
            //    using (var db = new dbQLThiTracNghiemDataContext())
            //    {
            //        gvExams.DataSource = db.Examinations.Where(p => p.type.Contains("thử"));
            //    }
            //}
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                gvExams.DataSource = db.Examinations.Where(p => p.type.Contains(cbExamType.SelectedItem.ToString()));
            };
        }
    }
}
