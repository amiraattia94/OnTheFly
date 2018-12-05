using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.Model.Service {
    public static class HelperClass {
        public static int BranchID;
        public static int JobID;
        public static int Customer;
        public static int CarID;
        public static int userID;
        public static int employeeID;
        public static int systemUserID;
        public static int payrollID;
        public static decimal overtimeHourPrice;
        public static decimal overtimeDayPrice;
        public static decimal lateHourPrice;
        public static decimal AbsentDayPrice;
        public static int DeliveryPriceID;
        public static int vendorID;
        public static int vendorBranchID;
        public static int categoryID;
        public static int CustodyID;
        public static int DeliveryID;
        public static int POSSelectedCustomerID;
        public static int POSSelectedDeliveryServiceID;
        public static int? POSSelectedCustodyID;
        public static int POSInvoiceID;
        public static int POSInvoiceIDView;
        public static int POSDeliveryID;


        //LoginUserData
        public static int LoginEmployeeID;
        public static int LoginUserID;

        public static string LoginUserName;
        public static string LoginEmployeeName;



        public static void assignPayrolls()
        {
            SettingsViewModel settingsViewModel;
            settingsViewModel = new SettingsViewModel();
            settingsViewModel.GetAllSettings();
            foreach (SettingsDTO setting in settingsViewModel.viewSettings){
                switch (setting.settingID){
                    case 1:
                        HelperClass.overtimeHourPrice = setting.value_money??0;
                        break;
                    case 2:
                        HelperClass.overtimeDayPrice    = setting.value_money ?? 0;
                        break;
                    case 3:
                        HelperClass.AbsentDayPrice = setting.value_money ?? 0;
                        break;
                    case 4:
                        HelperClass.lateHourPrice = setting.value_money ?? 0;
                        break;
                    default:
                        break;
                }
            }
           
        }

        public async static void addFinanceFromPayroll(PayrollDTO payroll)
        {
            EmployeeViewModel employeeViewModel;
            FinanceViewModel financeViewModel;
            employeeViewModel = new EmployeeViewModel();
            financeViewModel = new FinanceViewModel();
            string finance_reason = "";
            employeeViewModel.GetEmployeeByID(payroll.employeeID);
            finance_reason += "تم دفع مرتب " + employeeViewModel.employee.name + " للشهر: " + payroll.payroll_month+" و السنة: " +payroll.payroll_year;
            try
            {
                await financeViewModel.AddFinance(false, payroll.gross_salary, finance_reason, HelperClass.systemUserID, HelperClass.LoginEmployeeName, DateTime.Now);
            }
            catch
            {
               
            }
            
        }
        public static bool TrueOrFalse(string status) {

            if (status == "0")
                return true;
            return false;
        }

        public static decimal calculateTotalAddition(decimal bonus, int number_of_over_work_days, int overtime_hours)
        {
            decimal result = 0;
            result = bonus + calculateParcial(overtimeDayPrice, overtime_hours) + calculateParcial(overtimeDayPrice, number_of_over_work_days);
            return result;
        }
        public static decimal calculateTotalAddition( decimal bonus)
        {
            decimal result = 0;

            result = bonus;
            return result;
        }
        public static decimal calculateTotalAddition(decimal bonus, int number_of_over_work_days)
        {
            decimal result = 0;
            result = bonus + calculateParcial(overtimeDayPrice, number_of_over_work_days);
            return result;
        }

        public static decimal calculateTotalDeduction(decimal cash_advance, int abcent_days, int late_hours)
        {
            decimal result = 0;
            result = cash_advance + calculateParcial(lateHourPrice, late_hours) + calculateParcial(AbsentDayPrice, abcent_days);
            return result;
        }
        public static decimal calculateTotalDeduction(decimal cash_advance, int abcent_days)
        {
            decimal result = 0;
            result = cash_advance + calculateParcial(AbsentDayPrice, abcent_days);
            return result;
        }
        public static decimal calculateTotalDeduction(decimal cash_advance)
        {
            decimal result = 0;
            result = cash_advance;
            return result;
        }


        public static decimal calculateParcial(decimal price, int count)
        {
            decimal result = 0;
            result = price * count;

            return result;
        }

        public static decimal calculateTotalSalary(decimal initial_salary, decimal total_addition, decimal total_deduction)
        {
            decimal result = 0;
            result = initial_salary + total_addition - total_deduction;
            return result;
        }
    }
}
