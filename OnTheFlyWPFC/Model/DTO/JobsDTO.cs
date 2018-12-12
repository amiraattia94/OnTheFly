using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class JobsDTO : ObservableObject, IDataErrorInfo
    {
        public int jobID { get; set; }
        private string _job_name { get; set; }
        public decimal basic_salary { get; set; }
        private int _working_days_per_month { get; set; }

        // constructors
        public string job_name
        {
            get
            {
                return _job_name;
            }
            set
            {
                _job_name = value;
                OnPropertyChanged("job_name");
            }
        }
        public int working_days_per_month
        {
            get
            {
                return _working_days_per_month;
            }
            set
            {
                _working_days_per_month = value;
                OnPropertyChanged("working_days_per_month");
            }
        }

        static readonly string[] ValidatedProperties =
        {
            "job_name","working_days_per_month"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "job_name":
                    error = ValidateJobName();
                    break;
                case "working_days_per_month":
                    error = ValidateWorkingDaysPerMonth();
                    break;

            }
            return error;
        }

        private string ValidateWorkingDaysPerMonth()
        {
            if (working_days_per_month > 288 )
            {
                return "لا يمكن ان تتجاوز ساعات العمل 288 ساعة";
            }
            return null;
        }

        private string ValidateJobName()
        {
            if (String.IsNullOrWhiteSpace(job_name))
            {
                return "لا يمكن ترك اسم الوظيفة فارغا";
            }
            else if (job_name.Length > 30)
            {
                return "لا يمكن ان يتجاوز الإسم 20 حرف";
            }
            return null;
        }

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

