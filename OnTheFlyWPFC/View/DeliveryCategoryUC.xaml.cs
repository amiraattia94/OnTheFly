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
    /// Interaction logic for DeliveryDestinationUC.xaml
    /// </summary>
    public partial class DeliveryCategoryUC : UserControl
    {
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        CategoryViewModel categoryViewModel;
        

        public DeliveryCategoryUC()
        {
            InitializeComponent();

            categoryViewModel = new CategoryViewModel();
        }

        private void BtnSearchDeliveryDestination_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstViewDeliveryCategory_Loaded(object sender, RoutedEventArgs e) {
            categoryViewModel.GetAllCategories();
            lstViewDeliveryCategory.ItemsSource = categoryViewModel.allCategories;
        }


        private void RefreshListView() {
            categoryViewModel.GetAllCategories();
            lstViewDeliveryCategory.ItemsSource = categoryViewModel.allCategories;
            lstViewDeliveryCategory.Items.Refresh();
        }

        private void Add(object sender, RoutedEventArgs e) {
            var newwindow = new DeliveryCategoryAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void EditCategory(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CategoryDTO;
            HelperClass.categoryID = (int)a.CategoryID;

            var newwindow = new DeliveryCategoryEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        async private void DeleteCategory(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            var a = button.CommandParameter as CategoryDTO;
            HelperClass.categoryID = (int)a.CategoryID;

            if (await categoryViewModel.DeleteCategoryByID((int)a.CategoryID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();

        }

        private void TxtSearchCategoryName_TextChanged(object sender, TextChangedEventArgs e) {
            categoryViewModel.GetCategoryByName(txtSearchCategoryName.Text);
            lstViewDeliveryCategory.ItemsSource = categoryViewModel.allCategories;
            lstViewDeliveryCategory.Items.Refresh();
        }
    }
}
