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
        JobsViewModel jobsViewModel;

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
            jobsViewModel = new JobsViewModel();
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
            //employeeViewModel.GetEmployeeByName(txtSearchEmployeeName.Text);
            //ObservableCollection<EmployeeDTO> employees = employeeViewModel.ViewEmployees;
            //employeeViewModel.GetEmployeeByIDs(fromCollectionToInts(employees));
            //payrollViewModel.GetPayrollByEmployeeIDs(fromCollectionToInts(employeeViewModel.ViewEmployees));
            //lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            //lstViewPayroll.Items.Refresh();
        }

        //private int[] fromCollectionToInts(ObservableCollection<EmployeeDTO> ids) {
        //    int[] empIDs = new int[] { };
        //    int i = 0;
        //    foreach (EmployeeDTO id in ids) {
        //        empIDs[i++] = id.employeeID;
        //    }
        //    return empIDs;

        //}

        private List<int> fromCollectionToInts(ObservableCollection<EmployeeDTO> ids) {
            List<int> empIDs = new List<int>();
            
            foreach (EmployeeDTO id in ids) {
                empIDs.Add( id.employeeID);
            }
            return empIDs;

        }

        private void TxtSearchEmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchEmployeeName.Text != "" ) {
                employeeViewModel.GetEmployeeByName(txtSearchEmployeeName.Text);
                ObservableCollection<EmployeeDTO> employees = employeeViewModel.ViewEmployees;
                employeeViewModel.GetEmployeeByIDs(fromCollectionToInts(employees));
                payrollViewModel.GetPayrollByEmployeeIDs(fromCollectionToInts(employeeViewModel.ViewEmployees));
                lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
                lstViewPayroll.Items.Refresh();
            }
            else{


                payrollViewModel.GetAllPayrollAtDate((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);
                lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
                lstViewPayroll.Items.Refresh();

            }

        }


        async private void lstViewPayroll_Loaded(object sender, RoutedEventArgs e)
        {
            //payrollViewModel.GetAllPayrolls();

            payrollViewModel.GetAllPayrollAtDate(DateTime.Now.Month, DateTime.Now.Year);
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;

            employeeViewModel.GetAllActiveEmployees();

            
            foreach (EmployeeDTO employee in employeeViewModel.ViewEmployees) {
                bool IsInPayroll = false;
                foreach (PayrollDTO payroll in payrollViewModel.viewPayrolls) {
                    if (payroll.employeeID == employee.employeeID) {
                        IsInPayroll = true;
                    }
                }

                if(IsInPayroll == false) {
                    jobsViewModel.GetJobByID(employee.jobID);
                    var salary = jobsViewModel.EditJob.basic_salary;
                    await payrollViewModel.AddPayroll(employee.employeeID, 0, 0, 0, 0, 0, 0, 0, 0, salary, DateTime.Now.Month, DateTime.Now.Year, false);
                }

            }

            payrollViewModel.GetAllPayrollAtDate(DateTime.Now.Month, DateTime.Now.Year);
            lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;


        }

        private void EditPayroll(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as PayrollDTO;
            HelperClass.payrollID = a.payrollID;
            if(a.paid == false) {
                var newwindow = new FinancePayrollEditMiniWindow();
                RefreshListEvent += new RefreshList(RefreshListView);
                newwindow.UpdateMainList = RefreshListEvent;
                newwindow.ShowDialog();
            }
            else {
                MessageBox.Show("لا يمكن التعديل بعد صرف المرتب");
            }

            
        }

        private void CmbMonth_Loaded(object sender, RoutedEventArgs e) {
            List<int> monthlist = new List<int>();
            for (int i = 1; i <= 12; i++) {
                monthlist.Add(i);

            }

            cmbMonth.ItemsSource = monthlist;
            cmbMonth.SelectedItem = DateTime.Now.Month;
        }

        private void CmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if(cmbYear.SelectedValue != null && cmbMonth.SelectedValue != null) {
                payrollViewModel.GetAllPayrollAtDate((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);
                lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            }
            
            
            
            
        }

        private void CmbYear_Loaded(object sender, RoutedEventArgs e) {
            List<int> yearlist = new List<int>();
            for (int i = 2017; i <= DateTime.Now.Year; i++) {
                yearlist.Add(i);

            }

            cmbYear.ItemsSource = yearlist;
            cmbYear.SelectedItem = DateTime.Now.Year;
        }

        private void CmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbYear.SelectedValue != null && cmbMonth.SelectedValue != null) {
                payrollViewModel.GetAllPayrollAtDate((int)cmbMonth.SelectedItem, (int)cmbYear.SelectedItem);
                lstViewPayroll.ItemsSource = payrollViewModel.viewPayrolls;
            }
        }


    }
}
