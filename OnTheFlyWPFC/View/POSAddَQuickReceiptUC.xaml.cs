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
    /// Interaction logic for POSAddReceiptUC.xaml
    /// </summary>
    public partial class POSAddQuickReceiptUC : UserControl
    {
        InvoiceViewModel invoiceViewModel;
        CityViewModel cityViewModel;
        CustomerViewModel customerViewModel;
        JobsViewModel jobsViewModel;
        EmployeeViewModel employeeViewModel;
        FinanceViewModel financeViewModel;

        public Delegate UpdateMainUC;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        int? custodyID = null;
        decimal totalPriceAfter;
        decimal totalDeliveryPriceAfter;


        public POSAddQuickReceiptUC()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();
            cityViewModel = new CityViewModel();
            customerViewModel = new CustomerViewModel();
            jobsViewModel = new JobsViewModel();
            employeeViewModel = new EmployeeViewModel();
            financeViewModel = new FinanceViewModel();
            //invoiceViewModel.AddNewInvoice();

            invoiceViewModel.GetNewInvoiceID();
            btnAddService.Visibility = System.Windows.Visibility.Hidden;
            //btnCustody.Visibility = System.Windows.Visibility.Hidden;

            //lblCustomerCredit.Content = 0;
            //lblCustomerCreditAfter.Content = 0;
            
            
        }

        private void LblNewInvoice_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.GetNewInvoiceID();
            lblNewInvoice.Content = invoiceViewModel.invoiceNewID.ToString("D8");
        }

        private void LblDate_Loaded(object sender, RoutedEventArgs e) {
            lblDate.Content = DateTime.Now.ToShortDateString();
        }

        private void cmbCities_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbCities.ItemsSource = cityViewModel.CityName;
            cmbCities.DisplayMemberPath = "name";
            cmbCities.SelectedValuePath = "cityCode";
        }

        private void LblEmployeeName_Loaded(object sender, RoutedEventArgs e) {
            lblEmployeeName.Content = HelperClass.LoginEmployeeName;
        }

        private void CmbDriver_Loaded(object sender, RoutedEventArgs e) {

            employeeViewModel.GetActiveEmployeeByJobID(2);

            cmbDriver.ItemsSource = employeeViewModel.ViewEmployees;
            cmbDriver.DisplayMemberPath = "name";
            cmbDriver.SelectedValuePath = "employeeID";


            //cityViewModel.GetAllCities();
            //cmbCities.ItemsSource = cityViewModel.CityName;
            //cmbCities.DisplayMemberPath = "name";
            //cmbCities.SelectedValuePath = "cityCode";
        }

        private void BtnCustomerSearch_Click(object sender, RoutedEventArgs e) {
            var newwindow = new POSAddReceipetSearchCustomerMiniWindow();

            RefreshListEvent += new RefreshList(RefreshCustomerInfo);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
            invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);

            RefreshDeliveryServiceList();
            RefreshCustomerInfo();

            if (HelperClass.POSSelectedCustomerID != 0)
                btnAddService.Visibility = System.Windows.Visibility.Visible;



        }

        void RefreshCustomerInfo() {
            customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);

            txtCustomerName.Text = customerViewModel.customer.name;
            //txtCustomerPhone.Text = customerViewModel.customer.phone1;
            //txtCustomerPhone2.Text = customerViewModel.customer.phone2;
            txtCustomerAddress.Text = customerViewModel.customer.address;
            //txtCities.Text = customerViewModel.customer.city;
            //lblCustomerCredit.Content = customerViewModel.customer.credit;
            //lblCustomerCreditAfter.Content = customerViewModel.customer.credit - decimal.Parse(lblTotalAfter.Content.ToString());

            //cmbPayment.SelectedIndex = 0;
          

            //invoiceViewModel.DeleteAllDeliveryServiceByinvoice(invoiceViewModel.invoiceNewID);

            RefreshInvoicePriceList();

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
            //lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
        }

        private void Edit_Service(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as DeliveryServiceDTO;
            HelperClass.POSSelectedDeliveryServiceID = a.deliverServiceID;
            HelperClass.POSInvoiceID = invoiceViewModel.invoiceNewID;

            var newwindow = new POSEditServiceMiniWindow();
            RefreshListEvent += new RefreshList(RefreshDeliveryServiceList);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void RefreshDeliveryServiceList() {
            invoiceViewModel.GetAllDeliveryServices();
            //lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
            //lstViewDeliveryServices.Items.Refresh();

            RefreshInvoicePriceList();
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

        async private void RefreshInvoicePriceList() {
            invoiceViewModel.GetTotalPriceByInvoiceID(HelperClass.POSInvoiceID);
            invoiceViewModel.GetTotalDeliveryPriceByInvoiceID(HelperClass.POSInvoiceID);
            lblTotalPrice.Content = invoiceViewModel.totalPrice;
            lblTotalDeliveryPrice.Content = invoiceViewModel.deliveryPrice;

            if (custodyID != null) {
                if (await invoiceViewModel.DeleteCustody((int)custodyID)) {

                }
                custodyID = null;
                //cmbPayment.SelectedIndex = 0;


            }

            //0913716521

            if (!string.IsNullOrEmpty(txtDiscount.Text) && txtDiscount.Text != "" && invoiceViewModel.totalPrice != null) {
                decimal discountpercent = decimal.Parse(txtDiscount.Text) / 100;
                //decimal total = discountpercent * (decimal)invoiceViewModel.totalPrice;
                decimal total = discountpercent * (decimal)invoiceViewModel.deliveryPrice;
                totalDeliveryPriceAfter = (decimal)invoiceViewModel.deliveryPrice - total;
                totalPriceAfter = (decimal)invoiceViewModel.totalPrice - total;
                lblTotalAfter.Content = (decimal)invoiceViewModel.totalPrice - total;


                //if (cmbPayment.SelectedIndex != 1) {

                //    lblCustomerCreditAfter.Content = customerViewModel.customer.credit - (decimal)invoiceViewModel.totalPrice - total;

                //}
            }
            else {
                if (lblTotalPrice.Content == null) {
                    lblTotalAfter.Content = 0;
                    totalPriceAfter = 0;
                    totalDeliveryPriceAfter = 0;
                    //lblCustomerCreditAfter.Content = customerViewModel.customer.credit;
                }
                else {
                    lblTotalAfter.Content = invoiceViewModel.totalPrice;
                    try {
                        totalPriceAfter = (decimal)invoiceViewModel.totalPrice;
                    }
                    catch (Exception) {

                        
                    }
                    try {
                        totalDeliveryPriceAfter = (decimal)invoiceViewModel.deliveryPrice;

                    }
                    catch (Exception) {

                        
                    }

                    //if (cmbPayment.SelectedIndex != 1) {
                    //    lblCustomerCreditAfter.Content = customerViewModel.customer.credit - invoiceViewModel.totalPrice;
                    //}
                    
                }
            }
                

            if (invoiceViewModel.totalPrice == null) {
                lblTotalPrice.Content = "0";
                lblTotalDeliveryPrice.Content = "0";
                lblTotalAfter.Content = "0";
                txtDiscount.Text = "0";
                totalPriceAfter = 0;
                totalDeliveryPriceAfter = 0;
            }
        }


        //async private void AddCostody(object sender, RoutedEventArgs e) {
        //    if (custodyID == null) {
        //        custodyID = await invoiceViewModel.AddCustodyInt((int)cmbDriver.SelectedValue, totalPriceAfter, false, HelperClass.POSInvoiceID);
        //        if (custodyID != null) {
        //            MessageBox.Show("تم الحفظ");
        //            return;
        //        }

        //    }
        //    MessageBox.Show("توجد عهدة سابقة");

        //}

        //private void CmbPayment_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        //    if(cmbPayment.SelectedIndex != -1) {
        //        if(cmbPayment.SelectedIndex == 0){
        //            //btnCustody.Visibility = System.Windows.Visibility.Hidden;
        //            RefreshInvoicePriceList();
        //            if (invoiceViewModel.totalPrice != null) {
        //                if (!string.IsNullOrEmpty(txtDiscount.Text)) {
        //                    if (txtDiscount.Text != "") {
        //                        decimal discountpercent = decimal.Parse(txtDiscount.Text) / 100;
        //                        //decimal totalDiscount = discountpercent * (decimal)invoiceViewModel.totalPrice;

        //                        //decimal totalDiscount = discountpercent * (decimal)invoiceViewModel.totalPrice;
        //                        //decimal total = discountpercent * (decimal)invoiceViewModel.totalPrice;
        //                        decimal total = discountpercent * (decimal)invoiceViewModel.deliveryPrice;
        //                        totalDeliveryPriceAfter = (decimal)invoiceViewModel.deliveryPrice - total;
        //                        totalPriceAfter = (decimal)invoiceViewModel.totalPrice - total;
        //                        lblTotalAfter.Content = (decimal)invoiceViewModel.totalPrice - total;

                                

        //                        if (cmbPayment.SelectedIndex != 1) {
        //                            lblCustomerCreditAfter.Content = customerViewModel.customer.credit - totalPriceAfter;

        //                        }
        //                    }

        //                }
        //            }
        //        }
        //        else if(cmbPayment.SelectedIndex == 1) {
                    
        //            //btnCustody.Visibility = System.Windows.Visibility.Visible;
        //            lblCustomerCreditAfter.Content =  customerViewModel.customer.credit;
        //        }
        //    }
        //}

        async private void addInvoice_Click(object sender, RoutedEventArgs e) {

            if (HelperClass.userGroupRoleDTO.add_POS) {
                if (cmbDriver.SelectedIndex == -1) {
                    MessageBox.Show("يجب اضافة سائق  ");
                    return;
                }
                if(totalPriceAfter < 0) {
                    MessageBox.Show("لايمكن تخزين قيمة سالبة");
                    return;
                }
                if(txtDiscount.Text == "") {
                    txtDiscount.Text = "0";
                }
                
                int? carID = null;
                DateTime? enddate = null;
                int? deliveryID = null;

                //try {
                //    deliveryID = await invoiceViewModel.AddDeliveryInt(carID, (int)cmbDriver.SelectedValue, DateTime.Now, enddate, 1, firstdate, lastdate, HelperClass.POSInvoiceID);
                //} 
                //catch (Exception) {
                //    MessageBox.Show("لم يتم الحفظ");
                //    return;
                //}
                custodyID = await invoiceViewModel.AddCustodyInt((int)cmbDriver.SelectedValue, totalPriceAfter, false, HelperClass.POSInvoiceID);

                if (await invoiceViewModel.AddInvoice(HelperClass.LoginUserID, null , decimal.Parse(txtDiscount.Text), null , totalPriceAfter, totalDeliveryPriceAfter, null )) {
                    MessageBox.Show("تم الحفظ");

                    bool isfull = true;
                    if (cmbIsFull.SelectedIndex == 0)
                        isfull = true;
                    if (cmbIsFull.SelectedIndex == 1)
                        isfull = false;


                    await invoiceViewModel.AddQuickDeliveryService(HelperClass.POSInvoiceID, txtCustomerName.Text, int.Parse(txtCustomerPhone1.Text), (string)cmbCities.SelectedValue, txtCustomerAddress.Text, txtCategoryName.Text, txtDistination.Text, isfull);

                    //if(custodyID  == null) {
                    //    if (await financeViewModel.AddFinance(false, totalPriceAfter, " خصم من حساب " + txtCustomerName.Text  + "فاتورة رقم " + HelperClass.POSInvoiceID , HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now)) {
                    //        //MessageBox.Show("تم الحفظ");
                    //    }
                    //}else 
                    
                    if (custodyID != null) {
                        if (await financeViewModel.AddFinance(false, totalPriceAfter, "فاتورة رقم " + HelperClass.POSInvoiceID + " لي  " + txtCustomerName.Text +  " عهدة رقم  " + custodyID, HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now)) {
                            //MessageBox.Show("تم الحفظ");
                        }
                    }
                    //if (await financeViewModel.AddFinance(false, totalPriceAfter, "فاتورة رقم " + HelperClass.POSInvoiceID + " لي  " + txtCustomerName.Text, HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now)) {
                    //   //MessageBox.Show("تم الحفظ");
                    //}
                    if (await financeViewModel.AddFinance(true, totalDeliveryPriceAfter, "فاتورة رقم " + HelperClass.POSInvoiceID + " لي  " + txtCustomerName.Text, HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now)) {
                        //MessageBox.Show("تم الحفظ");
                    }
                    //if (cmbPayment.SelectedIndex == 0) {
                    //    if (await customerViewModel.RemoveCreditFromCustomer(HelperClass.POSSelectedCustomerID, totalPriceAfter)) {
                    //    }
                    //}

                    HelperClass.POSInvoiceIDView = HelperClass.POSInvoiceID;
                    var printreport = new CrystalReportView();
                    printreport.ShowDialog();
                    //UpdateMainUC.DynamicInvoke();

                    HelperClass.POSSelectedCustomerID = 0;
                    HelperClass.POSInvoiceID = 0;
                    HelperClass.POSSelectedDeliveryServiceID = 0;
                    customerViewModel.GetCustomerByID(HelperClass.POSSelectedCustomerID);

                    invoiceViewModel.GetNewInvoiceID();
                    invoiceViewModel.GetNewInvoiceID();

                    lblNewInvoice.Content = invoiceViewModel.invoiceNewID.ToString("D8");
                    invoiceViewModel.GetAllDeliveryServices();
                    //lstViewDeliveryServices.ItemsSource = invoiceViewModel.allDeliveryService;
                    txtCustomerName.Text = "اسم المستخدم";
                    //txtCustomerPhone.Text = "رقم الهاتف";
                    //txtCustomerPhone2.Text = "رقم الهاتف";
                    //txtCities.Text = "المدينة";
                    txtCustomerAddress.Text = "العنوان";
                    //lblCustomerCredit.Content = 0;
                    //lblCustomerCreditAfter.Content = 0;
                    txtDiscount.Text = null;
                    cmbDriver.SelectedIndex = -1;
                    //RefreshDeliveryServiceList();
                    RefreshInvoicePriceList();

                }
                else {

                }
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            
        }

        private void CmbPayment_Loaded(object sender, RoutedEventArgs e) {
            //cmbPayment.SelectedIndex = 0;
        }

        private void TxtPaidPrice_TextChanged(object sender, TextChangedEventArgs e) {
            refreshPrice();
        }

        private void TxtDeliveryPrice_TextChanged(object sender, TextChangedEventArgs e) {
            refreshPrice();
        }


        private void TxtDiscount_TextChanged(object sender, TextChangedEventArgs e) {
            refreshPrice();
        }

        private void refreshPrice(){
            try {
                if (string.IsNullOrWhiteSpace(txtPaidPrice.Text))
                    txtPaidPrice.Text = "0";
                if (string.IsNullOrWhiteSpace(txtDeliveryPrice.Text))
                    txtDeliveryPrice.Text = "0";
                lblTotalPrice.Content = decimal.Parse(txtPaidPrice.Text) + decimal.Parse(txtDeliveryPrice.Text);
                lblTotalDeliveryPrice.Content = decimal.Parse(txtDeliveryPrice.Text);
                decimal discountpercent = decimal.Parse(txtDiscount.Text) / 100;
                decimal total = (discountpercent * decimal.Parse(txtDeliveryPrice.Text));
                decimal totaldelivery = decimal.Parse(txtDeliveryPrice.Text) - total;
                lblTotalAfter.Content = decimal.Parse(txtPaidPrice.Text) + totaldelivery;

            }
            catch (Exception) {

                
            }

        }
    }
}
