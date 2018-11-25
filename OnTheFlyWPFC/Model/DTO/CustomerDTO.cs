using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    class CustomerDTO {

        public int customerID { get; set; }
        public string name { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string adddate { get; set; }
        public Nullable<decimal> credit { get; set; }

    }
}
