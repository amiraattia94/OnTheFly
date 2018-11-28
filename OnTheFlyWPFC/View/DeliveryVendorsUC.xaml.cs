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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for DeliveryDestinationUC.xaml
    /// </summary>
    public partial class DeliveryVendorsUC : UserControl
    {
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        CategoryViewModel categoryViewModel;
        VendorViewModel vendorViewModel;

        public DeliveryVendorsUC()
        {
            InitializeComponent();

            categoryViewModel = new CategoryViewModel();
            vendorViewModel = new VendorViewModel();
        }

        private void BtnSearchDeliveryDestination_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbServiceType_Loaded(object sender, RoutedEventArgs e) {
            categoryViewModel.GetAllCategories();
            cmbServiceType.ItemsSource = categoryViewModel.allCategories;
            cmbServiceType.SelectedValuePath = "CategoryID";
            cmbServiceType.DisplayMemberPath = "CategoryName";
        }

        private void CmbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbServiceType.SelectedIndex != -1) {
                vendorViewModel.GetVendorByCategoryID((int)cmbServiceType.SelectedValue);
                lstViewDeliveryDistination.ItemsSource = vendorViewModel.vendors;
                lstViewDeliveryDistination.Items.Refresh();
                cmbServiceState.SelectedIndex = -1;
                txtSearchDistinationName.Text = "";

            }
        }

        private void CmbServiceState_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbServiceState.SelectedIndex != -1) {

                bool SelectedState = false;
                if (cmbServiceState.SelectedIndex == 0)
                    SelectedState = true;
                else if (cmbServiceState.SelectedIndex == 1)
                    SelectedState = false;

                vendorViewModel.GetVendorByState(SelectedState);
                lstViewDeliveryDistination.ItemsSource = vendorViewModel.vendors;
                lstViewDeliveryDistination.Items.Refresh();
                cmbServiceType.SelectedIndex = -1;
                txtSearchDistinationName.Text = "";
            }
        }

        private void TxtSearchDistinationName_TextChanged(object sender, TextChangedEventArgs e) {
            vendorViewModel.GetVendorByName(txtSearchDistinationName.Text);
            lstViewDeliveryDistination.ItemsSource = vendorViewModel.vendors;
            lstViewDeliveryDistination.Items.Refresh();
            cmbServiceType.SelectedIndex = -1;
            cmbServiceState.SelectedIndex = -1;
        }

        private void LstViewDeliveryDistination_Loaded(object sender, RoutedEventArgs e) {
            vendorViewModel.GetAllVendors();
            lstViewDeliveryDistination.ItemsSource = vendorViewModel.vendors;
        }


        private void RefreshListView() {
            vendorViewModel.GetAllVendors();
            lstViewDeliveryDistination.ItemsSource = vendorViewModel.vendors;
            lstViewDeliveryDistination.Items.Refresh();
        }

        private void VendorBranches_click(object sender, RoutedEventArgs e) {

        }

        private void Add(object sender, RoutedEventArgs e) {
            var newwindow = new DeliveryVendorsAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void EditVendor(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as VendorDTO;
            HelperClass.vendorID = a.VendorID;

            var newwindow = new DeliveryVendorsEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        async private void DeleteVendor(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as VendorDTO;
            HelperClass.vendorID = a.VendorID;
            if (await vendorViewModel.DeleteVendorByID(a.VendorID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();

        }

        private void TxtVendorBranchCount_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
