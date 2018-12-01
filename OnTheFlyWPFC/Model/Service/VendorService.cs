using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service
{
    class VendorService
    {
        async public Task<bool> AddVendor(int categoryID, string name, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.VendorTBLs.Add(new VendorTBL() {
                        
                        categoryID = categoryID,
                        name = name,
                        active = status

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditVendorByID(int vendorID, int categoryID, string name, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.VendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);
                    if (Result != null) {

                        try {
                            Result.vendorID = vendorID;
                            Result.categoryID = categoryID;
                            Result.name = name;
                            Result.active = status;

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

        async public Task<bool> DeleteVendorByID(int vendorID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                    var resultbranches = con.VendorBranchTBLs.Where(w => w.vendorID == vendorID).Select(s => new VendorBranchsDTO() {
                        vendorBranchID = s.vendor_branchID,
                    }).ToList();

                    var result = con.VendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);

                    if (result != null && resultbranches != null) {
                        for (int i = 0; i < resultbranches.Count(); i++) {
                            var id = resultbranches[i].vendorBranchID;
                            var temp = con.VendorBranchTBLs.SingleOrDefault(w => w.vendor_branchID == id);
                            con.VendorBranchTBLs.Remove(temp);
                        }

                        con.VendorTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        async public Task<ObservableCollection<VendorDTO>> GetAllVendors() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VendorTBLs.Select(s => new VendorDTO() {
                    VendorID = s.vendorID,
                    VendorName = s.name,
                    VendorCategoryID = s.categoryID,
                    VendorCategoryName = s.CategoriesTBL.category_name,
                    VendorStatus = s.active,
                    VendorBranchCount = s.VendorBranchTBLs.Count(),
                    //membershipCount = s.MembershipTBLs.Where(w => w.customerID == s.customerID).Count()
                }).ToList();

                return new ObservableCollection<VendorDTO>(result);
            }
        }

        async public Task<VendorDTO> GetVendorByID(int vendorID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);

                if (result != null) {
                    return new VendorDTO() {
                        VendorID = result.vendorID,
                        VendorName = result.name,
                        VendorCategoryID = result.categoryID,
                        VendorCategoryName = result.CategoriesTBL.category_name,
                        VendorStatus = result.active,
                        VendorBranchCount = result.VendorBranchTBLs.Count(),


                    };
                };

                return new VendorDTO() { };



            }
        }

        async public Task<ObservableCollection<VendorDTO>> GetVendorByCategoryID(int categoryID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<VendorDTO> result = con.VendorTBLs.Where(w => w.categoryID == categoryID).Select(s => new VendorDTO()
                {
                    VendorID = s.vendorID,
                    VendorName = s.name,
                    VendorCategoryID = s.categoryID,
                    VendorCategoryName = s.CategoriesTBL.category_name,
                    VendorStatus = s.active,
                    VendorBranchCount = s.VendorBranchTBLs.Count(),



                }).ToList();

                return new ObservableCollection<VendorDTO>(result);
            }
        }

        async public Task<ObservableCollection<VendorDTO>> GetVendorByName(string vendorName) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VendorTBLs.Where(w => w.name.StartsWith(vendorName)).Select(s => new VendorDTO() {
                    VendorID = s.vendorID,
                    VendorName = s.name,
                    VendorCategoryID = s.categoryID,
                    VendorCategoryName = s.CategoriesTBL.category_name,
                    VendorStatus = s.active,
                    VendorBranchCount = s.VendorBranchTBLs.Count(),
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<VendorDTO>(result);
                }
                else {
                    return new ObservableCollection<VendorDTO>();
                }
            }

        }

        async public Task<ObservableCollection<VendorDTO>> GetVendorByState(bool state) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VendorTBLs.Where(w => w.active == state).Select(s => new VendorDTO() {
                    VendorID = s.vendorID,
                    VendorName = s.name,
                    VendorCategoryID = s.categoryID,
                    VendorCategoryName = s.CategoriesTBL.category_name,
                    VendorStatus = s.active,
                    VendorBranchCount = s.VendorBranchTBLs.Count(),
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<VendorDTO>(result);
                }
                else {
                    return new ObservableCollection<VendorDTO>();
                }
            }

        }

        async public Task<bool> AddVendorBranch(int vendorID, string name, string citycode , string address , string phone1, string phone2, bool state) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.VendorBranchTBLs.Add(new VendorBranchTBL() {
                        vendorID = vendorID,
                        name = name,
                        cityID = citycode,
                        address = address,
                        phone1 = phone1,
                        phone2 = phone2,
                        active = state
                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditVendorBranchByID(int vendorBranchID, string name, string citycode, string address, string phone1, string phone2, bool state) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.VendorBranchTBLs.SingleOrDefault(w => w.vendor_branchID == vendorBranchID);
                    if (Result != null) {

                        try {

                            Result.name = name;
                            Result.cityID = citycode;
                            Result.address = address;
                            Result.phone1 = phone1;
                            Result.phone2 = phone2;
                            Result.active = state;
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

        async public Task<bool> DeleteVendorBranchByID(int vendorBranchID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.VendorBranchTBLs.SingleOrDefault(w => w.vendor_branchID == vendorBranchID);

                    if (result != null) {
                        con.VendorBranchTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };
                }
            }
            catch {

            }
            return false;
        }

        async public Task<ObservableCollection<VendorBranchsDTO>> GetAllVendorBranchByID(int BranchByID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VendorBranchTBLs.Where(w => w.vendorID == BranchByID).Select(s => new VendorBranchsDTO() {
                    vendorBranchID = s.vendor_branchID,
                    vendorID = s.vendorID,
                    name = s.name,
                    cityCode = s.cityID,
                    cityName = s.LibyanCitiesTBL.name,
                    address = s.address,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    state = (bool)s.active,
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<VendorBranchsDTO>(result);
                }
                else {
                    return new ObservableCollection<VendorBranchsDTO>();
                }
            }
        }

        async public Task<VendorBranchsDTO> GetVendorBranchshipByID(int vendorBranshID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VendorBranchTBLs.SingleOrDefault(w => w.vendor_branchID == vendorBranshID);
                if (result != null) {
                    return new VendorBranchsDTO() {

                        vendorBranchID = result.vendor_branchID,
                        vendorID = result.vendorID,
                        name = result.name,
                        cityCode = result.cityID,
                        cityName = result.LibyanCitiesTBL.name,
                        address = result.address,
                        phone1 = result.phone1,
                        phone2 = result.phone2,
                        state = (bool)result.active,
                        
                    };
                };
                return new VendorBranchsDTO() { };
            }
        }

    }
}
