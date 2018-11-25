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
    /// Interaction logic for BranchAddMiniWindow.xaml
    /// </summary>
    public partial class BranchAddMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CityViewModel _cityViewModel;
        BranchViewModel _branchViewModel;
        
        public BranchAddMiniWindow()
        {
            
            _cityViewModel = new CityViewModel();
            _branchViewModel = new BranchViewModel();
            InitializeComponent();

        }

        private void cmbBranchCities_Loaded(object sender, RoutedEventArgs e) {
            _cityViewModel.GetAllCities();
            //cmbBranchCities.DataContext = _cityViewModel;
            cmbBranchCities.ItemsSource = _cityViewModel.CityName;
            cmbBranchCities.DisplayMemberPath = "name"; 
        }

        async private void Button_Click(object sender, RoutedEventArgs e) {
            _branchViewModel = new BranchViewModel();
            var city = (CityDTO)cmbBranchCities.SelectedValue;
            bool status = HelperClass.TrueOrFalse(cmbBranchStatus.SelectedIndex.ToString());

            if (await _branchViewModel.AddBranch(txtBranchName.Text, city.cityCode, txtBranchAddress.Text,status)) {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }

            
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
