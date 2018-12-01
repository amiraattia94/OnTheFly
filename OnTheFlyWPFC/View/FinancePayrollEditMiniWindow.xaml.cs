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
        JobsViewModel jobsViewModel;
        bool SelectedState = false;
        public FinancePayrollEditMiniWindow()
        {
            employeeViewModel = new EmployeeViewModel();
            payrollViewModel = new PayrollViewModel();
            jobsViewModel = new JobsViewModel();
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

        private async void btnEditPayroll_Click(object sender, RoutedEventArgs e)
        {
            employeeViewModel = new EmployeeViewModel();
            var employee = (EmployeeDTO)cmbEmployeeName.SelectedValue;
            payrollViewModel = new PayrollViewModel();
            jobsViewModel = new JobsViewModel();
            decimal total_addition, total_deduction, salary, bonus, cash_advance;
            int overtime_days, overtime_hours, absent_days, late_hours;
            bonus = cash_advance = 0;
            overtime_days = overtime_hours = absent_days = late_hours = 0;
            payrollViewModel = new PayrollViewModel();
            overtime_days = String.IsNullOrWhiteSpace(txtNumberOfWorkedDays.Text) ? 0 : int.Parse(txtNumberOfWorkedDays.Text);
            overtime_hours = String.IsNullOrWhiteSpace(txtNumberOfWorkedHours.Text) ? 0 : int.Parse(txtNumberOfWorkedHours.Text);
            absent_days = String.IsNullOrWhiteSpace(txtAbsentDays.Text) ? 0 : int.Parse(txtAbsentDays.Text);
            late_hours = String.IsNullOrWhiteSpace(txtLateHours.Text) ? 0 : int.Parse(txtLateHours.Text);
            bonus = String.IsNullOrWhiteSpace(txtBonus.Text) ? 0 : decimal.Parse(txtBonus.Text);
            cash_advance = String.IsNullOrWhiteSpace(txtCashAdvance.Text) ? 0 : decimal.Parse(txtCashAdvance.Text);
            total_addition = HelperClass.calculateTotalAddition(bonus, overtime_days, overtime_hours);
            total_deduction = HelperClass.calculateTotalDeduction(cash_advance, absent_days, late_hours);
            jobsViewModel.GetJobByID(employee.jobID);
            salary = HelperClass.calculateTotalSalary(jobsViewModel.EditJob.basic_salary, total_addition, total_deduction);

            if (await payrollViewModel.EditPayrollByID(HelperClass.payrollID,employee.employeeID, overtime_days, bonus, 0, cash_advance, late_hours, absent_days, total_deduction, total_addition, salary, int.Parse(txtMonth.Text), int.Parse(txtYear.Text), SelectedState))
            {
                MessageBox.Show("تم الحفظ");

                UpdateMainList.DynamicInvoke();
                this.Close();
            }
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
