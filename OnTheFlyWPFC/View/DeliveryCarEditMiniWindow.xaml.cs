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
    /// Interaction logic for DeliveryCarEditMiniWindow.xaml
    /// </summary>
    public partial class DeliveryCarEditMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CarViewModel carViewModel;
        BranchViewModel BranchViewModel;

        public DeliveryCarEditMiniWindow() {
            InitializeComponent();
            carViewModel = new CarViewModel();
            BranchViewModel = new BranchViewModel();
            carViewModel.GetCarByID(HelperClass.CarID);
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CmbCarType_Loaded(object sender, RoutedEventArgs e) {
            carViewModel.GetAllCarsType();
            cmbCarType.ItemsSource = carViewModel.ViewCarType;
            cmbCarType.DisplayMemberPath = "CarTName";
            cmbCarType.SelectedValuePath = "CarTID";

            cmbCarType.SelectedValue = carViewModel.car.CarTypeID;
            //foreach (CarTypeDTO cartype in cmbCarType.Items) {
            //    if (cartype.CarTID == carViewModel.car.CarID) {
            //        cmbCarType.SelectedValue = cartype.CarTID;
            //        break;
            //    }
            //}

        }

        private void cmbBranchS_Loaded(object sender, RoutedEventArgs e) {
            BranchViewModel.GetAllBranches();
            cmbBranchs.ItemsSource = BranchViewModel.ViewBranch;
            cmbBranchs.DisplayMemberPath = "branch_name";
            cmbBranchs.SelectedValuePath = "branchID";

            foreach (BranchDTO branch in cmbBranchs.Items) {
                if (branch.branchID == carViewModel.car.BranshID) {
                    cmbBranchs.SelectedValue = branch.branchID;
                    break;
                }
            }

        }

        private void CmbStatus_Loaded(object sender, RoutedEventArgs e) {
            if (carViewModel.car.State)
                cmbStatus.SelectedIndex = 0;
            else {
                cmbStatus.SelectedIndex = 1;
            }
        }

        private void StkcarEdit_Loaded(object sender, RoutedEventArgs e) {
            //carViewModel.GetCarByID(HelperClass.CarID);
            stkcarEdit.DataContext = carViewModel.car;
        }

        async private void Save(object sender, RoutedEventArgs e) {
            bool status = HelperClass.TrueOrFalse(cmbStatus.SelectedIndex.ToString());

            if (await carViewModel.EditCarID(HelperClass.CarID, (int)cmbCarType.SelectedValue, txtPlateNumber.Text, txtCompany.Text, txtModel.Text, int.Parse(txtYear.Text), (int)cmbBranchs.SelectedValue, status)) {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }
        }
    }
}
