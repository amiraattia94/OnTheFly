using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class EmployeeDTO
    {
        public int employeeID { get; set; }
        public string name { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public bool active { get; set; }
        public int jobID { get; set; }
        public int cityID { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int branchID { get; set; }
    }
}
