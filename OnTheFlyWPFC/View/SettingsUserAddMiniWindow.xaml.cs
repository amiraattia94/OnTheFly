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
            /*
            bool valid = usersViewModel.editUser.IsValid;
            if (valid)
            {*/
            //usersViewModel = new UsersViewModel();
            var employee = (EmployeeDTO)cmbUserEmployee.SelectedValue;


                if (await usersViewModel.AddUser(txtUserName.Text, pbPassword.Password, employee.employeeID))
                {
                    MessageBox.Show("تم الحفظ");
                    usersViewModel.GetLastUser();
                    addUserGroupRolePOS(usersViewModel.editUser.userID);
                    UpdateMainList.DynamicInvoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("عذراَ ، حدثت مشكلة في عملية الحفظ");
                }
/*
            }
            else
            {
                MessageBox.Show("عذراَ ، عليك التحقق من صحة الحقول اولاَ");
            }
            */
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
        private async void addUserGroupRolePOS(int userID)
        {
            UserGroupRoleDTO userGroupRole = new UserGroupRoleDTO();
            UserGroupRoleViewModel userGroupRoleViewModel = new UserGroupRoleViewModel();
            userGroupRole.name = "نقطةالبيع";
            userGroupRole.add_POS = true;
            userGroupRole.view_POS = true;
            userGroupRole.delete_POS = true;
            userGroupRole.add_HR = false;
            userGroupRole.view_HR = false;
            userGroupRole.delete_HR = false;
            userGroupRole.add_branch = false;
            userGroupRole.view_branch = false;
            userGroupRole.delete_branch = false;
            userGroupRole.add_custody = false;
            userGroupRole.view_custody = false;
            userGroupRole.delete_custody = false;
            userGroupRole.add_finance = false;
            userGroupRole.view_finance = false;
            userGroupRole.delete_finance = false;
            userGroupRole.add_delivery = false;
            userGroupRole.view_delivery = false;
            userGroupRole.delete_delivery = false;
            userGroupRole.add_customer = false;
            userGroupRole.delete_customer = false;
            userGroupRole.view_vendor = false;
            userGroupRole.add_vendor = false;
            userGroupRole.delete_vendor = false;
            userGroupRole.view_service = false;
            userGroupRole.add_service = false;
            userGroupRole.delete_service = false;
            userGroupRole.view_report = false;
            userGroupRole.admin_rights = false;
            userGroupRole.userID = 0;
            try
            {
                await userGroupRoleViewModel.AddUserGroupRoleByUserID(userID, userGroupRole);
            }
            catch
            {
                MessageBox.Show("لم تتم اضافة صلاحية نقطة البيغ بعد", "تحذير", MessageBoxButton.OK);
            }
          

        }

    }
}
