using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    class MembershipDTO
    {
        public string membershipID { get; set; }
        public int customerID { get; set; }
        public int vendorID { get; set; }

        public string name { get; set; }
        public string vendorname { get; set; }
        public string vendorCategory { get; set; }
        public int vendorCategoryID { get; set; }

    }
}
