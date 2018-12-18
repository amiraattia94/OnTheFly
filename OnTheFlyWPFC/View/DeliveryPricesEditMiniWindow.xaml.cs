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
    /// Interaction logic for DeliveryServiceEditMiniWindow.xaml
    /// </summary>
    public partial class DeliveryPricesEditMiniWindow : Window
    {

        public Delegate UpdateMainList;

        DeliveryPricesViewModel deliveryPricesViewModel;
        CategoryViewModel categoryViewModel;
        CityViewModel cityViewModel;

        public DeliveryPricesEditMiniWindow()
        {
            InitializeComponent();
            deliveryPricesViewModel = new DeliveryPricesViewModel();
            categoryViewModel = new CategoryViewModel();
            cityViewModel = new CityViewModel();

            deliveryPricesViewModel.GetDeliveryPriceByID(HelperClass.DeliveryPriceID);
            cityViewModel.GetAllCities();


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

            cmbServiceType.SelectedValue = deliveryPricesViewModel.DeliveryPrice.categoryID;
        }

        private void cmbCustomerLocation_Loaded(object sender, RoutedEventArgs e) {
            
            
            cmbCustomerLocation.ItemsSource = cityViewModel.CityName;
            cmbCustomerLocation.DisplayMemberPath = "name";
            cmbCustomerLocation.SelectedValuePath = "cityCode";

            cmbCustomerLocation.SelectedValue = deliveryPricesViewModel.DeliveryPrice.customerLocationCode;


        }

        private void cmbVendorLocation_Loaded(object sender, RoutedEventArgs e) {
            cmbVendorLocation.ItemsSource = cityViewModel.CityName;
            cmbVendorLocation.DisplayMemberPath = "name";
            cmbVendorLocation.SelectedValuePath = "cityCode";

            cmbVendorLocation.SelectedValue = deliveryPricesViewModel.DeliveryPrice.vendorLocationCode;

        }

        private void cmbServiceState_Loaded(object sender, RoutedEventArgs e) {
            if ((bool)deliveryPricesViewModel.DeliveryPrice.status)
                cmbServiceState.SelectedIndex = 0;
            else {
                cmbServiceState.SelectedIndex = 1;
            }
        }

        private void StkEditDeliveryPrice_Loaded(object sender, RoutedEventArgs e) {
            stkEditDeliveryPrice.DataContext = deliveryPricesViewModel.DeliveryPrice;
        }

        async private void Edit(object sender, RoutedEventArgs e) {
            bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());



            if(deliveryPricesViewModel.DeliveryPrice.customerLocationCode == cmbCustomerLocation.SelectedValue.ToString() && deliveryPricesViewModel.DeliveryPrice.vendorLocationCode == cmbVendorLocation.SelectedValue.ToString())
            {
                if (await deliveryPricesViewModel.EditDeliveryPrice(HelperClass.DeliveryPriceID, (int)cmbServiceType.SelectedValue, cmbCustomerLocation.SelectedValue.ToString(), cmbVendorLocation.SelectedValue.ToString(), decimal.Parse(txtFullPrice.Text), decimal.Parse(txtHalfPrice.Text), status))
                {
                    MessageBox.Show("تم الحفظ");
                    UpdateMainList.DynamicInvoke();
                    this.Close();
                }
            }
            else
            {
                if (!await deliveryPricesViewModel.CheckDeliveryExists((int)cmbServiceType.SelectedValue, cmbCustomerLocation.SelectedValue.ToString(), cmbVendorLocation.SelectedValue.ToString()))
                {
                    if (await deliveryPricesViewModel.EditDeliveryPrice(HelperClass.DeliveryPriceID, (int)cmbServiceType.SelectedValue, cmbCustomerLocation.SelectedValue.ToString(), cmbVendorLocation.SelectedValue.ToString(), decimal.Parse(txtFullPrice.Text), decimal.Parse(txtHalfPrice.Text), status))
                    {
                        MessageBox.Show("تم الحفظ");
                        UpdateMainList.DynamicInvoke();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("هدا العرض موجود مسبقا");
                }
            }


            


        }
    }
}
