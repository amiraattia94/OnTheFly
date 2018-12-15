using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    class VendorBranchsDTO : ObservableObject, IDataErrorInfo
    {
        // public properties
        public int? vendorID { get; set; }
        public int vendorBranchID { get; set; }
        public string cityCode { get; set; }
        public string cityName { get; set; }
        public bool state { get; set; }

        // private properties
        private string _name { get; set; }
        private string _address { get; set; }
        private string _phone1 { get; set; }
        private string _phone2 { get; set; }

        #region getters and setters
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
        public string phone1
        {
            get
            {
                return _phone1;
            }
            set
            {
                _phone1 = value;
                OnPropertyChanged("phone1");
            }
        }
        public string phone2
        {
            get
            {
                return _phone2;
            }
            set
            {
                _phone2 = value;
                OnPropertyChanged("phone2");
            }
        }    
        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged("address");
            }
        }

        #endregion

        #region Validations
        static readonly string[] ValidatedProperties =
     {
            "name","phone1","phone2","address"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "name":
                    error = ValidateName();
                    break;
                case "phone1":
                    error = ValidatePhone1();
                    break;
                case "phone2":
                    error = ValidatePhone2();
                    break;
                case "address":
                    error = ValidateAddress();
                    break;              
            }
            return error;
        }

        private string ValidateName()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            else if(name.Length > 30)
            {
                return "لا يمكن ان يتجاوز الإسم 30 حرف";
            }
            return null;
        }

        private string ValidatePhone1()
        {
            if (String.IsNullOrWhiteSpace(phone1))
            {
                return null;
            }
            else if (phone1.Length > 10)
            {
                return "لا يمكن ان يتجاوز رقم الهاتف 10 احرف";
            }
            if (phone1.Length < 10)
            {
                return "لا يمكن ان لا يقل رقم الهاتف عن 10 احرف";
            }
            return null;
        }

        private string ValidatePhone2()
        {
            if (String.IsNullOrWhiteSpace(phone2))
            {
                return null;
            }
            else if(phone2.Length > 10)
            {
                return "لا يمكن ان يتجاوز رقم الهاتف 10 احرف";
            }
            if (phone2.Length < 10)
            {
                return "لا يمكن ان لا يقل رقم الهاتف عن 10 احرف";
            }
            return null;
        }

        private string ValidateAddress()
        {
            if (String.IsNullOrWhiteSpace(address))
            {
                return "لا يمكن ترك العنوان فارغاَ";
            }
            else if(address.Length > 50)
            {
                return "لا يمكن ان يتجاوز العنوان 50 حرف";
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
