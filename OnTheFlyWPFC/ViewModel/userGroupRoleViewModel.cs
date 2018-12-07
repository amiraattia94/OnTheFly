using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.ViewModel
{
    public class UserGroupRoleViewModel
    {
        UserGroupRoleService userGroupRoleService;
        public ObservableCollection<UserGroupRoleDTO> ViewUserGroupRole { get; set; }
        public UserGroupRoleDTO EditUserGroupRole { get; set; }

        public UserGroupRoleViewModel()
        {
            userGroupRoleService = new UserGroupRoleService();
            ViewUserGroupRole = new ObservableCollection<UserGroupRoleDTO>();
            EditUserGroupRole = new UserGroupRoleDTO();

          //  GetAllUserGroupRoles();
        }
        async public void GetAllUserGroupRoles()
        {
            ViewUserGroupRole = await userGroupRoleService.GetAllUserGroupRole();
        }


        async public void getUserGroupRoleByUserID(int userID)
        {
            EditUserGroupRole= await userGroupRoleService.getUserGroupRoleByUserID(userID);
        }

        async public void getUserGroupRoleByGroupID(int groupID)
        {
            EditUserGroupRole = await userGroupRoleService.getUserGroupRoleByGroupID(groupID);
        }
        async public void getUserGroupRoleByIDs(int userID , int groupID)
        {
            EditUserGroupRole = await userGroupRoleService.getUserGroupRoleByIDs(userID, groupID);
        }


        async public  Task<bool> EditUserGroupRoleByGroupID(int groupID, string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
            bool add_HR,
            bool delete_HR, bool view_branch, bool add_branch, bool delete_branch, bool view_custody, bool add_custody,
            bool delete_custody, bool view_finance, bool add_finance, bool delete_finance, bool view_delivery, bool add_delivery
            , bool delete_delivery, bool view_customer, bool add_customer, bool delete_customer, bool view_vendor, bool add_vendor
            , bool delete_vendor, bool view_service, bool add_service, bool delete_service, bool admin_rights, bool view_report, int userID)
        {
            return await userGroupRoleService.EditUserGroupRoleByGroupID(groupID, name, view_POS, add_POS, delete_POS, view_HR,
             add_HR,
             delete_HR, view_branch, add_branch, delete_branch, view_custody, add_custody,
             delete_custody, view_finance, add_finance, delete_finance, view_delivery, add_delivery
            , delete_delivery, view_customer, add_customer, delete_customer, view_vendor, add_vendor
            , delete_vendor, view_service, add_service, delete_service, admin_rights, view_report, userID);
        }
        async public Task<bool> AddUserGroupRoleByUserID(int groupID, string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
           bool add_HR,
           bool delete_HR, bool view_branch, bool add_branch, bool delete_branch, bool view_custody, bool add_custody,
           bool delete_custody, bool view_finance, bool add_finance, bool delete_finance, bool view_delivery, bool add_delivery
           , bool delete_delivery, bool view_customer, bool add_customer, bool delete_customer, bool view_vendor, bool add_vendor
           , bool delete_vendor, bool view_service, bool add_service, bool delete_service, bool admin_rights, bool view_report, int userID)
        {
            return await userGroupRoleService.AddUserGroupRoleByUserID(groupID, name, view_POS, add_POS, delete_POS, view_HR,
             add_HR,
             delete_HR, view_branch, add_branch, delete_branch, view_custody, add_custody,
             delete_custody, view_finance, add_finance, delete_finance, view_delivery, add_delivery
            , delete_delivery, view_customer, add_customer, delete_customer, view_vendor, add_vendor
            , delete_vendor, view_service, add_service, delete_service, admin_rights, view_report, userID);
        }
        async public Task<bool> AddUserGroupRoleByUserID(int userID, UserGroupRoleDTO userGroupRole)
        {
            return await userGroupRoleService.AddUserGroupRoleByUserID(userID, userGroupRole);
        }

        async public Task<bool> EditUserGroupRoleByUserID(int userID , UserGroupRoleDTO userGroupRole)
        {
            return await userGroupRoleService.EditUserGroupRoleByUserID(userID , userGroupRole);
        }
        async public Task<bool> EditUserGroupRoleByGroupID(int groupID, UserGroupRoleDTO userGroupRole)
        {
            return await userGroupRoleService.EditUserGroupRoleByGroupID(groupID, userGroupRole);
        }

       
    }
}
