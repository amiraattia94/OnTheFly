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
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinancePayrollEditMiniWindow.xaml
    /// </summary>
    public partial class FinancePayrollEditMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel employeeViewModel;
        PayrollViewModel payrollViewModel;
        bool SelectedState = false;
        public FinancePayrollEditMiniWindow()
        {
            employeeViewModel = new EmployeeViewModel();
            payrollViewModel = new PayrollViewModel();
            InitializeComponent();
        }

        private void StkEditPayroll_Loaded(object sender, RoutedEventArgs e)
        {
            payrollViewModel.GetPayrollByID(HelperClass.payrollID);
            StkEditPayroll.DataContext = payrollViewModel.payroll;
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbPayrollPaid_Loaded(object sender, RoutedEventArgs e)
        {
            if (payrollViewModel.payroll.paid == true)
            {
                cmbPayrollPaid.SelectedIndex = 0;
            } else if (payrollViewModel.payroll.paid == true)
            {
                cmbPayrollPaid.SelectedIndex = 1;
            }
            else
            {
                cmbPayrollPaid.SelectedIndex = -1;
            }
        }

        private void cmbEmployeeName_Loaded(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetAllEmployees();
            cmbEmployeeName.ItemsSource = employeeViewModel.ViewEmployees;
            cmbEmployeeName.DisplayMemberPath = "name";
            foreach (EmployeeDTO employee in cmbEmployeeName.Items)
            {
                if (employee.employeeID == payrollViewModel.payroll.employeeID)
                {
                    cmbEmployeeName.SelectedValue = employee;
                    break;
                }
            }
        }

        private void btnEditPayroll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbPayrollPaid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPayrollPaid.SelectedIndex != -1)
            {
                if (cmbPayrollPaid.SelectedIndex == 0)
                    SelectedState = true;
                else if (cmbPayrollPaid.SelectedIndex == 1)
                    SelectedState = false;

            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
