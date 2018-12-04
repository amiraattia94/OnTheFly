using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class UserGroupRoleDTO
    {
        public int groupID { get; set; }
        public string name { get; set; }
        public bool view_POS { get; set; }
        public bool add_POS { get; set; }
        public bool delete_POS { get; set; }
        public bool view_HR { get; set; }
        public bool add_HR { get; set; }
        public bool delete_HR { get; set; }
        public bool view_branch { get; set; }
        public bool add_branch { get; set; }
        public bool delete_branch { get; set; }
        public bool view_custody { get; set; }
        public bool add_custody { get; set; }
        public bool delete_custody { get; set; }
        public bool view_finance { get; set; }
        public bool add_finance { get; set; }
        public bool delete_finance { get; set; }
        public bool view_delivery { get; set; }
        public bool add_delivery { get; set; }
        public bool delete_delivery { get; set; }
        public bool view_customer { get; set; }
        public bool add_customer { get; set; }
        public bool delete_customer { get; set; }
        public bool view_vendor { get; set; }
        public bool add_vendor { get; set; }
        public bool delete_vendor { get; set; }
        public bool view_service { get; set; }
        public bool add_service { get; set; }
        public bool delete_service { get; set; }
        public bool admin_rights { get; set; }
        public bool view_report { get; set; }
        public int userID { get; set; }



    }
}
