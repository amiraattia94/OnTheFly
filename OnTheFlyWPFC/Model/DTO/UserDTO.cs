using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnTheFlyWPFC.Model.DTO
{
    public class UserDTO : ObservableObject, IDataErrorInfo
    {
        public int userID { get; set; }
        private string Username;
        private string password { get; set; }
        public int EmployeeID { get; set; }
        private string employeeName { get; set; }
        public int? EmployeeBranchID { get; set; }
        public string EmployeeBranchName { get; set; }

        public string UserName
        {
            get
            {
                return Username;
            }
            set
            {
                Username = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
                OnPropertyChanged("EmployeeName");
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
            "UserName","Password","EmployeeName"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "UserName":
                    error = ValidateUserName();
                    break;
                case "Password":
                    error = ValidatePassword();
                    break;
                case "EmployeeName":
                    error = ValidateEmployeeName();
                    break;
            }
            return error;
        }

        private string ValidateEmployeeName()
        {
            if (String.IsNullOrWhiteSpace(EmployeeName))
            {
                return "يجب عليك اختيار الموظف المعني";
            }
            return null;
        }

        private string ValidatePassword()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                return "لا يمكن ترك اسم المستخدم فارغا";
            }
            return null;
        }

        private string ValidateUserName()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                return "لا يمكن ترك اسم المستخدم فارغا";
            }
            return null;
        }

    }
}
