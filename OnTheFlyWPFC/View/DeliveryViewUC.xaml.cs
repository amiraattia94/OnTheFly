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
    /// Interaction logic for DeliveryViewUC.xaml
    /// </summary>
    public partial class DeliveryViewUC : UserControl
    {
        public delegate void RefreshList();
        //public event RefreshList RefreshListEvent;

        InvoiceViewModel invoiceViewModel;
        DeliveryStatusViewModel deliveryStatusViewModel;

        public DeliveryViewUC()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();
            deliveryStatusViewModel = new DeliveryStatusViewModel();
        }

        private void BtnSearchDeliveryView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lstdelivery_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.GetAllDelivery();
            lstdelivery.ItemsSource = invoiceViewModel.allDelivery;

        }


        private void EditDelivery(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryDTO;
            HelperClass.DeliveryID = a.deliveryID;

            var newwindow = new DeliveryViewEditMiniWindow();

            //RefreshListEvent += new RefreshList(RefreshListView);
            //newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();

            invoiceViewModel.GetAllDelivery();
            lstdelivery.ItemsSource = invoiceViewModel.allDelivery;
        }

        private void RefreshListView() {
            invoiceViewModel.GetAllDelivery();
            lstdelivery.ItemsSource = invoiceViewModel.allDelivery;
        }



        private void CmbdeliveryStatus_Loaded(object sender, RoutedEventArgs e) {
            deliveryStatusViewModel.GetAllDeliveryStatus();
            cmbdeliveryStatus.ItemsSource = deliveryStatusViewModel.allDeliveryStatus;
            cmbdeliveryStatus.DisplayMemberPath = "name";
            cmbdeliveryStatus.SelectedValuePath = "statusID";
        }

        private void CmbdeliveryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbdeliveryStatus.SelectedIndex != -1) {
                invoiceViewModel.GetAllDeliveryByStatus((int)cmbdeliveryStatus.SelectedValue);
                lstdelivery.ItemsSource = invoiceViewModel.allDelivery;
            }
        }
    }
}
