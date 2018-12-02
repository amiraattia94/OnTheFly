using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class DeliveryDTO
    {
        public int deliveryID { get; set; }
        public int invoiceID { get; set; }

        public string customername { get; set; }
        public string customercityCodee { get; set; }
        public string customerCityname { get; set; }
        public string customerAddress { get; set; }

        public string phone1 { get; set; }
        public string phone2 { get; set; }

        
        public int driverID { get; set; }
        public string driverName { get; set; }

        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? firstItemdate { get; set; }
        public DateTime? lastItemDate { get; set; }

        public int? custodyID { get; set; }

        public int? ServicesCount { get; set; }

        public decimal totalCustodycost { get; set; }
        public decimal? totalcost { get; set; }

        

        public int status { get; set; }
        public string statusName { get; set; }

    }
}
