using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for FinancePayrollUC.xaml
    /// </summary>
    public partial class FinancePayrollUC : UserControl
    {
        EmployeeViewModel employeeViewModel;
        PayrollViewModel payrollViewModel;
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;
        private void RefreshListView()
        {
            payrollViewModel.GetAllPayrolls();
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            lstViewPayroll.Items.Refresh();
        }
        public FinancePayrollUC()
        {
            employeeViewModel = new EmployeeViewModel();
            payrollViewModel = new PayrollViewModel();
            InitializeComponent();
        }

        private void btnAddPayroll_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new FinancePayrollAddMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }

        private void BtnSearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetEmployeeByName(txtSearchEmployeeName.Text);
            ObservableCollection<EmployeeDTO> employees = employeeViewModel.ViewEmployees;
            employeeViewModel.GetEmployeeByIDs(fromCollectionToInts(employees));
            payrollViewModel.GetPayrollByEmployeeIDs(fromCollectionToInts(employeeViewModel.ViewEmployees));
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            lstViewPayroll.Items.Refresh();
        }
        private int[] fromCollectionToInts(ObservableCollection<EmployeeDTO> ids)
        {
            int[] empIDs = new int[] { };
            int i = 0;
            foreach (EmployeeDTO id in ids){
               empIDs[i++]= id.employeeID;
            }
            return empIDs;

        }
        private void TxtSearchEmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            employeeViewModel.GetEmployeeByName(txtSearchEmployeeName.Text);
            ObservableCollection<EmployeeDTO> employees = employeeViewModel.ViewEmployees;
            employeeViewModel.GetEmployeeByIDs(fromCollectionToInts(employees));
            payrollViewModel.GetPayrollByEmployeeIDs(fromCollectionToInts(employeeViewModel.ViewEmployees));
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            lstViewPayroll.Items.Refresh();
        }

        private void lstViewPayroll_Loaded(object sender, RoutedEventArgs e)
        {
            payrollViewModel.GetAllPayrolls();
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
        }

        private void EditPayroll(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as PayrollDTO;
            HelperClass.payrollID = a.payrollID;

            var newwindow = new FinancePayrollEditMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;
            newwindow.ShowDialog();
        }
    }
}
