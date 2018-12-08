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
using OnTheFlyWPFC.ViewModel;
using OnTheFlyWPFC.Model.Service;


namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinancePayrollAddMiniWindow.xaml
    /// </summary>
    public partial class FinancePayrollAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel employeeViewModel;
        PayrollViewModel payrollViewModel;
        JobsViewModel jobsViewModel;

        bool SelectedState = false;
        public FinancePayrollAddMiniWindow()
        {
            jobsViewModel = new JobsViewModel();
            employeeViewModel = new EmployeeViewModel();
            payrollViewModel = new PayrollViewModel();
            InitializeComponent();
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbEmployeeName_Loaded(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetAllEmployees();
            cmbEmployeeName.ItemsSource = employeeViewModel.ViewEmployees;
            cmbEmployeeName.DisplayMemberPath = "name";
        }

        private async void btnAddPayroll_Click(object sender, RoutedEventArgs e)
        {
       
            decimal total_addition, total_deduction, salary;
            int overtime_days, overtime_hours, absent_days, late_hours, bonus, cash_advance;
            overtime_days = overtime_hours = absent_days = late_hours = bonus = cash_advance = 0;
            payrollViewModel = new PayrollViewModel();
            var employee = (EmployeeDTO)cmbEmployeeName.SelectedValue;
            overtime_days = String.IsNullOrWhiteSpace(txtNumberOfWorkedDays.Text) ? 0 : int.Parse(txtNumberOfWorkedDays.Text);
            overtime_hours = String.IsNullOrWhiteSpace(txtNumberOfWorkedHours.Text) ? 0 : int.Parse(txtNumberOfWorkedHours.Text);
            absent_days = String.IsNullOrWhiteSpace(txtAbsentDays.Text) ? 0 : int.Parse(txtAbsentDays.Text);
            late_hours = String.IsNullOrWhiteSpace(txtLateHours.Text) ? 0 : int.Parse(txtLateHours.Text);
            bonus = String.IsNullOrWhiteSpace(txtBonus.Text) ? 0 : int.Parse(txtBonus.Text);
            cash_advance = String.IsNullOrWhiteSpace(txtCashAdvance.Text) ? 0 : int.Parse(txtCashAdvance.Text);
            total_addition = HelperClass.calculateTotalAddition(bonus, overtime_days, overtime_hours);
            total_deduction = HelperClass.calculateTotalDeduction(cash_advance, absent_days, late_hours);
            jobsViewModel.GetJobByID(employee.jobID);
            salary = HelperClass.calculateTotalSalary(jobsViewModel.EditJob.basic_salary,total_addition, total_deduction);
            if (await payrollViewModel.AddPayroll(employee.employeeID,overtime_days,bonus,0,cash_advance,late_hours,absent_days,total_deduction,total_addition,salary,int.Parse(txtMonth.Text), int.Parse(txtYear.Text),SelectedState))
            {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }
            if (SelectedState)
            {
                payrollViewModel.GetLastPayroll();
                HelperClass.addFinanceFromPayroll(payrollViewModel.payroll);
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

        private void cmbPayrollPaid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtNumberOfWorkedDays_Preview(object sender, TextCompositionEventArgs e)
        {
            {
          
            }
        }

        private void stkAddPayroll_Loaded(object sender, RoutedEventArgs e)
        {
           // payrollViewModel = new PayrollViewModel();
            //payrollViewModel.payroll_month = 12;
        }
    }
}
