using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class PayrollDTO
    {
        public int payrollID { get; set; }
        public int employeeID { get; set; }
        public int? extra_work_days { get; set; }
        public decimal? bonus { get; set; }
        public int? extra_work_hours { get; set; }
        public decimal? cash_advance { get; set; }
        public int? late_hours { get; set; }
        public int? absent_days { get; set; }
        public decimal total_deduction { get; set; }
        public decimal total_addition { get; set; }
        public decimal gross_salary { get; set; }
        public int payroll_month { get; set; }
        public int payroll_year { get; set; }
        public bool paid { get; set; }

    }
}
