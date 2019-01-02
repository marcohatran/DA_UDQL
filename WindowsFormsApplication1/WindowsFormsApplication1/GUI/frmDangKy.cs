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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
            txtID.TextChanged += TxtID_TextChanged;
            txtpass2.TextChanged += Txtpass2_TextChanged;
            txtusername.TextChanged += Txtusername_TextChanged;
            txtpass.TextChanged += Txtpass_TextChanged;
            rdstudent.CheckedChanged += Rdstudent_CheckedChanged;
        }

        private void Txtpass_TextChanged(object sender, EventArgs e)
        {
            Txtpass2_TextChanged(sender, e);
        }

        private void Rdstudent_CheckedChanged(object sender, EventArgs e)
        {
            TxtID_TextChanged(sender, e);
            Txtpass2_TextChanged(sender, e);
            Txtusername_TextChanged(sender, e);
        }

        private void Txtusername_TextChanged(object sender, EventArgs e)
        {
            using(var db = new dbQLThiTracNghiemDataContext())
            {
                var q = db.Accounts.Where(s => s.username == txtusername.Text).Select(s => s);
                if (q.Count() == 1) errorProvider1.SetError(txtusername, "tên đăng nhập đã tồn tại");
                else
                {
                    var q1 = db.AccountRequests.Where(s => s.username == txtusername.Text).Select(s => s);
                    if (q1.Count() == 1) errorProvider1.SetError(txtusername, "tên đăng nhập đã đăng ký");
                    else errorProvider1.SetError(txtusername, "");
                }
            }
        }

        private void Txtpass2_TextChanged(object sender, EventArgs e)
        {
            if (txtpass2.Text != txtpass.Text) errorProvider1.SetError(txtpass2, "mật khẩu không khớp");
            else errorProvider1.SetError(txtpass2, "");
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            int x = -1;
            int.TryParse(txtID.Text, out x);
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                if (rdstudent.Checked)
                {
                    var q = db.Students.Where(s => s.idStudent == x).Select(s => s);
                    if (q.Count() != 1) errorProvider1.SetError(txtID, "mã sinh viên không tồn tại");
                    else
                    {
                        if (q.SingleOrDefault().idAccount!=null) errorProvider1.SetError(txtID, "sinh viên đă có tài khoản");
                        else
                        {
                            var q1 = db.AccountRequests.Where(s => s.id == x && s.role==3).Select(s => s);
                            if (q1.Count() == 1) errorProvider1.SetError(txtID, "sinh viên đã đăng ký tài khoản");
                            else errorProvider1.SetError(txtID, "");
                        }
                    }
                }
                else
                {
                    var q = db.Teachers.Where(s => s.idTeacher == x).Select(s => s);
                    if (q.Count() != 1) errorProvider1.SetError(txtID, "mã giáo viên không tồn tại");
                    else
                    {
                        if (q.SingleOrDefault().idAccount != null) errorProvider1.SetError(txtID, "giáo viên đă có tài khoản");
                        else
                        {
                            var q1 = db.AccountRequests.Where(s => s.id == x && s.role==2).Select(s => s);
                            if (q1.Count() == 1) errorProvider1.SetError(txtID, "giáo viên đã đăng ký tài khoản");
                            else errorProvider1.SetError(txtID, "");
                        }
                    }
                }
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            using(var db = new dbQLThiTracNghiemDataContext())
            {
                if (txtID.Text=="" || txtusername.Text == "" || txtpass2.Text=="" || txtpass.Text == "") { MessageBox.Show("Vui lòng điền đầy đủ các thông tin!"); return; }
                if (errorProvider1.GetError(txtID).Length + errorProvider1.GetError(txtusername).Length + errorProvider1.GetError(txtpass2).Length != 0) { MessageBox.Show("Đăng ký thất bại!"); return; }
                try
                {
                    var acc = new AccountRequest()
                    {
                        id = int.Parse(txtID.Text),
                        username = txtusername.Text,
                        password = txtpass2.Text
                    };
                    if (rdstudent.Checked) acc.role = 3;
                    else acc.role = 2;
                    db.AccountRequests.InsertOnSubmit(acc);
                    db.SubmitChanges();
                    MessageBox.Show("Đăng ký thành công, tài khoản đang chờ duyệt!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Đăng ký thất bại!");
                }   
            }
        }
    }
}
