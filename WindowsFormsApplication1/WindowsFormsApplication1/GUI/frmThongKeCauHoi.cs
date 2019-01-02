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
    public partial class frmThongKeCauHoi : Form
    {
        public frmThongKeCauHoi()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            refeshGVQLCauHoi();
        }
        void refeshGVQLCauHoi()
        {
            gvQuestions.Columns.Clear();
            var newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "ID";
            newCol.Width = 30;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "Question";
            newCol.Width = 200;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "True answer";
            newCol.Width = 100;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "Subject";
            newCol.Width = 50;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "grade";
            newCol.Width = 50;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "Hard level";
            newCol.Width = 50;
            gvQuestions.Columns.Add(newCol);

            newCol = new DataGridViewTextBoxColumn();
            newCol.HeaderText = "Used(%)";
            newCol.Width = 50;
            gvQuestions.Columns.Add(newCol);

            //newCol = new DataGridViewTextBoxColumn();
            //newCol.HeaderText = "True(%)";
            //newCol.Width = 50;
            //gvQuestions.Columns.Add(newCol);

            gvQuestions.Rows.Clear();
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                foreach (var item in db.Questions)
                {
                    row = new DataGridViewRow();
                    row.Tag = item;
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.idQuestion;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.question;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.answerTrue;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.subject;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.grade;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = item.hardlevel;
                    row.Cells.Add(cell);

                    cell = new DataGridViewTextBoxCell();
                    cell.Value = db.Question_Tests.Where(q => q.idQuestion == item.idQuestion).Count() * 100 / db.Tests.Count();
                    row.Cells.Add(cell);

                    gvQuestions.Rows.Add(row);
                }
            }
        }
    }
}
