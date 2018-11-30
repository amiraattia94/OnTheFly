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
    /// Interaction logic for POSAddServiceMiniWindow.xaml
    /// </summary>
    public partial class POSEditServiceMiniWindow : Window
    {

        public Delegate UpdateMainList;

        DeliveryPricesViewModel deliveryPricesViewModel;
        CategoryViewModel categoryViewModel;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;
        InvoiceViewModel invoiceViewModel;
        VendorViewModel vendorViewModel;

        bool isfull;
        decimal? deliveryPrice;
        

        public POSEditServiceMiniWindow()
        {
            InitializeComponent();

            deliveryPricesViewModel = new DeliveryPricesViewModel();
            categoryViewModel = new CategoryViewModel();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            invoiceViewModel = new InvoiceViewModel();
            vendorViewModel = new VendorViewModel();

            invoiceViewModel.GetDeliveryServiceByID(HelperClass.POSSelectedDeliveryServiceID);

            cmbVendors.IsEnabled = false;
            cmbBranches.IsEnabled = false;
            cmbTrip.IsEnabled = false;
            cmbPaid.IsEnabled = false;
            txtPaidPrice.IsEnabled = false;
            lblTotalPrice.Content = "0";
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e) {
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

            cmbServiceType.SelectedValue = invoiceViewModel.deliveryService.CategoryID;
        }

        private void CmbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbServiceType.SelectedIndex != -1) {
                cmbVendors.IsEnabled = true;
                vendorViewModel.GetVendorByCategoryID(invoiceViewModel.deliveryService.CategoryID);
                cmbVendors.ItemsSource = vendorViewModel.vendors;
                cmbVendors.SelectedValuePath = "VendorID";
                cmbVendors.DisplayMemberPath = "VendorName";

                cmbVendors.SelectedValue = invoiceViewModel.deliveryService.VendorID;
            }
                
        }

        private void CmbVendors_Loaded(object sender, RoutedEventArgs e) {
            


        }

        private void CmbVendors_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbVendors.SelectedIndex != -1) {
                cmbBranches.IsEnabled = true;
                vendorViewModel.GetAllVendorBranchByID(invoiceViewModel.deliveryService.VendorID);
                cmbBranches.ItemsSource = vendorViewModel.vendorBranches;
                cmbBranches.SelectedValuePath = "vendorBranchID"; 
                cmbBranches.DisplayMemberPath = "name";

                cmbBranches.SelectedValue = invoiceViewModel.deliveryService.VendorBranchID;

            }
        }

        private void CmbBranches_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void CmbBranches_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbBranches.SelectedIndex != -1) {

                cmbTrip.IsEnabled = true;
            }
                
        }

        private void CmbTrip_Loaded(object sender, RoutedEventArgs e) {
            if (invoiceViewModel.deliveryService.isFulTrip) {
                cmbTrip.SelectedIndex = 0;
            }
            else {
                cmbTrip.SelectedIndex = 1;

            }

        }

        async private void CmbTrip_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbTrip.SelectedIndex != -1) {
                vendorViewModel.GetVendorBranchshipByID((int)cmbBranches.SelectedValue);
                var vendorLocation = vendorViewModel.vendorBranche.cityCode;

                customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);
                var customerLocation = customerViewModel.customer.cityCode;

                txtDeliveryPrice.IsEnabled = true;
                cmbPaid.IsEnabled = true;
                

                if(cmbTrip.SelectedIndex == 0) {
                    deliveryPrice = await deliveryPricesViewModel.GetDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, true);
                    isfull = true;
                }
                else if (cmbTrip.SelectedIndex == 1) {
                    
                    deliveryPrice = await deliveryPricesViewModel.GetDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, false);
                    isfull = false;
                }

                lblTotalPrice.Content = deliveryPrice + decimal.Parse(txtPaidPrice.Text);

                txtDeliveryPrice.Text = deliveryPrice.ToString();



            }
        }


        private void TxtPaidPrice_TextChanged(object sender, TextChangedEventArgs e) {
            if(txtPaidPrice.Text != "")
                lblTotalPrice.Content = deliveryPrice + decimal.Parse(txtPaidPrice.Text);
        }

        private void CmbPaid_Loaded(object sender, RoutedEventArgs e) {
            if(invoiceViewModel.deliveryService.productPrice == 0) {
                cmbPaid.SelectedIndex = 0;
                txtPaidPrice.IsEnabled = false;
                txtPaidPrice.Text = "0";
            }
            else if (invoiceViewModel.deliveryService.productPrice != 0) {
                cmbPaid.SelectedIndex = 1;
                txtPaidPrice.IsEnabled = true;
                txtPaidPrice.Text = invoiceViewModel.deliveryService.productPrice.ToString();
            }
        }

        private void CmbPaid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if(cmbPaid.SelectedIndex != -1) {
                if(cmbPaid.SelectedIndex == 0) {
                    txtPaidPrice.IsEnabled = false;
                    txtPaidPrice.Text = "0";
                }
                else if(cmbPaid.SelectedIndex == 1) {
                    txtPaidPrice.IsEnabled = true;
                    txtPaidPrice.Text = "0";

                }

            }
        }

        async private void AddService_click(object sender, RoutedEventArgs e) {

            //var city = (CityDTO)cmbBranchCities.SelectedValue;
            //bool status = HelperClass.TrueOrFalse(cmbBranchStatus.SelectedIndex.ToString());






            if (await invoiceViewModel.EditDeliveryService(HelperClass.POSSelectedDeliveryServiceID, HelperClass.POSInvoiceID, (int)cmbServiceType.SelectedValue, (int)cmbBranches.SelectedValue, HelperClass.POSSelectedCustomerID, isfull, decimal.Parse(txtPaidPrice.Text), (decimal)deliveryPrice, true, DateTime.Now)
)           {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }

        }

        private void TxtDeliveryPrice_Loaded(object sender, RoutedEventArgs e) {
            deliveryPrice = invoiceViewModel.deliveryService.deliveryPrice;
            txtDeliveryPrice.Text = deliveryPrice.ToString();

        }

        private void TxtPaidPrice_Loaded(object sender, RoutedEventArgs e) {

            txtPaidPrice.Text = invoiceViewModel.deliveryService.productPrice.ToString();

        }

        private void LblTotalPrice_Loaded(object sender, RoutedEventArgs e) {
            lblTotalPrice.Content = deliveryPrice + invoiceViewModel.deliveryService.productPrice;
        }
    }
}
