using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.Collections.ObjectModel;

namespace OnTheFlyWPFC.ViewModel
{
    public class UserGroupsViewModel
    {
        UserGroupsService userGroupsService;
        public ObservableCollection<UserGroupsDTO> viewUserGroups { get; set; }
        public UserGroupsDTO userGroups { get; set; }


        public UserGroupsViewModel()
        {
            userGroupsService = new UserGroupsService();
            viewUserGroups = new ObservableCollection<UserGroupsDTO>();
            userGroups = new UserGroupsDTO();

            GetAllUserGroups();
        }

        async public Task<bool> AddUserGroup(int userID, int groupID)
        {
            return await userGroupsService.AddUserGroup(userID, groupID);
        }

        async public void GetAllUserGroups()
        {
            viewUserGroups = await userGroupsService.GetAllUserGroups();
        }

        async Task<bool> EditUserGroupByIDs(int userID, int groupID, int newUserID, int newGroupID)
        {
            return await userGroupsService.EditUserGroupByIDs(userID, groupID,newUserID,newGroupID);
        }

        async public Task<bool> DeleteUserGroupsByIDs(int userID, int groupID)
        {
            return await userGroupsService.DeleteUserGroupsByIDs(userID,groupID);
        }

        async public void GetUserGroupsByUserID(int userID)
        {
            viewUserGroups = await userGroupsService.GetUserGroupsByUserID(userID);
        }

        async public void GetUserGroupsByGroupID(int groupID)
        {
            viewUserGroups = await userGroupsService.GetUserGroupsByUserID(groupID);
        }
    }

}
