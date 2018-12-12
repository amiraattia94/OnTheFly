using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    class VendorDTO : ObservableObject, IDataErrorInfo
    {
        public int? VendorID { get; set; }
        public int? VendorCategoryID { get; set; }
        public string VendorCategoryName { get; set; }
        public bool VendorStatus { get; set; }
        public int VendorBranchCount { get; set; }
        // private properties
        private string vendorName { get; set; }
        #region getters and setters
        public string VendorName
        {
            get
            {
                return vendorName;
            }
            set
            {
                vendorName = value;
                OnPropertyChanged("VendorName");
            }
        }
       
        #endregion

        #region Validations
        static readonly string[] ValidatedProperties =
     {
            "VendorName"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "VendorName":
                    error = ValidateVendorName();
                    break;
            }
            return error;
        }

        private string ValidateVendorName()
        {
            if (String.IsNullOrWhiteSpace(VendorName))
            {
                return "لا يمكن ترك الإسم فارغاَ";
            }
            else if (VendorName.Length > 30)
            {
                return "لا يمكن ان يتجاوز الإسم 30 حرف";
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
