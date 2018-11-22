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
    /// Interaction logic for BranchViewUC.xaml
    /// </summary>
    public partial class BranchViewUC : UserControl
    {
        CityViewModel cityViewModel;
        BranchViewModel branchViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView() {
            branchViewModel.GetAllBranches();
            lstViewBraches.ItemsSource = branchViewModel.ViewBranch;
            lstViewBraches.Items.Refresh();

        }


        public BranchViewUC()
        {
            cityViewModel = new CityViewModel();
            branchViewModel = new BranchViewModel();

            InitializeComponent();
        }

        private void lstViewBraches_Loaded(object sender, RoutedEventArgs e) {
            branchViewModel.GetAllBranches();
            lstViewBraches.ItemsSource = branchViewModel.ViewBranch;

        }

        private async void DeleteBranch(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as BranchDTO;
            HelperClass.BranchID =  a.branchID;

            if (await branchViewModel.DeleteBranchByID(a.branchID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();

            
        }

        private void EditBranch(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as BranchDTO;
            HelperClass.BranchID = a.branchID;

            var newwindow = new BranchEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.Show();
            
            
        }

        private void cmbBranchCity_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbBranchCity.ItemsSource = cityViewModel.CityName;
            cmbBranchCity.DisplayMemberPath = "name";

            foreach (CityDTO city in cmbBranchCity.Items) {
                if (city.name == branchViewModel.EditBranch.cityID) {
                    cmbBranchCity.SelectedValue = city;
                    break;
                }
            }
        }

        private void cmbBranchCity_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if(cmbBranchCity.SelectedIndex != -1) {
                var selectedcity = (CityDTO)cmbBranchCity.SelectedItem;
                branchViewModel.GetBranchByCity(selectedcity.cityCode);
                lstViewBraches.ItemsSource = branchViewModel.ViewBranch;
                lstViewBraches.Items.Refresh();
                cmbBranchState.SelectedIndex = -1;
                txtSearchBranshName.Text = "";
            }
           

        }

        private void cmbBranchState_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cmbBranchState.SelectedIndex != -1) {
                bool SelectedState = false;
                if (cmbBranchState.SelectedIndex == 0)
                    SelectedState = true;
                else if (cmbBranchState.SelectedIndex == 1)
                    SelectedState = false;

                branchViewModel.GetBranchByState(SelectedState);
                lstViewBraches.ItemsSource = branchViewModel.ViewBranch;
                lstViewBraches.Items.Refresh();
                cmbBranchCity.SelectedIndex = -1;
                txtSearchBranshName.Text = "";

            }
        }

        private void btnAddBranch_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new BranchAddMiniWindow();
          
            
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
         
           newwindow.ShowDialog();
        }

        private void BtnSearchBranch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtSearchBranshName_TextChanged(object sender, TextChangedEventArgs e) {
            branchViewModel.GetBranchByName(txtSearchBranshName.Text);
            lstViewBraches.ItemsSource = branchViewModel.ViewBranch;
            lstViewBraches.Items.Refresh();
            cmbBranchCity.SelectedIndex = -1;
            cmbBranchState.SelectedIndex = -1;

        }
    }
}
