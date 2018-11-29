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
        public static int userID;
        public static int employeeID;


        public static bool TrueOrFalse(string status) {

            if (status == "0")
                return true;

            return false;
        }
    }
}
