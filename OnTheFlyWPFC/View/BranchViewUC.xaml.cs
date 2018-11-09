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
        CityViewModel _cityViewModel;
        BranchViewModel _branchViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView() {
            _branchViewModel.GetAllBranches();
            lstViewBraches.ItemsSource = _branchViewModel.ViewBranch;
            lstViewBraches.Items.Refresh();

        }


        public BranchViewUC()
        {
            _cityViewModel = new CityViewModel();
            _branchViewModel = new BranchViewModel();

            InitializeComponent();
        }

        private void lstViewBraches_Loaded(object sender, RoutedEventArgs e) {
            _branchViewModel.GetAllBranches();
            lstViewBraches.ItemsSource = _branchViewModel.ViewBranch;

        }

        private async void DeleteBranch(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as BranchDTO;
            HelperClass.BranchID =  a.branchID;

            if (await _branchViewModel.DeleteBranchByID(a.branchID))
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

        
    }
}
