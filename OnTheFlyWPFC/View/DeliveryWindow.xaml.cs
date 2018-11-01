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
    /// Interaction logic for DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        public DeliveryWindow()
        {
            InitializeComponent();
            usc = new MainHomeUC();
            MainUC.Children.Add(usc);
        }

        UserControl usc = null;

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
                case "ItemHome":
                    usc = new MainHomeUC();

                    MainUC.Children.Add(usc);
                    break;
                default:
                    break;
            }
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

        private void btnMain_Click(object sender, RoutedEventArgs e) {
            var newwindow = new MainWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
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

        private void btnReports_Click(object sender, RoutedEventArgs e) {
            var newwindow = new ReportsWindow();
            newwindow.WindowState = this.WindowState;
            newwindow.Show();
            this.Close();
        }
    }
}
