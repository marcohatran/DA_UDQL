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
    public partial class frmCauHoi : Form
    {
        public bool subEdit = false;
        public frmCauHoi()
        {
            InitializeComponent();
        }
        public Question getValue()
        {
            var q = new Question()
            {
                question = richTextBox1.Text,
                answerA = textBox1.Text,
                answerB = textBox2.Text,
                answerC = textBox3.Text,
                answerD = textBox4.Text,
                answerTrue = textBox5.Text,
                subject=textBox6.Text,
                hardlevel = (int)numericUpDown1.Value,
                grade = (int)numericUpDown2.Value
            };
            return q;
        }
        public void loadvalue(Question q)
        {
            richTextBox1.Text = q.question;
            textBox1.Text = q.answerA;
            textBox2.Text = q.answerB;
            textBox3.Text = q.answerC;
            textBox4.Text = q.answerD;
            textBox5.Text = q.answerTrue;
            textBox6.Text = q.subject;
            numericUpDown1.Value = (decimal)q.hardlevel;
            numericUpDown2.Value = (decimal)q.grade;
        }
        private void LuuCauHoi_Click(object sender, EventArgs e)
        {
            subEdit = true;
            Close();
        }
    }
}
