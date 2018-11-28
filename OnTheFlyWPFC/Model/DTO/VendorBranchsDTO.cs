using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    class VendorBranchsDTO {

        public int vendorID { get; set; }
        public int vendorBranchID { get; set; }
        public string name { get; set; }
        public string cityCode { get; set; }
        public string cityName { get; set; }
        public string address { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public bool state { get; set; }

    }
}
