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
    public partial class frmDongGopCauHoi : Form
    {
        int id;
        public frmDongGopCauHoi(int idstudent)
        {
            InitializeComponent();
            id = idstudent;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtAnswerA.Text=="" || txtAnswerB.Text=="" || txtAnswerC.Text == "" || txtAnswerD.Text == "" ||txtQuestion.Text == "" | txtSubject.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin!");
                return;
            }
            // Create a new Order object.
            QuestionRequest quesRe = new QuestionRequest
            {
                idStudent = id,
                subject = txtSubject.Text,
                grade = int.Parse(cbbKhoi_dg.SelectedItem.ToString()),
                question = txtQuestion.Text,
                answerA = txtAnswerA.Text,
                answerB = txtAnswerB.Text,
                answerC = txtAnswerC.Text,
                answerD = txtAnswerD.Text,
                answerTrue = cbbDADung_dg.SelectedItem.ToString(),
                hardlevel = int.Parse(cbbDoKho_dg.SelectedItem.ToString())
            };
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                // Add the new object to the Orders collection.
                db.QuestionRequests.InsertOnSubmit(quesRe);
                // Submit the change to the database.
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    db.SubmitChanges();
                }
            }
            Close();

        }
    }
}
