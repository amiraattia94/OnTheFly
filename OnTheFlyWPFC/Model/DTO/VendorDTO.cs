using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    class VendorDTO
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public int? VendorCategoryID { get; set; }
        public string VendorCategoryName { get; set; }
        public bool VendorStatus { get; set; }
        public int VendorBranchCount { get; set; }


    }
}
