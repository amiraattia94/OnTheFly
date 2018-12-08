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
    /// Interaction logic for CustomerViewUC.xaml
    /// </summary>
    public partial class CustomerViewUC : UserControl
    {

        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;
        FinanceViewModel financeViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;


        public CustomerViewUC()
        {

            InitializeComponent();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            financeViewModel = new FinanceViewModel();
        }

        private void RefreshListView()
        {
            customerViewModel.GetAllCustomers();
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
            lstviewCustomers.Items.Refresh();
        }



        private void lstviewCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            customerViewModel.GetAllCustomers();
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
        }

        private void cmbCustomerCity_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();
            cmbCustomerCity.ItemsSource = cityViewModel.CityName;
            cmbCustomerCity.DisplayMemberPath = "name";


        }

        private void cmbCustomerCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbCustomerCity.SelectedIndex != -1)
            {
                var selectedcity = (CityDTO)cmbCustomerCity.SelectedItem;
                customerViewModel.GetCustomerByCity(selectedcity.cityCode);
                lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
                lstviewCustomers.Items.Refresh();

                txtSearchCustomerName.Text = "";
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_customer) {

                var newwindow = new CustomerAddMiniWindow();
                RefreshListEvent += new RefreshList(RefreshListView);
                newwindow.UpdateMainList = RefreshListEvent;
                newwindow.ShowDialog();
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_customer) {

                Button button = sender as Button;
                var a = button.CommandParameter as CustomerDTO;
                HelperClass.Customer = a.customerID;

                var newwindow = new CustomerEditMiniWindow();

                RefreshListEvent += new RefreshList(RefreshListView);
                newwindow.UpdateMainList = RefreshListEvent;

                newwindow.ShowDialog();
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        async private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.delete_customer) {
                Button button = sender as Button;
                var a = button.CommandParameter as CustomerDTO;
                HelperClass.Customer = a.customerID;

                customerViewModel.GetCustomerByID(a.customerID);
                if (await customerViewModel.DeleteCustomerByID(a.customerID)) {
                    if (await financeViewModel.AddFinance(false, (decimal)customerViewModel.customer.credit, "مسح رصيد مع زبون " + customerViewModel.customer.name, HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now))
                        MessageBox.Show("تم المسح بنجاح");
                }

                customerViewModel.customer = null;

                RefreshListView();
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }


        }

        private void TxtSearchCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbSearchType.SelectedIndex == 0)
            {
                customerViewModel.GetCustomerByName(txtSearchCustomerName.Text);
                lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
                lstviewCustomers.Items.Refresh();
                cmbCustomerCity.SelectedIndex = -1;
            }
            if (cmbSearchType.SelectedIndex == 1)
            {
                customerViewModel.GetCustomerByMembershipID(txtSearchCustomerName.Text);
                lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
                lstviewCustomers.Items.Refresh();
                cmbCustomerCity.SelectedIndex = -1;
            }


        }

        private void Memberships(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_customer) {

                Button button = sender as Button;
                var a = button.CommandParameter as CustomerDTO;
                HelperClass.Customer = a.customerID;

                var newwindow = new CustomerMembershipMiniWindow();

                RefreshListEvent += new RefreshList(RefreshListView);
                newwindow.UpdateMainList = RefreshListEvent;

                newwindow.ShowDialog();
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }


        }

        private void TxtMembershipCount_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
