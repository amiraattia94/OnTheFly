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
using OnTheFlyWPFC.Model;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsUserEditMiniWindow.xaml
    /// </summary>
    public partial class SettingsUserEditMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel employeeViewModel;
        UsersViewModel usersViewModel;
        public SettingsUserEditMiniWindow()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            usersViewModel = new UsersViewModel();
        }

        private void StkEditUser_Loaded(object sender, RoutedEventArgs e)
        {
            usersViewModel.GetUserByID(HelperClass.userID);
           StkEditUser.DataContext = usersViewModel.editUser;
        }

        private void cmbUserEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetAllEmployees();
            cmbUserEmployee.ItemsSource = employeeViewModel.ViewEmployees;
            cmbUserEmployee.DisplayMemberPath = "name";
            foreach (EmployeeDTO employee in cmbUserEmployee.Items)
            {
                if (employee.employeeID == employeeViewModel.employee.employeeID)
                {
                    cmbUserEmployee.SelectedValue = employee;
                    break;
                }
            }
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            usersViewModel = new UsersViewModel();
            var employee = (EmployeeDTO)cmbUserEmployee.SelectedValue;


            if (await usersViewModel.EditUsrByID(HelperClass.employeeID, txtUserName.Text, txtPassword.Text, employee.employeeID))
            {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }
    }
}
