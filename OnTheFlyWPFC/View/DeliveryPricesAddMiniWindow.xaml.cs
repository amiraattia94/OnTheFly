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
using System.Windows.Shapes;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for DeliveryServiceAddMiniWindow.xaml
    /// </summary>
    public partial class DeliveryPricesAddMiniWindow : Window {

        public Delegate UpdateMainList;

        DeliveryPricesViewModel deliveryPricesViewModel;
        CategoryViewModel categoryViewModel;
        CityViewModel cityViewModel;


        public DeliveryPricesAddMiniWindow() {
            InitializeComponent();
            deliveryPricesViewModel = new DeliveryPricesViewModel();
            categoryViewModel = new CategoryViewModel();
            cityViewModel = new CityViewModel();

        }
        
        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
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

        private void cmbCustomerLocation_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbCustomerLocation.ItemsSource = cityViewModel.CityName;
            cmbCustomerLocation.DisplayMemberPath = "name";
            cmbCustomerLocation.SelectedValuePath = "cityCode";

        }

        private void cmbVendorLocation_Loaded(object sender, RoutedEventArgs e) {
            //cityViewModel.GetAllCities();
            cmbVendorLocation.ItemsSource = cityViewModel.CityName;
            cmbVendorLocation.DisplayMemberPath = "name";
            cmbVendorLocation.SelectedValuePath = "cityCode";
        }

        async private void Add(object sender, RoutedEventArgs e) {

            bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());

            if (await deliveryPricesViewModel.AddDeliveryPrice((int)cmbServiceType.SelectedValue,cmbCustomerLocation.SelectedValue.ToString(),cmbVendorLocation.SelectedValue.ToString(),decimal.Parse( txtFullPrice.Text),decimal.Parse( txtHalfPrice.Text), status)) {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }
    }
}
