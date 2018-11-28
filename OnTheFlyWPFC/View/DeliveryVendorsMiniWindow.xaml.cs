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
    /// Interaction logic for CustomerMembershipMiniWindow.xaml
    /// </summary>
    public partial class DeliveryVendorsMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CityViewModel cityViewModel;

        private bool saveButton = true;

        public DeliveryVendorsMiniWindow()
        {
            InitializeComponent();
            cityViewModel = new CityViewModel();
        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            UpdateMainList.DynamicInvoke();
            this.Close();
        }
        
        private void cmbBranchCities_Loaded(object sender, RoutedEventArgs e) {
            cityViewModel.GetAllCities();
            cmbBranchCities.ItemsSource = cityViewModel.CityName;
            cmbBranchCities.DisplayMemberPath = "name";
            cmbBranchCities.SelectedValuePath = "cityCode";
        }


    }
}
