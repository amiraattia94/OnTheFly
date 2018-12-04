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

        async public Task<bool> EditUserGroupRoleByUserID(int groupID, string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
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
                    var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.userID == userID);
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

        async public Task<bool> AddUserGroupRoleByUserID( string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
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
                    var result = con.userGroupRoleTBLs.SingleOrDefault(w => w.userID == userID);
                    if (result != null)
                    {

                        try
                        {
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
        /*
        async public Task<bool> AddUserGroupRoleByUserID(string name, bool view_POS, bool add_POS, bool delete_POS, bool view_HR,
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
                    con.DeliveryServiceTBLs.Add(new DeliveryServiceTBL()
                    {

                        invoiceID = invoiceID,
                        categoryID = categoreID,
                        vendorBranchID = vendorBranchID,
                        customerID = customerID,
                        isFullTrip = isFullTrip,
                        productPrice = productPrice,
                        deliveryPrice = deliveryPrice,
                        status = status,
                        availabilityDay = avilable


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
        */

    }
}
