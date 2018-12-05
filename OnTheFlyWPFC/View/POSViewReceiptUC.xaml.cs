using CrystalDecisions.CrystalReports.Engine;
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

                    if(invoiceViewModel.allDeliveryService != null) {
                        HelperClass.POSInvoiceIDView = int.Parse(lblNewInvoice.Text);

                    }
                    else {
                        HelperClass.POSInvoiceIDView = 0;
                    }

                    txtDiscount.Content = invoiceViewModel.Invoice.discount;
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

            //invoiceViewModel = new InvoiceViewModel();

            //invoiceViewModel.GetAllDeliveryServicesByInvoice2(HelperClass.POSInvoiceID);
            //invoiceViewModel.GetInvoiceByID(HelperClass.POSInvoiceID);

            //try {
            //    ReportDocument rDoc = new ReportDocument();


            //    //note change this later to something like System.Windows.Forms.Application.StartupPath + @"";
            //    //rDoc.Load( @"C:\Users\Altah3r\Documents\GitHub\OnTheFly\OnTheFlyWPFC\View\CrystalReport1.rpt");


            //    rDoc.Load(@"C:\Users\Taher\Documents\GitHub\OnTheFly\OnTheFlyWPFC\View\CrystalReport1.rpt");
            //    rDoc.SetDataSource(invoiceViewModel.allDeliveryService2);
            //    rDoc.SetParameterValue("pInvoiceID", invoiceViewModel.Invoice.invoiceID.ToString());
            //    rDoc.SetParameterValue("pCustomerName", invoiceViewModel.Invoice.customername);
            //    rDoc.SetParameterValue("pCustomerAddress", invoiceViewModel.Invoice.customerAddress);
            //    rDoc.SetParameterValue("pCustomerPhone1", invoiceViewModel.Invoice.phone1);
            //    rDoc.SetParameterValue("pCustomerPhone2", invoiceViewModel.Invoice.phone2);
            //    rDoc.SetParameterValue("pInvoiceDate", invoiceViewModel.Invoice.dateTime);
            //    rDoc.SetParameterValue("pImployeeName", invoiceViewModel.Invoice.issuerName);
            //    rDoc.SetParameterValue("pDriverName", invoiceViewModel.Invoice.DriverName);
            //    var a0 = invoiceViewModel.Invoice.discount.ToString("#.##");
            //    rDoc.SetParameterValue("pDiscoundPercent", (a0 + "%"));
            //    rDoc.SetParameterValue("pTotalPrice", invoiceViewModel.Invoice.totalafter);

            //    //CrystalViewr.ViewerCore.ReportSource = rDoc;
            //    //rDoc.PrintOptions.PrinterName = "Default Printer Name";
            //    rDoc.PrintToPrinter(1, false, 0, 0);

            //}
            //catch (Exception) {

            //}


            var printreport = new CrystalReportView();
            printreport.ShowDialog();
        }


    }
}
