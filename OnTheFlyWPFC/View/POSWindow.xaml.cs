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
    /// Interaction logic for POSWindow.xaml
    /// </summary>
    public partial class POSWindow : Window
    {
        public delegate void RefreshUC();
        public event RefreshUC RefreshUCEvent;


        public POSWindow()
        {
            InitializeComponent();
            usc = new POSAddReceiptUC();
            MainUC.Children.Add(usc);
        }

        UserControl usc = null;
        POSAddReceiptUC uscA = null;

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e) {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            usc = null;
            MainUC.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name) {
                case "POSAddReceipt":
                    uscA = new POSAddReceiptUC();
                    MainUC.Children.Add(uscA);
                    RefreshUCEvent += new RefreshUC(RefreshListView);
                    uscA.UpdateMainUC = RefreshUCEvent;

                    lblMenuename.Content = "نقطة البيع";
                    break;
                case "viewReceipt":
                    usc = new POSReceiptSumUC();
                    MainUC.Children.Add(usc);
                    lblMenuename.Content = "عرض الفواتير";
                    break;
                case "POSSearchReceipt":
                    usc = new POSViewReceiptUC();
                    MainUC.Children.Add(usc);
                    lblMenuename.Content = "البحث عن فاتورة";
                    break;                
                default:
                    break;
            }
        }

        private void RefreshListView() {
            
            uscA = new POSAddReceiptUC();
            MainUC.Children.Add(uscA);

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void btnMaxForm_Click(object sender, RoutedEventArgs e) {
            if (WindowState != WindowState.Maximized) {
                WindowState = WindowState.Maximized;
            }
            else {
                WindowState = WindowState.Normal;
            }


        }

        private void btnMinForm_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

       
        private void btnPOS_Click(object sender, RoutedEventArgs e) {
            var newwindow = new POSWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

        private void btnBranch_Click(object sender, RoutedEventArgs e) {
            var newwindow = new BranchWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }


        private void btnCustomer_Click(object sender, RoutedEventArgs e) {
            var newwindow = new CustomerWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

        private void btnHR_Click(object sender, RoutedEventArgs e) {
            var newwindow = new HRWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

        private void btnCustody_Click(object sender, RoutedEventArgs e) {
            var newwindow = new CustodyWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

        private void btnFinance_Click(object sender, RoutedEventArgs e) {
            var newwindow = new FinanceWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e) {
            var newwindow = new DeliveryWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }

 
        private void POSAddReceipt_Selected(object sender, RoutedEventArgs e) {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult dialog = System.Windows.Forms.MessageBox.Show("هل انت متأكد من رغبتك بتسجيل الخروج", "تسجيل الخروج", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dialog == System.Windows.Forms.DialogResult.Yes)
            {

                var newwindow = new LoginWindow();

                newwindow.Show();
                this.Close();
            }
            else if (dialog == System.Windows.Forms.DialogResult.No)
            {

            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new SettingsWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }
    }
}

