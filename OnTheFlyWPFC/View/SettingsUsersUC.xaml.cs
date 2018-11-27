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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsUserGroupUC.xaml
    /// </summary>
    public partial class SettingsUsersUC : UserControl
    {

        UsersViewModel usersViewModel;
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView()
        {
            usersViewModel.GetAllUsers();
            lstViewUsers.ItemsSource = usersViewModel.viewUser;
            lstViewUsers.Items.Refresh();
        }


        public SettingsUsersUC()
        {
            usersViewModel = new UsersViewModel();
            InitializeComponent();
        }

        private void lstViewUsers_Loaded(object sender, RoutedEventArgs e)
        {
            usersViewModel.GetAllUsers();
            lstViewUsers.ItemsSource = usersViewModel.viewUser;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as UserDTO;
            HelperClass.userID = a.userID;

            var newwindow = new  BranchEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.Show();

        }

        private async void DeleteUser(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as UserDTO;
            HelperClass.userID = a.userID;

            if (await usersViewModel.DeleteUserByID(a.userID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();

        }

        private void BtnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            //ViewBranch = await _branchService.GetBranchByName(branchName);
        }

        private void TxtSearchUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            usersViewModel.GetUserByName(txtSearchUserName.Text);
            lstViewUsers.ItemsSource = usersViewModel.viewUser;
            lstViewUsers.Items.Refresh();
            
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new BranchAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }
    }
}
