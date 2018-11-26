using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class VehicleDTO
    {
        public int vehicleID { get; set; }
        public string vehicleType { get; set; }
        public int? typeID { get; set; }
        public string plate_number { get; set; }
        public string made_company { get; set; }
        public int made_year { get; set; }
        public string edition_name { get; set; }
        public string Bransh { get; set; }
        public int? branchID { get; set; }
        public bool state { get; set; }

    }
}
