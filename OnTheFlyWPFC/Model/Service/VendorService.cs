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
                    con.vendorTBLs.Add(new vendorTBL() {
                        
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
                    var Result = con.vendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);
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
                    var result = con.vendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);

                    if (result != null) {
                        con.vendorTBLs.Remove(result);
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
                var result = con.vendorTBLs.Select(s => new VendorDTO() {
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
                var result = con.vendorTBLs.SingleOrDefault(w => w.vendorID == vendorID);

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
                List<VendorDTO> result = con.vendorTBLs.Where(w => w.categoryID == categoryID).Select(s => new VendorDTO()
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

                var result = con.vendorTBLs.Where(w => w.name.StartsWith(vendorName)).Select(s => new VendorDTO() {
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

                var result = con.vendorTBLs.Where(w => w.active == state).Select(s => new VendorDTO() {
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


    }
}
