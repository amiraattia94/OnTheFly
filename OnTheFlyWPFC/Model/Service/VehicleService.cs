using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
  public class VehicleService {

        async public Task<bool> AddVehicle(int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.VehicleTBLs.Add(new VehicleTBL() {
                        typeID = Type,
                        plate_number = Plate,
                        made_company = Company,
                        edition_name = Model,
                        made_year = Year,
                        branchID = Branch,
                        state = Status
                        

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditVehicleID(int CarID, int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == CarID);
                    if (Result != null) {

                        try {
                            Result.typeID = Type;
                            Result.plate_number = Plate;
                            Result.made_company = Company;
                            Result.edition_name = Model;
                            Result.made_year = Year;
                            Result.branchID = Branch;
                            Result.state = Status;



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
        
        async public Task<bool> DeleteVehicleByID(int vehicleID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == vehicleID);

                    if (result != null) {
                        con.VehicleTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        async public Task<ObservableCollection<VehicleDTO>> GetAllVehicle() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTBLs.Select(s => new VehicleDTO() {
                    vehicleID = s.vehicleID,
                    vehicleType = s.VehicleTypeTBL.vehicleTName,
                    plate_number = s.plate_number,
                    made_company = s.made_company,
                    edition_name = s.edition_name,
                    made_year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    state = s.state

                }).ToList();

                return new ObservableCollection<VehicleDTO>(result);
            }
        }

        async public Task<VehicleDTO> GetVehicleByID(int vehicleID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == vehicleID);

                if (result != null) {
                    return new VehicleDTO() {
                        vehicleID = result.vehicleID,
                        vehicleType = result.VehicleTypeTBL.vehicleTName,
                        typeID = result.VehicleTypeTBL.vehicleTID,
                        plate_number = result.plate_number,
                        made_company = result.made_company,
                        edition_name = result.edition_name,
                        made_year = (int)result.made_year,
                        Bransh = result.CompanyBranchTBL.branch_name,
                        branchID = result.CompanyBranchTBL.branchID,
                        state = result.state


                    };
                };
                return new VehicleDTO() { };
            }
        }
        
        async public Task<ObservableCollection<VehicleDTO>> GetVehicleByPlate(string Plate) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VehicleTBLs.Where(w => w.plate_number.StartsWith(Plate)).Select(s => new VehicleDTO() {
                    vehicleID = s.vehicleID,
                    vehicleType = s.VehicleTypeTBL.vehicleTName,
                    plate_number = s.plate_number,
                    made_company = s.made_company,
                    edition_name = s.edition_name,
                    made_year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    state = s.state
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<VehicleDTO>(result);
                }
                else {
                    return new ObservableCollection<VehicleDTO>();
                }
            }

        }

        async public Task<ObservableCollection<VehicleDTO>> GetVehicleByType(int type) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VehicleTBLs.Where(w => w.typeID == type).Select(s => new VehicleDTO() {
                    vehicleID = s.vehicleID,
                    vehicleType = s.VehicleTypeTBL.vehicleTName,
                    plate_number = s.plate_number,
                    made_company = s.made_company,
                    edition_name = s.edition_name,
                    made_year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    state = s.state
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<VehicleDTO>(result);
                }
                else {
                    return new ObservableCollection<VehicleDTO>();
                }
            }

        }

        async public Task<ObservableCollection<VehicleTypeDTO>> GetAllVehiclesType() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTypeTBLs.Select(s => new VehicleTypeDTO() {
                    vehileTID = s.vehicleTID,
                    vehicleTName = s.vehicleTName

                }).ToList();

                return new ObservableCollection<VehicleTypeDTO>(result);
            }
        }


    }
}
