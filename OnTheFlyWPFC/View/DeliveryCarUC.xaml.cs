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

        VehicleViewModel vehicleViewModel;
        BranchViewModel BranchViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        public DeliveryCarUC()
        {
            InitializeComponent();
            vehicleViewModel = new VehicleViewModel();
            BranchViewModel = new BranchViewModel();

            RefreshListView();
        }

        private void RefreshListView()
        {
            vehicleViewModel.GetAllVehicles();
            lstCarView.ItemsSource = vehicleViewModel.viewVehicles;
            lstCarView.Items.Refresh();
        }

        private void BtnSearchDeliveryCars_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbCarType_Loaded(object sender, RoutedEventArgs e)
        {
            vehicleViewModel.GetAllVehicleType();
            cmbCarType.ItemsSource = vehicleViewModel.viewVehicleType;
            cmbCarType.DisplayMemberPath = "vehicleTName";
            cmbCarType.SelectedValuePath = "vehicleTID";

        }

        private void CmbCarType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCarType.SelectedIndex != -1)
            {
                var selectedcity = (VehicleTypeDTO)cmbCarType.SelectedItem;
                vehicleViewModel.GetVehicleByType(selectedcity.vehileTID);
                lstCarView.ItemsSource = vehicleViewModel.viewVehicles;
                lstCarView.Items.Refresh();

                txtSearchPlateNumber.Text = "";
            }
        }

        private void TxtSearchPlateNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            vehicleViewModel.GetVehicleByPlate(txtSearchPlateNumber.Text);
            lstCarView.ItemsSource = vehicleViewModel.viewVehicles;
            lstCarView.Items.Refresh();
            cmbCarType.SelectedIndex = -1;
        }

        private void LstCarView_Loaded(object sender, RoutedEventArgs e)
        {
            lstCarView.ItemsSource = vehicleViewModel.viewVehicles;
            lstCarView.Items.Refresh();
        }

        async private void Delete_Car(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as VehicleDTO;
            HelperClass.Customer = a.vehicleID;

            if (await vehicleViewModel.DeleteVehicleByID(a.vehicleID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();
        }

        private void Edit_Car(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as VehicleDTO;
            HelperClass.CarID = a.vehicleID;

            var newwindow = new DeliveryCarEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            var newwindow = new DeliveryCarAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }
    }
}
