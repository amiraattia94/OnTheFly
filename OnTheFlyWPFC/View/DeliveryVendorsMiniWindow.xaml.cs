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
    public partial class DeliveryVendorsMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CityViewModel cityViewModel;
        VendorViewModel vendorViewModel;

        private bool saveButton = true;

        public DeliveryVendorsMiniWindow()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
            vendorViewModel = new VendorViewModel();

            RefreshList();
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            UpdateMainList.DynamicInvoke();
            this.Close();
        }
        
        private void cmbBranchCities_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbBranchCities.ItemsSource = cityViewModel.CityName;
            cmbBranchCities.DisplayMemberPath = "name";
            cmbBranchCities.SelectedValuePath = "cityCode";
        }

        async private void BtnSaveOrEdit_Click(object sender, RoutedEventArgs e) {
            if (HelperClass.userGroupRoleDTO.add_vendor) {
                bool status = HelperClass.TrueOrFalse(cmbBranchStatus.SelectedIndex.ToString());

                if (!saveButton) {
                    if (await vendorViewModel.EditVendorBranchByID(HelperClass.vendorBranchID, txtname.Text, cmbBranchCities.SelectedValue.ToString(), txtaddress.Text, txtphone1.Text, txtphone2.Text, status))
                        MessageBox.Show("تم الحفظ");
                }
                else {
                    if (await vendorViewModel.AddVendorBranch(HelperClass.vendorID, txtname.Text, cmbBranchCities.SelectedValue.ToString(), txtaddress.Text, txtphone1.Text, txtphone2.Text, status))
                        MessageBox.Show("تم الحفظ");
                }
                RefreshList();
                UpdateMainList.DynamicInvoke();
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            
        }

        private void RefreshList() {
            vendorViewModel.GetAllVendorBranchByID(HelperClass.vendorID);
            lstVendorBranches.ItemsSource = vendorViewModel.vendorBranches;
            lstVendorBranches.Items.Refresh();
        }

        private void lstVendorBranches_Loaded(object sender, RoutedEventArgs e) {
            vendorViewModel.GetAllVendorBranchByID(HelperClass.vendorID);
            lstVendorBranches.ItemsSource = vendorViewModel.vendorBranches;
        }

        private void EditVendorBranch(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as VendorBranchsDTO;

            lblVendorBranch.Content = "تعديل فرع";
            cmbBranchCities.SelectedValue = a.cityCode;
            txtname.Text = a.name;
            txtaddress.Text = a.address;
            txtphone1.Text = a.phone1;
            txtphone2.Text = a.phone2;
            if (a.state)
                cmbBranchStatus.SelectedIndex = 0;
            else
                cmbBranchStatus.SelectedIndex = 1;

            borderSaveOrEdit.Background = (Brush)(new BrushConverter().ConvertFrom("#2C99F5"));
            txtSaveOrEdit.Text = "تعديل";
            saveButton = false;
           
        }

        async private void DeleteVendorBranch(object sender, RoutedEventArgs e) {
            if (HelperClass.userGroupRoleDTO.delete_vendor) {
                Button button = sender as Button;
                var a = button.CommandParameter as VendorBranchsDTO;

                if (await vendorViewModel.DeleteVendorBranchByID(a.vendorBranchID))
                    MessageBox.Show("تم المسح بنجاح");
                RefreshList();

                lblVendorBranch.Content = " اضافة فرع";
                cmbBranchCities.SelectedIndex = -1;
                txtname.Text = "ادخل الاسم";
                txtaddress.Text = "ادخل العنوان";
                txtphone1.Text = "ادخل رقم الهاتف";
                txtphone2.Text = "ادخل رقم الهاتف";
                cmbBranchStatus.SelectedIndex = -1;
                borderSaveOrEdit.Background = (Brush)(new BrushConverter().ConvertFrom("#ADE23F"));
                txtSaveOrEdit.Text = "اضافة";
                saveButton = true;
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }



        }

        private void addNewVendorBranch_Click(object sender, RoutedEventArgs e) {
            lblVendorBranch.Content = " اضافة فرع";
            cmbBranchCities.SelectedIndex = -1;
            txtname.Text = "ادخل الاسم";
            txtaddress.Text = "ادخل العنوان";
            txtphone1.Text = "ادخل رقم الهاتف";
            txtphone2.Text = "ادخل رقم الهاتف";
            cmbBranchStatus.SelectedIndex = -1;
            borderSaveOrEdit.Background = (Brush)(new BrushConverter().ConvertFrom("#ADE23F"));
            txtSaveOrEdit.Text = "اضافة";
            saveButton = true;
        }
    }
}
