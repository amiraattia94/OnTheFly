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
    /// Interaction logic for POSViewReceiptUC.xaml
    /// </summary>
    public partial class POSViewReceiptUC : UserControl
    {
        InvoiceViewModel invoiceViewModel;

        public POSViewReceiptUC()
        {
            InitializeComponent();

            invoiceViewModel = new InvoiceViewModel();
        }

        private void LblNewInvoice_TextChanged(object sender, TextChangedEventArgs e) {

            try {
                if(lblNewInvoice.Text != "") {
                    invoiceViewModel.GetInvoiceByID(int.Parse(lblNewInvoice.Text));
                    lblDate.Content = invoiceViewModel.Invoice.dateTime;
                    txtCustomerName.Text = invoiceViewModel.Invoice.customername;
                    txtCustomerPhone.Text = invoiceViewModel.Invoice.phone1;
                    txtCustomerPhone2.Text = invoiceViewModel.Invoice.phone2;
                    txtCities.Text = invoiceViewModel.Invoice.customerCityname;
                    txtCustomerAddress.Text = invoiceViewModel.Invoice.customerAddress;
                    cmbDriver.Text = invoiceViewModel.Invoice.DriverName;
                    lblEmployeeName.Content = invoiceViewModel.Invoice.issuerName;


                    //lstViewDeliveryServices.Items.Clear();
                    invoiceViewModel.GetAllDeliveryServicesByInvoice(int.Parse(lblNewInvoice.Text));
                    lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;


                    lblTotalAfter.Content = invoiceViewModel.Invoice.totalafter;

                    if (invoiceViewModel.Invoice.custodyID == null) {
                        cmbPayment.Content = "رصيد";
                    }
                    else if (invoiceViewModel.Invoice.custodyID != null) {
                        cmbPayment.Content = "عهدة رقم " + invoiceViewModel.Invoice.custodyID;
                    }
                }
                
            }
            catch {

            }
            

        }

        private void LblNewInvoice_Loaded(object sender, RoutedEventArgs e) {

        }

        private void LblDate_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void CmbDriver_Loaded(object sender, RoutedEventArgs e) {

        }

        private void LblEmployeeName_Loaded(object sender, RoutedEventArgs e) {

        }

        private void LstViewDeliveryServices_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Edit_Service(object sender, RoutedEventArgs e) {

        }

        private void Delete_Service(object sender, RoutedEventArgs e) {

        }

        private void TxtDiscount_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void CmbPayment_Loaded(object sender, RoutedEventArgs e) {

        }

        private void CmbPayment_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void addInvoice_Click(object sender, RoutedEventArgs e) {

        }

        private void cmbCities_Loaded(object sender, RoutedEventArgs e) {

        }

        private void PrintInvoice_Click(object sender, RoutedEventArgs e) {

        }


    }
}
