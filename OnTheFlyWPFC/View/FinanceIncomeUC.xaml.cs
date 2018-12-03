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
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;


namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinanceIncomeUC.xaml
    /// </summary>
    public partial class FinanceIncomeUC : UserControl
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
        public FinanceIncomeUC()
        {
            financeViewModel = new FinanceViewModel();
            InitializeComponent();
        }

        private void lstViewFinance_Loaded(object sender, RoutedEventArgs e)
        {
            financeViewModel.GetAllPosativeFinance();
            lstViewFinance.ItemsSource = financeViewModel.viewFinances;
        }

        private void btnAddFinance_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new FinanceIncomeAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();

            financeViewModel.GetAllPosativeFinance();
            lstViewFinance.ItemsSource = financeViewModel.viewFinances;
        }
    }
}
