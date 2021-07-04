using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class DeliveryServicesService {

        async public Task<bool> AddDeliveryServices(int categoryID,string customerLocation,string vendorLocation, decimal fullTrip,decimal halfTrip, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.serviceTBLs.Add(new serviceTBL() {
                        categoryID = categoryID,
                        customerLocation = customerLocation,
                        vendorLocation = vendorLocation,
                        fullTripPrice = fullTrip,
                        halfTripPrice = halfTrip,
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

        async public Task<bool> EditDeliveryServices(int branchID, string branchname, string cityCode, string branchAddress, bool branchstatus) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.CompanyBranchTBLs.SingleOrDefault(w => w.branchID == branchID);
                    if (Result != null) {

                        try {
                            Result.branch_name = branchname;
                            Result.cityID = cityCode;
                            Result.address = branchAddress;
                            Result.status = branchstatus;

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


        async public Task<bool> DeleteDeliveryServicesByID(int BranchID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.CompanyBranchTBLs.SingleOrDefault(w => w.branchID == BranchID);

                    if (result != null) {
                        con.CompanyBranchTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }


        async public Task<ObservableCollection<BranchDTO>> GetAllDeliveryServices() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.CompanyBranchTBLs.Select(s => new BranchDTO() {
                    branchID = s.branchID,
                    branch_name = s.branch_name,
                    address = s.address,
                    status = s.status,
                    cityID = s.LibyanCitiesTBL.name
                }).ToList();

                return new ObservableCollection<BranchDTO>(result);
            }

        }

        async public Task<BranchDTO> GetDeliveryServicesByID(int BranchID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.CompanyBranchTBLs.SingleOrDefault(w => w.branchID == BranchID);

                if (result != null) {
                    return new BranchDTO() {
                        branchID = result.branchID,
                        branch_name = result.branch_name,
                        address = result.address,
                        status = result.status,
                        cityID = result.LibyanCitiesTBL.name

                    };
                };

                return new BranchDTO() {
                    branchID = 0,
                    branch_name = "0",
                    address = "0",
                    status = false,
                    cityID = "0"

                };



            }

        }

        async public Task<ObservableCollection<BranchDTO>> GetDeliveryServicesByState(bool BranchState) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.CompanyBranchTBLs.Where(w => w.status == BranchState).Select(s => new BranchDTO() {
                    branchID = s.branchID,
                    branch_name = s.branch_name,
                    address = s.address,
                    status = s.status,
                    cityID = s.LibyanCitiesTBL.name
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<BranchDTO>(result);
                }
                else {
                    return new ObservableCollection<BranchDTO>();
                }



            }

        }

        async public Task<ObservableCollection<BranchDTO>> GetDeliveryServicesByDeliveryType(bool BranchState) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.CompanyBranchTBLs.Where(w => w.status == BranchState).Select(s => new BranchDTO() {
                    branchID = s.branchID,
                    branch_name = s.branch_name,
                    address = s.address,
                    status = s.status,
                    cityID = s.LibyanCitiesTBL.name
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<BranchDTO>(result);
                }
                else {
                    return new ObservableCollection<BranchDTO>();
                }



            }

        }


    }
}
