using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class SettingsDTO : ObservableObject, IDataErrorInfo
    {
        public int settingID { get; set; }
        private string _name { get; set; }
        public decimal? value_money { get; set; }
        public int? value_int { get; set; }
        private string _code { get; set; }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("code");
            }
        }

        static readonly string[] ValidatedProperties =
        {
            "name","code"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "name":
                    error = ValidateName();
                    break;
                case "code":
                    error = ValidateCode();
                    break;
            }
            return error;
        }

        private string ValidateCode()
        {
            if (_code.Length > 10)
            {
                return "لا يمكن ان يتجاوز الرمز 10 احرف";
            }
            return null;
        }

        private string ValidateName()
        {
            if (name.Length > 50)
            {
                return "لا يمكن ان يتجاوز الاسم 50 حرفاَ";
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
