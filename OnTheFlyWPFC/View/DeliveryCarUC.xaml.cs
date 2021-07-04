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
    /// Interaction logic for DeliveryCarUC.xaml
    /// </summary>
    public partial class DeliveryCarUC : UserControl
    {

        CarViewModel carViewModel;
        BranchViewModel BranchViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        public DeliveryCarUC()
        {
            InitializeComponent();
            carViewModel = new CarViewModel();
            BranchViewModel = new BranchViewModel();

            RefreshListView();
        }

        private void RefreshListView() {
            carViewModel.GetAllCars();
            lstCarView.ItemsSource = carViewModel.ViewCars;
            lstCarView.Items.Refresh();
        }

        private void BtnSearchDeliveryCars_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbCarType_Loaded(object sender, RoutedEventArgs e) {
            carViewModel.GetAllCarsType();
            cmbCarType.ItemsSource = carViewModel.ViewCarType;
            cmbCarType.DisplayMemberPath = "CarTName";
            cmbCarType.SelectedValuePath = "CarTID";
            
        }

        private void CmbCarType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbCarType.SelectedIndex != -1) {
                var selectedcity = (CarTypeDTO)cmbCarType.SelectedItem;
                carViewModel.GetCarByType(selectedcity.CarTID);
                lstCarView.ItemsSource = carViewModel.ViewCars;
                lstCarView.Items.Refresh();

                txtSearchPlateNumber.Text = "";
            }
        }

        private void TxtSearchPlateNumber_TextChanged(object sender, TextChangedEventArgs e) {
            carViewModel.GetCarByPlate(txtSearchPlateNumber.Text);
            lstCarView.ItemsSource = carViewModel.ViewCars;
            lstCarView.Items.Refresh();
            cmbCarType.SelectedIndex = -1;
        }

        private void LstCarView_Loaded(object sender, RoutedEventArgs e) {
            lstCarView.ItemsSource = carViewModel.ViewCars;
            lstCarView.Items.Refresh();
        }

        async private void Delete_Car(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CarDTO;
            HelperClass.Customer = a.CarID;

            if (await carViewModel.DeleteCarByID(a.CarID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();
        }

        private void Edit_Car(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CarDTO;
            HelperClass.CarID = a.CarID;

            var newwindow = new DeliveryCarEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        private void AddCar(object sender, RoutedEventArgs e) {
            var newwindow = new DeliveryCarAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }
    }
}
