using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class UserGroupsDTO
    {
        public int userID { get; set; }
        public int groupID { get; set; }
        public string user_name { get; set; }
        public string group_name { get; set; }
    }
}
