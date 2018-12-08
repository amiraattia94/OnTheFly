using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.Collections.ObjectModel;

namespace OnTheFlyWPFC.ViewModel
{
    class PayrollViewModel
    {

        PayrollService payrollService;
        public ObservableCollection<PayrollDTO> viewPayrolls { get; set; }
        public PayrollDTO payroll { get; set; }

        public PayrollViewModel()
        {
            payrollService = new PayrollService();
            viewPayrolls = new ObservableCollection<PayrollDTO>();            
            payroll = new PayrollDTO();

            GetAllPayrolls();
        }


        async public Task<bool> AddPayroll(int employeeID, int extra_work_days, decimal bonus, int extra_work_hours, int cash_advance, int late_hours, int absent_days, decimal total_deduction, decimal total_addition, decimal gross_salary, int payroll_month, int payroll_year, bool paid)
        {
            return await payrollService.AddPayroll( employeeID, extra_work_days,  bonus, extra_work_hours,  cash_advance,  late_hours,  absent_days,  total_deduction,  total_addition,  gross_salary,  payroll_month,  payroll_year,  paid);
        }

        async public Task<bool> EditPayrollByID(int payrollID, int employeeID, int extra_work_days, decimal bonus, int extra_work_hours, decimal cash_advance, int late_hours, int absent_days, decimal total_deduction, decimal total_addition, decimal gross_salary, int payroll_month, int payroll_year, bool paid)
        {
            return await payrollService.EditPayrollByID(payrollID, employeeID, extra_work_days, bonus, extra_work_hours, cash_advance, late_hours, absent_days, total_deduction, total_addition, gross_salary, payroll_month, payroll_year, paid);
        }
               
        async public void GetAllPayrolls()
        {
            viewPayrolls = await payrollService.GetAllPayroll();
        }

        async public void GetAllPayrollAtDate(int month, int year) {
            viewPayrolls = await payrollService.GetAllPayrollAtDate(month,year);
        }

        async public void GetPayrollByID(int payrollID)
        {
            payroll = await payrollService.GetPayrollByID(payrollID);
        }

        async public void GetLastPayroll()
        {
            payroll = await payrollService.GetLastPayroll();
        }

        async public void GetPayrollByEmployeeID(int employeeID)
        {
            viewPayrolls = await payrollService.GetPayrollByEmployeeID(employeeID);
        }

        async public void GetPayrollByPaid(bool paid)
        {
            viewPayrolls = await payrollService.GetPayrollByPaid(paid);
        }

        async public void GetPayrollByMonthAndYear(int month,int year)
        {
            viewPayrolls = await payrollService.GetPayrollByMonthAndYear(month, year);
        }

        async public void GetPayrollByMonth(int month)
        {
            viewPayrolls = await payrollService.GetPayrollByMonth(month);
        }
        
        async public void GetPayrollByYear(int year)
        {
            viewPayrolls = await payrollService.GetPayrollByYear(year);
        }

        async public void GetPayrollByBonus(decimal bonus)
        {
            viewPayrolls = await payrollService.GetPayrollByBonus(bonus);
        }
                
        async public void GetPayrollByCashAdvance(decimal cash_advance)
        {
            viewPayrolls = await payrollService.GetPayrollByCashAdvance(cash_advance);
        }

        async public void GetPayrollByAbsentDays(int absent_days)
        {
            viewPayrolls = await payrollService.GetPayrollByAbsentDays(absent_days);
        }

        //async public void GetPayrollByEmployeeIDs(int[] employeeIDs)
        //{
        //    viewPayrolls = await payrollService.GetPayrollByEmployeeIDs(employeeIDs);
        //}

        async public void GetPayrollByEmployeeIDs(List<int> employeeIDs) {
            viewPayrolls = await payrollService.GetPayrollByEmployeeIDs(employeeIDs);
        }
    }
}
