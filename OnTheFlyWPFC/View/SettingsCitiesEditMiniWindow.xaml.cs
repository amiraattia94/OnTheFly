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
    /// Interaction logic for SettingsCitiesEditMiniWindow.xaml
    /// </summary>
    public partial class SettingsCitiesEditMiniWindow : Window
    {
        public Delegate UpdateMainList;

        CityViewModel cityViewModel;

        public SettingsCitiesEditMiniWindow()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
            cityViewModel.GetCityByCode(HelperClass.cityCode);
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAddCity_Click(object sender, RoutedEventArgs e)
        {

            if (await  cityViewModel.EditCity(HelperClass.cityCode, txtCityCode.Text, txtCityName.Text))
            {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();

            }

        }

        private void StkEditCity_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetCityByCode(HelperClass.cityCode);
            StkEditCity.DataContext = cityViewModel.cityDTO;
        }
    }
}
