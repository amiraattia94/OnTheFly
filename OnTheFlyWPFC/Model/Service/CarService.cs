using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class CarService {

        async public Task<bool> AddCar(int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.VehicleTBLs.Add(new VehicleTBL() {
                        TypeID = Type,
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

        async public Task<bool> EditCarID(int CarID, int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == CarID);
                    if (Result != null) {

                        try {
                            Result.TypeID = Type;
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
        
        async public Task<bool> DeleteCarByID(int CarID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == CarID);

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

        async public Task<ObservableCollection<CarDTO>> GetAllCars() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTBLs.Select(s => new CarDTO() {
                    CarID = s.vehicleID,
                    CarType = s.VehicleTypeTBL.vehicleTName,
                    Plate = s.plate_number,
                    Company = s.made_company,
                    Model = s.edition_name,
                    Year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    State = s.state

                }).ToList();

                return new ObservableCollection<CarDTO>(result);
            }
        }

        async public Task<CarDTO> GetCarByID(int CarID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTBLs.SingleOrDefault(w => w.vehicleID == CarID);

                if (result != null) {
                    return new CarDTO() {
                        CarID = result.vehicleID,
                        CarType = result.VehicleTypeTBL.vehicleTName,
                        CarTypeID = result.VehicleTypeTBL.vehicleTID,
                        Plate = result.plate_number,
                        Company = result.made_company,
                        Model = result.edition_name,
                        Year = (int)result.made_year,
                        Bransh = result.CompanyBranchTBL.branch_name,
                        BranshID = result.CompanyBranchTBL.branchID,
                        State = result.state


                    };
                };
                return new CarDTO() { };
            }
        }
        
        async public Task<ObservableCollection<CarDTO>> GetCarByPlate(string Plate) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VehicleTBLs.Where(w => w.plate_number.StartsWith(Plate)).Select(s => new CarDTO() {
                    CarID = s.vehicleID,
                    CarType = s.VehicleTypeTBL.vehicleTName,
                    Plate = s.plate_number,
                    Company = s.made_company,
                    Model = s.edition_name,
                    Year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    State = s.state
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<CarDTO>(result);
                }
                else {
                    return new ObservableCollection<CarDTO>();
                }
            }

        }

        async public Task<ObservableCollection<CarDTO>> GetCarByType(int type) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.VehicleTBLs.Where(w => w.TypeID == type).Select(s => new CarDTO() {
                    CarID = s.vehicleID,
                    CarType = s.VehicleTypeTBL.vehicleTName,
                    Plate = s.plate_number,
                    Company = s.made_company,
                    Model = s.edition_name,
                    Year = (int)s.made_year,
                    Bransh = s.CompanyBranchTBL.branch_name,
                    State = s.state
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<CarDTO>(result);
                }
                else {
                    return new ObservableCollection<CarDTO>();
                }
            }

        }

        async public Task<ObservableCollection<CarTypeDTO>> GetAllCarsType() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.VehicleTypeTBLs.Select(s => new CarTypeDTO() {
                    CarTID = s.vehicleTID,
                    CarTName = s.vehicleTName

                }).ToList();

                return new ObservableCollection<CarTypeDTO>(result);
            }
        }


    }
}
