using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    class CategoryDTO : ObservableObject, IDataErrorInfo
    {
        public int CategoryID { get; set; }
        private string _categoryName { get; set; }


        // constructors
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        static readonly string[] ValidatedProperties =
       {
            "CategoryName"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "CategoryName":
                    error = ValidateCategoryName();
                    break;
               
            }
            return error;
        }

        private string ValidateCategoryName()
        {
            if (String.IsNullOrWhiteSpace(CategoryName))
            {
                return null;
            }
            else if (CategoryName.Length > 20)
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
