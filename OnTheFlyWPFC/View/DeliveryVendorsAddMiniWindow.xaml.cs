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
    /// Interaction logic for DeliveryDestinationAddMiniWindow.xaml
    /// </summary>
    public partial class DeliveryVendorsAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        VendorViewModel vendorViewModel;
        CategoryViewModel categoryViewModel;

        public DeliveryVendorsAddMiniWindow()
        {
            InitializeComponent();
            vendorViewModel = new VendorViewModel();
            categoryViewModel = new CategoryViewModel();    
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

        async private void Save(object sender, RoutedEventArgs e) {
            bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());

            if (await vendorViewModel.AddVendor((int)cmbServiceType.SelectedValue, txtVendorName.Text, status)) {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }
    }
}
