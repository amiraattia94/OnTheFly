using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static decimal overtimeHourPrice = 0;
        public static decimal overtimeDayPrice = 0;
        public static decimal lateHourPrice = 0;
        public static decimal AbsentDayPrice = 0;



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
