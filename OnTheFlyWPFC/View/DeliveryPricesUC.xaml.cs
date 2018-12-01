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
    /// Interaction logic for DeliveryServicesUC.xaml
    /// </summary>
    public partial class DeliveryPricesUC : UserControl
    {
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        CategoryViewModel categoryViewModel;
        DeliveryPricesViewModel DeliveryPricesViewModel;

        public DeliveryPricesUC()
        {
            InitializeComponent();
            categoryViewModel = new CategoryViewModel();
            DeliveryPricesViewModel = new DeliveryPricesViewModel();
        }

        private void BtnSearchDeliveryService_Click(object sender, RoutedEventArgs e) {

        }

        private void cmbServiceType_Loaded(object sender, RoutedEventArgs e) {
            categoryViewModel.GetAllCategories();
            cmbServiceType.ItemsSource = categoryViewModel.allCategories;
            cmbServiceType.SelectedValuePath = "CategoryID";
            cmbServiceType.DisplayMemberPath = "CategoryName";
        }

        private void cmbServiceState_Loaded(object sender, RoutedEventArgs e) {

        }

        private void cmbServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (cmbServiceType.SelectedIndex != -1) {
                DeliveryPricesViewModel.GetDeliveryPriceByDeliveryCategory((int)cmbServiceType.SelectedValue);
                lstServiceView.ItemsSource = DeliveryPricesViewModel.ViewDeliveryPrices;
                lstServiceView.Items.Refresh();
                cmbServiceState.SelectedIndex = -1;
            }
        }

        private void cmbServiceState_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbServiceState.SelectedIndex != -1) {

                bool SelectedState = false;
                if (cmbServiceState.SelectedIndex == 0)
                    SelectedState = true;
                else if (cmbServiceState.SelectedIndex == 1)
                    SelectedState = false;

                DeliveryPricesViewModel.GetDeliveryPriceByState(SelectedState);
                lstServiceView.ItemsSource = DeliveryPricesViewModel.ViewDeliveryPrices;
                lstServiceView.Items.Refresh();
                cmbServiceType.SelectedIndex = -1;
            }
        }

        private void lstServiceView_Loaded(object sender, RoutedEventArgs e) {
            DeliveryPricesViewModel.GetAllDeliveryPrice();
            lstServiceView.ItemsSource = DeliveryPricesViewModel.ViewDeliveryPrices;
        }

        private void Edit_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryPriceDTO;
            HelperClass.DeliveryPriceID = a.deliveryPriceID;

            var newwindow = new DeliveryPricesEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();

        }

        async private void Delete_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryPriceDTO;
            HelperClass.DeliveryPriceID = a.deliveryPriceID;

            if (await DeliveryPricesViewModel.DeleteDeliveryPriceByID(a.deliveryPriceID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();

        }

        private void AddService(object sender, RoutedEventArgs e) {
            var newwindow = new DeliveryPricesAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void RefreshListView() {
            DeliveryPricesViewModel.GetAllDeliveryPrice();
            lstServiceView.ItemsSource = DeliveryPricesViewModel.ViewDeliveryPrices;
            lstServiceView.Items.Refresh();
        }

    }
}
