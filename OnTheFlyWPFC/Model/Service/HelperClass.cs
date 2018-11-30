using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    public static class HelperClass {
        public static int BranchID;
        public static int JobID;
        public static int Customer;
        public static int CarID;
        public static int DeliveryPriceID;
        public static int vendorID;
        public static int vendorBranchID;
        public static int categoryID;
        public static int POSSelectedCustomerID;
        public static int POSSelectedDeliveryServiceID;
        public static int POSInvoiceID;



        public static bool TrueOrFalse(string status) {

            if (status == "0")
                return true;

            return false;
        }
    }
}
