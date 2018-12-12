using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class VehicleDTO : ObservableObject, IDataErrorInfo
    {
        // public properties
        public int vehicleID { get; set; }
        public string vehicleType { get; set; }
        public int? typeID { get; set; }       
        public string Bransh { get; set; }
        public int? branchID { get; set; }
        public bool state { get; set; }

        // private properties
        private string _plate_number { get; set; }
        private string _made_company { get; set; }
        private int _made_year { get; set; }
        private string _edition_name { get; set; }

        #region Getters and Setters

        public string plate_number
        {
            get
            {
                return _plate_number;
            }
            set
            {
                _plate_number = value;
                OnPropertyChanged("plate_number");
            }
        }

        public string made_company
        {
            get
            {
                return _made_company;
            }
            set
            {
                _made_company = value;
                OnPropertyChanged("made_company");
            }
        }

        public int made_year
        {
            get
            {
                return _made_year;
            }
            set
            {
                _made_year = value;
                OnPropertyChanged("made_year");
            }
        }

        public string edition_name
        {
            get
            {
                return _edition_name;
            }
            set
            {
                _edition_name = value;
                OnPropertyChanged("edition_name");
            }
        }

        #endregion

        #region Validation 


        static readonly string[] ValidatedProperties =
        {
            "plate_number","made_company","made_year","edition_name"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "plate_number":
                    error = ValidatePlateNumber();
                    break;
                case "made_company":
                    error = ValidateMadeCompany();
                    break;
                case "made_year":
                    error = ValidateMadeYear();
                    break;
                case "edition_name":
                    error = ValidateEditionName();
                    break;
            }
            return error;
        }

        private string ValidatePlateNumber()
        {
            if (String.IsNullOrWhiteSpace(plate_number))
            {
                return "لا يمكن ترك رقم اللوحة فارغا";
            }
            else if (plate_number.Length > 50)
            {
                return "لا يمكن ان يتجاوز رقم اللوحة 50 حرف";
            }
            return null;
        }

        private string ValidateMadeCompany()
        {
            if (made_company.Length > 50)
            {
                return "لا يمكن ان يتجاوز اسم الشركة المصنعة 50 حرف";
            }
            return null;
        }

        private string ValidateMadeYear()
        {
            if (made_year < 1960)
            {
                return "يجب ان لا تقل سنة الصنع عن 1960";
            }
            else if (made_year > 2020)
            {
                return "يجب ان لا تزيد سنة الصنع عن 2020";
            }
            return null;
        }
            private string ValidateEditionName()
        {
            if (edition_name.Length > 50)
            {
                return "لا يمكن ان يتجاوز اسم الموديل المصنعة 50 حرف";
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
