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
                 userGroupRoleViewModel.getUserGroupRoleByUserID(selectedUser.userID);
                 if (userGroupRoleViewModel.EditUserGroupRole==null)
                {
                    checkCheckBoxes(false);            
                }
                else
                {
                    checkCheckBoxes(userGroupRoleViewModel.EditUserGroupRole);
                }

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

        private async void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            UserGroupRoleDTO userGroupRole = new UserGroupRoleDTO();
            if (txtButtonName.Text == "تعديل")
            {
                enableCheckboxes(true);
                txtButtonName.Text = "حفظ";
            }
            else if (txtButtonName.Text == "حفظ")
            {
                enableCheckboxes(false);
                txtButtonName.Text = "تعديل";
                if (cmbUserName.SelectedIndex != -1)
                {
                    var selectedUser = (UserDTO)cmbUserName.SelectedItem;

                    userGroupRole = assignUserGroupRoleFromCheckBoxes();
                    userGroupRoleViewModel.getUserGroupRoleByUserID(selectedUser.userID);
                    if (userGroupRoleViewModel.EditUserGroupRole == null || userGroupRoleViewModel.EditUserGroupRole.groupID == 0)
                    {
                        await userGroupRoleViewModel.AddUserGroupRoleByUserID(selectedUser.userID, userGroupRole);
                    }
                    else
                    {
                        await userGroupRoleViewModel.EditUserGroupRoleByUserID(selectedUser.userID, userGroupRole);
                    }
                    if (selectedUser.userID == HelperClass.systemUserID)
                    {
                        HelperClass.userGroupRoleDTO = userGroupRole;
                    }

                }
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
            chkViewReports.IsEnabled = enable;
            chkAdminRights.IsEnabled = enable;
        }
        private void checkCheckBoxes( bool check)
        {
            chkPOSView.IsChecked = check;
            chkPOSAdd.IsChecked = check;
            chkPOSDelete.IsChecked = check;
            chkHRView.IsChecked = check;
            chkHRAdd.IsChecked = check;
            chkHRDelete.IsChecked = check;
            chkBranchView.IsChecked = check;
            chkBranchAdd.IsChecked = check;
            chkBranchDelete.IsChecked = check;
            chkCustodyView.IsChecked = check;
            chkCustodyAdd.IsChecked = check;
            chkCustodyDelete.IsChecked = check;
            chkFinanceView.IsChecked = check;
            chkFinanceAdd.IsChecked = check;
            chkFinanceDelete.IsChecked = check;
            chkDeliveryView.IsChecked = check;
            chkDeliveryAdd.IsChecked = check;
            chkDeliveryDelete.IsChecked = check;
            chkCustomerView.IsChecked = check;
            chkCustomerAdd.IsChecked = check;
            chkCustomerDelete.IsChecked = check;
            chkVendorView.IsChecked = check;
            chkVendorAdd.IsChecked = check;
            chkVendorDelete.IsChecked = check;
            chkServiceView.IsChecked = check;
            chkServiceAdd.IsChecked = check;
            chkServiceDelete.IsChecked = check;
            chkViewReports.IsChecked = check;
            chkAdminRights.IsChecked = check;
        }
        private void checkCheckBoxes(UserGroupRoleDTO userGroupRole)
        {
            chkPOSView.IsChecked = userGroupRole.view_POS;
            chkPOSAdd.IsChecked = userGroupRole.add_POS;
            chkPOSDelete.IsChecked = userGroupRole.delete_POS;
            chkHRView.IsChecked = userGroupRole.view_HR;
            chkHRAdd.IsChecked = userGroupRole.add_HR;
            chkHRDelete.IsChecked = userGroupRole.delete_HR;
            chkBranchView.IsChecked = userGroupRole.view_branch;
            chkBranchAdd.IsChecked = userGroupRole.add_branch;
            chkBranchDelete.IsChecked = userGroupRole.delete_branch;
            chkCustodyView.IsChecked = userGroupRole.view_custody;
            chkCustodyAdd.IsChecked = userGroupRole.add_custody;
            chkCustodyDelete.IsChecked = userGroupRole.delete_custody;
            chkFinanceView.IsChecked = userGroupRole.view_finance;
            chkFinanceAdd.IsChecked = userGroupRole.add_finance;
            chkFinanceDelete.IsChecked = userGroupRole.view_finance;
            chkDeliveryView.IsChecked = userGroupRole.view_delivery;
            chkDeliveryAdd.IsChecked = userGroupRole.add_delivery;
            chkDeliveryDelete.IsChecked = userGroupRole.delete_delivery;
            chkCustomerView.IsChecked = userGroupRole.view_customer;
            chkCustomerAdd.IsChecked = userGroupRole.delete_customer;
            chkCustomerDelete.IsChecked = userGroupRole.delete_customer;
            chkVendorView.IsChecked = userGroupRole.view_vendor;
            chkVendorAdd.IsChecked = userGroupRole.add_vendor;
            chkVendorDelete.IsChecked = userGroupRole.delete_vendor;
            chkServiceView.IsChecked = userGroupRole.view_service;
            chkServiceAdd.IsChecked = userGroupRole.add_service;
            chkServiceDelete.IsChecked = userGroupRole.delete_service;
            chkViewReports.IsChecked = userGroupRole.view_report;
            chkAdminRights.IsChecked = userGroupRole.admin_rights;
        }
        private UserGroupRoleDTO assignUserGroupRoleFromCheckBoxes()
        {
            UserGroupRoleDTO userGroupRole = new UserGroupRoleDTO();
            userGroupRole.name = "";
            userGroupRole.view_POS = chkPOSView.IsChecked?? false;
            userGroupRole.add_POS = chkPOSAdd.IsChecked ?? false;
            userGroupRole.delete_POS= chkPOSDelete.IsChecked ?? false;
            userGroupRole.view_HR = chkHRView.IsChecked ?? false;
            userGroupRole.add_HR = chkHRAdd.IsChecked ?? false;
            userGroupRole.delete_HR = chkHRDelete.IsChecked ?? false;
            userGroupRole.view_branch = chkBranchView.IsChecked ?? false;
            userGroupRole.add_branch = chkBranchAdd.IsChecked ?? false;
            userGroupRole.delete_branch = chkBranchDelete.IsChecked ?? false;
            userGroupRole.view_custody = chkCustodyView.IsChecked ?? false;
            userGroupRole.add_custody = chkCustodyAdd.IsChecked ?? false;
            userGroupRole.delete_custody = chkCustodyDelete.IsChecked ?? false;
            userGroupRole.view_finance = chkFinanceView.IsChecked ?? false;
            userGroupRole.add_finance = chkFinanceAdd.IsChecked ?? false;
            userGroupRole.delete_finance = chkFinanceDelete.IsChecked ?? false;
            userGroupRole.view_delivery = chkDeliveryView.IsChecked ?? false;
            userGroupRole.add_delivery = chkDeliveryAdd.IsChecked ?? false;
            userGroupRole.delete_delivery = chkDeliveryDelete.IsChecked ?? false;
            userGroupRole.view_report = chkViewReports.IsChecked ?? false;
            userGroupRole.view_customer = chkCustomerView.IsChecked ?? false;
            userGroupRole.add_customer = chkCustomerAdd.IsChecked ?? false;
            userGroupRole.delete_customer = chkCustomerDelete.IsChecked ?? false;
            userGroupRole.view_vendor = chkVendorView.IsChecked ?? false;
            userGroupRole.add_vendor = chkVendorAdd.IsChecked ?? false;
            userGroupRole.delete_vendor = chkVendorDelete.IsChecked ?? false;
            userGroupRole.view_service = chkServiceView.IsChecked ?? false;
            userGroupRole.add_service = chkServiceAdd.IsChecked ?? false;
            userGroupRole.delete_service = chkServiceDelete.IsChecked ?? false;
            userGroupRole.admin_rights = chkAdminRights.IsChecked ?? false;
            userGroupRole.userID = 0;
            return userGroupRole;

        }

        private void stkUserGroupRoles_Loaded(object sender, RoutedEventArgs e)
        {
            enableCheckboxes(false);
        }
    }
}
