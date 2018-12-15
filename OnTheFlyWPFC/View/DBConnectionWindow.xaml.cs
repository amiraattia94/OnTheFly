using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Shapes;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class DBConnectionWindow : Window
    {


        Configuration config;

        public DBConnectionWindow()
        {

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            InitializeComponent();

            fillData();


        }

        private void fillData() {

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["OnTheFlyDBEntities"].ConnectionString);
            var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);
            usernametxt.Text = sqlCnxStringBuilder.UserID.ToString();
            pbPassword.Password = sqlCnxStringBuilder.Password.ToString();

            var ipandpor = sqlCnxStringBuilder.DataSource.Split(',');

            IPAddress.Text = ipandpor[0];
            port.Text = ipandpor[1];


        }

        private string get_message()
         {

             string result = "عفواَ ، لقد نسيت تعبئة الحفول الآتية : \n";

            if (string.IsNullOrWhiteSpace(IPAddress.Text)) {
                result = result + "\t IP address \n";

            }

            if (string.IsNullOrWhiteSpace(port.Text)) {
                result = result + "\t Port \n";

            }

            if (string.IsNullOrWhiteSpace(usernametxt.Text))
             {
                 result = result + "\tاسم المستخدم \n";

             }
             if (string.IsNullOrWhiteSpace(pbPassword.Password))
             {
                 result = result + "\t كلمة المرور \n";

             }

             return result;
             
         }





        private void BtnChangeDB_Click(object sender, RoutedEventArgs e) {

            //DataBaseService.ChangeDatabase(
            //    initialCatalog: "OnTheFlyDB",
            //    userId: usernametxt.Text,
            //    password: pbPassword.Password,
            //    dataSource: IPAddress.Text + " , 1443",
            //    integratedSecuity: true

            //    );

            if (string.IsNullOrWhiteSpace(usernametxt.Text) || string.IsNullOrWhiteSpace(pbPassword.Password) || string.IsNullOrWhiteSpace(IPAddress.Text) || string.IsNullOrWhiteSpace(port.Text)) {

                var error_message = get_message();
                MessageBox.Show(error_message, "خطأ ", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }


            try {
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["OnTheFlyDBEntities"].ConnectionString);
            var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);
            sqlCnxStringBuilder.InitialCatalog = "OnTheFlyDB";
            sqlCnxStringBuilder.UserID = usernametxt.Text;
            sqlCnxStringBuilder.Password = pbPassword.Password;
            sqlCnxStringBuilder.DataSource = IPAddress.Text + " ," + port.Text;
                

            entityCnxStringBuilder.ProviderConnectionString = sqlCnxStringBuilder.ConnectionString;
                





                try {
                    //var TestDB = await userViewModel.GetUserExists("aaa", "aaa");

                    var testConnection = new SqlConnection(sqlCnxStringBuilder.ConnectionString);

                    if(testConnection.State == System.Data.ConnectionState.Closed) {
                        testConnection.Open();

                        config.ConnectionStrings.ConnectionStrings["OnTheFlyDBEntities"].ConnectionString = entityCnxStringBuilder.ConnectionString;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("connectionStrings");
                        ConfigurationManager.RefreshSection("OnTheFlyDBEntities");

                        System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("تم الاتصال بقاعدة البيانات سيتم اعادة تشغيل البرنامج ", "تم الاتصال", System.Windows.Forms.MessageBoxButtons.OK);
                        if (dialog == System.Windows.Forms.DialogResult.OK) {
                            //     Close entire appliction

                            Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                        }

                        fillData();

                    }

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    //System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("عفواَ، هناك خطأ في الإتصال بقاعدة البيانات", "خطأ", System.Windows.Forms.MessageBoxButtons.OK);
                    //if (dialog == System.Windows.Forms.DialogResult.OK) {
                    //    //     Close entire appliction
                    //    System.Windows.Application.Current.Shutdown();
                    //}
                }
            }
            catch (Exception) {

                
            }





        }




        private void btnCloseForm_Click(object sender, RoutedEventArgs e) {
            //System.Windows.Application.Current.Shutdown();
            this.Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


    }
}
