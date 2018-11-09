using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class BranchDTO
    {
        public int branchID { get; set; }
        public string branch_name { get; set; }
        public string address { get; set; }
        public bool status { get; set; }
        public string cityID { get; set; }
    }
}
