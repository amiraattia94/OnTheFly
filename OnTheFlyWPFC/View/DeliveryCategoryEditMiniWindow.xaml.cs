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
    /// Interaction logic for DeliveryDestinationEditMiniWindow.xaml
    /// </summary>
    public partial class DeliveryCategoryEditMiniWindow : Window
    {

        public Delegate UpdateMainList;
        CategoryViewModel categoryViewModel;

        public DeliveryCategoryEditMiniWindow()
        {
            InitializeComponent();

            categoryViewModel = new CategoryViewModel();
            categoryViewModel.GetCategoryByID(HelperClass.categoryID);
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }



        async private void Edit(object sender, RoutedEventArgs e) {
            //bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());

            if (await categoryViewModel.EditCategoryByID(HelperClass.categoryID, txtCategoryName.Text)) {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }

        private void StkEditVendors_Loaded(object sender, RoutedEventArgs e) {
        }

        private void StkCategoryEdit_Loaded(object sender, RoutedEventArgs e) {
            stkCategoryEdit.DataContext = categoryViewModel.categories;
        }
    }
}
