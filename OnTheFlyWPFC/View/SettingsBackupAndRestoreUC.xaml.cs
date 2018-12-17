using OnTheFlyWPFC.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsBackupAndRestoreUC.xaml
    /// </summary>
    public partial class SettingsBackupAndRestoreUC : UserControl
    {
        //SqlConnection con;

        public SettingsBackupAndRestoreUC()
        {
            InitializeComponent();
            btnBackUp.IsEnabled = false;
            btnRestore.IsEnabled = false;

            txtBackupFilePath.Text = @"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\Backup";
            btnBackUp.IsEnabled = true;

            OnTheFlyDBEntities db = new OnTheFlyDBEntities();

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["OnTheFlyDBEntities"].ConnectionString);
            var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

            //con = new SqlConnection(sqlCnxStringBuilder.ConnectionString);


        }

        private void btnGetPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupFilePath.Text = dlg.SelectedPath;

                btnBackUp.IsEnabled = true;
            }
        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            try {
                OnTheFlyDBEntities db = new OnTheFlyDBEntities();
                string dbname = db.Database.Connection.Database;
                //string sqlCommand = @"BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'MyAir-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                string sqlCommand = @"BACKUP DATABASE [{0}] TO DISK = N'{0}_Database_BackUP-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak' WITH NOFORMAT, NOINIT, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                string sqlCommand2 = @"BACKUP DATABASE [{0}] TO DISK='{1}\{0}_Database_BackUP-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";



                db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname));

                MessageBox.Show("تمت العملية بنجاح");

                db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand2, dbname, txtBackupFilePath.Text));

                //string database = con.Database.ToString();

                //string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtBackupFilePath.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                //using (SqlCommand command = new SqlCommand(cmd, con)) {
                //    if (con.State != ConnectionState.Open) {
                //        con.Open();
                //    }
                //    command.ExecuteNonQuery();
                //    con.Close();
                //    MessageBox.Show("database backup done successefully");

                //}

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);


            }

        }

        private void btnGetRestoreFilePath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRestoreFilePath.Text = dlg.FileName;
                btnRestore.IsEnabled = true;
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            try {
                OnTheFlyDBEntities db = new OnTheFlyDBEntities();
                string dbname = db.Database.Connection.Database;

                //RESTORE DATABASE[" + database + "] FROM DISK = '" + textBox2.Text + "'WITH REPLACE; "
                string sqlCommand = @"USE MASTER RESTORE DATABASE [{0}] FROM DISK = '{1}'WITH REPLACE; ";



                db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, txtRestoreFilePath.Text));

                MessageBox.Show("تمت العملية بنجاح");

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);


            }
        }
    }
}
