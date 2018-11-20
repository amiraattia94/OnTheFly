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
        //public event RefreshList RefreshListEvent;


        public CustomerViewUC() {

            InitializeComponent();

            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();


        }

        private void RefreshListView() {
            //branchViewModel.GetAllBranches();
            //lstViewBraches.ItemsSource = branchViewModel.ViewBranch;
            //lstViewBraches.Items.Refresh();

        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e) {
            var newwindow = new CustomerAddMiniWindow();

            //RefreshListEvent += new RefreshList(RefreshListView);
            //newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        private void lstviewCustomers_Loaded(object sender, RoutedEventArgs e) {
            customerViewModel.GetAllCustomers();
            lstviewCustomers.ItemsSource = customerViewModel.ViewCustomers;
        }

        private void EditCustomer(object sender, RoutedEventArgs e) {

        }

        private void DeleteCustomer(object sender, RoutedEventArgs e) {

        }
    }
}
