using OnTheFlyWPFC.Model.DTO;
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
    /// Interaction logic for CustomerAddMiniWindow.xaml
    /// </summary>
    public partial class CustomerAddMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;


        public CustomerAddMiniWindow()
        {
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            InitializeComponent();
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void cmbBranchCities_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();

            cmbBranchCities.ItemsSource = cityViewModel.CityName;
            cmbBranchCities.DisplayMemberPath = "name";
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            customerViewModel = new CustomerViewModel();
            var city = (CityDTO)cmbBranchCities.SelectedValue;


            if (await customerViewModel.AddCustomer(txtCustomerName.Text, txtCustomerPhone1.Text, txtCustomerPhone2.Text, city.cityCode, txtCustomerAddress.Text, decimal.Parse(txtCustomerCredit.Text)))
            {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }


        }
    }
}
