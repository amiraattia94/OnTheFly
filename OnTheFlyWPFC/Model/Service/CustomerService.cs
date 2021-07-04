using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service
{
    class CustomerService
    {
        async public Task<bool> AddCustomer(string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.CustomerTBLs.Add(new CustomerTBL()
                    {
                        name = CustomerName,
                        phone1 = CustomerPhone1,
                        phone2 = CustomerPhone2,
                        cityID = cityCode,
                        address = CustomerAddress,
                        credit = CustomerCredit,
                        add_date = DateTime.Now.Date

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
                
        async public Task<bool> EditCustomerByID(int CustomerID, string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.CustomerTBLs.SingleOrDefault(w => w.customerID == CustomerID);
                    if (Result != null) {

                        try {
                            Result.name = CustomerName;
                            Result.phone1 = CustomerPhone1;
                            Result.phone2 = CustomerPhone2;
                            Result.cityID = cityCode;
                            Result.address = CustomerAddress;
                            Result.credit = CustomerCredit;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch {

                        }
                        return false;
                    }
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> DeleteCustomerByID(int CustomerID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.CustomerTBLs.SingleOrDefault(w => w.customerID == CustomerID);

                    if (result != null) {
                        con.CustomerTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        //async public Task<bool> EditCustomerByID(int CustomerID, string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit)
        //{
        //    try
        //    {
        //        using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
        //        {
        //            var Result = con.CustomerTBLs.SingleOrDefault(w => w.customerID == CustomerID);
        //            if (Result != null)
        //            {

        //                try
        //                {
        //                    Result.name = CustomerName;
        //                    Result.phone1 = CustomerPhone1;
        //                    Result.phone2 = CustomerPhone2;
        //                    Result.cityID = cityCode;
        //                    Result.address = CustomerAddress;
        //                    Result.credit = CustomerCredit;

        //                    await con.SaveChangesAsync();
        //                    return true;
        //                }
        //                catch
        //                {

        //                }
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return false;
        //}

        //async public Task<bool> DeleteCustomerByID(int CustomerID)
        //{
        //    await Task.FromResult(true);

        //    try
        //    {
        //        using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
        //        {
        //            var result = con.CustomerTBLs.SingleOrDefault(w => w.customerID == CustomerID);

        //            if (result != null)
        //            {
        //                con.CustomerTBLs.Remove(result);
        //                await con.SaveChangesAsync();
        //                return true;
        //            };

        //        }
        //    }
        //    catch
        //    {

        //    }

        //    return false;

        //}

        async public Task<ObservableCollection<CustomerDTO>> GetAllCustomers()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.CustomerTBLs.Select(s => new CustomerDTO()
                {
                    customerID = s.customerID,
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    city = s.LibyanCitiesTBL.name,
                    adddate = s.add_date.ToString(),
                    credit = s.credit,
                    membershipCount = s.MembershipTBLs.Where(w => w.customerID == s.customerID).Count()
                }).ToList();

                return new ObservableCollection<CustomerDTO>(result);
            }
        }

        async public Task<CustomerDTO> GetCustomerByID(int customerID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.CustomerTBLs.SingleOrDefault(w => w.customerID == customerID);

                if (result != null)
                {
                    return new CustomerDTO()
                    {
                        customerID = result.customerID,
                        name = result.name,
                        address = result.address,
                        phone1 = result.phone1,
                        phone2 = result.phone2,
                        city = result.LibyanCitiesTBL.name,
                        credit = result.credit,
                        membershipCount = result.MembershipTBLs.Where(w => w.customerID == customerID).Count()


                    };
                };

                return new CustomerDTO()
                {
                    customerID = 0,
                    name = "0",
                    address = "0",
                    phone1 = "0",
                    phone2 = "0",
                    city = "0",
                    credit = 0
                };



            }
        }

        async public Task<ObservableCollection<CustomerDTO>> GetCustomerByName(string CustomerName)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.CustomerTBLs.Where(w => w.name.StartsWith(CustomerName)).Select(s => new CustomerDTO()
                {
                    customerID = s.customerID,
                    name = s.name,
                    address = s.address,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    credit = s.credit,
                    city = s.LibyanCitiesTBL.name,
                    membershipCount = s.MembershipTBLs.Where(w => w.customerID == s.customerID).Count()
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<CustomerDTO>(result);
                }
                else
                {
                    return new ObservableCollection<CustomerDTO>();
                }
            }

        }

        async public Task<ObservableCollection<CustomerDTO>> GetCustomerByMembershipID(string membershipID)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.MembershipTBLs.Where(w => w.membershipID.StartsWith(membershipID)).Select(s => new CustomerDTO()
                {
                    customerID = s.customerID,
                    name = s.CustomerTBL.name,
                    address = s.CustomerTBL.address,
                    phone1 = s.CustomerTBL.phone1,
                    phone2 = s.CustomerTBL.phone2,
                    credit = s.CustomerTBL.credit,
                    city = s.CustomerTBL.LibyanCitiesTBL.name,
                    membershipCount = s.CustomerTBL.MembershipTBLs.Where(w => w.customerID == s.customerID).Count()
                }).ToList();


                if (result != null)
                {
                    return new ObservableCollection<CustomerDTO>(result);
                }
                else
                {
                    return new ObservableCollection<CustomerDTO>();
                }
            }
        }

        async public Task<ObservableCollection<CustomerDTO>> GetCustomerByCity(string City)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.CustomerTBLs.Where(w => w.cityID == City).Select(s => new CustomerDTO()
                {
                    customerID = s.customerID,
                    name = s.name,
                    address = s.address,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    credit = s.credit,
                    city = s.LibyanCitiesTBL.name,
                    membershipCount = s.MembershipTBLs.Where(w => w.customerID == s.customerID).Count()
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<CustomerDTO>(result);
                }
                else
                {
                    return new ObservableCollection<CustomerDTO>();
                }



            }

        }

        private bool CheckMembershipNew(string membershipID)
        {
            try
            {

                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.MembershipTBLs.SingleOrDefault(w => w.membershipID == membershipID);
                    if (result == null)
                        return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<bool> AddMembership(string MembershipID, int CustomerID, int VendorID)
        {
            try
            {

                if (CheckMembershipNew(MembershipID))
                {
                    using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                    {
                        con.MembershipTBLs.Add(new MembershipTBL()
                        {
                            membershipID = MembershipID,
                            customerID = CustomerID,
                            vendorID = VendorID,


                        });
                        await con.SaveChangesAsync();
                        return true;
                    }
                }

            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<bool> EditMembershipByID(string MembershipID, int VendorID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.MembershipTBLs.SingleOrDefault(w => w.membershipID == MembershipID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.vendorID = VendorID;

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

        async public Task<bool> DeleteMembershipByID(string MembershipID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.MembershipTBLs.SingleOrDefault(w => w.membershipID == MembershipID);

                    if (result != null)
                    {
                        con.MembershipTBLs.Remove(result);
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

        async public Task<ObservableCollection<MembershipDTO>> GetMembershipByCustomerID(int CustomerID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.MembershipTBLs.Where(w => w.customerID == CustomerID).Select(s => new MembershipDTO()
                {
                    membershipID = s.membershipID.ToString(),
                    vendorID = s.vendorID,
                    customerID = s.customerID,
                    name = s.CustomerTBL.name,
                    vendorname = s.vendorTBL.name,
                    vendorCategory = s.vendorTBL.CategoriesTBL.category_name,
                    vendorCategoryID = s.vendorTBL.CategoriesTBL.categoryID

                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<MembershipDTO>(result);
                }
                else
                {
                    return new ObservableCollection<MembershipDTO>();
                }
            }
        }

        async public Task<MembershipDTO> GetMembershipByID(string membershipID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {


                var result = con.MembershipTBLs.SingleOrDefault(w => w.membershipID == membershipID);

                if (result != null)
                {
                    return new MembershipDTO()
                    {
                        membershipID = result.membershipID.ToString(),
                        customerID = result.customerID,
                        vendorID = result.vendorID,
                        name = result.CustomerTBL.name,
                        vendorname = result.vendorTBL.name,
                        vendorCategory = result.vendorTBL.CategoriesTBL.category_name,
                        vendorCategoryID = result.vendorTBL.CategoriesTBL.categoryID
                    };
                };
                return new MembershipDTO() { };
            }
        }

    }
}
