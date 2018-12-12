using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class DeliveryDTO : ObservableObject, IDataErrorInfo
    {
        public int deliveryID { get; set; }
        public int? invoiceID { get; set; }

        public string customername { get; set; }
        public string customercityCodee { get; set; }
        public string customerCityname { get; set; }
        public string customerAddress { get; set; }

        public string phone1 { get; set; }
        public string phone2 { get; set; }

        
        public int? driverID { get; set; }
        public string driverName { get; set; }

        private DateTime? _start_date { get; set; }
        private DateTime? _end_date { get; set; }
        public DateTime? firstItemdate { get; set; }
        public DateTime? lastItemDate { get; set; }

        public int? custodyID { get; set; }

        public int? ServicesCount { get; set; }

        public decimal? totalCustodycost { get; set; }
        public decimal? totalcost { get; set; }

        

        public int? status { get; set; }
        public string statusName { get; set; }


        // constructors
        public DateTime? start_date
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
                OnPropertyChanged("start_date");
            }
        }

        public DateTime? end_date
        {
            get
            {
                return _end_date;
            }
            set
            {
                _end_date = value;
                OnPropertyChanged("end_date");
            }
        }

        static readonly string[] ValidatedProperties =
       {
            "start_date","end_date"
        };
        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "start_date":
                    error = ValidateStartDate();
                    break;
                case "end_date":
                    error = ValidateEndDate();
                    break;               
            }
            return error;
        }

        private string ValidateEndDate()
        {
            if (end_date< start_date)
            {
                return "يجب ان يكون موعد الإنتهاء في نفس اليوم او بعد موعد البدء";
            }
            return null;            
        }

        private string ValidateStartDate()
        {
            if (end_date < start_date)
            {
                return "يجب ان يكون موعد البدأ في نفس يوم موعد الانتهء او قبله";
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
