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
    public partial class frmDangNhap : Form
    {
        int id, role;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public void nextForm()
        {
            switch (role)
            {
                case 1:
                    AdminForm adminform = new AdminForm();
                    adminform.ShowDialog();
                    break;
                case 2:
                    frmGiaoVien frmGV = new frmGiaoVien();
                    frmGV.LoadID(id);
                    frmGV.StartPosition = FormStartPosition.CenterScreen;
                    frmGV.ShowDialog();
                    break;
                case 3:
                    frmSinhVien frmSV = new frmSinhVien();
                    frmSV.LoadID(id);
                    frmSV.StartPosition = FormStartPosition.CenterScreen;
                    frmSV.ShowDialog();
                    break;
            }
        }

        private void llbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy frmDK = new frmDangKy();
            frmDK.StartPosition = FormStartPosition.CenterParent;
            frmDK.ShowDialog();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var r = db.Accounts.Where(a => a.username == txtUsername.Text && a.password == Object.MyTool.getHashString(txtUsername.Text+txtPass.Text)).Select(a => a).SingleOrDefault();
                if (r != null)
                {
                    id = r.idAccount;
                    role = (int)r.role;
                    Close();
                }
                else MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
        
    }
}
