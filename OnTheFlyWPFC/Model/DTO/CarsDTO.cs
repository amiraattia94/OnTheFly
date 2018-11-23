using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class CarsDTO
    {
        public int carID { get; set; }
        public string plate_number { get; set; }
        public string made_company { get; set; }
        public string edition_name { get; set; }
        public int? branchID { get; set; }


    }
}
