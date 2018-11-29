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
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsUserAddMiniWindow.xaml
    /// </summary>
    public partial class SettingsUserAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel employeeViewModel;
        UsersViewModel usersViewModel;
        public SettingsUserAddMiniWindow()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            usersViewModel = new UsersViewModel();

        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            usersViewModel = new UsersViewModel();
            var employee = (EmployeeDTO)cmbUserEmployee.SelectedValue;


            if (await usersViewModel.AddUser(txtUserName.Text,txtPassword.Text,employee.employeeID))
            {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void cmbUserEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetAllEmployees();
            cmbUserEmployee.ItemsSource = employeeViewModel.ViewEmployees;
            cmbUserEmployee.DisplayMemberPath = "name";
        }
    }
}
