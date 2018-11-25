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
        UserGroupRoleService _userGroupRoleService;
        public ObservableCollection<UserGroupRoleDTO> ViewUserGroupRole { get; set; }
        public UserGroupRoleDTO EditUserGroupRole { get; set; }

        public UserGroupRoleViewModel()
        {
            _userGroupRoleService = new UserGroupRoleService();
            ViewUserGroupRole = new ObservableCollection<UserGroupRoleDTO>();
            EditUserGroupRole = new UserGroupRoleDTO();

            GetAllUserGroupRoles();
        }
        async public void GetAllUserGroupRoles()
        {
            ViewUserGroupRole = await _userGroupRoleService.GetUserGroupRole();
        }
    }
}
