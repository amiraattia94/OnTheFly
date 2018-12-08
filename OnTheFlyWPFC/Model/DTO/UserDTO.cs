using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class UserDTO : IDataErrorInfo, INotifyPropertyChanged
    {
        public int userID { get; set; }
        private string Username;
        public string password { get; set; }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }

        }

        static readonly string[] ValidatedProperties =
        {
            "UserName"
        };

        public event PropertyChangedEventHandler PropertyChanged;

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
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "UserName":
                    error = ValidateUserName();
                    break;
            }
            return error;
        }
        private string ValidateUserName()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                return "UserName cannot be empty";
            }
            return null;
        }
    }
}
