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
    public partial class frmSinhVien : Form
    {
        Student my;
        public frmSinhVien()
        {
            InitializeComponent();
            Load += FrmSinhVien_Load;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            cbExams.SelectedIndexChanged += CbExams_SelectedIndexChanged;
            cbExams2.SelectedIndexChanged += CbExams2_SelectedIndexChanged;   
        }

        public void LoadID(int id)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                my = db.Students.Where(s => s.idAccount == id).SingleOrDefault();
            }
        }

        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            refrestTab1();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedTab == tabPage2)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    var g = db.Classes.Where(c => c.className == my.@class).SingleOrDefault();
                    var s = (from ex in db.Examinations
                            from re in db.Results
                            where re.idExamination==ex.idExamination &&
                            my.idStudent==re.idStudent
                            select ex);
                    s = s.Distinct();
                    foreach(Examination i in s)
                    {
                        i.nameExamination += " - " + i.startTime.Value.Year.ToString() + " - " + i.type;
                    }
                    cbExams.DataSource = s.ToList();
                    cbExams.DisplayMember = "nameExamination";
                }
                refrestGVKQ();
            }
            if ((sender as TabControl).SelectedTab == tabPage3)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    var g = db.Classes.Where(c => c.className == my.@class).SingleOrDefault();
                    var s = from ex in db.Examinations
                            where ex.grade == g.grade &&
                            ex.startTime>=DateTime.Now
                            select ex;
                    foreach (Examination i in s)
                    {
                        i.nameExamination += " - " + i.startTime.Value.Year.ToString() + " - " + i.type;
                    }
                    cbExams2.DataSource = s.ToList();
                    cbExams2.DisplayMember = "nameExamination";
                }
                refrestGVLT();
            }
            if ((sender as TabControl).SelectedTab == tabPage1)
            {
                refrestTab1();
            }
            if ((sender as TabControl).SelectedTab == tabPage4)
            {
                using(var db = new dbQLThiTracNghiemDataContext())
                {
                    gvFakeExams.DataSource = db.Examinations.Where(ex => ex.type == "thi thử").ToList();
                }
            }
            if ((sender as TabControl).SelectedTab == tabPage5)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    dgvDSCH.DataSource = db.QuestionRequests.Where(q => q.idStudent == my.idStudent).ToList();
                }
            }
        }
        // Xem LT
        private void CbExams2_SelectedIndexChanged(object sender, EventArgs e)
        {
            refrestGVLT();
        }
        void refrestGVLT()
        {
            var exam = cbExams2.SelectedItem as Examination;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var abc = db.Examinations.Where(r =>r.idExamination == exam.idExamination && r.startTime >= DateTime.Now).ToList();
                if(abc!= null) gvExamTime.DataSource = abc;
            }
        }

        // Xem KQ
        void refrestGVKQ()
        {
            var exam = cbExams.SelectedItem as Examination;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var abc = db.Results.Where(r => r.idStudent == my.idStudent && r.idExamination == exam.idExamination).ToList();
                if (abc != null) gvResults.DataSource = abc;
            }
        }
        private void CbExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            refrestGVKQ();
        }

        // Thong Tin Ca Nhan

        void refrestTab1()
        {
            lbmssv.Text = my.idStudent.ToString();
            lbClass.Text = my.@class.ToString();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                lbAccount.Text = db.Accounts.Where(a => a.idAccount == my.idAccount).Select(a => a.username).SingleOrDefault().ToString();
             }
            txtName.Text = my.nameStudent;
            if (my.gender == "nam") rdMale.Checked = true;
            else rdFemale.Checked = true;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "") my.nameStudent = txtName.Text;
            else { MessageBox.Show("Không được để trống họ và tên!"); return; }
            if (rdMale.Checked) my.gender = "nam";
            else my.gender = "nữ";
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var std = db.Students.Where(s => s.idStudent == my.idStudent).SingleOrDefault();
                std.nameStudent = my.nameStudent;
                std.gender = my.gender;
                db.SubmitChanges();
            }
            txtName.Text = my.nameStudent;
            if (my.gender == "nam") rdMale.Checked = true;
            else rdFemale.Checked = true;
            MessageBox.Show("Thay đổi thành công!");
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.LoadID(my);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        // thi
        private void btnStartFakeExam_Click(object sender, EventArgs e)
        {
            if (gvFakeExams.SelectedRows.Count == 1)
            {
                Examination exam = gvFakeExams.SelectedRows[0].DataBoundItem as Examination;
                frmTracNghiem frm = new frmTracNghiem(my.idStudent, exam.idExamination);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else MessageBox.Show("Chọn 1 kì thi thử để bắt đầu thi!");
        }
        private void BtnStartExam_Click(object sender, EventArgs e)
        {
            using(var db = new dbQLThiTracNghiemDataContext())
            {
                var x = db.Results.Where(r => r.idExamination == 2 && r.idStudent == my.idStudent).Count();
                if (x == 1)
                {
                    MessageBox.Show("chưa có kì thi nào để thi!");
                    return;
                }
            }
            frmTracNghiem frm = new frmTracNghiem(my.idStudent, 2);            
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        // gop cau hoi    
        private void btnThemCauHoi_Click_1(object sender, EventArgs e)
        {
            frmDongGopCauHoi f2 = new frmDongGopCauHoi(my.idStudent);
            f2.ShowDialog();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                dgvDSCH.DataSource = db.QuestionRequests.Where(q => q.idStudent == my.idStudent).ToList();
            }
        }
    }
}
