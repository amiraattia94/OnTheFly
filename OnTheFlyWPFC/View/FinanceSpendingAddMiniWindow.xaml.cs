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
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinanceSpendingAddMiniWindow.xaml
    /// </summary>
    public partial class FinanceSpendingAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        FinanceViewModel FinanceViewModel;

        public FinanceSpendingAddMiniWindow()
        {
            InitializeComponent();
            FinanceViewModel = new FinanceViewModel();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private async void btnAddFinance_Click(object sender, RoutedEventArgs e)
        {
            if (await FinanceViewModel.AddFinance(false, decimal.Parse(txtFinanceValue.Text), txtFinanceReason.Text, HelperClass.systemUserID, DateTime.Now))

            {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();
            }
        }
    }
}
