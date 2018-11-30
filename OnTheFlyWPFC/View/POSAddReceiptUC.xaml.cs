﻿using OnTheFlyWPFC.Model.DTO;
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
    /// Interaction logic for POSAddReceiptUC.xaml
    /// </summary>
    public partial class POSAddReceiptUC : UserControl
    {
        InvoiceViewModel invoiceViewModel;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        public POSAddReceiptUC()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();

            invoiceViewModel.AddNewInvoice();
            invoiceViewModel.GetNewInvoiceID();
            ADDService.IsEnabled = false;
        }


        

        private void LblNewInvoice_Loaded(object sender, RoutedEventArgs e) {
            lblNewInvoice.Content = invoiceViewModel.invoiceNewID.ToString("D8");
        }

        private void LblDate_Loaded(object sender, RoutedEventArgs e) {
            lblDate.Content = DateTime.Now.ToShortDateString();
        }

        private void cmbCities_Loaded(object sender, RoutedEventArgs e) {
            //cityViewModel.GetAllCities();
            //cmbCities.ItemsSource = cityViewModel.CityName;
            //cmbCities.DisplayMemberPath = "name";
            //cmbCities.SelectedValuePath = "cityCode";
        }

        private void LblEmployeeName_Loaded(object sender, RoutedEventArgs e) {

        }

        private void CmbDriver_Loaded(object sender, RoutedEventArgs e) {

        }

        private void BtnCustomerSearch_Click(object sender, RoutedEventArgs e) {
            var newwindow = new POSAddReceipetSearchCustomerMiniWindow();

            RefreshListEvent += new RefreshList(RefreshCustomerInfo);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();

            if (HelperClass.POSSelectedCustomerID != 0)
                ADDService.IsEnabled = true;
                

        }

        private void RefreshCustomerInfo() {
            customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);

            txtCustomerName.Text = customerViewModel.customer.name;
            txtCustomerPhone.Text = customerViewModel.customer.phone1;
            txtCustomerPhone2.Text = customerViewModel.customer.phone2;
            txtCustomerAddress.Text = customerViewModel.customer.address;
            txtCities.Text = customerViewModel.customer.city;
            //foreach (CityDTO city in cmbCities.Items) {
            //    if (city.name == customerViewModel.customer.city) {
            //        cmbCities.SelectedValue = city.cityCode;
            //        break;
            //    }
            //}

            //throw new NotImplementedException();
        }

        private void LstViewDeliveryServices_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);
            invoiceViewModel.GetAllDeliveryServices();
            lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;

        }

        private void Edit_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryServiceDTO;
            HelperClass.POSSelectedDeliveryServiceID = a.deliverServiceID;
            HelperClass.POSInvoiceID = invoiceViewModel.invoiceNewID;

            var newwindow = new DeliveryPricesEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshDeliveryServiceList);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();

        }

        private void RefreshDeliveryServiceList() {
            invoiceViewModel.GetAllDeliveryServices();
            lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
            lstViewDeliveryServices.Items.Refresh();
        }

        async private void Delete_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryServiceDTO;
            HelperClass.POSSelectedDeliveryServiceID = a.deliverServiceID;

            if (await invoiceViewModel.DeleteDeliveryServiceByID(a.deliverServiceID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshDeliveryServiceList();

        }

        private void ADDService_Click(object sender, RoutedEventArgs e) {
            
            HelperClass.POSInvoiceID = invoiceViewModel.invoiceNewID;

            var newwindow = new POSAddServiceMiniWindow();
            RefreshListEvent += new RefreshList(RefreshDeliveryServiceList);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();

        }

    }
}
