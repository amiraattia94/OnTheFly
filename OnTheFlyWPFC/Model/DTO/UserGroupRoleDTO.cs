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
        public Boolean view_POS { get; set; }
        public Boolean add_POS { get; set; }
        public Boolean delete_POS { get; set; }
        public Boolean view_HR { get; set; }
        public Boolean add_HR { get; set; }
        public Boolean delete_HR { get; set; }
        public Boolean view_branch { get; set; }
        public Boolean add_branch { get; set; }
        public Boolean delete_branch { get; set; }
        public Boolean view_custody { get; set; }
        public Boolean add_custody { get; set; }
        public Boolean delete_custody { get; set; }
        public Boolean view_finance { get; set; }
        public Boolean add_finance { get; set; }
        public Boolean delete_finance { get; set; }
        public Boolean view_delivery { get; set; }
        public Boolean add_delivery { get; set; }
        public Boolean delete_delivery { get; set; }
        public Boolean view_report { get; set; }
        public Boolean view_customer { get; set; }
        public Boolean add_customer { get; set; }
        public Boolean delete_customer { get; set; }
        public Boolean view_vendor { get; set; }
        public Boolean add_vendor { get; set; }
        public Boolean delete_vendor { get; set; }
        public Boolean view_service { get; set; }
        public Boolean add_service { get; set; }
        public Boolean delete_service { get; set; }
        public Boolean admin_rights { get; set; }
        public int roleID { get; set; }


    }
}
