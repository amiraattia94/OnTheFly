using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    class DeliveryServicesDTO {

        public int serviceID { get; set; }
        public int categoryID { get; set; }
        public string categoryname { get; set; }
        public string customerAddressCode { get; set; }
        public string customerAddress { get; set; }
        public string vendorAddressCode { get; set; }
        public string vendorAddress { get; set; }
        public decimal fullPrice { get; set; }
        public decimal halfPrice { get; set; }
        public bool status { get; set; }
    }
}
