using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class BranchDTO : ObservableObject, IDataErrorInfo
    {
        public int branchID { get; set; }
        private string _branch_name { get; set; }
        private string _address { get; set; }
        private bool _status { get; set; }
        public string cityID { get; set; }

        // constructors
        public string branch_name
        {
            get
            {
                return _branch_name;
            }
            set
            {
                _branch_name = value;
                OnPropertyChanged("branch_name");
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
        public bool status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
               
            }
        }


        static readonly string[] ValidatedProperties =
        {
            "branch_name","address"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "branch_name":
                    error = ValidateBranchName();
                    break;
                case "address":
                    error = ValidateAddtess();
                    break;                
            }
            return error;
        }

        private string ValidateBranchName()
        {
            if (String.IsNullOrWhiteSpace(branch_name))
            {
                return "لا يمكن ترك اسم الفرع فارغا";
            }
            else if (branch_name.Length > 50)
            {
                return "لا يمكن ان يتجاوز اسم المدينة 50 حرف";
            }
            return null;
        }

        private string ValidateAddtess()
        {
            if (String.IsNullOrWhiteSpace(address))
            {
                return "لا يمكن ترك العنوان فارغا";
            }
            else if (address.Length > 50)
            {
                return "لا يمكن ان يتجاوز العنوان 50 حرف";
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
