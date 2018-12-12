using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class InvoiceDTO
    {
        public int invoiceID { get; set; }

        public DateTime dateTime { get; set; }

        public int customerID { get; set; }
        public string customername { get; set; }
        public string customercityCodee { get; set; }
        public string customerCityname { get; set; }
        public string customerAddress { get; set; }

        public string phone1 { get; set; }
        public string phone2 { get; set; }

        public int? DeliveryID { get; set; }
        public int DriverID { get; set; }
        public string DriverName { get; set; }

        public Nullable<int> issuerID { get; set; }
        public string issuerName { get; set; }
        public Nullable<int> branchID { get; set; }

        public int ServiceNumber { get; set; }

        public decimal discount { get; set; }
        public decimal totalafter { get; set; }
        public decimal totalBefore { get; set; }

        public bool? InvoiceState { get; set; }
        


        public int? custodyID { get; set; }
        public decimal? deliveryPriceAfter { get; set; }

    }
}
