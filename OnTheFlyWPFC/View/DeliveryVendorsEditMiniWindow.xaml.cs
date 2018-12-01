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
    /// Interaction logic for DeliveryDestinationEditMiniWindow.xaml
    /// </summary>
    public partial class DeliveryVendorsEditMiniWindow : Window
    {

        public Delegate UpdateMainList;
        VendorViewModel vendorViewModel;
        CategoryViewModel categoryViewModel;

        public DeliveryVendorsEditMiniWindow()
        {
            InitializeComponent();

            vendorViewModel = new VendorViewModel();
            categoryViewModel = new CategoryViewModel();

            vendorViewModel.GetVendorByID(HelperClass.vendorID);
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void cmbServiceType_Loaded(object sender, RoutedEventArgs e) {
            categoryViewModel.GetAllCategories();
            cmbServiceType.ItemsSource = categoryViewModel.allCategories;
            cmbServiceType.SelectedValuePath = "CategoryID";
            cmbServiceType.DisplayMemberPath = "CategoryName";

            cmbServiceType.SelectedValue = vendorViewModel.vendor.VendorCategoryID;
        }

        private void CmbServiceState_Loaded(object sender, RoutedEventArgs e) {
            if ((bool)vendorViewModel.vendor.VendorStatus)
                cmbServiceState.SelectedIndex = 0;
            else {
                cmbServiceState.SelectedIndex = 1;
            }
        }

        async private void Edit(object sender, RoutedEventArgs e) {
            bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());

            if (await vendorViewModel.EditVendorByID(HelperClass.vendorID, (int)cmbServiceType.SelectedValue, txtVendorName.Text, status)) {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }

        private void StkEditVendors_Loaded(object sender, RoutedEventArgs e) {
            stkEditVendors.DataContext = vendorViewModel.vendor;
        }
    }
}
