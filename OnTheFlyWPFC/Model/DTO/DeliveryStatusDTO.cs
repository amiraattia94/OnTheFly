using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class DeliveryStatusDTO : ObservableObject, IDataErrorInfo
    {
        public int statusID { get; set; }
        private string _name { get; set; }


        // constructors
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


        static readonly string[] ValidatedProperties =
       {
            "name"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "name":
                    error = ValidateName();
                    break;
            }
            return error;
        }

        private string ValidateName()
        {
            if (name.Length > 10)
            {
                return "لا يمكن ان يتجاوز الإسم 10 احرف";
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
