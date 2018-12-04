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
    /// Interaction logic for SettingsUserGroupRoleUC.xaml
    /// </summary>
    public partial class SettingsUserGroupRoleUC : UserControl
    {
        UserGroupRoleViewModel userGroupRoleViewModel;
        UsersViewModel usersViewModel;


        public SettingsUserGroupRoleUC()
        {
            userGroupRoleViewModel = new UserGroupRoleViewModel();
            usersViewModel = new UsersViewModel();
            InitializeComponent();
        }

        

        private void cmbUserName_Selection_changed(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUserName.SelectedIndex != -1)
            {
                var selectedUser = (UserDTO)cmbUserName.SelectedItem;
               
                  //  userGroupRoleViewModel.GetUserByID(selectedUser.userID);
                                  
                /*
                
                
                lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
                lstviewEmployees.Items.Refresh();

                cmbEmployeeCity.SelectedIndex = -1;
                cmbEmployeeState.SelectedIndex = -1;
                TxtSearchEmployeeName.Text = "";*/
            }
        }

        private void cmbUserName_Loaded(object sender, RoutedEventArgs e)
        {
            usersViewModel.GetAllUsers();
            cmbUserName.ItemsSource = usersViewModel.viewUser;
            cmbUserName.DisplayMemberPath = "username";
        }

        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtButtonName.Text == "تعديل")
            {
                enableCheckboxes(true);
                txtButtonName.Text = "حفظ";
            }
            else if (txtButtonName.Text == "حفظ")
            {
                enableCheckboxes(false);
                txtButtonName.Text = "تعديل";
            }
        }
        private void enableCheckboxes(bool enable)
        {
            chkPOSView.IsEnabled = enable;
            chkPOSAdd.IsEnabled = enable;
            chkPOSDelete.IsEnabled = enable;
            chkHRView.IsEnabled = enable;
            chkHRAdd.IsEnabled = enable;
            chkHRDelete.IsEnabled = enable;
            chkBranchView.IsEnabled = enable;
            chkBranchAdd.IsEnabled = enable;
            chkBranchDelete.IsEnabled = enable;
            chkCustodyView.IsEnabled = enable;
            chkCustodyAdd.IsEnabled = enable;
            chkCustodyDelete.IsEnabled = enable;
            chkFinanceView.IsEnabled = enable;
            chkFinanceAdd.IsEnabled = enable;
            chkFinanceDelete.IsEnabled = enable;
            chkDeliveryView.IsEnabled = enable;
            chkDeliveryAdd.IsEnabled = enable;
            chkDeliveryDelete.IsEnabled = enable;
            chkCustomerView.IsEnabled = enable;
            chkCustomerAdd.IsEnabled = enable;
            chkCustomerDelete.IsEnabled = enable;
            chkVendorView.IsEnabled = enable;
            chkVendorAdd.IsEnabled = enable;
            chkVendorDelete.IsEnabled = enable;
            chkServiceView.IsEnabled = enable;
            chkServiceAdd.IsEnabled = enable;
            chkServiceDelete.IsEnabled = enable;

        }

        private void stkUserGroupRoles_Loaded(object sender, RoutedEventArgs e)
        {
            enableCheckboxes(false);
        }
    }
}
