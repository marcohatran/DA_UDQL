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
    public partial class frmDoiMatKhau : Form
    {
        Account ac;
        public frmDoiMatKhau()
        {
            InitializeComponent();
            txtOldpass.TextChanged += TxtOldpass_TextChanged;
            txtpass2.TextChanged += Txtpass2_TextChanged;
        }

        private void Txtpass2_TextChanged(object sender, EventArgs e)
        {
            if (txtpass.Text != txtpass2.Text) errorProvider1.SetError(txtpass2, "mật khẩu không khớp!");
            else errorProvider1.SetError(txtpass2, "");
        }

        private void TxtOldpass_TextChanged(object sender, EventArgs e)
        {
            if (WindowsFormsApplication1.Object.MyTool.getHashString(ac.username+ txtOldpass.Text) != ac.password) errorProvider1.SetError(txtOldpass, "sai mật khẩu!");
            else errorProvider1.SetError(txtOldpass, "");
        }

        public void LoadID(Student x)
        {
            using(var db = new dbQLThiTracNghiemDataContext())
            {
                ac = db.Accounts.Where(a => a.idAccount == x.idAccount).SingleOrDefault();
            }
            lbAccount.Text += ac.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(txtOldpass).Length == 0 && errorProvider1.GetError(txtpass2).Length == 0 && txtpass2.Text.Length!=0 && txtOldpass.Text.Length!=0)
            {
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    Account x = db.Accounts.Where(a => a.idAccount == ac.idAccount).Select(a=> a).Single();
                    x.password = WindowsFormsApplication1.Object.MyTool.getHashString(ac.username+ txtpass2.Text);
                    db.SubmitChanges();
                    MessageBox.Show("Thay đổi thành công!");
                    Close();
                }
            }
            else MessageBox.Show("Thay đổi thấy bại!");
        }
    }
}
