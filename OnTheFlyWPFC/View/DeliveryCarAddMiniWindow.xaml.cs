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
    /// Interaction logic for DeliveryCarAddMiniWindow.xaml
    /// </summary>
    public partial class DeliveryCarAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        VehicleViewModel vehicleViewModel;
        BranchViewModel BranchViewModel;

        public DeliveryCarAddMiniWindow()
        {
            InitializeComponent();
            vehicleViewModel = new VehicleViewModel();
            BranchViewModel = new BranchViewModel();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CmbCarType_Loaded(object sender, RoutedEventArgs e)
        {
            vehicleViewModel.GetAllVehicleType();
            cmbCarType.ItemsSource = vehicleViewModel.viewVehicleType;
            cmbCarType.DisplayMemberPath = "vehicleTName";
            cmbCarType.SelectedValuePath = "vehileTID";
        }

        private void cmbBranchS_Loaded(object sender, RoutedEventArgs e)
        {
            BranchViewModel.GetAllBranches();
            cmbBranchs.ItemsSource = BranchViewModel.ViewBranch;
            cmbBranchs.DisplayMemberPath = "branch_name";
            cmbBranchs.SelectedValuePath = "branchID";
        }

        async private void Save(object sender, RoutedEventArgs e)
        {
            bool status = HelperClass.TrueOrFalse(cmbStatus.SelectedIndex.ToString());

            if (await vehicleViewModel.AddVehicle((int)cmbCarType.SelectedValue, txtPlateNumber.Text, txtCompany.Text, txtModel.Text, int.Parse(txtYear.Text), (int)cmbBranchs.SelectedValue, status))
            {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }
        }
    }
}
