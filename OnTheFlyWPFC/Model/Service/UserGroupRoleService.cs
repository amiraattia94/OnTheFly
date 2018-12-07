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
        async public Task<ObservableCollection<UserGroupRoleDTO>> GetAllUserGroupRole()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<UserGroupRoleDTO> result = con.userGroupRoleTBLs.Select(s => new UserGroupRoleDTO()
                {
                    groupID = s.groupID,
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
                    userID= s.userID
                }).ToList();

                return new ObservableCollection<UserGroupRoleDTO>(result);
            }
        }

        async public Task<UserGroupRoleDTO> getUserGroupRoleByUserID(int userID)
        {
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                await Task.FromResult(true);
                try
                {
                    var result =  con.userGroupRoleTBLs.SingleOrDefault(w => w.userID == userID);

                    if (result != null)
                    {
                        return new UserGroupRoleDTO()
                        {
                            groupID = result.groupID,
                            name = result.name,
                            add_POS = result.add_POS,
                            view_POS = result.view_POS,
                            delete_POS = result.delete_POS,
                            add_HR = result.add_HR,
                            view_HR = result.view_HR,
                            delete_HR = result.delete_HR,
                            add_branch = result.add_branch,
                            view_branch = result.view_branch,
                            delete_branch = result.delete_branch,
                            add_custody = result.add_custody,
                            view_custody = result.view_custody,
                            delete_custody = result.delete_custody,
                            add_finance = result.add_finance,
                            view_finance = result.view_finance,
                            delete_finance = result.delete_finance,
                            add_delivery = result.add_delivery,
                            view_delivery = result.view_delivery,
                            delete_delivery = result.delete_delivery,
                            add_customer = result.add_customer,
                            view_customer = result.view_customer,
                            delete_customer = result.delete_customer,
                            view_vendor = result.view_vendor,
                            add_vendor = result.add_vendor,
                            delete_vendor = result.delete_vendor,
                            view_service = result.view_service,
                            add_service = result.add_service,
                            delete_service = result.delete_service,
                            view_report = result.view_report,
                            admin_rights = result.admin_rights,
                            userID = result.userID

                        };
                    };

                    return new UserGroupRoleDTO()
                    {
                        groupID = 0,
                        name = "",
                        add_POS = false,
                        view_POS = false,
                        delete_POS = false,
                        add_HR = false,
                        view_HR = false,
                        delete_HR = false,
                        add_branch = false,
                        view_branch = false,
                        delete_branch = false,
                        add_custody = false,
                        view_custody = false,
                        delete_custody = false,
                        add_finance = false,
                        view_finance = false,
                        delete_finance = false,
                        add_delivery = false,
                        view_delivery = false,
                        delete_delivery = false,
                        add_customer = false,
                        view_customer = false,
                        delete_customer = false,
                        view_vendor = false,
                        add_vendor = false,
                        delete_vendor = false,
                        view_service = false,
                        add_service = false,
                        delete_service = false,
                        view_report = false,
                        admin_rights = false,
                        userID = 0,
                    };
                }
                catch {
                    return null;
                }

            }
        }

        async public Task<UserGroupRoleDTO> getUserGroupRoleByGroupID(int groupID)
        {
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                await Task.FromResult(true);

                var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.groupID == groupID);

                if (result != null)
                {
                    return new UserGroupRoleDTO()
                    {
                        groupID = result.groupID,
                        name = result.name,
                        add_POS = result.add_POS,
                        view_POS = result.view_POS,
                        delete_POS = result.delete_POS,
                        add_HR = result.add_HR,
                        view_HR = result.view_HR,
                        delete_HR = result.delete_HR,
                        add_branch = result.add_branch,
                        view_branch = result.view_branch,
                        delete_branch = result.delete_branch,
                        add_custody = result.add_custody,
                        view_custody = result.view_custody,
                        delete_custody = result.delete_custody,
                        add_finance = result.add_finance,
                        view_finance = result.view_finance,
                        delete_finance = result.delete_finance,
                        add_delivery = result.add_delivery,
                        view_delivery = result.view_delivery,
                        delete_delivery = result.delete_delivery,
                        add_customer = result.add_customer,
                        view_customer = result.view_customer,
                        delete_customer = result.delete_customer,
                        view_vendor = result.view_vendor,
                        add_vendor = result.add_vendor,
                        delete_vendor = result.delete_vendor,
                        view_service = result.view_service,
                        add_service = result.add_service,
                        delete_service = result.delete_service,
                        view_report = result.view_report,
                        admin_rights = result.admin_rights,
                        userID = result.userID

                    };
                };

                return new UserGroupRoleDTO()
                {
                    groupID = 0,
                    name = "",
                    add_POS = false,
                    view_POS = false,
                    delete_POS = false,
                    add_HR = false,
                    view_HR = false,
                    delete_HR = false,
                    add_branch = false,
                    view_branch = false,
                    delete_branch = false,
                    add_custody = false,
                    view_custody = false,
                    delete_custody = false,
                    add_finance = false,
                    view_finance = false,
                    delete_finance = false,
                    add_delivery = false,
                    view_delivery = false,
                    delete_delivery = false,
                    add_customer = false,
                    view_customer = false,
                    delete_customer = false,
                    view_vendor = false,
                    add_vendor = false,
                    delete_vendor = false,
                    view_service = false,
                    add_service = false,
                    delete_service = false,
                    view_report = false,
                    admin_rights = false,
                    userID = 0,
                };
            }
        }

        async public Task<UserGroupRoleDTO> getUserGroupRoleByIDs(int userID,int groupID)
        {
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                await Task.FromResult(true);

                var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.groupID == groupID && w.userID == userID);

                if (result != null)
                {
                    return new UserGroupRoleDTO()
                    {
                        groupID = result.groupID,
                        name = result.name,
                        add_POS = result.add_POS,
                        view_POS = result.view_POS,
                        delete_POS = result.delete_POS,
                        add_HR = result.add_HR,
                        view_HR = result.view_HR,
                        delete_HR = result.delete_HR,
                        add_branch = result.add_branch,
                        view_branch = result.view_branch,
                        delete_branch = result.delete_branch,
                        add_custody = result.add_custody,
                        view_custody = result.view_custody,
                        delete_custody = result.delete_custody,
                        add_finance = result.add_finance,
                        view_finance = result.view_finance,
                        delete_finance = result.delete_finance,
                        add_delivery = result.add_delivery,
                        view_delivery = result.view_delivery,
                        delete_delivery = result.delete_delivery,
                        add_customer = result.add_customer,
                        view_customer = result.view_customer,
                        delete_customer = result.delete_customer,
                        view_vendor = result.view_vendor,
                        add_vendor = result.add_vendor,
                        delete_vendor = result.delete_vendor,
                        view_service = result.view_service,
                        add_service = result.add_service,
                        delete_service = result.delete_service,
                        view_report = result.view_report,
                        admin_rights = result.admin_rights,
                        userID = result.userID

                    };
                };

                return new UserGroupRoleDTO()
                {
                    groupID = 0,
                    name = "",
                    add_POS = false,
                    view_POS = false,
                    delete_POS = false,
                    add_HR = false,
                    view_HR = false,
                    delete_HR = false,
                    add_branch = false,
                    view_branch = false,
                    delete_branch = false,
                    add_custody = false,
                    view_custody = false,
                    delete_custody = false,
                    add_finance = false,
                    view_finance = false,
                    delete_finance = false,
                    add_delivery = false,
                    view_delivery = false,
                    delete_delivery = false,
                    add_customer = false,
                    view_customer = false,
                    delete_customer = false,
                    view_vendor = false,
                    add_vendor = false,
                    delete_vendor = false,
                    view_service = false,
                    add_service = false,
                    delete_service = false,
                    view_report = false,
                    admin_rights = false,
                    userID = 0,
                };
            }
        }


        async public Task<bool> EditUserGroupRoleByGroupID(int groupID, string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
            bool add_HR, 
            bool delete_HR, bool view_branch, bool add_branch, bool delete_branch, bool view_custody, bool add_custody,
            bool delete_custody, bool view_finance, bool add_finance, bool delete_finance, bool view_delivery, bool add_delivery
            , bool delete_delivery, bool view_customer, bool add_customer, bool delete_customer, bool view_vendor, bool add_vendor
            , bool delete_vendor, bool view_service, bool add_service, bool delete_service, bool admin_rights, bool view_report, int userID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.groupID == groupID);
                    if (result != null)
                    {

                        try
                        {
                            result.groupID = groupID;
                            result.name = name;
                            result.view_POS = view_POS;
                            result.add_POS = add_POS;
                            result.delete_POS = delete_POS;
                            result.view_HR = view_HR;
                            result.add_HR = add_HR;
                            result.delete_HR = delete_HR;
                            result.view_branch = view_branch;
                            result.add_branch = add_branch;
                            result.delete_branch = delete_branch;
                            result.view_custody = view_custody;
                            result.add_custody = add_custody;
                            result.delete_custody = delete_custody;
                            result.view_finance = view_finance;
                            result.add_finance = add_finance;
                            result.delete_finance = delete_finance;
                            result.view_delivery = view_delivery;
                            result.add_delivery = add_delivery;
                            result.delete_delivery = delete_delivery;
                            result.view_customer = view_customer;
                            result.add_customer = add_customer;
                            result.delete_customer = delete_customer;
                            result.view_vendor = view_vendor;
                            result.add_vendor = add_vendor;
                            result.delete_vendor = delete_vendor;
                            result.view_service = view_service;
                            result.add_service = add_service;
                            result.delete_service = delete_service;
                            result.view_report = view_report;
                            result.admin_rights = admin_rights;
                            result.userID = userID;
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
        async public Task<bool> EditUserGroupRoleByGroupID(int groupID, UserGroupRoleDTO userGroupRole)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.groupID == groupID);
                    if (result != null)
                    {

                        try
                        {
                            result.groupID = groupID;
                            result.name = userGroupRole.name;
                            result.view_POS = userGroupRole.view_POS;
                            result.add_POS = userGroupRole.add_POS;
                            result.delete_POS = userGroupRole.delete_POS;
                            result.view_HR = userGroupRole.view_HR;
                            result.add_HR = userGroupRole.add_HR;
                            result.delete_HR = userGroupRole.delete_HR;
                            result.view_branch = userGroupRole.view_branch;
                            result.add_branch = userGroupRole.add_branch;
                            result.delete_branch = userGroupRole.delete_branch;
                            result.view_custody = userGroupRole.view_custody;
                            result.add_custody = userGroupRole.add_custody;
                            result.delete_custody = userGroupRole.delete_custody;
                            result.view_finance = userGroupRole.view_finance;
                            result.add_finance = userGroupRole.add_finance;
                            result.delete_finance = userGroupRole.delete_finance;
                            result.view_delivery = userGroupRole.view_delivery;
                            result.add_delivery = userGroupRole.add_delivery;
                            result.delete_delivery = userGroupRole.delete_delivery;
                            result.view_customer = userGroupRole.view_customer;
                            result.add_customer = userGroupRole.add_customer;
                            result.delete_customer = userGroupRole.delete_customer;
                            result.view_vendor = userGroupRole.view_vendor;
                            result.add_vendor = userGroupRole.add_vendor;
                            result.delete_vendor = userGroupRole.delete_vendor;
                            result.view_service = userGroupRole.view_service;
                            result.add_service = userGroupRole.add_service;
                            result.delete_service = userGroupRole.delete_service;
                            result.view_report = userGroupRole.view_report;
                            result.admin_rights = userGroupRole.admin_rights;
                            result.userID = userGroupRole.userID;
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
        async public Task<bool> EditUserGroupRoleByUserID(int userID, UserGroupRoleDTO userGroupRole)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.userID == userID);
                    if (result != null)
                    {

                        try
                        {
                            result.groupID = userGroupRole.groupID;
                            result.name = userGroupRole.name;
                            result.view_POS = userGroupRole.view_POS;
                            result.add_POS = userGroupRole.add_POS;
                            result.delete_POS = userGroupRole.delete_POS;
                            result.view_HR = userGroupRole.view_HR;
                            result.add_HR = userGroupRole.add_HR;
                            result.delete_HR = userGroupRole.delete_HR;
                            result.view_branch = userGroupRole.view_branch;
                            result.add_branch = userGroupRole.add_branch;
                            result.delete_branch = userGroupRole.delete_branch;
                            result.view_custody = userGroupRole.view_custody;
                            result.add_custody = userGroupRole.add_custody;
                            result.delete_custody = userGroupRole.delete_custody;
                            result.view_finance = userGroupRole.view_finance;
                            result.add_finance = userGroupRole.add_finance;
                            result.delete_finance = userGroupRole.delete_finance;
                            result.view_delivery = userGroupRole.view_delivery;
                            result.add_delivery = userGroupRole.add_delivery;
                            result.delete_delivery = userGroupRole.delete_delivery;
                            result.view_customer = userGroupRole.view_customer;
                            result.add_customer = userGroupRole.add_customer;
                            result.delete_customer = userGroupRole.delete_customer;
                            result.view_vendor = userGroupRole.view_vendor;
                            result.add_vendor = userGroupRole.add_vendor;
                            result.delete_vendor = userGroupRole.delete_vendor;
                            result.view_service = userGroupRole.view_service;
                            result.add_service = userGroupRole.add_service;
                            result.delete_service = userGroupRole.delete_service;
                            result.view_report = userGroupRole.view_report;
                            result.admin_rights = userGroupRole.admin_rights;
                            result.userID = userID;
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

        async public Task<bool> AddUserGroupRoleByUserID( int groupID, string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
            bool add_HR,
            bool delete_HR, bool view_branch, bool add_branch, bool delete_branch, bool view_custody, bool add_custody,
            bool delete_custody, bool view_finance, bool add_finance, bool delete_finance, bool view_delivery, bool add_delivery
            , bool delete_delivery, bool view_customer, bool add_customer, bool delete_customer, bool view_vendor, bool add_vendor
            , bool delete_vendor, bool view_service, bool add_service, bool delete_service, bool admin_rights, bool view_report, int userID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.userGroupRoleTBLs.Add(new userGroupRoleTBL()
                    {
                        name = name,
                        view_POS = view_POS,
                        add_POS = add_POS,
                        delete_POS = delete_POS,
                        view_HR = view_HR,
                        add_HR = add_HR,
                        delete_HR = delete_HR,
                        view_branch = view_branch,
                        add_branch = add_branch,
                        delete_branch = delete_branch,
                        view_custody = view_custody,
                        add_custody = add_custody,
                        delete_custody = delete_custody,
                        view_finance = view_finance,
                        add_finance = add_finance,
                        delete_finance = delete_finance,
                        view_delivery = view_delivery,
                        add_delivery = add_delivery,
                        delete_delivery = delete_delivery,

                        view_customer = view_customer,
                        add_customer = add_customer,
                        delete_customer = delete_customer,
                        view_vendor = view_vendor,
                        add_vendor = add_vendor,
                        delete_vendor = delete_vendor,
                        view_service = view_service,
                        add_service = add_service,
                        delete_service = delete_service,
                        view_report = view_report,
                        admin_rights = admin_rights,
                        userID = userID,

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

        async public Task<bool> AddUserGroupRoleByUserID(int userID, UserGroupRoleDTO userGroupRole)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.userGroupRoleTBLs.Add(new userGroupRoleTBL()
                    {
                        name = userGroupRole.name,
                        view_POS = userGroupRole.view_POS,
                        add_POS = userGroupRole.add_POS,
                        delete_POS = userGroupRole.delete_POS,
                        view_HR = userGroupRole.view_HR,
                        add_HR = userGroupRole.add_HR,
                        delete_HR = userGroupRole.delete_HR,
                        view_branch = userGroupRole.view_branch,
                        add_branch = userGroupRole.add_branch,
                        delete_branch = userGroupRole.delete_branch,
                        view_custody = userGroupRole.view_custody,
                        add_custody = userGroupRole.add_custody,
                        delete_custody = userGroupRole.delete_custody,
                        view_finance = userGroupRole.view_finance,
                        add_finance = userGroupRole.add_finance,
                        delete_finance = userGroupRole.delete_finance,
                        view_delivery = userGroupRole.view_delivery,
                        add_delivery = userGroupRole.add_delivery,
                        delete_delivery = userGroupRole.delete_delivery,
                        view_report = userGroupRole.view_report,
                        view_customer = userGroupRole.view_customer,
                        add_customer = userGroupRole.add_customer,
                        delete_customer = userGroupRole.delete_customer,
                        view_vendor = userGroupRole.view_vendor,
                        add_vendor = userGroupRole.add_vendor,
                        delete_vendor = userGroupRole.delete_vendor,
                        view_service = userGroupRole.view_service,
                        add_service = userGroupRole.add_service,
                        delete_service = userGroupRole.delete_service,          
                        admin_rights = userGroupRole.admin_rights,
                        userID = userID

                });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return false;
        }


    }
}
