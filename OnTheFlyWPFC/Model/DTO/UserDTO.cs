using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class UserDTO
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public int? EmployeeBranchID { get; set; }
        public string EmployeeBranchName { get; set; }
    }
}
