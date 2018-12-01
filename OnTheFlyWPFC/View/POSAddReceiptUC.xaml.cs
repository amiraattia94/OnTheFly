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
    /// Interaction logic for POSAddReceiptUC.xaml
    /// </summary>
    public partial class POSAddReceiptUC : UserControl
    {
        InvoiceViewModel invoiceViewModel;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        
        public POSAddReceiptUC()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();

            invoiceViewModel.AddNewInvoice();
            invoiceViewModel.GetNewInvoiceID();
            btnAddService.Visibility = System.Windows.Visibility.Hidden;
            btnCustody.Visibility = System.Windows.Visibility.Hidden;

        }

        private void LblNewInvoice_Loaded(object sender, RoutedEventArgs e) {
            lblNewInvoice.Content = invoiceViewModel.invoiceNewID.ToString("D8");
        }

        private void LblDate_Loaded(object sender, RoutedEventArgs e) {
            lblDate.Content = DateTime.Now.ToShortDateString();
        }

        private void cmbCities_Loaded(object sender, RoutedEventArgs e) {
            //cityViewModel.GetAllCities();
            //cmbCities.ItemsSource = cityViewModel.CityName;
            //cmbCities.DisplayMemberPath = "name";
            //cmbCities.SelectedValuePath = "cityCode";
        }

        private void LblEmployeeName_Loaded(object sender, RoutedEventArgs e) {

        }

        private void CmbDriver_Loaded(object sender, RoutedEventArgs e) {

        }

        private void BtnCustomerSearch_Click(object sender, RoutedEventArgs e) {
            var newwindow = new POSAddReceipetSearchCustomerMiniWindow();

            RefreshListEvent += new RefreshList(RefreshCustomerInfo);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
            invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);

            RefreshDeliveryServiceList();
            RefreshCustomerInfo();

            if (HelperClass.POSSelectedCustomerID != 0)
                btnAddService.Visibility = System.Windows.Visibility.Visible;



        }

        private void RefreshCustomerInfo() {
            customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);

            txtCustomerName.Text = customerViewModel.customer.name;
            txtCustomerPhone.Text = customerViewModel.customer.phone1;
            txtCustomerPhone2.Text = customerViewModel.customer.phone2;
            txtCustomerAddress.Text = customerViewModel.customer.address;
            txtCities.Text = customerViewModel.customer.city;
            lblCustomerCredit.Content = customerViewModel.customer.credit;
            lblCustomerCreditAfter.Content = customerViewModel.customer.credit - decimal.Parse(lblTotalAfter.Content.ToString());

            //invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);

            RefreshInvoicePriceList();

            //foreach (CityDTO city in cmbCities.Items) {
            //    if (city.name == customerViewModel.customer.city) {
            //        cmbCities.SelectedValue = city.cityCode;
            //        break;
            //    }
            //}

            //throw new NotImplementedException();
        }

        private void LstViewDeliveryServices_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);
            invoiceViewModel.GetAllDeliveryServices();
            lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
        }

        private void Edit_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryServiceDTO;
            HelperClass.POSSelectedDeliveryServiceID = a.deliverServiceID;
            HelperClass.POSInvoiceID = invoiceViewModel.invoiceNewID;

            var newwindow = new POSEditServiceMiniWindow();
            RefreshListEvent += new RefreshList(RefreshDeliveryServiceList);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void RefreshDeliveryServiceList() {
            invoiceViewModel.GetAllDeliveryServices();
            lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
            lstViewDeliveryServices.Items.Refresh();

            RefreshInvoicePriceList();
        }

        async private void Delete_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryServiceDTO;
            HelperClass.POSSelectedDeliveryServiceID = a.deliverServiceID;

            if (await invoiceViewModel.DeleteDeliveryServiceByID(a.deliverServiceID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshDeliveryServiceList();

        }

        private void ADDService_Click(object sender, RoutedEventArgs e) {
            HelperClass.POSInvoiceID = invoiceViewModel.invoiceNewID;
            var newwindow = new POSAddServiceMiniWindow();
            RefreshListEvent += new RefreshList(RefreshDeliveryServiceList);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void RefreshInvoicePriceList() {
            invoiceViewModel.GetTotalPriceByInvoiceID(HelperClass.POSInvoiceID);
            invoiceViewModel.GetTotalDeliveryPriceByInvoiceID(HelperClass.POSInvoiceID);
            lblTotalPrice.Content = invoiceViewModel.totalPrice;
            lblTotalDeliveryPrice.Content = invoiceViewModel.deliveryPrice;

            if (string.IsNullOrEmpty(txtDiscount.Text)) {
                decimal discountpercent = decimal.Parse(txtDiscount.Text) / 100;
                decimal total = discountpercent * (decimal)invoiceViewModel.totalPrice;
                lblTotalAfter.Content = (decimal)invoiceViewModel.totalPrice - total;


                if (cmbPayment.SelectedIndex != 1) {
                    lblCustomerCreditAfter.Content = customerViewModel.customer.credit - (decimal)invoiceViewModel.totalPrice - total;

                }
            }
            else {
                if (lblTotalPrice.Content == null) {
                    lblTotalAfter.Content = 0;

                    lblCustomerCreditAfter.Content = customerViewModel.customer.credit;
                }
                else {
                    lblTotalAfter.Content = invoiceViewModel.totalPrice;


                    if (cmbPayment.SelectedIndex != 1) {
                        lblCustomerCreditAfter.Content = customerViewModel.customer.credit - invoiceViewModel.totalPrice;
                    }
                    
                }
            }
                

            if (invoiceViewModel.totalPrice == null) {
                lblTotalPrice.Content = "0";
                lblTotalDeliveryPrice.Content = "0";
                lblTotalAfter.Content = "0";
                txtDiscount.Text = "0";
            }
        }

        private void TxtDiscount_TextChanged(object sender, TextChangedEventArgs e) {
            if(invoiceViewModel != null) {
                if (!string.IsNullOrEmpty(txtDiscount.Text)) {
                    if (txtDiscount.Text != "") {
                        decimal discountpercent = decimal.Parse(txtDiscount.Text) / 100;
                        decimal totalDiscount = discountpercent * (decimal)invoiceViewModel.totalPrice;
                        lblTotalAfter.Content = (decimal)invoiceViewModel.totalPrice - totalDiscount;

                        if(cmbPayment.SelectedIndex != 1) {
                            lblCustomerCreditAfter.Content = customerViewModel.customer.credit - (decimal)invoiceViewModel.totalPrice - totalDiscount;

                        }
                    }

                }
            }
        }

        private void AddCostody(object sender, RoutedEventArgs e) {

        }

        private void CmbPayment_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbPayment.SelectedIndex != -1) {
                if(cmbPayment.SelectedIndex == 0){
                    btnCustody.Visibility = System.Windows.Visibility.Hidden;
                    RefreshInvoicePriceList();

                }
                else if(cmbPayment.SelectedIndex == 1) {
                    btnCustody.Visibility = System.Windows.Visibility.Visible;
                    lblCustomerCreditAfter.Content =  customerViewModel.customer.credit;
                }
            }
        }

        async private void addInvoice_Click(object sender, RoutedEventArgs e) {
            //if (await invoiceViewModel.AddNewInvoice(HelperClass.POSInvoiceID, (int)cmbServiceType.SelectedValue, (int)cmbBranches.SelectedValue, HelperClass.POSSelectedCustomerID, isfull, decimal.Parse(txtPaidPrice.Text), (decimal)deliveryPrice, true, DateTime.Now)) {
            //    MessageBox.Show("تم الحفظ");
            //    UpdateMainList.DynamicInvoke();
            //    this.Close();

            //}
        }
    }
}
