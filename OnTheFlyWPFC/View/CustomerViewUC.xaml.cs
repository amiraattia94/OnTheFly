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
    /// Interaction logic for CustomerViewUC.xaml
    /// </summary>
    public partial class CustomerViewUC : UserControl {

        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;


        public CustomerViewUC() {

            InitializeComponent();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
        }

        private void RefreshListView() {
            customerViewModel.GetAllCustomers();
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
            lstviewCustomers.Items.Refresh();
        }



        private void lstviewCustomers_Loaded(object sender, RoutedEventArgs e) {
            customerViewModel.GetAllCustomers();
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
        }


        



        private void cmbCustomerCity_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbCustomerCity.ItemsSource = cityViewModel.CityName;
            cmbCustomerCity.DisplayMemberPath = "name";

            
        }

        private void cmbCustomerCity_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if (cmbCustomerCity.SelectedIndex != -1) {
                var selectedcity = (CityDTO)cmbCustomerCity.SelectedItem;
                customerViewModel.GetCustomerByCity(selectedcity.cityCode);
                lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
                lstviewCustomers.Items.Refresh();
                
                txtSearchCustomerName.Text = "";
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e) {
            var newwindow = new CustomerAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void EditCustomer(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CustomerDTO;
            HelperClass.Customer = a.customerID;

            var newwindow = new CustomerEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        async private void DeleteCustomer(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CustomerDTO;
            HelperClass.Customer = a.customerID;

            if (await customerViewModel.DeleteCustomerByID(a.customerID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();
        }

        private void TxtSearchCustomerName_TextChanged(object sender, TextChangedEventArgs e) {
            customerViewModel.GetCustomerByName(txtSearchCustomerName.Text);
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
            lstviewCustomers.Items.Refresh();
            cmbCustomerCity.SelectedIndex = -1;
            
        }

        private void Memberships(object sender, RoutedEventArgs e) {

        }

        private void TxtMembershipCount_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
