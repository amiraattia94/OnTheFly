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
            txtDeliveryPrice.Text = "0";
            txtPaidPrice.Text = "0";
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
            if (cmbServiceType.SelectedIndex != -1  && cmbServiceType.SelectedValue != null) {
                cmbVendors.IsEnabled = true;
                vendorViewModel.GetVendorByCategoryID((int)cmbServiceType.SelectedValue);
                cmbVendors.ItemsSource = vendorViewModel.vendors;
                cmbVendors.SelectedValuePath = "VendorID";
                cmbVendors.DisplayMemberPath = "VendorName";


                cmbVendors.SelectedIndex = -1;
                cmbBranches.SelectedIndex = -1;
                cmbBranches.IsEnabled = false;
                cmbTrip.SelectedIndex = -1;
                cmbTrip.IsEnabled = false;
                cmbPaid.SelectedIndex = -1;
                cmbPaid.IsEnabled = false;

                txtDeliveryPrice.Text = "0";
                txtPaidPrice.Text = "0";

            }
                
        }

        private void CmbVendors_Loaded(object sender, RoutedEventArgs e) {
            


        }

        private void CmbVendors_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbVendors.SelectedIndex != -1 && cmbVendors.SelectedValue != null) {
                cmbBranches.IsEnabled = true;
                vendorViewModel.GetAllVendorBranchByID((int)cmbVendors.SelectedValue);
                cmbBranches.ItemsSource = vendorViewModel.vendorBranches;
                cmbBranches.SelectedValuePath = "vendorBranchID"; 
                cmbBranches.DisplayMemberPath = "name";

                //cmbVendors.SelectedIndex = -1;
                cmbBranches.SelectedIndex = -1;
                //cmbBranches.IsEnabled = false;
                cmbTrip.SelectedIndex = -1;
                cmbTrip.IsEnabled = false;
                cmbPaid.SelectedIndex = -1;
                cmbPaid.IsEnabled = false;

                txtDeliveryPrice.Text = "0";
                txtPaidPrice.Text = "0";

            }
        }

        private void CmbBranches_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void CmbBranches_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbBranches.SelectedIndex != -1) {

                cmbTrip.IsEnabled = true;

                //cmbVendors.SelectedIndex = -1;
                //cmbBranches.SelectedIndex = -1;
                cmbTrip.SelectedIndex = -1;
                cmbPaid.SelectedIndex = -1;
                cmbPaid.IsEnabled = false;


                txtDeliveryPrice.Text = "0";
                txtPaidPrice.Text = "0";




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
                    deliveryPrice = await deliveryPricesViewModel.GetActiveDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, true);
                    isfull = true;
                }
                else if (cmbTrip.SelectedIndex == 1) {
                    
                    deliveryPrice = await deliveryPricesViewModel.GetActiveDeliveryPrice((int)cmbServiceType.SelectedValue, vendorLocation, customerLocation, false);
                    isfull = false;
                }

                if(txtPaidPrice.Text != "") {
                    lblTotalPrice.Content = decimal.Parse(txtDeliveryPrice.Text) + decimal.Parse(txtPaidPrice.Text);

                    txtDeliveryPrice.Text = deliveryPrice.ToString();

                }

                //cmbVendors.SelectedIndex = -1;
                //cmbBranches.SelectedIndex = -1;
                //cmbTrip.SelectedIndex = -1;
                cmbPaid.SelectedIndex = -1;

                //txtDeliveryPrice.Text = "0";
                txtPaidPrice.Text = "0";



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

            if (HelperClass.userGroupRoleDTO.add_service) {

                if ((int)cmbServiceType.SelectedIndex == -1) {
                    MessageBox.Show("يجب اختيار نوع الخدمة ");
                    return;
                }
                if ((int)cmbVendors.SelectedIndex == -1) {
                    MessageBox.Show("يجب اختيار مزود الخدمة ");
                    return;
                }
                if ((int)cmbBranches.SelectedIndex == -1) {
                    MessageBox.Show("يجب اختيار الفرع ");
                    return;
                }
                if ((int)cmbTrip.SelectedIndex == -1) {
                    MessageBox.Show("يجب اختيار نوع الرحلة ");
                    return;
                }
                if ((int)cmbPaid.SelectedIndex == -1) {
                    MessageBox.Show("يجب اختيار نوع الدفع ");
                    return;
                }
                if (txtDeliveryPrice.Text == "") {
                    MessageBox.Show("يجب تعبعةرالحقل ");
                    return;
                }
                if (txtPaidPrice.Text == "") {
                    MessageBox.Show("يجب تعبعةرالحقل ");
                    return;
                }

                if (await invoiceViewModel.AddDeliveryService(HelperClass.POSInvoiceID, (int)cmbServiceType.SelectedValue, (int)cmbBranches.SelectedValue, HelperClass.POSSelectedCustomerID, isfull, decimal.Parse(txtPaidPrice.Text), decimal.Parse(txtDeliveryPrice.Text), true, (DateTime)datePickerStartDate.SelectedDate)) {
                    MessageBox.Show("تم الحفظ");
                    UpdateMainList.DynamicInvoke();
                    this.Close();

                }


            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }




        }

        private void DatePickerStartDate_Loaded(object sender, RoutedEventArgs e) {
            datePickerStartDate.SelectedDate = DateTime.Today;
        }

        private void TxtDeliveryPrice_TextChanged(object sender, TextChangedEventArgs e) {
            if(txtPaidPrice.Text != "") {
                lblTotalPrice.Content = decimal.Parse(txtDeliveryPrice.Text) + decimal.Parse(txtPaidPrice.Text);

            }
        }

        private void CmbMembership_Loaded(object sender, RoutedEventArgs e) {
            customerViewModel.GetMembershipByCustomerID(HelperClass.POSSelectedCustomerID);
            cmbMembership.ItemsSource = customerViewModel.ViewMembership;
            cmbMembership.SelectedValuePath = "membershipID";
            cmbMembership.DisplayMemberPath = "membershipID";


        }

        private void CmbMembership_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbMembership.SelectedIndex != -1) {

                customerViewModel.GetMembershipByID((string)cmbMembership.SelectedValue);
                cmbServiceType.SelectedValue = customerViewModel.membership.vendorCategoryID;
                cmbServiceType.IsEnabled = false;

                vendorViewModel.GetVendorByCategoryID((int)cmbServiceType.SelectedValue);
                cmbVendors.ItemsSource = vendorViewModel.vendors;
                cmbVendors.SelectedValuePath = "VendorID";
                cmbVendors.DisplayMemberPath = "VendorName";
                cmbVendors.SelectedValue = customerViewModel.membership.vendorID;


                vendorViewModel.GetAllVendorBranchByID((int)cmbVendors.SelectedValue);
                cmbBranches.ItemsSource = vendorViewModel.vendorBranches;
                cmbBranches.SelectedValuePath = "vendorBranchID";
                cmbBranches.DisplayMemberPath = "name";

                cmbVendors.IsEnabled = false;

                cmbBranches.IsEnabled = true;

                //cmbVendors.SelectedIndex = -1;
                cmbBranches.SelectedIndex = -1;
                cmbTrip.SelectedIndex = -1;
                cmbTrip.IsEnabled = false;
                cmbPaid.SelectedIndex = -1;
                cmbPaid.IsEnabled = false;


                txtDeliveryPrice.Text = "0";
                txtPaidPrice.Text = "0";


            }
            else {
                

            }
        }
    }
}
