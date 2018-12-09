using System;
using System.Collections.Generic;
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
    public partial class LoginWindow : Window
    {
        UsersViewModel userViewModel;
        LoginViewModel loginViewModel;
        public LoginWindow()
        {
            userViewModel = new UsersViewModel();
            loginViewModel = new LoginViewModel();
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            string username, password, error_message;
            bool user_exist = false ;
            if (string.IsNullOrWhiteSpace(usernametxt.Text) || string.IsNullOrWhiteSpace(pbPassword.Password))
            {
                error_message = get_message();
                MessageBox.Show(error_message, "خطأ ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            password = pbPassword.Password;// passwordtxt.Text;
            username = usernametxt.Text;
            try
            {
                user_exist = await userViewModel.GetUserExists(usernametxt.Text, pbPassword.Password);
                
                if (user_exist == true)
                {
                    
                    initiateSession(userViewModel.editUser, usernametxt.Text);                    
                    var tempW = new POSWindow();
                    tempW.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("عفواً، لقد اخطأت في اسم المستخدم او كلمة المرور ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch(Exception )
            {
                System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("عفواَ، هناك خطأ في الإتصال بقاعدة البيانات", "خطأ", System.Windows.Forms.MessageBoxButtons.OK);
                if (dialog == System.Windows.Forms.DialogResult.OK)
                {
                    //     Close entire appliction
                    System.Windows.Application.Current.Shutdown();
                }
            }
            
           

        }

        private void initiateSession(UserDTO userDTO , string text)
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.GetUserByName(text);
            HelperClass.systemUserID = usersViewModel.editUser.userID;


            UserGroupRoleViewModel userGroupRoleViewModel = new UserGroupRoleViewModel();
            userGroupRoleViewModel.getUserGroupRoleByUserID(usersViewModel.editUser.userID);
            HelperClass.userGroupRoleDTO = userGroupRoleViewModel.EditUserGroupRole;


            loginViewModel.GetLoginUserData(usernametxt.Text, pbPassword.Password);



        }
        
         private string get_message()
         {

             string result = "عفواَ ، لقد نسيت تعبئة الحفول الآتية : \n";
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

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
