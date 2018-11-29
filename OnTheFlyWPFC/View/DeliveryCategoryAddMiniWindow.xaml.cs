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
    /// Interaction logic for DeliveryDestinationAddMiniWindow.xaml
    /// </summary>
    public partial class DeliveryCategoryAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        CategoryViewModel categoryViewModel;

        public DeliveryCategoryAddMiniWindow()
        {
            InitializeComponent();
            categoryViewModel = new CategoryViewModel();    
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        async private void Save(object sender, RoutedEventArgs e) {
            //bool status = HelperClass.TrueOrFalse(cmbServiceState.SelectedIndex.ToString());

            if (await categoryViewModel.AddCategory(txtCategoryName.Text)) {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }
    }
}
