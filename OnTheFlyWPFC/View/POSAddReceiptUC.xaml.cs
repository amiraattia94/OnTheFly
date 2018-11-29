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

        public POSAddReceiptUC()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();

            invoiceViewModel.GetNewInvoiceID();
        }


        private void ADDService_Click(object sender, RoutedEventArgs e) {
            var tempW = new POSAddServiceMiniWindow();
            tempW.ShowDialog();

        }

        private void LblNewInvoice_Loaded(object sender, RoutedEventArgs e) {
            lblNewInvoice.DataContext = invoiceViewModel.invoiceNewID;
        }
    }
}
