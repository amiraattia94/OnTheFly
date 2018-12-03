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

using OnTheFlyWPFC.ViewModel;
using OnTheFlyWPFC.Model.Service;


namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinanceSpendingUC.xaml
    /// </summary>
    public partial class FinanceSpendingUC : UserControl
    {
        FinanceViewModel financeViewModel;
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;
        private void RefreshListView()
        {
            financeViewModel.GetAllFinances();
            lstViewFinance.ItemsSource = financeViewModel.viewFinances;
            lstViewFinance.Items.Refresh();
        }
        public FinanceSpendingUC()
        {
            financeViewModel = new FinanceViewModel();
            InitializeComponent();
        }

        private void lstViewFinance_Loaded(object sender, RoutedEventArgs e)
        {
            financeViewModel.GetAllNegativeFinance();
            lstViewFinance.ItemsSource = financeViewModel.viewFinances;
        }

        private void btnAddFinanceSpending_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new FinanceSpendingAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
            financeViewModel.GetAllNegativeFinance();
            lstViewFinance.ItemsSource = financeViewModel.viewFinances;

        }
    }
}
