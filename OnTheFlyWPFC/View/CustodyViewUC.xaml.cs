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

namespace OnTheFlyWPFC.View {
    /// <summary>
    /// Interaction logic for CustodyViewUC.xaml
    /// </summary>
    public partial class CustodyViewUC : UserControl {

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        InvoiceViewModel invoiceViewModel;

        public CustodyViewUC() {
            InitializeComponent();

            invoiceViewModel = new InvoiceViewModel();
        }

        private void BtnSearchCustody_Click(object sender, RoutedEventArgs e) {

        }

        private void LstViewCustody_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.GetAllCustody();
            lstViewCustody.ItemsSource = invoiceViewModel.allCustody;

        }

        private void CmbState_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbState.SelectedIndex == 0) {
                invoiceViewModel.GetCustodyByState(false);
                lstViewCustody.ItemsSource = invoiceViewModel.allCustody;
            }
            else if (cmbState.SelectedIndex == 1) {
                invoiceViewModel.GetCustodyByState(true);
                lstViewCustody.ItemsSource = invoiceViewModel.allCustody;
            }
        }

        private void EditCustody(object sender, RoutedEventArgs e) {
            if (HelperClass.userGroupRoleDTO.add_custody) {

                Button button = sender as Button;
                var a = button.CommandParameter as CustodyDTO;
                HelperClass.CustodyID = a.custodyID;

                var newwindow = new CustodyViewEditMiniWindow();

                RefreshListEvent += new RefreshList(RefreshListView);
                newwindow.UpdateMainList = RefreshListEvent;

                newwindow.ShowDialog();
                invoiceViewModel.GetAllCustody();
                lstViewCustody.Items.Refresh();
                lstViewCustody.ItemsSource = invoiceViewModel.allCustody;
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        private void RefreshListView() {
            invoiceViewModel.GetAllCustody();
            lstViewCustody.ItemsSource = invoiceViewModel.allCustody;
            lstViewCustody.Items.Refresh();
        }
    }
}

