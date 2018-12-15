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

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsBackupAndRestoreUC.xaml
    /// </summary>
    public partial class SettingsBackupAndRestoreUC : UserControl
    {
        public SettingsBackupAndRestoreUC()
        {
            InitializeComponent();
            btnBackUp.IsEnabled = false;
            btnRestore.IsEnabled = false;
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
            OnTheFlyDBEntities db = new OnTheFlyDBEntities();
            string dbname = db.Database.Connection.Database;
            string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'MyAir-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, "Amin9999999999999.bak"));
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

        }
    }
}
