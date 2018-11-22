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
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username, password, error_message;
            //bool result;
            if (string.IsNullOrWhiteSpace(usernametxt.Text) || string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                error_message = get_message();
                MessageBox.Show(error_message, "خطأ ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            password = passwordtxt.Text;
            username = usernametxt.Text;
            LoginViewModel user = new LoginViewModel();           
            if (user.UserExists == true) 
                {
                    var tempW = new MainWindow();
                    tempW.Show();
                    this.Hide();
                }
            else
            {
                MessageBox.Show("عفواً، لقد اخطأت في اسم المستخدم او كلمة المرور ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

       

        private string get_message()
        {
            string result = "عفواَ ، لقد نسيت تعبئة الحفول الآتية : \n";
            if (string.IsNullOrWhiteSpace(usernametxt.Text))
            {
                result = result + "\tاسم المستخدم \n";

            }
            if (string.IsNullOrWhiteSpace(passwordtxt.Text))
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
