using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel
{
    class VehicleViewModel
    {

        VehicleService vehicleService;
        public ObservableCollection<VehicleDTO> viewVehicles { get; set; }
        public ObservableCollection<VehicleTypeDTO> viewVehicleType { get; set; }
        public VehicleDTO vehicle { get; set; }
        public VehicleTypeDTO vehicleType { get; set; }

        public VehicleViewModel()
        {

            vehicleService = new VehicleService();
            viewVehicles = new ObservableCollection<VehicleDTO>();
            viewVehicleType = new ObservableCollection<VehicleTypeDTO>();
            vehicle = new VehicleDTO();
            vehicleType = new VehicleTypeDTO();


        }

        async public Task<bool> AddVehicle(int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status)
        {
            return await vehicleService.AddVehicle(Type, Plate, Company, Model, Year, Branch, Status);
        }

        async public Task<bool> EditVehicleID(int CarID, int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status)
        {
            return await vehicleService.EditVehicleID(CarID, Type, Plate, Company, Model, Year, Branch, Status);
        }

        async public Task<bool> DeleteVehicleByID(int CarID)
        {
            return await vehicleService.DeleteVehicleByID(CarID);
        }

        async public void GetAllVehicles()
        {
            viewVehicles = await vehicleService.GetAllVehicle();
        }

        async public void GetVehicleByID(int CarID)
        {
            vehicle = await vehicleService.GetVehicleByID(CarID);
        }

        async public void GetVehicleByPlate(string Plate)
        {
            viewVehicles = await vehicleService.GetVehicleByPlate(Plate);
        }

        async public void GetVehicleByType(int Type)
        {
            viewVehicles = await vehicleService.GetVehicleByType(Type);
        }

        async public void GetAllVehicleType()
        {
            viewVehicleType = await vehicleService.GetAllVehiclesType();
        }

    }
}
