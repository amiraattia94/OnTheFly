using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service
{
    public class UserGroupsService
    {
        
        /// GET USERGROUPS BY GROUP
              
        /// ADD USERGROUP
        async public Task<bool> AddUserGroup(int userID, int groupID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.userGroupTBLs.Add(new userGroupTBL()
                    {
                        userID = userID,
                        groupID = groupID

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        /// EDIT USERGROUP
        async public Task<bool> EditUserGroupByIDs(int userID, int groupID, int newUserID, int newGroupID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.userGroupTBLs.SingleOrDefault(w => w.userID == userID && w.groupID == groupID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.userID = newUserID;
                            Result.groupID = newGroupID;
                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {

                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        /// DELETE USERGROUP
        async public Task<bool> DeleteUserGroupsByIDs(int userID, int groupID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.userGroupTBLs.SingleOrDefault(w => w.userID == userID && w.groupID == groupID);

                    if (result != null)
                    {
                        con.userGroupTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch
            {

            }

            return false;

        }

        /// GET ALL GROUPS
        async public Task<ObservableCollection<UserGroupsDTO>> GetAllUserGroups()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.userGroupTBLs.Select(s => new UserGroupsDTO()
                {
                    userID = s.userID,
                    groupID = s.groupID,
                    user_name= s.UserTBL.user_name,
                    group_name = s.UserGroupRoleTBL.name
                }).ToList();

                return new ObservableCollection<UserGroupsDTO>(result);
            }
        }

        // GET USERGROUPS BY USER ID
        async public Task<ObservableCollection<UserGroupsDTO>> GetUserGroupsByUserID(int userID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.userGroupTBLs.Where(w => w.userID == userID).Select(s => new UserGroupsDTO()
                {
                    userID = s.userID,
                    groupID = s.groupID,
                    user_name = s.UserTBL.user_name,
                    group_name = s.UserGroupRoleTBL.name
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<UserGroupsDTO>(result);
                }
                else
                {
                    return new ObservableCollection<UserGroupsDTO>();
                }



            }

        }

        /// GET USERGROUPS BY GROUP ID
        async public Task<ObservableCollection<UserGroupsDTO>> GetUserGroupsByGroupID(int groupID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.userGroupTBLs.Where(w => w.groupID == groupID).Select(s => new UserGroupsDTO()
                {
                    userID = s.userID,
                    groupID = s.groupID,
                    user_name = s.UserTBL.user_name,
                    group_name = s.UserGroupRoleTBL.name
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<UserGroupsDTO>(result);
                }
                else
                {
                    return new ObservableCollection<UserGroupsDTO>();
                }



            }

        }


    }
}
