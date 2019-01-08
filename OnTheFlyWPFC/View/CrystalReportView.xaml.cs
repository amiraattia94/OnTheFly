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
using System.Windows.Shapes;

namespace OnTheFlyWPFC.View {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CrystalReportView : Window {
        InvoiceViewModel invoiceViewModel;

        public CrystalReportView() {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();

            invoiceViewModel.GetAllDeliveryServicesByInvoice2(HelperClass.POSInvoiceIDView);
            invoiceViewModel.GetInvoiceByID(HelperClass.POSInvoiceIDView);


            //ReportDocument rDoc = new ReportDocument();
            //rDoc.Load(@"C:\Users\Altah3r\Documents\GitHub\OnTheFly\OnTheFlyWPFC\View\CrystalReport1.rpt");

            // Do whatever else you need to setup rDoc here
            // SetDatabaseLogon, VerifyDatabase, Set ParameterFields, etc.
            //rDoc.SetDataSource(invoiceViewModel.allDeliveryService2);
            //rDoc.SetParameterValue("pInvoiceID", invoiceViewModel.Invoice.invoiceID.ToString());
            //rDoc.SetParameterValue("pCustomerName", invoiceViewModel.Invoice.customername);
            //rDoc.SetParameterValue("pCustomerAddress", invoiceViewModel.Invoice.customerAddress);
            //rDoc.SetParameterValue("pCustomerPhone1", invoiceViewModel.Invoice.phone1);
            //rDoc.SetParameterValue("pCustomerPhone2", invoiceViewModel.Invoice.phone2);
            //rDoc.SetParameterValue("pInvoiceDate", invoiceViewModel.Invoice.dateTime);
            //rDoc.SetParameterValue("pImployeeName", invoiceViewModel.Invoice.issuerName);
            //rDoc.SetParameterValue("pDriverName", invoiceViewModel.Invoice.DriverName);
            //var a0 = invoiceViewModel.Invoice.discount.ToString("#.##");
            //rDoc.SetParameterValue("pDiscoundPercent", (a0 + "%"));
            //rDoc.SetParameterValue("pTotalPrice", invoiceViewModel.Invoice.totalafter);

            //CrystalViewr.ViewerCore.ReportSource = rDoc;
            //// Find out what the Default Printer Name is
            ////rDoc.PrintOptions.PrinterName = "Default Printer Name";
            //try {
            //    rDoc.PrintToPrinter(1, false, 0, 0);

            //}
            //catch (Exception) {

            //}




        }

        private void CrystalViewr_Loaded(object sender, RoutedEventArgs e) {

            try {
                CrystalReport1 crystalReport = new CrystalReport1();
                crystalReport.Load(@"CrystalReport1.rep");

                /*string.IsNullOrWhiteSpace(invoiceViewModel.Invoice.customername)*/
                if (invoiceViewModel.Invoice.customerID == null) {
                    invoiceViewModel.GetQuickDeliveryInvoiceByID(HelperClass.POSInvoiceIDView);
                    invoiceViewModel.GetQuickDeliveryServiceByID(HelperClass.POSInvoiceIDView);

                    invoiceViewModel.allDeliveryService2.Clear();
                    var result = invoiceViewModel.allDeliveryService.SingleOrDefault(w => w.InvoiceID == HelperClass.POSInvoiceIDView);
                    invoiceViewModel.allDeliveryService2.Add(new Model.DTO.DeliveryServiceDTO2() {
                        CategoryName = result.CategoryName,
                        VendorName = result.VendorName,
                        VendorCityname = result.VendorCityname,
                        deliveryPrice = result.deliveryPrice,
                        productPrice = (decimal)result.productPrice,
                    });

                    crystalReport.SetDataSource(invoiceViewModel.allDeliveryService2);
                    crystalReport.SetParameterValue("pInvoiceID", invoiceViewModel.Invoice.invoiceID.ToString());
                    crystalReport.SetParameterValue("pCustomerName", invoiceViewModel.Invoice.customername);
                    crystalReport.SetParameterValue("pCustomerAddress", invoiceViewModel.Invoice.customerAddress);
                    crystalReport.SetParameterValue("pCustomerPhone1", invoiceViewModel.Invoice.phone1);
                    crystalReport.SetParameterValue("pCustomerPhone2", invoiceViewModel.Invoice.phone2);
                    crystalReport.SetParameterValue("pInvoiceDate", invoiceViewModel.Invoice.dateTime);
                    crystalReport.SetParameterValue("pImployeeName", invoiceViewModel.Invoice.issuerName);
                    crystalReport.SetParameterValue("pDriverName", invoiceViewModel.Invoice.DriverName);
                    crystalReport.SetParameterValue("pTotalBefore", invoiceViewModel.Invoice.totalBefore);
                    var a = invoiceViewModel.Invoice.discount.ToString("0.##");
                    crystalReport.SetParameterValue("pDiscoundPercent", (a + "%"));
                    crystalReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    crystalReport.SetParameterValue("pTotalPrice", invoiceViewModel.Invoice.totalafter);
                    //crystalReport.PrintToPrinter(1, false, 0, 0);
                    CrystalViewr.ViewerCore.ReportSource = crystalReport;
                }
                else {

                    crystalReport.SetDataSource(invoiceViewModel.allDeliveryService2);
                    crystalReport.SetParameterValue("pInvoiceID", invoiceViewModel.Invoice.invoiceID.ToString());
                    crystalReport.SetParameterValue("pCustomerName", invoiceViewModel.Invoice.customername);
                    crystalReport.SetParameterValue("pCustomerAddress", invoiceViewModel.Invoice.customerAddress);
                    crystalReport.SetParameterValue("pCustomerPhone1", invoiceViewModel.Invoice.phone1);
                    crystalReport.SetParameterValue("pCustomerPhone2", invoiceViewModel.Invoice.phone2);
                    crystalReport.SetParameterValue("pInvoiceDate", invoiceViewModel.Invoice.dateTime);
                    crystalReport.SetParameterValue("pImployeeName", invoiceViewModel.Invoice.issuerName);
                    crystalReport.SetParameterValue("pDriverName", invoiceViewModel.Invoice.DriverName);
                    crystalReport.SetParameterValue("pTotalBefore", invoiceViewModel.Invoice.totalBefore);
                    var a = invoiceViewModel.Invoice.discount.ToString("0.##");
                    crystalReport.SetParameterValue("pDiscoundPercent", (a + "%"));
                    crystalReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    crystalReport.SetParameterValue("pTotalPrice", invoiceViewModel.Invoice.totalafter);
                    //crystalReport.PrintToPrinter(1, false, 0, 0);
                    CrystalViewr.ViewerCore.ReportSource = crystalReport;
                }

            }catch {

            }

            






        }



    }
}
