using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;
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
    /// Interaction logic for CustomerMembershipMiniWindow.xaml
    /// </summary>
    public partial class CustomerMembershipMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CustomerViewModel customerViewModel;
        CategoryViewModel categoryViewModel;
        VendorViewModel vendorViewModel;
        private bool saveButton = true;

        public CustomerMembershipMiniWindow()
        {
            InitializeComponent();

            customerViewModel = new CustomerViewModel();
            categoryViewModel = new CategoryViewModel();
            vendorViewModel = new VendorViewModel();

            cmbVendors.IsEnabled = false;
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            UpdateMainList.DynamicInvoke();
            this.Close();
        }

        private void lstMembership_Loaded(object sender, RoutedEventArgs e)
        {
            customerViewModel.GetMembershipByCustomerID(HelperClass.Customer);
            lstMembership.ItemsSource = customerViewModel.ViewMembership;
        }

        private void RefreshList()
        {
            customerViewModel.GetMembershipByCustomerID(HelperClass.Customer);
            lstMembership.ItemsSource = customerViewModel.ViewMembership;
            lstMembership.Items.Refresh();
        }

        private void addNewMembership_Click(object sender, RoutedEventArgs e)
        {
            lblMembership.Content = "اضافة عضوية";
            txtMembershipID.Text = "ادخل رقم العضوية";
            txtMembershipID.IsEnabled = true;
            cmbServiceCategory.SelectedIndex = -1;
            cmbVendors.SelectedIndex = -1;
            borderSaveOrEdit.Background = (Brush)(new BrushConverter().ConvertFrom("#ADE23F"));
            txtSaveOrEdit.Text = "اضافة";
            saveButton = true;

        }

        private void EditMembership(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as MembershipDTO;

            lblMembership.Content = "تعديل عضوية";
            txtMembershipID.Text = a.membershipID;
            txtMembershipID.IsEnabled = false;
            cmbServiceCategory.SelectedValue = a.vendorCategoryID;
            vendorViewModel.GetVendors(a.vendorCategoryID);
            cmbVendors.ItemsSource = vendorViewModel.vendors;
            cmbVendors.SelectedValue = a.vendorID;
            borderSaveOrEdit.Background = (Brush)(new BrushConverter().ConvertFrom("#2C99F5"));
            txtSaveOrEdit.Text = "تعديل";
            saveButton = false;

        }

        async private void DeleteMembership(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as MembershipDTO;

            if (await customerViewModel.DeleteMembershipByID(a.membershipID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshList();
        }

        private void cmbServiceCategory_Loaded(object sender, RoutedEventArgs e)
        {
            categoryViewModel.GetAllCategories();
            cmbServiceCategory.ItemsSource = categoryViewModel.allCategories;
            cmbServiceCategory.SelectedValuePath = "CategoryID";
            cmbServiceCategory.DisplayMemberPath = "CategoryName";
        }

        private void cmbServiceCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbServiceCategory.SelectedIndex == -1)
            {
                cmbVendors.IsEnabled = false;
            }
            else
            {
                cmbVendors.IsEnabled = true;
                if (cmbServiceCategory.SelectedValue != null)
                {
                    vendorViewModel.GetVendors((int)cmbServiceCategory.SelectedValue);
                    cmbVendors.ItemsSource = vendorViewModel.vendors;
                    cmbVendors.SelectedValuePath = "VendorID";
                    cmbVendors.DisplayMemberPath = "VendorName";
                }


            }

        }

        private void cmbVendors_Loaded(object sender, RoutedEventArgs e)
        {
            cmbVendors.ItemsSource = vendorViewModel.vendors;
            cmbVendors.SelectedValuePath = "VendorID";
            cmbVendors.DisplayMemberPath = "VendorName";

        }

        async private void BtnSaveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!saveButton)
            {
                if (await customerViewModel.EditMembershipByID(txtMembershipID.Text, (int)cmbVendors.SelectedValue))
                    MessageBox.Show("تم الحفظ");
            }
            else
            {
                if (await customerViewModel.AddMembership(txtMembershipID.Text, HelperClass.Customer, (int)cmbVendors.SelectedValue))
                    MessageBox.Show("تم الحفظ");
            }
            RefreshList();
            UpdateMainList.DynamicInvoke();
        }

        private void StkCustomerEdit_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void StkBranchEditorAdd_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
