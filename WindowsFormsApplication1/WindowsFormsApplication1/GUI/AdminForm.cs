using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Object;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.GUI
{
    public partial class AdminForm : Form
    {
        BindingManagerBase bindingManagerAdmin
        {

            get
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
                return BindingContext[dbQLThiTracNghiemDataContext.Admins];
            }
        }

        BindingManagerBase bindingManagerTeacher
        {
            get
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
                return BindingContext[dbQLThiTracNghiemDataContext.Teachers];
            }
        }

        BindingManagerBase bindingManagerStudent
        {
            get
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
                return BindingContext[dbQLThiTracNghiemDataContext.Students];
            }
        }

        BindingManagerBase bindingManagerAccountRequest
        {

            get
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
                return BindingContext[new AccountRequestUser()];
            }
        }

        public AdminForm()
        {
            InitializeComponent();
            this.txtID.Enabled = false;
            Load += LoadFormFirst;
            btnInsert.Enabled = true;
        }

        void LoadFormFirst(object sender, EventArgs e)
        {
            cbUser.SelectedItem = cbUser.Items[0];
            cbUser_SelectedIndexChanged(sender, e);
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string user = cbUser.SelectedItem as string;
            if (user.Equals("Admin"))
            {
                LoadAdmin();
            }
            else if (user.Equals("Teacher"))
            {
                LoadTeacher();
            }
            else if (user.Equals("Student"))
            {
                LoadStudent();
            }
            else if (user.Equals("Disapprove"))
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtName.Text = "";
                txtID.Text = "";
                txtGender.Text = "";
                LoadListDisApprove();
                btnInsert.Enabled = false;
            }
        }

        BindingSource adminBS = new BindingSource();
        BindingSource teacherBS = new BindingSource();
        BindingSource studentBS = new BindingSource();
        BindingSource accountRequestUserBS = new BindingSource();
        void LoadAdmin()
        {
            
            try
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();

                var data = from ad in dbQLThiTracNghiemDataContext.Admins
                           join ac in dbQLThiTracNghiemDataContext.Accounts on ad.idAccount equals ac.idAccount
                           select new { ad.idAdmin, ad.nameAdmin, ad.gender, ac.username, ac.password };

                adminBS.DataSource = data;
                dgvUser.DataSource = adminBS;

                ClearDataBinding();

                txtID.DataBindings.Add("Text", adminBS, "idAdmin");
                txtName.DataBindings.Add("Text", adminBS, "nameAdmin");
                txtGender.DataBindings.Add("Text", adminBS, "gender");
                txtUsername.DataBindings.Add("Text", adminBS, "username");
                txtPassword.DataBindings.Add("Text", adminBS, "password");

                txtClass.Visible = false;
                txtGrade.Visible = false;
                lblClass.Visible = false;
                lblGrade.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "  DataBase invalid. Please check DataBase");
            }
           
        }

        void LoadTeacher()
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            var data = from t in dbQLThiTracNghiemDataContext.Teachers
                       join ac in dbQLThiTracNghiemDataContext.Accounts on t.idAccount equals ac.idAccount
                       select new { t.idTeacher, t.nameTeacher, t.gender, ac.username, ac.password};

            teacherBS.DataSource = data;
            dgvUser.DataSource = teacherBS;

            ClearDataBinding();
            txtID.DataBindings.Add("Text", teacherBS, "idTeacher");
            txtName.DataBindings.Add("Text", teacherBS, "nameTeacher");
            txtGender.DataBindings.Add("Text", teacherBS, "gender");
            txtUsername.DataBindings.Add("Text", teacherBS, "username");
            txtPassword.DataBindings.Add("Text", teacherBS, "password");

            txtClass.Visible = false;
            txtGrade.Visible = false;
            lblClass.Visible = false;
            lblGrade.Visible = false;
        }

        void LoadStudent()
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            var data = from s in dbQLThiTracNghiemDataContext.Students
                       join ac in dbQLThiTracNghiemDataContext.Accounts on s.idAccount equals ac.idAccount
                       select new { s.idStudent, s.nameStudent, s.gender,s.@class, ac.username, ac.password};

            studentBS.DataSource = data;
            dgvUser.DataSource = studentBS;

            ClearDataBinding();
            txtID.DataBindings.Add("Text", studentBS, "idStudent");
            txtName.DataBindings.Add("Text", studentBS, "nameStudent");
            txtGender.DataBindings.Add("Text", studentBS, "gender");
            txtUsername.DataBindings.Add("Text", studentBS, "username");
            txtPassword.DataBindings.Add("Text", studentBS, "password");
            txtClass.DataBindings.Add("Text", studentBS, "class");

            txtClass.Visible = true;
            txtGrade.Visible = true;
            lblClass.Visible = true;
            lblGrade.Visible = true;
        }

        public void LoadListDisApprove()
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            var data = from s in dbQLThiTracNghiemDataContext.Students
                       join ac in dbQLThiTracNghiemDataContext.AccountRequests on s.idStudent equals ac.id
                       where ac.role == 3
                       select new { s.idStudent, s.nameStudent, s.gender, ac.role,ac.username, ac.password};

            var data1 = from t in dbQLThiTracNghiemDataContext.Teachers
                        join ac in dbQLThiTracNghiemDataContext.AccountRequests on t.idTeacher equals ac.id
                        where ac.role == 2
                        select new { t.idTeacher, t.nameTeacher, t.gender, ac.username, ac.password, ac.role};

            List<AccountRequestUser> user = new List<AccountRequestUser>();
            foreach (var item in data)
            {
                AccountRequestUser temp = new AccountRequestUser();
                temp.id = item.idStudent;
                temp.name = item.nameStudent;
                temp.password = item.password;
                temp.username = item.username;
                temp.gender = item.gender;
                temp.role = item.role.ToString();
                user.Add(temp);
            }

            foreach (var item in data1)
            {
                AccountRequestUser temp = new AccountRequestUser();
                temp.id = item.idTeacher;
                temp.name = item.nameTeacher;
                temp.password = item.password;
                temp.username = item.username;
                temp.gender = item.gender;
                temp.role = item.role.ToString();
                user.Add(temp);
            }

            accountRequestUserBS.DataSource = user;
            dgvUser.DataSource = accountRequestUserBS;

            ClearDataBinding();
            txtID.DataBindings.Add("Text", accountRequestUserBS, "id");
            txtName.DataBindings.Add("Text", accountRequestUserBS, "name");
            txtGender.DataBindings.Add("Text", accountRequestUserBS, "gender");
            txtUsername.DataBindings.Add("Text", accountRequestUserBS, "username");
            txtPassword.DataBindings.Add("Text", accountRequestUserBS, "password");

            txtClass.Visible = false;
            txtGrade.Visible = false;
            lblClass.Visible = false;
            lblGrade.Visible = false;

        }

        void ClearDataBinding()
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtGender.DataBindings.Clear();
            txtClass.DataBindings.Clear();
            txtGrade.DataBindings.Clear();
        }
        public delegate void ForwardHandler(Form f);
        public event ForwardHandler forward;
        private void btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            DataBaseForm db = new DataBaseForm(this);
            db.forward += ActionThisForm;
            Button btn = new Button();
            btn.Location = btnDatabaseConfig.Location;
            btn.Text = btnDatabaseConfig.Text;
            btn.Size = btnDatabaseConfig.Size;
            this.tabPageUserManager.Controls.Add(btn);
            this.tabPageUserManager.Controls.Remove(btnDatabaseConfig);
            btn.Click += fireEvent;
            this.Hide();
            db.ShowDialog();
            
        }

        public void fireEvent(object sender, EventArgs e)
        {
            forward(this);
        }

        public void ActionThisForm(Form f)
        {
            f.Hide();
            this.Location = f.Location;
            AdminForm a = new AdminForm();
            a.ShowDialog(); 
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            string username = "";
            string password = "";
            try
            {
               
                username = txtUsername.Text;
                password = MyTool.getHashString(username + txtPassword.Text);

                var q = dbQLThiTracNghiemDataContext.Accounts.Where((i) => (i.username == username && i.password == password)).SingleOrDefault();

                if (q != null)
                {
                    MessageBox.Show("Username and password invalid");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            if (cbUser.Text == "Admin")
            {
                try
                {
                    Admin a = new Admin();
                    a.nameAdmin = txtName.Text;
                    a.gender = txtGender.Text;
                    Account ac = new Account();
                    ac.username = username;
                    ac.password = password;
                    ac.role = 1; // role admin
                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    var q1 = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.password == password && t.username == username)).SingleOrDefault();
                    a.idAccount = q1.idAccount;

                    dbQLThiTracNghiemDataContext.Admins.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    if (MessageBox.Show("insert successfull") == DialogResult.OK)
                    {
                        LoadAdmin();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (cbUser.Text == "Teacher")
            {
                try
                {
                    Teacher a = new Teacher();
                    a.nameTeacher = txtName.Text;
                    a.gender = txtGender.Text;
                    Account ac = new Account();
                    ac.username = username;
                    ac.password = password;
                    ac.role = 2; // role teacher
                    var qtest = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.password == ac.password && t.username == ac.username)).SingleOrDefault();
                    if (qtest != null)
                    {
                        MessageBox.Show("username and pasword invalid");
                        return;
                    }
                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    var q1 = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.password == password && t.username == username)).SingleOrDefault();
                    a.idAccount = q1.idAccount;

                    dbQLThiTracNghiemDataContext.Teachers.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    if (MessageBox.Show("insert successfull") == DialogResult.OK)
                    {
                        LoadTeacher();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            } else if (cbUser.Text == "Student")
            {
                try
                {
                    Student a = new Student();
                    a.nameStudent = txtName.Text;
                    a.gender = txtGender.Text;
                    a.@class = txtClass.Text;
                    Account ac = new Account();
                    ac.username = username;
                    ac.password = MyTool.getHashString(password);
                    ac.role = 2; // role teacher
                    var qtest = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.password == ac.password && t.username == ac.username)).SingleOrDefault();
                    if (qtest != null)
                    {
                        MessageBox.Show("username and pasword invalid");
                        return;
                    }

                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    var q1 = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.password == password && t.username == username)).SingleOrDefault();
                    a.idAccount = q1.idAccount;

                    dbQLThiTracNghiemDataContext.Students.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    if (MessageBox.Show("insert successfull") == DialogResult.OK)
                    {
                        LoadStudent();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();

            if (cbUser.Text == "Admin")
            {
                var q = dbQLThiTracNghiemDataContext.Admins.Where((t) => (t.idAdmin == int.Parse(txtID.Text))).SingleOrDefault();
                var ac = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == q.idAccount)).SingleOrDefault();
                q.nameAdmin = txtName.Text;
                q.gender = txtGender.Text;
                ac.username = txtUsername.Text;
                ac.password = MyTool.getHashString(txtUsername.Text);
                dbQLThiTracNghiemDataContext.SubmitChanges();
                LoadAdmin();
            }
            else if (cbUser.Text == "Teacher")
            {
                var q = dbQLThiTracNghiemDataContext.Teachers.Where((t) => (t.idTeacher == int.Parse(txtID.Text))).SingleOrDefault();
                var ac = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == q.idAccount)).SingleOrDefault();
                q.nameTeacher = txtName.Text;
                q.gender = txtGender.Text;
                ac.username = txtUsername.Text;
                ac.password = MyTool.getHashString(txtUsername.Text);
                dbQLThiTracNghiemDataContext.SubmitChanges();
                LoadTeacher();

            } else if (cbUser.Text == "Student")
            {
                var q = dbQLThiTracNghiemDataContext.Students.Where((t) => (t.idStudent == int.Parse(txtID.Text))).SingleOrDefault();
                var ac = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == q.idAccount)).SingleOrDefault();
                q.nameStudent = txtName.Text;
                q.gender = txtGender.Text;
                q.@class = txtClass.Text;
                ac.username = txtUsername.Text;
                ac.password = MyTool.getHashString(txtUsername.Text);
                dbQLThiTracNghiemDataContext.SubmitChanges();
                LoadStudent();
            } else if (cbUser.Text == "Disapprove")
            {
                DataGridViewRow a = null;
                try
                {
                    a = dgvUser?.SelectedRows[0];
                }
                catch (Exception)
                {

                    MessageBox.Show("please, select a row");
                    return;
                    
                }

                if (a != null)
                {
                    int id = int.Parse(a.Cells["id"].Value.ToString());
                    int role = int.Parse(a.Cells["role"].Value.ToString());
                    var accountrequest = dbQLThiTracNghiemDataContext.AccountRequests.Where((i) => (i.id == id)).SingleOrDefault();
                    if (role == 2)
                    {
                        var teacher = dbQLThiTracNghiemDataContext.Teachers.Where((i) => i.idTeacher == id).SingleOrDefault();
                        Account account = new Account();
                        account.username = accountrequest.username;
                        account.password = MyTool.getHashString(accountrequest.password);
                        account.role = accountrequest.role;
                        try
                        {
                            var temp = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                                    (t.username == account.username && t.password == account.password)).SingleOrDefault();

                            if (temp != null)
                            {
                                MessageBox.Show("username and password invalid");
                                return;
                            }
                            dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(account);
                            dbQLThiTracNghiemDataContext.SubmitChanges();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        var temp1 = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                                    (t.username == account.username && t.password == account.password)).SingleOrDefault();

                        if (temp1 != null)
                        {
                            teacher.idAccount = temp1.idAccount;
                            dbQLThiTracNghiemDataContext.SubmitChanges();
                        }
                    }
                    else if (role == 3)
                    {
                        var teacher = dbQLThiTracNghiemDataContext.Students.Where((i) => i.idStudent == id).SingleOrDefault();
                        Account account = new Account();
                        account.username = accountrequest.username;
                        account.password = MyTool.getHashString(accountrequest.password);
                        account.role = accountrequest.role;
                        try
                        {
                            var temp = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                                    (t.username == account.username && t.password == account.password)).SingleOrDefault();

                            if (temp == null)
                            {
                                MessageBox.Show("username and password invalid");
                                return;
                            }
                            dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(account);
                            dbQLThiTracNghiemDataContext.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        var temp1 = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                                    (t.username == account.username && t.password == account.password)).SingleOrDefault();

                        if (temp1 != null)
                        {
                            teacher.idAccount = temp1.idAccount;
                            dbQLThiTracNghiemDataContext.SubmitChanges();
                        }
                    }
                    dbQLThiTracNghiemDataContext.AccountRequests.DeleteOnSubmit(accountrequest);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    LoadListDisApprove();
                }
            }
            MessageBox.Show("Update successfull");
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            try
            {
                var selectedRow = dgvUser.SelectedRows[0];
                if (cbUser.Text == "Admin")
                {
                    int id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    var admin = dbQLThiTracNghiemDataContext.Admins.Where((t) => (t.idAdmin == id)).SingleOrDefault();
                    int idaccount = int.Parse(admin.idAccount.ToString());
                    var account = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == admin.idAccount)).SingleOrDefault();

                    dbQLThiTracNghiemDataContext.Admins.DeleteOnSubmit(admin);
                    dbQLThiTracNghiemDataContext.Accounts.DeleteOnSubmit(account);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    LoadAdmin();
                }
                else if (cbUser.Text == "Teacher")
                {
                    int id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    var teacher = dbQLThiTracNghiemDataContext.Teachers.Where((t) => (t.idTeacher == id)).SingleOrDefault();
                    int idaccount = int.Parse(teacher.idAccount.ToString());
                    var account = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == teacher.idAccount)).SingleOrDefault();

                    dbQLThiTracNghiemDataContext.Teachers.DeleteOnSubmit(teacher);
                    dbQLThiTracNghiemDataContext.Accounts.DeleteOnSubmit(account);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    LoadTeacher();
                }
                else if (cbUser.Text == "Student")
                {
                    int id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    var student = dbQLThiTracNghiemDataContext.Students.Where((t) => (t.idStudent == id)).SingleOrDefault();
                    int idaccount = int.Parse(student.idAccount.ToString());
                    var account = dbQLThiTracNghiemDataContext.Accounts.Where((t) => (t.idAccount == student.idAccount)).SingleOrDefault();

                    dbQLThiTracNghiemDataContext.Students.DeleteOnSubmit(student);
                    dbQLThiTracNghiemDataContext.Accounts.DeleteOnSubmit(account);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    LoadStudent();
                }
                else
                {
                    int id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    var ac = dbQLThiTracNghiemDataContext.AccountRequests.Where((t) => (t.id == id)).SingleOrDefault();
                    dbQLThiTracNghiemDataContext.AccountRequests.DeleteOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                    LoadListDisApprove();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cbUser.Text != "Disapprove")
            {
                //Tạo đối tượng lưu tệp tin
                SaveFileDialog fsave = new SaveFileDialog();
                //chĩ ra đuôi
                fsave.Filter = "(Tất cả các tệp)|*.*|(Các tệp excel)|*.xlsx";
                fsave.ShowDialog();
                // xử lý
                if (fsave.FileName != "")
                {
                    //tạo excel app
                    Excel.Application app = new Excel.Application();
                    //táo 1 workbook
                    Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                    //tạo sheet
                    Excel._Worksheet sheet = null;
                    try
                    {
                        //đọc dử liệu ra file excel
                        sheet = wb.ActiveSheet;
                        sheet.Name = cbUser.Text;
                        sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgvUser.Columns.Count]].Merge();
                        sheet.Cells[1, 1].Value = "Danh sách " + cbUser.Text;
                        sheet.Cells[1, 1].Font.Size = 20;
                        sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        //sinh tiêu đề
                        for (int i = 0; i < dgvUser.Columns.Count; i++)
                        {
                            sheet.Cells[2, i + 1] = dgvUser.Columns[i].HeaderText;
                            sheet.Cells[2, i + 1].Font.Bold = true;
                            sheet.Cells[2, i + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        }

                        //sinh dữ liệu
                        for (int i = 0; i < dgvUser.Rows.Count; i++)
                        {

                            for (int j = 0; j < dgvUser.Columns.Count; j++)
                            {
                                string a = dgvUser.Rows[i].Cells[j].Value.ToString();

                                sheet.Cells[i + 3, j + 1] = a;

                            }
                        }
                        wb.SaveAs(fsave.FileName);
                        MessageBox.Show("Export thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        app.Quit();
                        wb = null;
                    }


                }
                else
                {
                    MessageBox.Show("Bạn không chọn tập tin nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Disapprove không cho export ra file excel");
            }
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng mở tệp tin
            OpenFileDialog fopen = new OpenFileDialog();
            //chĩ ra đuôi
            fopen.Filter = "(Tất cả các tệp)|*.*|(Các tệp excel)|*.xlsx";
            fopen.ShowDialog();
            // xử lý
            if (fopen.FileName != "")
            {
                string path = fopen.FileName;
                //tạo đối tượng excel
                Excel.Application app = new Excel.Application();
                //Mở tệp excel
                Excel.Workbook wb = app.Workbooks.Open(fopen.FileName);
                try
                {
                    //mở sheet
                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;

                   if (cbUser.Text == "Admin")
                    {
                        importAdmin(range);
                        LoadAdmin();
                    }
                   else if (cbUser.Text == "Teacher")
                    {
                        importTeacher(range);
                        LoadTeacher();
                    }
                   else if (cbUser.Text == "Student")
                    {
                        importStudent(range);
                        LoadStudent();
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            else
            {
                MessageBox.Show("Bạn không chọn tập tin nào", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        
        }

        public void importAdmin(Excel.Range range)
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            // dữ liệu
            for(int i = 3;i<= rows; i++)
            {               
                Admin a = new Admin();
                a.nameAdmin = range.Cells[i, 1].Value.ToString();
                a.gender = range.Cells[i, 2].Value.ToString();
                Account ac = new Account();
                ac.username = range.Cells[i, 3].Value.ToString();
                ac.password = MyTool.getHashString(ac.username + range.Cells[i, 4].Value.ToString());

                var q = dbQLThiTracNghiemDataContext.Accounts.Where((t)
                    => (t.password == ac.password && t.username == ac.username)).SingleOrDefault();
                if (q != null)
                {
                    MessageBox.Show(
                        String.Format("Trong danh sách có 1 account tồn tại : Name {0} - Username {1}", a.nameAdmin, q.username));
                    return;
                } else
                {
                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();

                    var temp = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                        (t.password == ac.password && t.username == ac.username)).SingleOrDefault();

                    a.idAccount = temp.idAccount;

                    dbQLThiTracNghiemDataContext.Admins.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                }               
            }
            MessageBox.Show("Import Admin successfully");
        }
        public void importStudent(Excel.Range range)
        {
            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            // dữ liệu
            for (int i = 3; i <= rows; i++)
            {
                Student a = new Student();
                a.nameStudent = range.Cells[i, 1].Value.ToString();
                a.gender = range.Cells[i, 2].Value.ToString();
                Account ac = new Account();
                ac.username = range.Cells[i, 3].Value.ToString();
                ac.password = MyTool.getHashString(ac.username + range.Cells[i, 4].Value.ToString());
                a.@class = range.Cells[i, 6].Value.ToString();

                var q = dbQLThiTracNghiemDataContext.Accounts.Where((t)
                    => (t.password == ac.password && t.username == ac.username)).SingleOrDefault();
                if (q != null)
                {
                    MessageBox.Show(
                        String.Format("Trong danh sách có 1 account tồn tại : Name {0} - Username {1}", a.nameStudent, q.username));
                    return;
                }
                else
                {
                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();

                    var temp = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                        (t.password == MyTool.getHashString(ac.password) && t.username == ac.username)).SingleOrDefault();

                    a.idAccount = temp.idAccount;

                    dbQLThiTracNghiemDataContext.Students.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                }
            }
            MessageBox.Show("Import Student successfully");
        }
        public void importTeacher(Excel.Range range)
        {

            dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            // dữ liệu
            for (int i = 3; i <= rows; i++)
            {
                Teacher a = new Teacher();
                a.nameTeacher = range.Cells[i, 1].Value.ToString();
                a.gender = range.Cells[i, 2].Value.ToString();
                Account ac = new Account();
                ac.username = range.Cells[i, 3].Value.ToString();
                ac.password = MyTool.getHashString(ac.username + range.Cells[i, 4].Value.ToString());

                var q = dbQLThiTracNghiemDataContext.Accounts.Where((t)
                    => (t.password == ac.password && t.username == ac.username)).SingleOrDefault();
                if (q != null)
                {
                    MessageBox.Show(
                        String.Format("Trong danh sách có 1 account tồn tại : Name {0} - Username {1}", a.nameTeacher, q.username));
                    return;
                }
                else
                {
                    dbQLThiTracNghiemDataContext.Accounts.InsertOnSubmit(ac);
                    dbQLThiTracNghiemDataContext.SubmitChanges();

                    var temp = dbQLThiTracNghiemDataContext.Accounts.Where((t) =>
                        (t.password == ac.password && t.username == ac.username)).SingleOrDefault();

                    a.idAccount = temp.idAccount;

                    dbQLThiTracNghiemDataContext.Teachers.InsertOnSubmit(a);
                    dbQLThiTracNghiemDataContext.SubmitChanges();
                }
            }
            MessageBox.Show("Import Teacher successfully");
        }
    }
}
