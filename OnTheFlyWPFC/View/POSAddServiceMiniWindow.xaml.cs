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
    public partial class POSAddServiceMiniWindow : Window
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
        

        public POSAddServiceMiniWindow()
        {
            InitializeComponent();

            deliveryPricesViewModel = new DeliveryPricesViewModel();
            categoryViewModel = new CategoryViewModel();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            invoiceViewModel = new InvoiceViewModel();
            vendorViewModel = new VendorViewModel();


            cmbVendors.IsEnabled = false;
            cmbBranches.IsEnabled = false;
            cmbTrip.IsEnabled = false;
            cmbPaid.IsEnabled = false;
            txtPaidPrice.IsEnabled = false;
            lblTotalPrice.Content = "0";
            datePickerStartDate.SelectedDate = DateTime.Today;

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
        }

        private void CmbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbServiceType.SelectedIndex != -1) {
                cmbVendors.IsEnabled = true;
                vendorViewModel.GetVendorByCategoryID((int)cmbServiceType.SelectedValue);
                cmbVendors.ItemsSource = vendorViewModel.vendors;
                cmbVendors.SelectedValuePath = "VendorID";
                cmbVendors.DisplayMemberPath = "VendorName";
            }
                
        }

        private void CmbVendors_Loaded(object sender, RoutedEventArgs e) {
            


        }

        private void CmbVendors_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbVendors.SelectedIndex != -1) {
                cmbBranches.IsEnabled = true;
                vendorViewModel.GetAllVendorBranchByID((int)cmbVendors.SelectedValue);
                cmbBranches.ItemsSource = vendorViewModel.vendorBranches;
                cmbBranches.SelectedValuePath = "vendorBranchID"; 
                cmbBranches.DisplayMemberPath = "name";
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

        }

        async private void CmbTrip_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbTrip.SelectedIndex != -1) {
                vendorViewModel.GetVendorBranchshipByID((int)cmbBranches.SelectedValue);
                var vendorLocation = vendorViewModel.vendorBranche.cityCode;

                customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);
                var customerLocation = customerViewModel.customer.cityCode;

                txtDeliveryPrice.IsEnabled = true;
                cmbPaid.IsEnabled = true;

                txtDeliveryPrice.Text = "0";
                if (cmbTrip.SelectedIndex == 0) {
                    deliveryPrice = await deliveryPricesViewModel.GetDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, true);
                    isfull = true;
                }
                else if (cmbTrip.SelectedIndex == 1) {
                    
                    deliveryPrice = await deliveryPricesViewModel.GetDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, false);
                    isfull = false;
                }


                lblTotalPrice.Content = decimal.Parse(txtDeliveryPrice.Text) + decimal.Parse(txtPaidPrice.Text);

                txtDeliveryPrice.Text = deliveryPrice.ToString();



            }
        }

        private void TxtPaidPrice_TextChanged(object sender, TextChangedEventArgs e) {
            if(txtPaidPrice.Text != "")
                lblTotalPrice.Content = deliveryPrice + decimal.Parse(txtPaidPrice.Text)  ;
        }

        private void CmbPaid_Loaded(object sender, RoutedEventArgs e) {

        }

        private void CmbPaid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbPaid.SelectedIndex != -1) {
                if(cmbPaid.SelectedIndex == 0) {
                    txtPaidPrice.IsEnabled = false;
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






            if (await invoiceViewModel.AddDeliveryService(HelperClass.POSInvoiceID, (int)cmbServiceType.SelectedValue, (int)cmbBranches.SelectedValue, HelperClass.POSSelectedCustomerID, isfull, decimal.Parse(txtPaidPrice.Text), decimal.Parse(txtDeliveryPrice.Text), true, (DateTime)datePickerStartDate.SelectedDate)
)           {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }

        }

        private void DatePickerStartDate_Loaded(object sender, RoutedEventArgs e) {
            datePickerStartDate.SelectedDate = DateTime.Today;
        }

        private void TxtDeliveryPrice_TextChanged(object sender, TextChangedEventArgs e) {
            lblTotalPrice.Content = decimal.Parse(txtDeliveryPrice.Text) + decimal.Parse(txtPaidPrice.Text);
        }
    }
}
