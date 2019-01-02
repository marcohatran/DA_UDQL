using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1.GUI
{
    public partial class DataBaseForm : Form
    {
        BindingManagerBase bindingManagerAdmin
        {

            get
            {
                dbQLThiTracNghiemDataContext dbQLThiTracNghiemDataContext = new dbQLThiTracNghiemDataContext();
                return BindingContext[dbQLThiTracNghiemDataContext.Admins];
            }
        }

        BindingSource adminBS = new BindingSource();

        private static string GetConnectStringsWithoutUserNamePassword(string datasource, string database)
        {
            return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", datasource, database);
        }
        private static string GetConnectStringsWithUserNamePassword(string datasource, string database, string username, string password)
        {
            return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;User ID={2};Password={3};", datasource, database, username, password);
        }
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        string sql = "";
        string connectionString = "";


        public delegate void ForwardHandler(Form f);
        public event ForwardHandler forward;
        public DataBaseForm(AdminForm f)
        {
            Location = f.Location;
            InitializeComponent();
            Load += Form_Load;
            FormClosed += DataBaseForm_FormClosed;
            f.forward += ActionThisForm;
        }

        public void ActionThisForm(Form f)
        {
            this.Location = f.Location;
            f.Hide();
            this.Show();
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            btnDisConnect.Enabled = false;
            btnRestore.Enabled = false;
            btnSave.Enabled = false;
            btnBrowseRestore.Enabled = false;
            btnBrowseBackup.Enabled = false;
            btnBackup.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text.CompareTo("") != 0 && txtPassword.Text != null
                    && txtUserId.Text.CompareTo("") != 0 && txtUserId.Text != null)
                {
                    connectionString = "Data Source = " +
                        txtDataSource.Text + "; User Id=" + txtUserId.Text + "; Password=" + txtPassword.Text;
                } else
                {
                    connectionString = "Data Source="+txtDataSource.Text+";Integrated Security=True";
                }

                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "select * from sys.databases d where d.database_id > 4";
                command = new SqlCommand(sql, conn);
                dataReader = command.ExecuteReader();
                cbDBSelect.Items.Clear();
                while (dataReader.Read())
                {
                    cbDBSelect.Items.Add(dataReader[0].ToString());
                }
                txtDataSource.Enabled = false;
                txtPassword.Enabled = false;
                btnConnect.Enabled = false;
                txtUserId.Enabled = false;

                cbDBSelect.Enabled = true;
                btnBrowseRestore.Enabled = true;
                btnBrowseBackup.Enabled = true;
                btnBackup.Enabled = true;
                btnRestore.Enabled = true;
                btnSave.Enabled = true;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
          
            cbDBSelect.Items.Clear();
            txtDataSource.Enabled = true;
            txtUserId.Enabled = true;
            txtPassword.Enabled = true;
            cbDBSelect.Enabled = false;
            btnConnect.Enabled = true;
            btnRestore.Enabled = false;
            btnBackup.Enabled = false;
            btnBrowseBackup.Enabled = false;
            btnBrowseRestore.Enabled = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDBSelect.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please select database");
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "backup database " + cbDBSelect.Text + " to disk ='" +
                    txtLocation.Text + "\\" + cbDBSelect.Text + "-" + DateTime.Now.Ticks.ToString()+".bak'";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Database Backup Completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Backup failed, you should the path D:\");

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }   
        }

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.SelectedPath;
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = dlg.FileName;
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDBSelect.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Please, select a database");
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "Alter database " + cbDBSelect.Text + " set single_user with rollback immediate;";
                sql += "Restore Database " + cbDBSelect.Text + " from disk = '"+txtBackupPath.Text+"' with replace;";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                
                MessageBox.Show("Successfully restore database");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.CompareTo("") != 0 && txtPassword.Text != null
                   && txtUserId.Text.CompareTo("") != 0 && txtUserId.Text != null)
            {
                connectionString = GetConnectStringsWithUserNamePassword(txtDataSource.Text,cbDBSelect.Text,txtUserId.Text, txtPassword.Text);
            }
            else
            {
                connectionString = GetConnectStringsWithoutUserNamePassword(txtDataSource.Text, cbDBSelect.Text);
            }
          
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string oldConnectString = config.ConnectionStrings.ConnectionStrings["Admin.Properties.Settings.TestManagementConnectionString"].ConnectionString;
            try
            {
               
                config.ConnectionStrings.ConnectionStrings["Admin.Properties.Settings.TestManagementConnectionString"].ConnectionString = connectionString;
                

                if (MessageBox.Show("Set up database successfully.Please restart application", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    == DialogResult.OK)
                {
                    config.Save(ConfigurationSaveMode.Full);
                    Application.Restart();
                }
                
            }
            catch (Exception ex)
            {
                config.ConnectionStrings.ConnectionStrings["Admin.Properties.Settings.TestManagementConnectionString"].ConnectionString = oldConnectString;
                config.Save(ConfigurationSaveMode.Full);
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAdminForm_Click(object sender, EventArgs e)
        {
            forward(this);
        }

        private void DataBaseForm_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataBaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
