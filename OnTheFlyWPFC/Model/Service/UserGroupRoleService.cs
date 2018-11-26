using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    public class UserGroupRoleService
    {
        async public Task<ObservableCollection<UserGroupRoleDTO>> GetUserGroupRole()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<UserGroupRoleDTO> result = con.UserGroupRoleTBLs.Select(s => new UserGroupRoleDTO()
                {

                    name = s.name,
                    add_POS = s.add_POS,
                    view_POS= s.view_POS,
                    delete_POS = s.delete_POS,
                    add_HR = s.add_HR,
                    view_HR = s.view_HR,
                    delete_HR = s.delete_HR,
                    add_branch = s.add_branch,
                    view_branch = s.view_branch,
                    delete_branch = s.delete_branch,
                    add_custody = s.add_custody,
                    view_custody = s.view_custody,
                    delete_custody = s.delete_custody,
                    add_finance = s.add_finance,
                    view_finance = s.view_finance,
                    delete_finance = s.delete_finance,
                    add_delivery = s.add_delivery,
                    view_delivery = s.view_delivery,
                    delete_delivery = s.delete_delivery,
                    add_customer = s.add_customer,
                    view_customer = s.view_customer,
                    delete_customer = s.delete_customer,
                    view_vendor = s.view_vendor,
                    add_vendor = s.add_vendor,
                    delete_vendor = s.delete_vendor,
                    view_service = s.view_service,
                    add_service = s.add_service,
                    delete_service = s.delete_service,
                    view_report = s.view_report,
                    admin_rights = s.admin_rights,
                }).ToList();

                return new ObservableCollection<UserGroupRoleDTO>(result);
            }
        }
    }
}
