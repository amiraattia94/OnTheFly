using OnTheFlyWPFC.Model.Service;
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

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            usc = new SettingsUsersUC();
            MainUC.Children.Add(usc);
        }
        

            UserControl usc = null;

            private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
            {
                ButtonCloseMenu.Visibility = Visibility.Visible;
                ButtonOpenMenu.Visibility = Visibility.Collapsed;
            }

            private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
            {
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
                ButtonOpenMenu.Visibility = Visibility.Visible;
            }

            private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                usc = null;
                MainUC.Children.Clear();

                switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
                {
                    case "ItemUsers":
                        usc = new SettingsUsersUC();

                        MainUC.Children.Add(usc);
                        break;
                    case "ItemUserRoles":
                        usc = new SettingsUserGroupRoleUC();

                        MainUC.Children.Add(usc);
                        break;
                    

                default:
                        break;
                }
            }

            private void Border_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }

            private void btnCloseForm_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }

            private void btnMaxForm_Click(object sender, RoutedEventArgs e)
            {
                if (WindowState != WindowState.Maximized)
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    WindowState = WindowState.Normal;
                }


            }

            private void btnMinForm_Click(object sender, RoutedEventArgs e)
            {
                WindowState = WindowState.Minimized;
            }


        private void btnPOS_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_POS)
            {
                var newwindow = new POSWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        private void btnBranch_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_branch)
            {
                var newwindow = new BranchWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }


        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_customer)
            {
                var newwindow = new CustomerWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnHR_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_HR)
            {
                var newwindow = new HRWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnCustody_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_custody)
            {
                var newwindow = new CustodyWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnFinance_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_finance)
            {
                var newwindow = new FinanceWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.view_delivery)
            {
                var newwindow = new DeliveryWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
            {
            if (HelperClass.userGroupRoleDTO.admin_rights)
            {
                var newwindow = new SettingsWindow();
                newwindow.WindowState = this.WindowState;
                newwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

            private void btnLogout_Click(object sender, RoutedEventArgs e)
            {
                System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("هل انت متأكد من رغبتك بتسجيل الخروج", "تسجيل الخروج", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {

                    var newwindow = new LoginWindow();

                    newwindow.Show();
                    this.Close();
                }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                {

                }
            }
        }
    }


