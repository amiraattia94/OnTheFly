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
using OnTheFlyWPFC.ViewModel;
using OnTheFlyWPFC.Model;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsCitiesUC.xaml
    /// </summary>
    public partial class SettingsCitiesUC : UserControl
    {
        CityViewModel cityViewModel;
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView()
        {
            cityViewModel.GetAllTheCities();
            lstviewCities.ItemsSource = cityViewModel.CityName;
            lstviewCities.Items.Refresh();
        }
        public SettingsCitiesUC()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
        }

        private void txtSearchCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbSearchType.SelectedIndex == 0)// city code
            {
                cityViewModel.GetCityStartByName(txtSearchCity.Text);
                lstviewCities.ItemsSource = cityViewModel.CityName;
                lstviewCities.Items.Refresh();
                cmbSearchType.SelectedIndex = -1;
         
            }
            if (cmbSearchType.SelectedIndex == 1)//city name
            {
                cityViewModel.GetCityStartByCode(txtSearchCity.Text);
                lstviewCities.ItemsSource = cityViewModel.CityName;
                lstviewCities.Items.Refresh();
                cmbSearchType.SelectedIndex = -1;
            }
         
            if (cmbSearchType.SelectedIndex == -1 && txtSearchCity.Text=="")//city name
            {
                cityViewModel.GetAllTheCities();
                lstviewCities.ItemsSource = cityViewModel.CityName;
                lstviewCities.Items.Refresh();
                cmbSearchType.SelectedIndex = -1;
            }
           

        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new SettingsCitiesAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private async void DeleteCity(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as CityDTO;
            HelperClass.cityCode = a.cityCode;            
            await cityViewModel.DeleteCityCode(a.cityCode);      
         //   cityViewModel.CityName = null;
            RefreshListView();
        }

        private void EditCity(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as CityDTO;
            HelperClass.cityCode = a.cityCode;

            var newwindow = new SettingsCitiesEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        private void lstviewCities_Loaded(object sender, RoutedEventArgs e)
        {
           // lstviewCities.DataContext = cityViewModel.CityName;
            cityViewModel.GetAllTheCities();
            lstviewCities.ItemsSource = cityViewModel.CityName;
        }

        private void cmbSearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
