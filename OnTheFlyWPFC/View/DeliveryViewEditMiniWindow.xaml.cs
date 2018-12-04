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
    /// Interaction logic for DeliveryViewEditMiniWindow.xaml
    /// </summary>
    public partial class DeliveryViewEditMiniWindow : Window
    {
        DeliveryStatusViewModel deliveryStatusViewModel;
        InvoiceViewModel invoiceViewModel;


        public DeliveryViewEditMiniWindow()
        {
            InitializeComponent();

            deliveryStatusViewModel = new DeliveryStatusViewModel();
            invoiceViewModel = new InvoiceViewModel();
        }

        private void CmbChangeStatus_Loaded(object sender, RoutedEventArgs e) {
            deliveryStatusViewModel.GetAllDeliveryStatus();
            cmbChangeStatus.ItemsSource = deliveryStatusViewModel.allDeliveryStatus;
            cmbChangeStatus.DisplayMemberPath = "name";
            cmbChangeStatus.SelectedValuePath = "statusID";

            invoiceViewModel.GetDeliveryByID(HelperClass.DeliveryID);
            cmbChangeStatus.SelectedValue = invoiceViewModel.Delivery.status;

            if (invoiceViewModel.Delivery.status == 4)
                cmbChangeStatus.IsEnabled = false;

        }

        private void CmbChangeStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        async private void Edit(object sender, RoutedEventArgs e) {
            if(cmbChangeStatus.SelectedIndex != 0) {
                if(invoiceViewModel.Delivery.status == 4) {
                    MessageBox.Show("لا يمكن تعديل بعد اانتهاء التوصيل");
                    this.Close();
                    return;
                }
                if (await invoiceViewModel.EditDelivery(HelperClass.DeliveryID, (int)cmbChangeStatus.SelectedValue)) {
                    MessageBox.Show("تم الحفظ");
                    this.Close();
                }
            }
            
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
