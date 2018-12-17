using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class PayrollDTO : ObservableObject, IDataErrorInfo
    {
        // public properties
        public int payrollID { get; set; }
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public decimal? cash_advance { get; set; }
        public decimal? bonus { get; set; }
        public decimal total_deduction { get; set; }
        public decimal total_addition { get; set; }
        public decimal gross_salary { get; set; }
        public bool paid { get; set; }
        public string stateName { get; set; }
        // private properties
        private int? _extra_work_days { get; set; }
        private int? _extra_work_hours { get; set; }

        private int? _late_hours { get; set; }
        private int? _absent_days { get; set; }

        private int _payroll_month { get; set; }
        private int _payroll_year { get; set; }
        

        // Constructors 
       
        public int? extra_work_days
        {
            get
            {
                return _extra_work_days;
            }
            set
            {
                _extra_work_days = value;
                OnPropertyChanged("extra_work_days");
            }
        }

        public int? extra_work_hours
        {
            get
            {
                return _extra_work_hours;
            }
            set
            {
                _extra_work_hours = value;
                OnPropertyChanged("extra_work_hours");
            }
        }

        public int? late_hours
        {
            get
            {
                return _late_hours;
            }
            set
            {
                _late_hours = value;
                OnPropertyChanged("late_hours");
            }
        }

        public int? absent_days
        {
            get
            {
                return _absent_days;
            }
            set
            {
                _absent_days = value;
                OnPropertyChanged("absent_days");
            }
        }

        public int payroll_month
        {
            get
            {
                return _payroll_month;
            }
            set
            {
                _payroll_month = value;
                OnPropertyChanged("payroll_month");
            }

        }

        public int payroll_year
        {
            get
            {
                return _payroll_year;
            }
            set
            {
                _payroll_year = value;
                OnPropertyChanged("payroll_year");
            }

        }

        #region Data Validation


        static readonly string[] ValidatedProperties =
        {
            "extra_work_days","extra_work_hours","late_hours","absent_days","payroll_month","payroll_year"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "extra_work_days":
                    error = ValidateExtraWorkDays();
                    break;
                case "extra_work_hours":
                    error = ValidateExtraWorkHours();
                    break;
                case "late_hours":
                    error = ValidateLateHours();
                    break;
                case "absent_days":
                    error = ValidateAbsentDays();
                    break;
                case "payroll_month":
                    error = ValidatePayrollMonth();
                    break;
                case "payroll_year":
                    error = ValidatePayrollYear();
                    break;
            }
            return error;
        }

        private string ValidatePayrollMonth()
        {
            if (payroll_month <1)
            {
                return "لا يمكن ادخال قيمة شهر اقل من 1";
            }
            else if (payroll_month > 12)
            {
                return "لا يمكن ادخال قيمة شهر اكبر من 12";
            }
            return null;
        }

        private string ValidatePayrollYear()
        {
            if (payroll_year <1999 )
            {
                return "لا يمكن ادخال قيمة سنة اقل من 1999";
            }
            else if (payroll_year > 2050)
            {
                return "لا يمكن ادخال قيمة سنة اكبر من 2050";
            }
            return null;
        }

        private string ValidateLateHours()
        {
            if (late_hours> 80)
            {
                return "لا يمكن ان تتجاوز ساعات التأخير 80 ساعة";
            }
            else if (late_hours < 0)
            {
                return "لا يمكن ادخال قيمة ساعة سالبة";
            }
            return null;
        }

        private string ValidateExtraWorkHours()
        {
            if (extra_work_hours > 100)
            {
                return "لا يمكن ان تتجاوز الساعات الاضافية 100 ساعة";
            }
            else if (extra_work_hours < 0)
            {
                return "لا يمكن ادخال قيمة ساعة اضافية سالبة";
            }
            return null;
        }

        private string ValidateExtraWorkDays()
        {
            if (extra_work_days > 15)
            {
                return "لا يمكن ان تتجاوز الايام الاضافية 15 يوماَ";
            }
            else if (extra_work_days < 0)
            {
                return "لا يمكن ادخال قيمة ايام اضافية سالبة";
            }
            return null;
        }

        private string ValidateAbsentDays()
        {
            if (absent_days > 30)
            {
                return "لا يمكن ان تتجاوزايام الغياب 30 يوماَ";
            }
            else if (absent_days < 0)
            {
                return "لا يمكن ادخال قيمة ايام غياب سالبة";
            }
            return null;
        }

       


        #endregion





        #region IData & IsValid
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }

        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;

            }
        }
        #endregion

    }
}
