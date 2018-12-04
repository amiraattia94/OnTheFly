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
    /// Interaction logic for CustomerEditMiniWindow.xaml
    /// </summary>
    public partial class CustomerEditMiniWindow : Window
    {
        public Delegate UpdateMainList;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;
        FinanceViewModel financeViewModel;
        decimal oldmoney;

        public CustomerEditMiniWindow()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            financeViewModel = new FinanceViewModel();
            customerViewModel.GetCustomerByID(HelperClass.Customer);

        }

        private void cmbcustomerCities_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();

            cmbcustomerCities.ItemsSource = cityViewModel.CityName;
            cmbcustomerCities.DisplayMemberPath = "name";

            foreach (CityDTO city in cmbcustomerCities.Items)
            {
                if (city.name == customerViewModel.customer.city)
                {
                    cmbcustomerCities.SelectedValue = city;
                    break;
                }
            }

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



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var city = (CityDTO)cmbcustomerCities.SelectedValue;

            

            if (await customerViewModel.EditCustomer(HelperClass.Customer, txtCustomerName.Text, txtCustomerPhone1.Text, txtCustomerPhone2.Text, city.cityCode, txtCustomerAddress.Text, decimal.Parse(txtCustomerCredit.Text)))
            {
                if(await financeViewModel.AddFinance(false,oldmoney,"تعديل رصيد زبون  " + customerViewModel.customer.name ,HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now))
                    if(await financeViewModel.AddFinance(true, decimal.Parse(txtCustomerCredit.Text), "تعديل رصيد زبون  " + customerViewModel.customer.name,HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now))
                        MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();

            }

        }

        private void StkCustomerEdit_Loaded(object sender, RoutedEventArgs e)
        {
            customerViewModel.GetCustomerByID(HelperClass.Customer);
            stkCustomerEdit.DataContext = customerViewModel.customer;
            oldmoney = (decimal)customerViewModel.customer.credit;
        }
    }
}
