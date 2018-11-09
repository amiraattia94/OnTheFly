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
    /// Interaction logic for BranshEditMiniWindow.xaml
    /// </summary>
    public partial class BranchEditMiniWindow : Window
    {
        public Delegate UpdateMainList;


        BranchViewModel branchViewModel;
        CityViewModel cityViewModel;

        public BranchEditMiniWindow()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
            branchViewModel = new BranchViewModel();
            branchViewModel.GetBranchByID(HelperClass.BranchID);

            


        }

        private void cmbBranchCities_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbBranchCities.ItemsSource = cityViewModel.CityName;
            cmbBranchCities.DisplayMemberPath = "name";

            foreach(CityDTO city in cmbBranchCities.Items) {
                if (city.name == branchViewModel.EditBranch.cityID ) {
                    cmbBranchCities.SelectedValue = city;
                    break;
                }
            }
            
        }

        private void cmbBranchStatus_Loaded(object sender, RoutedEventArgs e) {
            if (branchViewModel.EditBranch.status)
                cmbBranchStatus.SelectedIndex = 0;
            else {
                cmbBranchStatus.SelectedIndex = 1;
            }
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void StkEditBranch_Loaded(object sender, RoutedEventArgs e) {
            branchViewModel.GetBranchByID(HelperClass.BranchID);
            StkEditBranch.DataContext = branchViewModel.EditBranch;
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            branchViewModel = new BranchViewModel();
            var city = (CityDTO)cmbBranchCities.SelectedValue;
            bool status = HelperClass.TrueOrFalse(cmbBranchStatus.SelectedIndex.ToString());

            if (await branchViewModel.EditBranchByID(HelperClass.BranchID, txtBranchName.Text, city.cityCode, txtBranchAddress.Text, status)) {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();

            }

        }

        
    }
}
