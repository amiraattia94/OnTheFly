using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    public class CityDTO : ObservableObject, IDataErrorInfo
    {
     
        // public string cityCode { get; set; }
        private string _cityCode{ get; set; }
        private string _name { get; set; }
        public string cityCode
        {
            get
            {
                return _cityCode;
            }
            set
            {
                _cityCode = value;
                OnPropertyChanged("cityCode");
            }
        }

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


        static readonly string[] ValidatedProperties =
        {
            "cityCode","name"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "cityCode":
                    error = ValidateCityCode();
                    break;
                case "name":
                    error = ValidateName();
                    break;
                
            }
            return error;
        }

        private string ValidateName()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return "لا يمكن ترك اسم المدينة فارغا";
            }else if (name.Length > 20)
            {
                return "لا يمكن ان يتجاوز اسم المدينة 20 حرف";
            }
            return null;
        }

        private string ValidateCityCode()
        {
            if (String.IsNullOrWhiteSpace(cityCode))
            {
                return "لا يمكن ترك رمز المدينة فارغا";
            }
            else if (cityCode.Length > 2 )
            {
                return "لا يمكن ان يتجاوز اسم المدينة حرفين";
            }
            return null;
        }


    }
}
