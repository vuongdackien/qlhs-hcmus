using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;

namespace DatabaseConnectionManagement
{
    public partial class frmAddConnection : Form
    {
        ServerConnection m_ServerConnection;
        Server m_Server;
        EventHandler _Handler;
        DataTable dtServers = new DataTable();
        public frmAddConnection()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            frmAddConnection frm = new frmAddConnection();
            return frm.ShowDialog();
        }

        public Server DatabaseServer
        {
            get { return this.m_Server; }
        }
        private string[] GetInstance()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\");
            }
            catch (Exception)
            {
                rk = Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\Microsoft\Microsoft SQL Server\");
            }
            if (rk == null)
                return null;
            return (String[])rk.GetValue("InstalledInstances");
        }
        void Application_Idle(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            // Application was idle and thats when we do the work.
            // Lets first un-register the event.
            Application.Idle -= this._Handler;

            // Find local instance
            dtServers.Columns.Add(new DataColumn("Name"));
            string[] instances = GetInstance();
            string computername = "localhost";

            DataRow dr;
            foreach (string si in instances)
            {
                if (si != computername)
                {
                    dr = dtServers.NewRow();
                    dr["Name"] = computername + @"\" + si;
                    dtServers.Rows.Add(dr);
                }
            }
            dr = dtServers.NewRow();
            dr["Name"] = computername; // computername
            dtServers.Rows.Add(dr);



            dtServers.PrimaryKey = new DataColumn[] { dtServers.Columns[0] };
            this.cmbServerName.DataSource = dtServers;
            this.cmbServerName.DisplayMember = "Name";
            this.cmbServerName.ValueMember = "Name";

            //Set the default server
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Server))
            {
                this.cmbServerName.SelectedIndex = dtServers.Rows.IndexOf(dtServers.Rows.Find(Properties.Settings.Default.Server.ToString()));
            }
            else
            {
                this.cmbServerName.SelectedIndex = 0;
            }

            //What type of authentication the user wants?  We will have to change the string as required.
            if (Properties.Settings.Default.SQLAuthenticationMode)
            {
                this.rdbServerAuthentication.Checked = true;
                this.rdbWindowsAuthentication.Checked = false;

                if (Properties.Settings.Default.SavePassword == true)
                {
                    this.txtUserName.Text = Properties.Settings.Default.UserName;
                    this.txtPassword.Text = Properties.Settings.Default.Password;
                }
                else
                {
                    this.lblSyncStatus.Visible = false;
                    this.pnlConnectionInfo.Enabled = true;
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                this.rdbServerAuthentication.Checked = false;
                this.rdbWindowsAuthentication.Checked = true;
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
            }

            string tmpDbName = Properties.Settings.Default.DatabaseName;
            if (!string.IsNullOrEmpty(tmpDbName))
            {
                this.btnTestConnection_Click(this, null);
                this.cmbDbName.SelectedItem = Properties.Settings.Default.DatabaseName;
            }
            this.lblSyncStatus.Visible = false;
            this.pnlConnectionInfo.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.lblSyncStatus.Visible = true;
            this.lblSyncStatus.BringToFront();
            this.pnlConnectionInfo.Enabled = false;
            // Lets do the work when we've got some time.
            this._Handler = new EventHandler(this.Application_Idle);
            Application.Idle += this._Handler;
        }

        private bool CheckExistsServer(DataTable tb, DataRow row)
        {
            foreach (DataRow item in tb.Rows)
            {
                if (item["Name"].ToString() == row["Name"].ToString())
                    return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tìm kiếm các máy chủ trong mạng LAN có thể mất nhiều thời gian."
                                + "\nBạn có thể gõ Tên máy chủ hoặc IP của máy chủ trong mạng LAN."
                                + "\nBạn có chắc chắn muốn tìm các máy chủ hoạt động trong mạng LAN?", "Network finding...",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable mdtServers = SmoApplication.EnumAvailableSqlServers(false);
                DataRow dr;
                foreach (DataRow item in mdtServers.Rows)
                {
                    if (!CheckExistsServer(dtServers, item))
                    {
                        dr = dtServers.NewRow();
                        dr["Name"] = item["Name"];
                        dtServers.Rows.Add(dr);
                    }
                }
                this.cmbServerName.DataSource = dtServers;
                this.cmbServerName.DisplayMember = "Name";
                this.cmbServerName.ValueMember = "Name";
                this.Cursor = Cursors.Default;
            }
        }

        private void ListDatabasesInServer(string select_db_name = null)
        {
            this.cmbDbName.Items.Clear();
            int i = 0, selected = 0;
            // Loop through the databases list
            foreach (Database db in this.m_Server.Databases)
            {
                //We don't want to be adding the System databases to our list
                //Check if database is system database
                if (!db.IsSystemObject)
                {
                    if (select_db_name != null && select_db_name == db.Name)
                        selected = i;
                    i++;
                    this.cmbDbName.Items.Add(db.Name); // Add database to combobox
                }
            }
            if (i > 0)
                this.cmbDbName.SelectedIndex = selected;
        }

        private void rdbServerAuthentication_Click(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = true;
            this.txtPassword.Enabled = true;
        }

        private void rdbWindowsAuthentication_Click(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = false;
            this.txtPassword.Enabled = false;
            //this.chkSavePassword.Enabled = false;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // If a server is selected
                if (!string.IsNullOrEmpty(this.cmbServerName.Text))
                {
                    string message = this.ConnectDatabase();
                    if (string.IsNullOrEmpty(message))
                    {
                        //This will populate list of databases on selected server
                        this.ListDatabasesInServer();
                        cmbDbName.Enabled = true;
                        btnTaoMoi.Enabled = true;
                        btnTaoMoiDuLieuMau.Enabled = true;
                        txtNewDB.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(message, "SQL Authetication", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    // A server was not selected, show an error message
                    MessageBox.Show("Bạn hãy chọn hoặc gõ Tên máy chủ để thực hiện!", "Server not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                cmbDbName.Enabled = false;
                btnTaoMoi.Enabled = false;
                txtNewDB.Enabled = false;
                btnTaoMoiDuLieuMau.Enabled = false;
                MessageBox.Show(ex.Message, "SQL Authetication", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private string ConnectDatabase()
        {
            if (!string.IsNullOrEmpty(this.cmbServerName.Text))
            {
                try
                {
                    this.m_ServerConnection = new ServerConnection(this.cmbServerName.Text.ToString());
                    //this.m_ServerConnection
                    //First Check type of Authentication
                    if (this.rdbWindowsAuthentication.Checked)   //Windows Authentication
                    {
                        this.m_ServerConnection.LoginSecure = true;
                        this.m_Server = new Server(this.m_ServerConnection);
                    }
                    else
                    {
                        // Create a new connection to the selected server name
                        this.m_ServerConnection.LoginSecure = false;
                        this.m_ServerConnection.Login = this.txtUserName.Text;       //Login User
                        this.m_ServerConnection.Password = this.txtPassword.Text;    //Login Password
                        // Create a new SQL Server object using the connection we created
                        this.m_Server = new Server(this.m_ServerConnection);
                    }
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "Không có server nào được chọn";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static string BuildConnectString()
        {
            string connect_str = "";
            if (!Properties.Settings.Default.SQLAuthenticationMode)
            {
                connect_str = @"Server=" + Properties.Settings.Default.Server + ";Database=" + Properties.Settings.Default.DatabaseName + ";Trusted_Connection=True;";
            }
            else
            {
                connect_str = @"Server=" + Properties.Settings.Default.Server + ";Database=" + Properties.Settings.Default.DatabaseName + ";Integrated Security=SSPI;User ID=" + Properties.Settings.Default.UserName + ";Password=" + Properties.Settings.Default.Password + ";";
            }
            return connect_str;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = this.cmbServerName.SelectedValue.ToString();
            Properties.Settings.Default.SQLAuthenticationMode = this.rdbServerAuthentication.Checked;
            if (!string.IsNullOrEmpty(this.cmbDbName.Text))
            {
                Properties.Settings.Default.DatabaseName = this.cmbDbName.SelectedItem.ToString();
            }
            else
            {
                Properties.Settings.Default.DatabaseName = string.Empty;
            }

            if (rdbServerAuthentication.Checked)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.SavePassword = true;
            }
            else
            {
                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.SavePassword = false;
            }

            string message = ConnectDatabase();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(this, message, "SQL Authentication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Properties.Settings.Default.DatabaseName == "")
                {
                    MessageBox.Show("Chưa chọn được cơ sở dữ liệu để lưu cấu hình!");
                    return;
                }
                Properties.Settings.Default.ConnectString = frmAddConnection.BuildConnectString();
                Properties.Settings.Default.Save();
                string con = Properties.Settings.Default.ConnectString;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public static bool TestConnect()
        {
            string _strConnect = _strConnect = Properties.Settings.Default.ConnectString;
            if(_strConnect.Equals(""))
                return false;
            SqlConnection m_Connect = null;
            try
            {
                m_Connect = new SqlConnection(_strConnect);
                m_Connect.Open();
                m_Connect.Close();
                return true;
            }
            catch
            {
                if (m_Connect != null)
                    if (m_Connect.State == ConnectionState.Open)
                        m_Connect.Close();
                return false;
            }
        }


        private void cmbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbDbName.Items.Clear();
            cmbDbName.Enabled = false;
            btnTaoMoi.Enabled = false;
            txtNewDB.Enabled = false;
            btnTaoMoiDuLieuMau.Enabled = false;
        }

        private void btnTaoMoiDuLieuMau_Click(object sender, EventArgs e)
        {
            try
            {
                string data_file = Application.StartupPath+@"/scripts/QLHS.sql";
                StreamReader sr = new StreamReader(data_file);
                string data = sr.ReadToEnd();
                string dbname = this.cmbDbName.SelectedItem.ToString();
                data = data.Replace("__DBNAME__", dbname);
                m_Server.Databases[dbname].ExecuteNonQuery(data);
                MessageBox.Show("Đã tạo dữ liệu mẫu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình tạo cơ sở dữ liệu mẫu: " + ex.Message);
            }

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            if (txtNewDB.Text.Equals(""))
            {
                MessageBox.Show("Hãy gõ tên database cần thêm!");
                return;
            }
            string db_name = txtNewDB.Text;
            Database newDB = new Database(m_Server, db_name);

            string msg = "";
            try
            {
                newDB.Create();
                this.ListDatabasesInServer(db_name);
            }
            catch (Exception exc)
            {
                msg = exc.Message;

                if (exc.InnerException != null)
                {
                    msg = exc.InnerException.Message;
                }
            }
            msg = msg.Equals("") ? "Tạo database \"" + db_name + "\" thành công!" : msg;
            MessageBox.Show(msg);
        }


    }
}