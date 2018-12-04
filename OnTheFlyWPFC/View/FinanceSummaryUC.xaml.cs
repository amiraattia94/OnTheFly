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
    /// Interaction logic for FinanceSummaryUC.xaml
    /// </summary>
    public partial class FinanceSummaryUC : UserControl
    {
        FinanceViewModel financeViewModel;

        public FinanceSummaryUC()
        {

            InitializeComponent();
            financeViewModel = new FinanceViewModel();
        }

        async private void LblMainHome_1_Loaded(object sender, RoutedEventArgs e) {
            lblMainHome_1.Content = (await financeViewModel.GetAllNegativeFinanceDecimal()).ToString("0.##");
        }

        async private void LblMainHome_3_Loaded(object sender, RoutedEventArgs e) {
            lblMainHome_3.Content = (await financeViewModel.GetAllPosativeFinanceDecimal()).ToString("0.##");

        }

        async private void LblMainHome_4_Loaded(object sender, RoutedEventArgs e) {
            lblMainHome_4.Content = ((await financeViewModel.GetAllPosativeFinanceDecimal()) - (await financeViewModel.GetAllNegativeFinanceDecimal())).ToString("0.##");

        }
    }
}
