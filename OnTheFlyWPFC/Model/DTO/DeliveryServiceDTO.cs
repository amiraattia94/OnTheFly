using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    class DeliveryServiceDTO
    {
        public int deliverServiceID { get; set; }
        public int InvoiceID { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public int VendorID { get; set; }
        public string VendorName { get; set; }

        public int VendorBranchID { get; set; }
        public string VendorCityCode { get; set; }
        public string VendorCityname { get; set; }

        public int? CustomerID { get; set; }
        public string Customername { get; set; }
        public string CustomerCityCode { get; set; }

        public bool isFulTrip { get; set; }

        public decimal? productPrice { get; set; }
        public decimal deliveryPrice { get; set; }

        public bool status { get; set; }

        public DateTime? dateAvailable { get; set; }

        public DateTime dateDelivered { get; set; }





    }
}
