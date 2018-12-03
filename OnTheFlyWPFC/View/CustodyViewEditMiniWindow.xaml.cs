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
    /// Interaction logic for CustodyViewEditMiniWindow.xaml
    /// </summary>
    public partial class CustodyViewEditMiniWindow : Window
    {

        InvoiceViewModel invoiceViewModel;
        FinanceViewModel financeViewModel;
        bool status;

        public Delegate UpdateMainList;


        public CustodyViewEditMiniWindow()
        {
            InitializeComponent();
            invoiceViewModel = new InvoiceViewModel();
            financeViewModel = new FinanceViewModel();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void StkCustody_Loaded(object sender, RoutedEventArgs e) {
            invoiceViewModel.GetCustodyByID(HelperClass.CustodyID);
            txtcustodyID.Text = invoiceViewModel.Custody.custodyID.ToString();   
            txtowner.Text = invoiceViewModel.Custody.ownerName.ToString();   
            txtgiver.Text = invoiceViewModel.Custody.giverName.ToString();   
            txtinvoice.Text = invoiceViewModel.Custody.invoiceID.ToString();   
            txtammount.Text = invoiceViewModel.Custody.amount.ToString();

            if (invoiceViewModel.Custody.actve) {
                cmbstate.SelectedIndex = 1;
                cmbstate.IsEnabled = false;

            }
            else if(!invoiceViewModel.Custody.actve) {
                cmbstate.SelectedIndex = 0;
            }
        }

        async private void editcustody(object sender, RoutedEventArgs e) {

            if (cmbstate.SelectedIndex == 1)
                status = true;
            if (cmbstate.SelectedIndex == 0)
                status = false;
            if(cmbstate.SelectedIndex != 0) {
                if (invoiceViewModel.Custody.actve) {
                    MessageBox.Show("لا يمكن تعديل بعد اقفال العهدة");
                    this.Close();
                    return;
                }
                if (await invoiceViewModel.EditCustody(HelperClass.CustodyID, status)) {
                    if(await financeViewModel.AddFinance(true, invoiceViewModel.Custody.amount,"اغلاق عهدة رقم "+ invoiceViewModel.Custody.custodyID,HelperClass.LoginEmployeeID, HelperClass.LoginEmployeeName, DateTime.Now)) {
                        MessageBox.Show("تم الحفظ");

                        UpdateMainList.DynamicInvoke();
                        this.Close();
                    }
                    
                }
            }

        }
    }
}
