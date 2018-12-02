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
    /// Interaction logic for SettingsUsersAddUserGroupsMiniWindow.xaml
    /// </summary>
    public partial class SettingsUsersAddUserGroupsMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel employeeViewModel;
        UsersViewModel usersViewModel;
        UserGroupRoleViewModel userGroupRoleViewModel;
        UserGroupsViewModel userGroupsViewModel;
        public SettingsUsersAddUserGroupsMiniWindow()
        {
            InitializeComponent();
            userGroupsViewModel = new UserGroupsViewModel();
            userGroupRoleViewModel = new UserGroupRoleViewModel();
            employeeViewModel = new EmployeeViewModel();
            usersViewModel = new UsersViewModel();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void groupList_Loaded(object sender, RoutedEventArgs e)
        {
            userGroupRoleViewModel.GetAllUserGroupRoles();
            groupList.DataContext = userGroupRoleViewModel.ViewUserGroupRole;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
